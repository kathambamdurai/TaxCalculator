namespace Payspace_Assessment.Models
{
    public class ProgressiveTaxDetails
    {
        public int ProgressiveTaxId { get; set; }

        public decimal? TaxPercentage { get; set; }

        public decimal? FromAmount { get; set; }

        public decimal? ToAmount { get; set; }
    }
}
