using System;
using System.Collections.Generic;

namespace Payspace_Assessment.DataAccess.DataObjects;

public partial class TaxCalculationType
{
    public int TaxCalculationTypeId { get; set; }

    public string? TaxCalculationTypeName { get; set; }

    public virtual ICollection<PostalCodeDetail> PostalCodeDetails { get; set; } = new List<PostalCodeDetail>();
}
