using OakleyShop.Domain.Entities;

namespace OakleyShop.Domain.InputModels
{
    public class ProductInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }

        public Product ToEntity()
            => new Product(Title, Description, ImgUrl, Price, Code);
    }
}
