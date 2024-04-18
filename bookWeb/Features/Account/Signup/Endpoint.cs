using bookWebApi.Entities;
using bookWebApi.Repository;

namespace Account.Signup
{
    internal sealed class Endpoint : Endpoint<SignUpRequest>
    {
        private readonly IUserRepository _repo;

        public Endpoint(IUserRepository userRepository)
        {
            _repo = userRepository;
        }

        public override void Configure()
        {
            Post("/api/account/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SignUpRequest r, CancellationToken c)
        {           
            if (await _repo.GetUserByEmail(r.Email) is not null)
            {
                ThrowError("Użytkownik z takim adresem e-mail już istnieje");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = r.Email,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Password = r.Password
            };

            if (await _repo.AddUser(user))
            {
                await SendOkAsync();
            }
            else
            {
                ThrowError("Coś poszło nie tak");
            }
        }
    }
}