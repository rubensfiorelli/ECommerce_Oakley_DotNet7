namespace OakleyShop.Domain.Entities
{
    public sealed class Category : BaseEntity
    {

        public Category(string title, string description) : base()
        {
            Title = title;
            Description = description;
            Products = new List<Product>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public List<Product> Products { get; set; }

        public void SetValues(string newTitle, string newDescription)
        {
            Title = newTitle;
            Description = newDescription;
        }
    }
}
