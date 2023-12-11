using System;
using System.Collections.Generic;

namespace Payspace_Assessment.DataAccess.DataObjects;

public partial class ProgressiveTax
{
    public int ProgressiveTaxId { get; set; }

    public decimal? TaxPercentage { get; set; }

    public decimal? FromAmount { get; set; }

    public decimal? ToAmount { get; set; }
}
