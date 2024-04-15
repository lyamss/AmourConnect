﻿using server_api.Data;
using server_api.Interfaces;
using server_api.Models;

namespace server_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context) 
        { 
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.User.ToList();
        }
    }
}