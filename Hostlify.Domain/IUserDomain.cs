﻿using Hostlify.Infraestructure;

namespace Hostlify.Domain;

public interface IUserDomain
{
    Task<string> Login(User user);
    Task<bool> Signup(User user);
    Task<User> GetByUsername(string username);
    Task<User> GetByUserId(int id);
    Task<bool> DeleteUser(int id);
    Task<List<User>> GetAllUsers();
}