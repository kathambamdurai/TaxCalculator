using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Payspace_Assessment.Interfaces;
using Payspace_Assessment.Models;

namespace Payspace_Assessment.Controllers
{
    public class TaxCalculatorController : Controller
    {
        private readonly ILogger _logger;
        private readonly ITaxCalculator_B _taxCalculator_B;
        private readonly ITaxCalculatorService _taxCalculatorService;
        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, ITaxCalculatorService taxCalculatorService, ITaxCalculator_B taxCalculator_B)
        {
            _logger = logger;
            _taxCalculatorService = taxCalculatorService;
            _taxCalculator_B = taxCalculator_B;
        }
        /// <summary>
        /// This is method is used to render the View to provide the data for tax calculation
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                var model = new TaxCalculatorModel
                {
                    PostalCodes = GetPostalCodes()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                Response.StatusCode = 500;
                throw;
            }
        }
        /// <summary>
        /// This method will calculate the tax based on the details provided
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateTax(TaxCalculatorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<PostalCodeDetails> postalCodeDetails = _taxCalculator_B.GetPostalCodeDetails();
                    double calculatedTax = _taxCalculatorService.CalculateTax(model.AnnualIncome, model.SelectedPostalCode!.ToString(), postalCodeDetails);

                    //Once the calculations are done, transaction will be stored in the database
                    _taxCalculator_B.InsertTaxCalculationDetails(new TaxCalculationDetails()
                    {
                        AnnualIncome = model.AnnualIncome,
                        PostalCodeId = Convert.ToInt32(model.SelectedPostalCode),
                        TaxAmount = calculatedTax
                    });
                    model.PostalCodes = GetPostalCodes();
                    model.CalculatedTax = calculatedTax;
                    _logger.LogInformation("Tax clacuation is done.");
                    return View("Index", model);
                }
                model.PostalCodes = GetPostalCodes();
                model.CalculatedTax = 0;
                _logger.LogInformation("Validation errors are captured.");
                return View("Index", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                Response.StatusCode = 500;
                throw;
            }
        }
        /// <summary>
        /// This method is used to get the postal codes from database
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetPostalCodes()
        {
            try
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                List<PostalCodeDetails> postalCodeDetails = _taxCalculator_B.GetPostalCodeDetails();

                if (postalCodeDetails != null)
                {
                    foreach (PostalCodeDetails postalCode in postalCodeDetails)
                    {
                        selectListItems.Add(new SelectListItem()
                        {
                            Text = postalCode.PostalCodeName,
                            Value = postalCode.PostalCodeId.ToString()
                        });

                    }
                }
                return selectListItems;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                Response.StatusCode = 500;
                throw;
            }
        }
        /// <summary>
        /// This method is to show the list of transctions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TaxCalculationList()
        {
            try
            {
                List<TaxCalculationDetails> taxCalculationDetails = _taxCalculator_B.GetTaxCalculationList();
                return View(taxCalculationDetails);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                Response.StatusCode = 500;
                throw;
            }
        }
    }
}

