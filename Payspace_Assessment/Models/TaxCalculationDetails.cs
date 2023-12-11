using System.ComponentModel.DataAnnotations;

namespace Payspace_Assessment.Models
{
    public class TaxCalculationDetails
    {
        public int TaxCalculationId { get; set; }
        public decimal? AnnualIncome { get; set; }
        public int? PostalCodeId { get; set; }
        public string? PostalCodeName { get; set; }
        public double? TaxAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? CalculatedOn { get; set; }
        public string? TaxCalculationName { get; set; }
    }
}