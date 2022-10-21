using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Identity.Entities.Models
{
    public class ApplicationRole : IdentityRole, IAuditableUtc, IIdentified
    {
        public ApplicationRole() : base()
        {
            Users = new HashSet<ApplicationUser>();
        }

        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }

        public DateTime CreatedAtUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<ApplicationUser>? Users { get; set; }
    }
}
