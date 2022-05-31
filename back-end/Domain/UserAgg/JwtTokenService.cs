using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SixB_Api.Infraestructure.Aspnetcore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/// <summary>
/// Simple JwtService to create a token when user is authenticated
/// </summary>
public class JwtTokenService : IJwtTokenService
{
    private BookingDataContext _context;
    private readonly AppSettings _appSettings;

    public JwtTokenService(
        BookingDataContext context,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Generate new token of user by the User instance object
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GetAllClaims(user),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Return all the claims for the token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private ClaimsIdentity GetAllClaims(User user)
    {
        return new ClaimsIdentity(new[] {
                new Claim("userId", user.Id.ToString())
            });
    }

    /// <summary>
    /// Service is used by the middleware to validate current token from the request
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Guid? ValidateJwtToken(string token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }


    }
}
