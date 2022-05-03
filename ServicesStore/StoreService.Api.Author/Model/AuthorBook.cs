namespace StoreService.Api.Author.Model
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Degrees> ListDegree { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
