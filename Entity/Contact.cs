using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("CONTACT")]
    public class Contact
    {
        [Key]
        [Column("CONTACT_ID")]
        public long ContactId { get; set; }

        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("PHONE_NUMBER")]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
