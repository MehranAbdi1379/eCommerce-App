using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Authentication.Service;
public class AuthManager
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly IConfiguration configuration;
    private IdentityUser? user;

    public AuthManager(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
    List<Claim> claims)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        var tokenOptions = new JwtSecurityToken
        (
        issuer: jwtSettings["Issuer"],
        audience: jwtSettings["Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: signingCredentials
        );
        return tokenOptions;
    }


    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
 {
 new Claim(ClaimTypes.Email, user.Email)
 };
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("KEY"));
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<bool> ValidateUser(UserSignInDTO userForAuth)
    {
        user = await userManager.FindByEmailAsync(userForAuth.Email);
        var result = user != null && await userManager.CheckPasswordAsync(user,
       userForAuth.Password) && await userManager.IsEmailConfirmedAsync(user);
        return result;
    }

}
