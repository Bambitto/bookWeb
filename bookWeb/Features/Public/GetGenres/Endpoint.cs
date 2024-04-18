using bookWebApi.Entities;
using bookWebApi.Repository;

namespace Public.GetGenres;

internal sealed class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IBookRepository _repo;

    public Endpoint(IBookRepository repo)
    {
        _repo = repo;
    }

    public override void Configure()
    {
        Post("route-pattern");
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        var genres  = await _repo.GetGenres();

        if (genres != null)
        {
            var response = new Response
            {
                Genres = genres.Select(x => new ResponseEntity
                {
                    Name = x.Name,
                    Id = x.Id,
                })
            };

            await SendOkAsync(response);
        }

        else
        {
            await SendNoContentAsync();
        }
    }
}