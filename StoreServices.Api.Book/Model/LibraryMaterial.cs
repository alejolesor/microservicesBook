﻿namespace StoreServices.Api.Book.Model
{
    public class LibraryMaterial
    {
        public Guid? LibraryMaterialId { get; set; }
        public string Title { get; set; }
        public DateTime? DatePublication { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
