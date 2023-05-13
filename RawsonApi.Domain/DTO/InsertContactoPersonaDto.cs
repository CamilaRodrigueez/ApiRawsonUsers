using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawsonApi.Domain.DTO
{
    public class InsertContactoPersonaDto
    {
        [Required(ErrorMessage ="Se requiere el Id del TipoContacto a relacionar")]
        public int IdTipoContacto { get; set; }
        [Required(ErrorMessage = "Se requiere el Id de la persona a relacionar el contacto")]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "Se quiere el valor del tipo contacto a relacionar")]
        public string Contacto { get; set; }
    }
}
