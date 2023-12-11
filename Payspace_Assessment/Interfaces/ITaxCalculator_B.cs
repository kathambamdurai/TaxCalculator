using Payspace_Assessment.Models;

namespace Payspace_Assessment.Interfaces
{
    public interface ITaxCalculator_B
    {
        public List<PostalCodeDetails> GetPostalCodeDetails();
        public List<ProgressiveTaxDetails> GetProgressiveTaxDetails();
        public List<TaxCalculationDetails> GetTaxCalculationList();
        public bool InsertTaxCalculationDetails(TaxCalculationDetails taxCalculationDetails);
    }
}
