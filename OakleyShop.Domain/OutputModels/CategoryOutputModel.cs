namespace OakleyShop.Domain.OutputModels
{
    public record CategoryOutputModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }

    }
}
