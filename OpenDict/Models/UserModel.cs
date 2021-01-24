using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDict.Models
{
    public class UserModel
    {
    
        public int Id { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterIp { get; set; } 
        public int UserGroupLevel { get; set; }
        public int EntryCount { get; set; }
        public int UserStatusId { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public int Activation { get; set; }

        public UserModel()
        {
            RegisterDate = DateTime.Now;
            LastOnlineDate = DateTime.Now;
            Token = "";
            RegisterIp = "";

        }
      
    }
}
