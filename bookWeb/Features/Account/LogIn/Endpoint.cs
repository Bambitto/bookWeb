namespace Account.LogIn
{
    internal sealed class Endpoint : Endpoint<LogInRequest>
    {
        public override void Configure()
        {
            Post("");
        }

        public override async Task HandleAsync(LogInRequest r, CancellationToken c)
        {
            await SendStringAsync("something went wrong", 400, cancellation: c);
        }
    }
}