namespace Hostlify.Domain;

public interface ITokenDomain
{
    string GenerateJwt(string username);
    string ValidateJwt(string token);
}