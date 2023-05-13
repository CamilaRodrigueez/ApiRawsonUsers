using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawsonApi.Domain.DTO
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        public string Identificacion { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
         ErrorMessage = "No se permiten caracteres")]
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = "No se permiten caracteres")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        public List<ContactoDto> InformacionContacto { get;set; }

        public PersonaDto()
        {
            this.Nombres= string.Empty;
            this.Apellidos= string.Empty;
            this.Identificacion= string.Empty;
        }
    }
}
