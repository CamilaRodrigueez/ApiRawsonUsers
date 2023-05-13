using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawsonApi.Domain.DTO
{
    public class ContactoDto
    {

        public int IdTipoContacto { get; set; }

        public string Contacto { get; set; }

        public ContactoDto()
        {
            this.Contacto = "";
        }

    }
}
