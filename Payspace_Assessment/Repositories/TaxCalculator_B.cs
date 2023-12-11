using Payspace_Assessment.DataAccess.Interfaces;
using Payspace_Assessment.Interfaces;
using Payspace_Assessment.Models;

namespace Payspace_Assessment.Repositories
{
    public class TaxCalculator_B : ITaxCalculator_B
    {
        private ITaxCalculator_D _db;
        public TaxCalculator_B(ITaxCalculator_D db)
        {
            _db = db;
        }
        public List<PostalCodeDetails> GetPostalCodeDetails()
        {
            try
            {
                return _db.GetPostalCodeDetails();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProgressiveTaxDetails> GetProgressiveTaxDetails()
        {
            try
            {
                return _db.GetProgressiveTaxDetails();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TaxCalculationDetails> GetTaxCalculationList()
        {
            try
            {
                return _db.GetTaxCalculationList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertTaxCalculationDetails(TaxCalculationDetails taxCalculationDetails)
        {
            try
            {
                return _db.InsertTaxCalculationDetails(taxCalculationDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
