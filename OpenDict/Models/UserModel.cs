using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDict.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterIp { get; set; }
        public int UserGroupId { get; set; }
        public int EntryCount { get; set; }
        public int UserStatusId { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public int Activation { get; set; }
    }
}
