using DNDCatalog.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DNDCatalog.FunctionalTests;

public static class MockJwtToken
{
    public static string Issuer { get; } = "https://localhost:5001";
    public static string Audience { get; } = "https://localhost:5001/resources";
    public static SecurityKey SecurityKey { get; }
    public static SigningCredentials SigningCredentials { get; }

    private static readonly JwtSecurityTokenHandler STokenHandler = new JwtSecurityTokenHandler();
    private static readonly RandomNumberGenerator SRng = RandomNumberGenerator.Create();
    private static readonly byte[] SKey = new byte[32];

    static MockJwtToken()
    {
        SRng.GetBytes(SKey);
        SecurityKey = new SymmetricSecurityKey(SKey) { KeyId = Guid.NewGuid().ToString() };
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }

    public static string GenerateJwtToken(IEnumerable<Claim> claims) => 
        STokenHandler.WriteToken(new JwtSecurityToken(Issuer, Audience, claims, null, DateTime.UtcNow.AddMinutes(20), SigningCredentials));

    public static string GenerateJwtTokenAsAdministrator() => GenerateJwtToken(AdministratorClaims);
    public static string GenerateJwtTokenAsEditor() => GenerateJwtToken(EditorClaims);
    public static string GenerateJwtTokenAsBadUser() => GenerateJwtToken(BadUserRoleClaims);

    public static IEnumerable<Claim> EditorClaims
    {
        get
        {
            yield return new Claim(ClaimTypes.Name, "editor@test.com");
            yield return new Claim(ClaimTypes.Role, nameof(Roles.EDITORS));
        }
    }

    public static IEnumerable<Claim> AdministratorClaims
    {
        get
        {
            yield return new Claim(ClaimTypes.Name, "admin@test.com");
            yield return new Claim(ClaimTypes.Role, nameof(Roles.ADMINISTRATORS));
        }
    }

    public static IEnumerable<Claim> BadUserRoleClaims
    {
        get
        {
            yield return new Claim(ClaimTypes.Name, "bad@test.com");
            yield return new Claim(ClaimTypes.Role, "BadRole");
        }
    }
}
