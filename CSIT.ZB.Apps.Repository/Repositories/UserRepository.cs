using CSIT.ZB.Apps.DataModels.Entities;
using CSIT.ZB.Apps.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Simulated user data, replace with actual database query
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Email = "user1@example.com", MobileNumber = "1234567890", IsVerified = true },
            new User { Id = 2, Email = "user2@example.com", MobileNumber = "0987654321", IsVerified = true }
        };

        // Authenticate using email or mobile number
        public async Task<User> GetUserByEmailOrMobileAsync(string identifier)
        {
            await Task.Delay(500); // Simulate database delay

            // Look for a user by email or mobile number
            return _users.FirstOrDefault(u => u.Email == identifier || u.MobileNumber == identifier);
        }
    }
}
