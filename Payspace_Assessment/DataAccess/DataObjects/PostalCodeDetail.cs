using System;
using System.Collections.Generic;

namespace Payspace_Assessment.DataAccess.DataObjects;

public partial class PostalCodeDetail
{
    public int PostalCodeId { get; set; }

    public string? PostalCodeName { get; set; }

    public int? TaxCalculationTypeId { get; set; }

    public virtual TaxCalculationType? TaxCalculationType { get; set; }
}
