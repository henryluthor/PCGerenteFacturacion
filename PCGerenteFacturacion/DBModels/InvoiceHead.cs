using System;
using System.Collections.Generic;

namespace PCGerenteFacturacion.DBModels;

public partial class InvoiceHead
{
    public int IdInvoiceHead { get; set; }

    public double? TaxZero { get; set; }

    public double? TaxTwelve { get; set; }

    public double Total { get; set; }

    public DateTime DateTime { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
