namespace bookWebApi.Entities
{
    public class User
    {
        public Guid Id {  get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
