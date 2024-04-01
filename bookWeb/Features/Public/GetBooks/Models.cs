using bookWebApi.Entities;

namespace Public.GetBooks
{
    internal sealed class ResponseEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid GenreId { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Review> Reviews { get; set; }
        public string Genre { get; set;}
    }

    internal sealed class Response
    {
        public required IEnumerable<ResponseEntity> Books { get; set; }
    }
}
