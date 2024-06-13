using System;
using System.Collections.Generic;

namespace PCGerenteFacturacion.DBModels;

public partial class InvoiceDetail
{
    public int IdInvoiceDetail { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int IdInvoiceHead { get; set; }

    public virtual InvoiceHead IdInvoiceHeadNavigation { get; set; } = null!;
}
