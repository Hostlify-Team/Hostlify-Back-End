namespace Hostlify.Infraestructure;

public interface IUserRepository
{
    Task<User> GetByUserId(int id);
    Task<int> GetRoomsLimitByUserId(int id);
    Task<bool> Login(User user);
    Task<bool> SingUp(User user);
    Task<bool> DeleteUser(int id);
    Task<List<User>> GetAllUsers();
    Task<User> GetByEmail(string email);
    Task<bool> PostPersonalPlan(string email, int roomsLimit);
}