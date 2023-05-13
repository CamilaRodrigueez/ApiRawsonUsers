using Common.Utils.Recursos;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using RawsonApi.Domain.DTO;
using RawsonApi.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RawsonApi.Domain.Services
{
    public class PersonaServices : IPersonaServices
    {

        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public PersonaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<PersonaDto> GetAllPersonas()
        {
            var listUser = _unitOfWork.PersonaRepository.GetAll();
            var listContactoPersona = _unitOfWork.ContactoPersonaRepository.GetAll(x => x.PersonaEntity
                                                                             , t => t.TipoContactoEntity);

            List<InsertContactoPersonaDto> listInfoContacto = listContactoPersona.Select(c => new InsertContactoPersonaDto
            {
                IdPersona = c.IdPersona,
                IdTipoContacto = c.TipoContactoEntity.IdTipoContacto,
                Contacto = c.Contacto,
            }).ToList();

            List<PersonaDto> list = listUser.Select(x => new PersonaDto
            {
                IdPersona = x.IdPersona,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                Identificacion = x.Identificacion,
                FechaNacimiento = x.FechaNacimiento,
                InformacionContacto = listInfoContacto.Where(c => c.IdPersona == x.IdPersona).Select(b => new ContactoDto
                {
                    IdTipoContacto = b.IdTipoContacto,
                    Contacto = b.Contacto,
                }).ToList(),
            }).ToList();

            return list;
        }
        public List<TipoContactoDto> GetAllTipoContacto()
        {
            var tipoContactos = _unitOfWork.TipoContactoRepository.GetAll();

            List<TipoContactoDto> list = tipoContactos.Select(x => new TipoContactoDto
            {
                IdTipoContacto = x.IdTipoContacto,
                TipoContacto = x.TipoContacto,
            }).ToList();
            return list;
        }
        public async Task<ResponseDto> InsertUser(PersonaDto userInsert)
        {
            ResponseDto response = new ResponseDto();
            bool validarIdentificacion = IsUniqueIdentification(userInsert.Identificacion);

            if (!validarIdentificacion)
            {
                response.Message = string.Format(GeneralMessages.ExistUserIdentificacion, userInsert.Identificacion);
                return response;
            }

            PersonaEntity personaEntity = new PersonaEntity()
            {
                Identificacion = userInsert.Identificacion,
                Nombres = userInsert.Nombres,
                Apellidos = userInsert.Apellidos,
                FechaNacimiento = userInsert.FechaNacimiento,
            };
            _unitOfWork.PersonaRepository.Insert(personaEntity);
            await _unitOfWork.Save();

            if (userInsert.InformacionContacto.Count > 0)
            {
                foreach (var item in userInsert.InformacionContacto)
                {
                    await InsertContatoPersona(item.IdTipoContacto, item.Contacto, personaEntity.IdPersona);
                }
            }

            userInsert.IdPersona = personaEntity.IdPersona;
            response.IsSuccess = true;
            response.Message = GeneralMessages.ItemInsert;
            response.Result = userInsert;


            return response;
        }


        public async Task<bool> InsertContatoPersona(int idTipoContacto, string contacto, int idPersona)
        {
            ContactoPersonaEntity contactoPersona = new ContactoPersonaEntity()
            {
                IdPersona = idPersona,
                IdTipoContacto = idTipoContacto,
                Contacto = contacto,
            };

            _unitOfWork.ContactoPersonaRepository.Insert(contactoPersona);
            return await _unitOfWork.Save() > 0;
        }

        public bool IsUniqueIdentification(string identification)
        {
            var persona = _unitOfWork.PersonaRepository.FirstOrDefault(x => x.Identificacion == identification);
            return persona != null ? false : true;
        }

        public bool ValidarMaxContacto(int idTipoContacto, int idPersona)
        {
            var contactoPersona = _unitOfWork.ContactoPersonaRepository.FirstOrDefault(x => x.IdTipoContacto == idTipoContacto && x.IdPersona == idPersona);
            return contactoPersona != null ? false : true;
        }

        #endregion
    }
}
