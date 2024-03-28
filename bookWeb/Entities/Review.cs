namespace bookWebApi.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public required double  Score { get; set; }
        public string? Comment { get; set; }

        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
