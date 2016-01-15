using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.User
{
    public class UserUIDTO
    {
        public int UserId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 6)]
        [Required()]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 0)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 0)]
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        [Required()]
        public string Email { get; set; }
        public Nullable<int> StudentId { get; set; }
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [Required()]
        public string Password { get; set; }

        public int Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIPCream.DataGateway.DAL2.Models.UserDisciplines> UserDiscipline { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIPCream.DataGateway.DAL2.Models.UserRoles> UserRole { get; set; }
    }
}