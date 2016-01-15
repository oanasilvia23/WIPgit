using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WIPCream.DataGateway.DAL2.Models;
using System.ComponentModel.DataAnnotations;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class UsersDTO
    {
        public int UserId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 6)]
        [Required()]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 2)]
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
        public virtual ICollection<UserDisciplines> UserDiscipline { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRole { get; set; }

    }
}
