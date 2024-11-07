namespace CSIT.ZB.Apps.DataModels.Entities
{
    public class TypeOfProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
