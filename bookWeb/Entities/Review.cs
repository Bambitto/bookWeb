namespace bookWebApi.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public required int  Score { get; set; }
        public string? Comment { get; set; }

        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
