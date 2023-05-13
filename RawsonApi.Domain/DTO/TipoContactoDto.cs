using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RawsonApi.Domain.DTO
{
    
    public class TipoContactoDto
    { 

        public int IdTipoContacto { get; set; }

        [Required]
        [MaxLength(50)]  
        public string TipoContacto{ get; set; }

    }
}
