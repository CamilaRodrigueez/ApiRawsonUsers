using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infraestructure.Entity.Models
{
    [Table("TipoContacto")]
    public class TipoContactoEntity
    {
        [Key]
        public int IdTipoContacto { get; set; }

        [Required]
        [MaxLength(50)]  
        
        public string TipoContacto{ get; set; }

    }
}
