namespace Admin.IsAdmin
{
    internal sealed class Endpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("api/admin");
            Roles("Admin");
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            await SendOkAsync(c);
        }
    }
}