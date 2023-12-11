using Payspace_Assessment.Interfaces;
using Payspace_Assessment.Models;

namespace Payspace_Assessment.Repositories
{
    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(decimal annualIncome)
        {
            List<ProgressiveTaxDetails> progressiveTaxDetails = GetProgressiveTaxDetails();

            double taxedAmount = 0;
            if (progressiveTaxDetails != null)
            {
                if (progressiveTaxDetails.Count > 0)
                {
                    if ((annualIncome >= progressiveTaxDetails[0].FromAmount) && (annualIncome <= progressiveTaxDetails[0].ToAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[0].TaxPercentage!.Value / 100));
                    }
                    else if ((annualIncome >= progressiveTaxDetails[1].FromAmount) && (annualIncome <= progressiveTaxDetails[1].ToAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[0].TaxPercentage!.Value / 100)) +
                            Convert.ToDouble(((annualIncome - progressiveTaxDetails[0].ToAmount) * (progressiveTaxDetails[1].TaxPercentage!.Value / 100)));
                    }
                    else if ((annualIncome >= progressiveTaxDetails[2].FromAmount) && (annualIncome <= progressiveTaxDetails[2].ToAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[1].TaxPercentage!.Value / 100)) +
                            Convert.ToDouble(((annualIncome - progressiveTaxDetails[1].ToAmount) * (progressiveTaxDetails[2].TaxPercentage!.Value / 100)));
                    }
                    else if ((annualIncome >= progressiveTaxDetails[3].FromAmount) && (annualIncome <= progressiveTaxDetails[3].ToAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[2].TaxPercentage!.Value / 100)) +
                            Convert.ToDouble(((annualIncome - progressiveTaxDetails[2].ToAmount) * (progressiveTaxDetails[3].TaxPercentage!.Value / 100)));
                    }
                    else if ((annualIncome >= progressiveTaxDetails[4].FromAmount) && (annualIncome <= progressiveTaxDetails[4].ToAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[3].TaxPercentage!.Value / 100)) +
                            Convert.ToDouble(((annualIncome - progressiveTaxDetails[3].ToAmount) * (progressiveTaxDetails[4].TaxPercentage!.Value / 100)));
                    }
                    else if ((annualIncome >= progressiveTaxDetails[5].FromAmount))
                    {
                        return taxedAmount = Convert.ToDouble(annualIncome * (progressiveTaxDetails[4].TaxPercentage!.Value / 100)) +
                            Convert.ToDouble(((annualIncome - progressiveTaxDetails[4].ToAmount) * (progressiveTaxDetails[5].TaxPercentage!.Value / 100)));
                    }
                }
            }
            return 0;
        }
        private List<ProgressiveTaxDetails> GetProgressiveTaxDetails()
        {
            List<ProgressiveTaxDetails> progressiveTaxDetails = new List<ProgressiveTaxDetails>();
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 1,
                FromAmount = 0,
                ToAmount = 8350,
                TaxPercentage = 10,
            });
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 2,
                FromAmount = 8351,
                ToAmount = 33950,
                TaxPercentage = 15,
            });
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 3,
                FromAmount = 33951,
                ToAmount = 82250,
                TaxPercentage = 25,
            });
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 3,
                FromAmount = 82251,
                ToAmount = 171550,
                TaxPercentage = 28,
            });
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 3,
                FromAmount = 171551,
                ToAmount = 372950,
                TaxPercentage = 33,
            });
            progressiveTaxDetails.Add(new ProgressiveTaxDetails()
            {
                ProgressiveTaxId = 3,
                FromAmount = 372951,
                ToAmount = 0,
                TaxPercentage = 35,
            });
            return progressiveTaxDetails;
        }
    }
}
