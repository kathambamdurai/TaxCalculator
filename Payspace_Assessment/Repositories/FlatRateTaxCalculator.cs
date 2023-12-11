using Payspace_Assessment.Interfaces;

namespace Payspace_Assessment.Repositories
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(decimal annualIncome)
        {
            double taxedAmount = 0;
            decimal taxPercentage = 17.5m;
            taxedAmount = Convert.ToDouble(annualIncome * (taxPercentage / 100));
            return taxedAmount;
        }
    }
}
