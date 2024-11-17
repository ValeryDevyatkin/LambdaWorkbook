using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LambdaWorkbook.Api;

public class JwtConfig
{
    public int LifetimeMinutes { get; }
    public string Secret { get; }
    public string Issuer { get; }
    public string Audience { get; }

    private JwtConfig(string secret, string issuer, string audience, int lifetimeMinutes)
    {
        Secret = secret;
        Issuer = issuer;
        Audience = audience;
        LifetimeMinutes = lifetimeMinutes;
    }

    public static JwtConfig CreateFromConfig(ConfigurationManager config)
    {
        var secret = config[$"{nameof(JwtConfig)}:{nameof(Secret)}"]?.Trim();
        var issuer = config[$"{nameof(JwtConfig)}:{nameof(Issuer)}"]?.Trim();
        var audience = config[$"{nameof(JwtConfig)}:{nameof(Audience)}"]?.Trim();

        var lifetimeMinutesStr = config[$"{nameof(JwtConfig)}:{nameof(LifetimeMinutes)}"]?.Trim();
        var isLifetaimeParsed = int.TryParse(lifetimeMinutesStr, out var lifetimeMinutes);

        if (string.IsNullOrEmpty(secret) ||
            string.IsNullOrEmpty(issuer) ||
            string.IsNullOrEmpty(audience) ||
            lifetimeMinutes < 1)
        {
            throw new ArgumentException(
                $"JWT was not properly configured ({nameof(Secret)}: {secret}, {nameof(Issuer)}: {issuer}, {nameof(Audience)}: {audience}, {nameof(LifetimeMinutes)}: {lifetimeMinutesStr}).");
        }

        return new JwtConfig(secret, issuer, audience, lifetimeMinutes);
    }

    public string GetToken(string login)
    {
        var key = Encoding.ASCII.GetBytes(Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(JwtRegisteredClaimNames.Aud, Audience),
                new Claim(JwtRegisteredClaimNames.Iss, Issuer)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(LifetimeMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }
}