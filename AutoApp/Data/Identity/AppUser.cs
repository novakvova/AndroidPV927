using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoApp.Data.Identity
{
    public class AppUser : IdentityUser<long>
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string SecondName { get; set; }
        [StringLength(150)]
        public string Photo { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
