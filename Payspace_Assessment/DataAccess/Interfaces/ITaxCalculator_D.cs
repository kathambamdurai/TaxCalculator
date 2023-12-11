using Payspace_Assessment.Models;

namespace Payspace_Assessment.DataAccess.Interfaces
{
    public interface ITaxCalculator_D
    {
        public List<PostalCodeDetails> GetPostalCodeDetails();
        public List<ProgressiveTaxDetails> GetProgressiveTaxDetails();
        public List<TaxCalculationDetails> GetTaxCalculationList();
        public bool InsertTaxCalculationDetails(TaxCalculationDetails taxCalculationDetails);
    }
}
