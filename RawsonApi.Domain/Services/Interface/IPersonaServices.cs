using Infraestructure.Entity.Models;
using RawsonApi.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawsonApi.Domain.Services.Interface
{
    public interface IPersonaServices
    {
        List<PersonaDto> GetAllPersonas();
        List<TipoContactoDto> GetAllTipoContacto();
        Task<ResponseDto> InsertUser(PersonaDto userInsert);
        bool IsUniqueIdentification(string identification);
        Task<bool> InsertContatoPersona(int idTipoContacto, string contacto, int idPersona);

        bool ValidarMaxContacto(int idTipoContacto, int idPersona);




    }
}
