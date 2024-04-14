namespace Admin.UpdateBook
{
    internal sealed class UpdateBookRequest
    {
        public Guid Id { get; set; }
        public string NewTitle { get; set; }
        public string NewAuthor { get; set; }
        public Guid NewGenreId { get; set; }
        public string NewDescription { get; set; }
    }

    internal sealed class Validator : Validator<UpdateBookRequest>
    {
        public Validator()
        {
            RuleFor(x => x.NewAuthor).NotEmpty().MaximumLength(64);
            RuleFor(x => x.NewTitle).NotEmpty().MaximumLength(64);
            RuleFor(x => x.NewDescription).MaximumLength(512);
            RuleFor(x => x.NewGenreId).NotEmpty();
        }
    }
}
