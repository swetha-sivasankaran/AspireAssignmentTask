using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Assignment.Contracts.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Assignment.Providers.Handlers.Queries
{
    public class SignInUserByUserNameQuery : IRequest<string>
    {
        public string UserName { get; }
        public string PassWord { get; }
        public SignInUserByUserNameQuery(string userName, string password)
        {
            UserName = userName;
            PassWord = password;
        }
    }

    public class SignInUserByUserNameQueryHandler : IRequestHandler<SignInUserByUserNameQuery, string>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;////Ioption to be changes 
   


        public SignInUserByUserNameQueryHandler(IUnitOfWork repository, IMapper mapper, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            
        }

        public async Task<string> Handle(SignInUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await Task.FromResult(_repository.User.GetAll().Where(con=>con.Username.Equals(request.UserName)).FirstOrDefault());

            if (user == null)
            {
                throw new EntityNotFoundException($"No User found for  {request.UserName}");
            }
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.PassWord);
            if(PasswordVerificationResult.Success!=result)
            {
                throw new InvalidcredentialsException($"Invalid credentials");
            }
            
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Authentication:Jwt:Secret"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("userId", request.UserName),
                    new Claim(ClaimTypes.Role,user.Roles) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
              var token= tokenHandler.CreateToken(tokenDescriptor);
              return token == null ? throw new EntityNotFoundException($"Faild to generate the token") : tokenHandler.WriteToken(token) ;
        }

     
    }
}