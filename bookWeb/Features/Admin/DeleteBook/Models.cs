namespace Admin.DeleteBook
{
    internal sealed class DeleteBookRequest
    {
        public Guid Id { get; set; }
    }

    internal sealed class Validator : Validator<DeleteBookRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }

}
