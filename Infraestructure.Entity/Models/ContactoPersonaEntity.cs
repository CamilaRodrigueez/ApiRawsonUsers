using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("ContactoPersona")]
    public class ContactoPersonaEntity
    {
        [Key]
        public int IdContacto { get; set; }
        [ForeignKey("TipoContactoEntity")]
        public int IdTipoContacto { get; set; }
        public TipoContactoEntity TipoContactoEntity { get; set; }  

        [ForeignKey("PersonaEntity")]
        public int IdPersona { get; set; }
        public PersonaEntity PersonaEntity { get; set; }
        [Required]
        public string Contacto { get; set; }    
    }
}
