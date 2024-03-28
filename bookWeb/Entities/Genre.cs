namespace bookWebApi.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
