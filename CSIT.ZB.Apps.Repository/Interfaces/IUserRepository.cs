using CSIT.ZB.Apps.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailOrMobileAsync(string identifier);
    }
}
