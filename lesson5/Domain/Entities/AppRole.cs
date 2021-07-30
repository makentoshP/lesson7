using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.Domain.Entities
{
    [Table("tblRole")]
    public class AppRole
    {
        [Key]
        public long Id { get; protected set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

    }
}
