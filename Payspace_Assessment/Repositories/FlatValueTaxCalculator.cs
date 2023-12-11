using Payspace_Assessment.Interfaces;

namespace Payspace_Assessment.Repositories
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(decimal annualIncome)
        {
            double taxedAmount = 0;
            if ((annualIncome >= 0) && (annualIncome <= 200000))
            {
                taxedAmount = Convert.ToDouble(annualIncome * (0.05m));
            }
            else
            {
                taxedAmount = 10000;
            }
            return taxedAmount;
        }
    }
}
