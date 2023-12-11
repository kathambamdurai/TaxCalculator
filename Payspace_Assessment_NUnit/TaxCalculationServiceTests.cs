using Payspace_Assessment.Repositories;
namespace Payspace_Assessment_NUnit
{
    public class TaxCalculationServiceTests
    {
        [Test]
        public void CalculateProgressiveTax()
        {
            ProgressiveTaxCalculator progressiveTaxCalculator = new ProgressiveTaxCalculator();
            var result = progressiveTaxCalculator.CalculateTax(372950);
            double actual = 77.7;
            Assert.That(actual, Is.EqualTo(result));
        }
        [Test]
        public void CalculateFlatValueTax()
        {
            FlatValueTaxCalculator flatValueTaxCalculator = new FlatValueTaxCalculator();
            var result = flatValueTaxCalculator.CalculateTax(777);
            double actual = 38.85;
            Assert.That(actual, Is.EqualTo(result));
        }
        [Test]
        public void CalculateFlatRateTax()
        {
            FlatRateTaxCalculator flatRateTaxCalculator = new FlatRateTaxCalculator();
            var result = flatRateTaxCalculator.CalculateTax(777);
            double actual = 135.975;
            Assert.That(actual, Is.EqualTo(result));
        }
    }
}