using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("SUPPLIER")]
    public class Supplier
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]

        [Column("SUPPLIER_CODE")]
        [StringLength(20)]
        public string SupplierCode { get; set; } = string.Empty;

        [Column("SUPPLIER_NAME")]
        [StringLength(200)]
        public string SupplierName { get; set; } = string.Empty;
    }
}
