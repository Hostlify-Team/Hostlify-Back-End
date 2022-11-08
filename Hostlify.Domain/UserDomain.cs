﻿using Hostlify.Infraestructure;

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
        var result = await _userRepository.GetByUsername(user.Username);

        if (result.Password == user.Password)
        {
            return _tokenDomain.GenerateJwt(user.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<bool> Signup(User user)
    {
        return await _userRepository.SingUp(user);
    }

    public async Task<User> GetByUsername(string username)
    {
        return  await _userRepository.GetByUsername(username);
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
}