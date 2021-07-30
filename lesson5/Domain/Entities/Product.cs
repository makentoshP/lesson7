using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.Domain.Entities
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public long Id { get; protected set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public long CatedoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
