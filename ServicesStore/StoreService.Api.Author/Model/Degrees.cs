namespace StoreService.Api.Author.Model
{
    public class Degrees
    {
        public int DegreesId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? DateDegree { get; set; }
        
        public AuthorBook AuthorBook { get; set; }
        public string DegreeGuid { get; set; }
        public int AuthorBookId { get; set; }


    }
}
