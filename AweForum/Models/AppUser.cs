using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class AppUser : IdentityUser
    {
        public int NrOfMessages { get; set; }
        public int NrOfTopics { get; set; }
        public List<User_Reaction> User_Reactions { get; set; }
    }
}
