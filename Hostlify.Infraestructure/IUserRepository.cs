namespace Hostlify.Infraestructure;

public interface IUserRepository
{
    Task<User> GetByUsername(string username);
    Task<bool> Login(User user);
    Task<bool> SingUp(User user);
}