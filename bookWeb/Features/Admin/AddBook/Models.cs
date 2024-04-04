using bookWebApi.Entities;
using Public.GetBooks;

namespace Admin.AddBook
{
    internal sealed class AddBookRequest
    {
        
        public required string Title { get; set; }
        public required string Author { get; set; }
        public Guid GenreId { get; set; }
        public string? Description { get; set; }

    }

    internal sealed class Validator : Validator<AddBookRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Autor jest wymagany")
                .MaximumLength(64);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Tytuł jest wymagany")
                .MaximumLength(64);

            RuleFor(x => x.Description)
                .MaximumLength(512);

            RuleFor(x => x.GenreId)
                .NotEmpty()
                .WithMessage("Gatunek jest wymagany");
        }
    }
}
