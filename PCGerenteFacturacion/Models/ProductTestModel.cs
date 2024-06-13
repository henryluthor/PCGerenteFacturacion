namespace PCGerenteFacturacion.Models
{
    public class ProductTestModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public bool Enabled { get; set; }
    }
}
