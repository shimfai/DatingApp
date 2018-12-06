using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);

            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {   
                passwordHash = hash.Key;
                passwordSalt = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        public Task<bool> UserExits(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}