namespace PCGerenteFacturacion.Models
{
    public class InvoiceHeadModel
    {
        public float TaxZero { get; set; }
        public float TaxTwelve { get; set; }
        public float Total {  get; set; }
        public List<InvoiceDetailModel>? Products { get; set; }
    }
}
