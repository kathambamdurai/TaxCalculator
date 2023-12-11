using System;
using System.Collections.Generic;

namespace Payspace_Assessment.DataAccess.DataObjects;

public partial class TaxCalculationDetail
{
    public int TaxCalculationId { get; set; }

    public decimal? AnnualIncome { get; set; }

    public int? PostalCodeId { get; set; }

    public decimal? TaxAmount { get; set; }

    public DateTime? CalculatedOn { get; set; }
}
