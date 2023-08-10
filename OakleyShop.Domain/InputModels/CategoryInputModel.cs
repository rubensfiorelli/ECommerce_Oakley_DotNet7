using OakleyShop.Domain.Entities;

namespace OakleyShop.Domain.InputModels
{
    public class CategoryInputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Category ToEntity()
             => new(Title, Description);
    }
}
