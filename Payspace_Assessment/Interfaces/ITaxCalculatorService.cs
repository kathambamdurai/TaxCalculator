using Payspace_Assessment.Models;

namespace Payspace_Assessment.Interfaces
{
    public interface ITaxCalculatorService
    {
        public double CalculateTax(decimal annualIncome, string postalCode, List<PostalCodeDetails> postalCodes);
    }
}
