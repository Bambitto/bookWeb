using bookWebApi.Entities;

namespace Public.GetGenres;

internal sealed class ResponseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}


internal sealed class Validator
{
    public Validator()
    {

    }
}

internal sealed class Response
{
    public IEnumerable<ResponseEntity>? Genres { get; set; }
}
