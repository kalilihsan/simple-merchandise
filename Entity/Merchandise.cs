using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("MERCHANDISE")]
    public class Merchandise
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]

        [Column("MERCHANDISE_TYPE_CODE")]
        [StringLength(100)]
        public string MerchandiseTypeCode { get; set; } = string.Empty;

        [Column("PRICE")]
        public decimal Price { get; set; }
    }
}
