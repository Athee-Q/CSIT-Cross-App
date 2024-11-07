namespace CSIT.ZB.Apps.DataModels.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TypeOfProduct> TypeOfProducts { get; set; }
    }
}
