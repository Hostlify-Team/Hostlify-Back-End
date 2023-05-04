using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public class UserDomain:IUserDomain
{
    private IUserRepository _userRepository;
    private ITokenDomain _tokenDomain;
    
    public UserDomain(IUserRepository userRepository,ITokenDomain tokenDomain)
    {
        _userRepository = userRepository;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(User user)
    {
        var result = await _userRepository.GetByEmail(user.Email);
        
        if (result.Password == user.Password && result.IsActive)
        {
            return _tokenDomain.GenerateJwt(user.Email);
        }

        throw new ArgumentException("Invalid Email or password");
    }

    public async Task<bool> Signup(User user)
    {
        return await _userRepository.SingUp(user);
    }
    
    public async Task<User> GetByEmail(string email)
    {
        return  await _userRepository.GetByEmail(email);
    }

    public async Task<int> GetRoomsLimitByUserId(int id)
    {
        return await _userRepository.GetRoomsLimitByUserId(id);
    }

    public async Task<User> GetByUserId(int id)
    {
        return  await _userRepository.GetByUserId(id);
    }

    public async Task<bool> DeleteUser(int id)
    {
        return  await _userRepository.DeleteUser(id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<bool> PostPersonalPlan(string email, int roomsLimit)
    {
        return await _userRepository.PostPersonalPlan(email, roomsLimit);
    }
}