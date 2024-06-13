namespace PCGerenteFacturacion.Models
{
    public class PersonModel
    {
        public int Personid { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<ProductTestModel>? Products { get; set; }
    }
}
