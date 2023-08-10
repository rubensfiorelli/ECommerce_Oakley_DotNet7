using OakleyShop.Domain.Enums;

namespace OakleyShop.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(string title,
                       string description,
                       string imgUrl,
                       decimal price,
                       string code) : base()
        {
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
            Code = code;
            Size = SizeEnum.Large;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImgUrl { get; private set; }
        public decimal Price { get; private set; }
        public string Code { get; private set; }
        public SizeEnum Size { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category? Category { get; set; }


        public void SetValues(string newTitle, string newDescription, string newImgUrl, decimal newPrice, string newCode, SizeEnum newSize)
        {
            Title = newTitle;
            Description = newDescription;
            ImgUrl = newImgUrl;
            Price = newPrice;
            Code = newCode;
            Size = newSize;

        }

    }
}
