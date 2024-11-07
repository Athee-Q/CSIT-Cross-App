using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT.ZB.Apps.DataModels.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsVerified { get; set; }
    }
}
