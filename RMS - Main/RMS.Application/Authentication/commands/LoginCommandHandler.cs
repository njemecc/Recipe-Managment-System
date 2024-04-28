using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Domain.Entities;

namespace RMS.Application.Authentication.commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand,string>
{

    private readonly IPostgresDbContext dbContext;
    private readonly IJwtProvider jwtProvider;

    public LoginCommandHandler(IPostgresDbContext dbContext, IJwtProvider jwtProvider)
    {
        this.dbContext = dbContext;
        this.jwtProvider = jwtProvider;
    }
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //get the user from the database

        ApplicationUser user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(request.Email));

        if (user is null)
        {
            throw new Exception("Wrong credentials");
        }

        //generate jwt

        string token = jwtProvider.GenerateJwt(user);

        //return jwt

        return token;
    }
}