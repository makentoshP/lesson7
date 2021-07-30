using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.Domain.Entities
{
    [Table("tbl_User")]
    public class AppUser
    {
        [Key]
        public long Id { get; protected set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
