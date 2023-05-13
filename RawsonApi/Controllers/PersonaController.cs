using Common.Utils.Recursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawsonApi.Domain.DTO;
using RawsonApi.Domain.Services.Interface;
using System.Net;
using static Common.Utils.Enums.Enums;

namespace RawsonApi.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        #region Attributes
        private readonly IPersonaServices _personaServices;
        private  IActionResult _response { get; set; }
        #endregion


        #region Builders
        public PersonaController(IPersonaServices personaServices)
        {
            _personaServices = personaServices;
        }
        #endregion
        /// <summary>
        /// Obtener Todas las personas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPersonas")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllPersonas()
        {
            List<PersonaDto> listaPersonas = _personaServices.GetAllPersonas();
            return Ok(listaPersonas);
        }
        /// <summary>
        /// Obtener todos los tipos de contactos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTipoContacto")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTipoContacto()
        {
            List<TipoContactoDto> listaTipoContactos = _personaServices.GetAllTipoContacto();
            return Ok(listaTipoContactos);
        }


        /// <summary>
        /// Servicio para insertar un usuario
        /// </summary>
        /// <param name="personaDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(201, Type = typeof(PersonaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] PersonaDto personaDto)
        {
            var usuario = await _personaServices.InsertUser(personaDto);
            if (!usuario.IsSuccess)
            {
                _response = BadRequest(usuario);
                return _response;
            }
            _response = Ok(usuario);
            return _response;
        }



        [HttpPost("InsertContactoPersona")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertContactoPersona([FromBody] InsertContactoPersonaDto personaDto)
        {
            ResponseDto responseDto = new ResponseDto();
            bool validarContactoMax = _personaServices.ValidarMaxContacto(personaDto.IdTipoContacto, personaDto.IdPersona);

            if (!validarContactoMax)
            {
                responseDto.IsSuccess = validarContactoMax;
                responseDto.Result = validarContactoMax;
                responseDto.Message = string.Format(GeneralMessages.ItemNoInsertContactoPersona, personaDto.IdTipoContacto);
                _response = BadRequest(responseDto);
                return _response;
            }
           
            await _personaServices.InsertContatoPersona(personaDto.IdTipoContacto, personaDto.Contacto, personaDto.IdPersona);
            responseDto.IsSuccess = validarContactoMax;
            responseDto.Result = validarContactoMax;
            responseDto.Message = GeneralMessages.ItemInsertContactoPersona;
            _response = Ok(responseDto);
            return _response;
        }
    }
}
