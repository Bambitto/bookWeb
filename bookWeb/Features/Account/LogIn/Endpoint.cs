namespace Account.LogIn
{
    internal sealed class Endpoint : Endpoint<Request, Mapper>
    {
        public override void Configure()
        {
            Post("");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await SendStringAsync("something went wrong", 400, cancellation: c);
        }
    }
}