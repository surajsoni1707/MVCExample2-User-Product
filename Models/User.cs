using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample2.Models
{
    public class User
    {
        
        public int UserId { set; get; }
        
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public int RoleId { set; get; }

    }
}
