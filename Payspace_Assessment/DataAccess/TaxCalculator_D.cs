using Payspace_Assessment.DataAccess.DataObjects;
using Payspace_Assessment.DataAccess.Interfaces;
using Payspace_Assessment.Models;

namespace Payspace_Assessment.DataAccess
{
    public class TaxCalculator_D : ITaxCalculator_D
    {
        private TaxCalculatorContext _context;
        public TaxCalculator_D(TaxCalculatorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all the postal code details
        /// </summary>
        /// <returns></returns>
        public List<PostalCodeDetails> GetPostalCodeDetails()
        {
            try
            {
                List<PostalCodeDetails> postalCodeDetails = (from postalCode in _context.PostalCodeDetails
                                                             select new PostalCodeDetails
                                                             {
                                                                 PostalCodeId = postalCode.PostalCodeId,
                                                                 PostalCodeName = postalCode.PostalCodeName,
                                                                 TaxCalculationTypeId = postalCode.TaxCalculationTypeId
                                                             }).ToList();
                return postalCodeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all the tax details of progressive tax type
        /// </summary>
        /// <returns></returns>
        public List<ProgressiveTaxDetails> GetProgressiveTaxDetails()
        {
            try
            {
                List<ProgressiveTaxDetails> progressiveTaxDetails = (from progressiveTax in _context.ProgressiveTaxes
                                                                     select new ProgressiveTaxDetails
                                                                     {
                                                                         ProgressiveTaxId = progressiveTax.ProgressiveTaxId,
                                                                         FromAmount = progressiveTax.FromAmount,
                                                                         ToAmount = progressiveTax.ToAmount,
                                                                         TaxPercentage = progressiveTax.TaxPercentage
                                                                     }).ToList();
                return progressiveTaxDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all the tax calculations saved
        /// </summary>
        /// <returns></returns>
        public List<TaxCalculationDetails> GetTaxCalculationList()
        {
            try
            {
                List<TaxCalculationDetails> taxCalculationDetails = (from taxCalculation in _context.TaxCalculationDetails
                                                                     join postalCode in _context.PostalCodeDetails on taxCalculation.PostalCodeId equals postalCode.PostalCodeId
                                                                     join taxCalculationType in _context.TaxCalculationTypes on postalCode.TaxCalculationTypeId equals taxCalculationType.TaxCalculationTypeId
                                                                     select new TaxCalculationDetails
                                                                     {
                                                                         TaxCalculationId = taxCalculation.TaxCalculationId,
                                                                         PostalCodeId = taxCalculation.PostalCodeId,
                                                                         TaxAmount = Convert.ToDouble(taxCalculation.TaxAmount),
                                                                         AnnualIncome = taxCalculation.AnnualIncome,
                                                                         CalculatedOn = taxCalculation.CalculatedOn,
                                                                         PostalCodeName = postalCode.PostalCodeName,
                                                                         TaxCalculationName = taxCalculationType.TaxCalculationTypeName
                                                                     }).ToList();
                return taxCalculationDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Insert the tax calculation details for future reference
        /// </summary>
        /// <param name="taxCalculationDetails"></param>
        /// <returns></returns>
        public bool InsertTaxCalculationDetails(TaxCalculationDetails taxCalculationDetails)
        {
            try
            {
                TaxCalculationDetail taxCalculationDetail = new TaxCalculationDetail();
                taxCalculationDetail.AnnualIncome = taxCalculationDetails.AnnualIncome;
                taxCalculationDetail.PostalCodeId = taxCalculationDetails.PostalCodeId;
                taxCalculationDetail.TaxAmount = Convert.ToDecimal(taxCalculationDetails.TaxAmount);
                taxCalculationDetail.CalculatedOn = DateTime.Now;
                _context.TaxCalculationDetails.Add(taxCalculationDetail);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

