using bookWebApi.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FastEndpoints.Security;

namespace Account.LogIn
{
    internal sealed class Endpoint : Endpoint<LogInRequest>
    {
        public Endpoint(IUserRepository repo) 
        {
            _repo = repo;
        }


        private readonly IUserRepository _repo;


        public override void Configure()
        {
            Post("/api/account/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LogInRequest r, CancellationToken c)
        {
            var user = await _repo.GetUserByEmail(r.Email);

            if (user == null)
            {
                ThrowError("Nieprawidłowy e-mail bądź hasło");
            }

            if(user.Password != r.Password)
            {
                ThrowError("Nieprawidłowy e-mail bądź hasło");
            }



            var tokenString = JwtBearer.CreateToken(o =>
            {
                o.SigningKey = Config["Jwt:secret"];
                o.ExpireAt = DateTime.UtcNow.AddHours(2);
                o.User.Roles.Add(user.Role.Name);
                o.User.Claims.Add(("Email", user.Email));
            }
            );

            await SendOkAsync(tokenString);
           
        }
    }
}