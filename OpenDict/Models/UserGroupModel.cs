using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDict.Models
{
    public class UserGroupModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string UserGroup { get; set; }
        public int LanguageId { get; set; }

    }
}
