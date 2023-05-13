using Common.Utils.Enums;
using Infraestructure.Entity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion


        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();


            await CheckTipoContactoAsync();


        }


        private async Task CheckTipoContactoAsync()
        {
            if (!_context.TipoContactoEntity.Any())
            {
                _context.TipoContactoEntity.AddRange(new List<TipoContactoEntity>
                {
                    new TipoContactoEntity
                    {
                        IdTipoContacto = (int)Enums.TipoContacto.Email,
                        TipoContacto = "Email"
                    },
                    new TipoContactoEntity
                    {
                        IdTipoContacto = (int)Enums.TipoContacto.Email2,
                        TipoContacto = "Email 2"
                    },
                     new TipoContactoEntity
                    {
                         IdTipoContacto = (int)Enums.TipoContacto.Direccion,
                        TipoContacto = "Direccion"
                    },
                      new TipoContactoEntity
                    {
                        IdTipoContacto = (int)Enums.TipoContacto.Direccion2,
                        TipoContacto = "Direccion 2"
                    },
                        new TipoContactoEntity
                    {
                        IdTipoContacto = (int)Enums.TipoContacto.Telefono,
                        TipoContacto = "Telefono"
                    },  new TipoContactoEntity
                    {
                        IdTipoContacto = (int)Enums.TipoContacto.Telefono2,
                        TipoContacto = "Telefono 2"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }

}