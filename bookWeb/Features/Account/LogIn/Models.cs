namespace Account.LogIn
{
    internal sealed class LogInRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
        internal sealed class Validator : Validator<LogInRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(64);

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
