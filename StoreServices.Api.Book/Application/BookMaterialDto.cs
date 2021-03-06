namespace StoreServices.Api.Book.Application
{
    public class BookMaterialDto
    {
        public Guid? LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePublication { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
