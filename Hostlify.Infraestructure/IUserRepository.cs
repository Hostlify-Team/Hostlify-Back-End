namespace Hostlify.Infraestructure;

public interface IUserRepository
{
    Task<User> GetByUsername(string username);
    
    Task<User> GetByUserId(int id);
    Task<bool> Login(User user);
    Task<bool> SingUp(User user);
    Task<bool> DeleteUser(int id);
    Task<List<User>> GetAllUsers();
}