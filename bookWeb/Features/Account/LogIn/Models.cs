namespace Account.LogIn
{
    internal sealed class Request
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public string Publisher { get; set; } = default!;
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}
