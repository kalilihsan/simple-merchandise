using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("MERCHANDISE_TYPE")]
    public class MerchandiseType
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("MERCHANDISE_TYPE_CODE")]
        [StringLength(100)]
        public string MerchandiseTypeCode { get; set; } = string.Empty;

        [Column("MERCHANDISE_TYPE_NAME")]
        [StringLength(200)]
        public string MerchandiseTypeName { get; set; } = string.Empty;
        [Required]
        [Column("SUPPLIER_CODE")]
        [StringLength(20)]
        public string SupplierCode { get; set; } = string.Empty;

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; }
    }
}
