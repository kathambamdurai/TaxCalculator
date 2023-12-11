using Payspace_Assessment.Interfaces;
using Payspace_Assessment.Models;

namespace Payspace_Assessment.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly Dictionary<string, ITaxCalculator> _taxCalculators;

        public TaxCalculatorService(IEnumerable<ITaxCalculator> taxCalculators)
        {
            _taxCalculators = taxCalculators.ToDictionary(tc => tc.GetType().Name, tc => tc);
        }
        /// <summary>
        /// This method is used to calculate the tax based on the values provided from the view
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <param name="postalCode"></param>
        /// <param name="postalCodes"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double CalculateTax(decimal annualIncome, string postalCode, List<PostalCodeDetails> postalCodes)
        {
            var taxCalculationType = (from code in postalCodes
                                      where code.PostalCodeId.ToString().Equals(postalCode)
                                      select code).FirstOrDefault();
            string taxCalculationTypeName = "";
            if (taxCalculationType != null)
            {
                taxCalculationTypeName = GetEnumTextFromValue<TaxType>(taxCalculationType.TaxCalculationTypeId.HasValue ? taxCalculationType.TaxCalculationTypeId.Value : 0);
            }

            if (_taxCalculators.TryGetValue(taxCalculationTypeName, out var taxCalculator))
            {
                return taxCalculator.CalculateTax(annualIncome);
            }
            throw new InvalidOperationException($"No tax calculator found for type: {postalCode}");
        }

        public static string GetEnumTextFromValue<TEnum>(int value) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return Enum.GetName(typeof(TEnum), value);
            }

            // Handle the case where the int value doesn't correspond to any enum value
            return "Unknown";
        }
    }
}
