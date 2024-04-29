    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using RMS.Application.Common.Interfaces;
    using RMS.Domain.Entities;

    namespace RMS.Infrastructure.services;

    internal sealed class JwtProvider:IJwtProvider
    {
        //iz nekog razloga infrastracture layer ne vidi Api layer
       // private readonly JwtOptions _jwtOptions;

        // public JwtProvider(IOptions<JwtOptions> options)
        // {
        //     _jwtOptions = options;
        // }
        public string GenerateJwt(ApplicationUser user)
        {   
            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Email,user.Email)
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret-key2131321312132132xDD2231212113")), SecurityAlgorithms.HmacSha256);
            
            
            var token = new JwtSecurityToken("issuer", "audience", claims, null, DateTime.UtcNow.AddHours(1),signingCredentials);


            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        } }