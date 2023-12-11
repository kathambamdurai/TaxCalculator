using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Payspace_Assessment.Models
{
    public enum TaxType
    {
        ProgressiveTaxCalculator = 1,
        FlatValueTaxCalculator = 2,
        FlatRateTaxCalculator = 3
    }
    public class TaxCalculatorModel
    {
        [Required(ErrorMessage = "Please provide annual income.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Annual income must be greater than 0.")]
        public decimal AnnualIncome { get; set; }
        [Required(ErrorMessage = "Please select postal code.")]
        public string? SelectedPostalCode { get; set; }
        public List<SelectListItem>? PostalCodes { get; set; }
        public double CalculatedTax { get; set; }
    }
}
