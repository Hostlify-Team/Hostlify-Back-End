using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IUserDomain
{
    Task<string> Login(User user);
    Task<bool> Signup(User user);
    Task<User> GetByEmail(string email);
    Task<int> GetRoomsLimitByUserId(int id);
    Task<User> GetByUserId(int id);
    Task<bool> DeleteUser(int id);
    Task<List<User>> GetAllUsers();
    Task<bool> PostPersonalPlan(string email, int roomsLimit);
}