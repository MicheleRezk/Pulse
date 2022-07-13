using Pulse.Application.Common;
using Pulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Infrastructure.Services
{
    /// <summary>
    /// handle all user db services (as fake dataStore)
    /// </summary>
    internal class UserServices : IUserServices
    {
        private const int DELAY = 3000; //in ms
        private List<User> _users;
        public UserServices()
        {
            //Mock the data
            _users = new List<User>
            {
                new User { Id = Guid.NewGuid(), FirstName="Michele", LastName ="George", Email="m.george@gmail.com"},
                new User { Id = Guid.NewGuid(), FirstName="Rico", LastName ="Petzold", Email="r.petzold@gmail.com"},
            };
        }
        public async Task CreateUserAsync(User user)
        {
            //Assume Database Response takes time
            await Task.Delay(DELAY);
            _users.Add(user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await Task.Delay(DELAY);
            var user = _users.FirstOrDefault(u => u.Id == userId);
            _users.Remove(user); 
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            await Task.Delay(DELAY);
            return _users;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            await Task.Delay(DELAY);
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            var retrievedUser = await GetUserByIdAsync(user.Id);
            if (retrievedUser != null)
            {
                retrievedUser.FirstName = user.FirstName;
                retrievedUser.LastName = user.LastName;
                retrievedUser.Email = user.Email;
            }
        }
    }
}
