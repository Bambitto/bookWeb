namespace Account.Signup
{
    internal sealed class SignUpRequest
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }
    }

    internal sealed class Validator : Validator<SignUpRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(64);

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(64);

            RuleFor(x => x.LastName)
                .MaximumLength(64);
        }
    }
}
