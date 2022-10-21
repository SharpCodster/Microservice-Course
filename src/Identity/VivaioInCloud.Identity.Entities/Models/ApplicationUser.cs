using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Identity.Entities.Models
{
    public class ApplicationUser : IdentityUser, IAuditableUtc, IIdentified
    {
        public ApplicationUser() : base()
        {
            IdentityRoles = new HashSet<ApplicationRole>();
        }

        public ApplicationUser(string userName) : base(userName)
        {
            IdentityRoles = new HashSet<ApplicationRole>();
        }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDate { get; set; }

        public bool IsDomainlUser { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public long? InstallerId { get; set; } = null;


        public DateTime CreatedAtUtc { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedAtUtc { get; set; }
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }


        public virtual ICollection<ApplicationRole>? IdentityRoles { get; set; }
    }
}
