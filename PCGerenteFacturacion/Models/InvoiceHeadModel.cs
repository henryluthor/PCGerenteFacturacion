namespace PCGerenteFacturacion.Models
{
    public class InvoiceHeadModel
    {
        public int? IdInvoiceHead { get; set; }
        public double Subtotal { get; set; }
        public double TaxZero { get; set; }
        public double TaxTwelve { get; set; }
        public double Total {  get; set; }
        public List<InvoiceDetailModel>? Products { get; set; }
    }
}
