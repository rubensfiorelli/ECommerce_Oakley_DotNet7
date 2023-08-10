using OakleyShop.Domain.Enums;

namespace OakleyShop.Domain.OutputModels
{
    public record ProductOutputModel
    {
        public Guid Id { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }
        public decimal Price { get; init; }
        public string Code { get; init; }
        public SizeEnum Size { get; init; }
        public Guid CategoryId { get; init; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }


    }
}
