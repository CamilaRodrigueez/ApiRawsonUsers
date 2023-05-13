using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        #region Attributes
        private readonly DataContext _context;
        private bool disposed = false;
        #endregion Attributes

        #region builder
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        #endregion builder

        #region Properties
        private IRepository<PersonaEntity> personaRepository;
        private IRepository<TipoContactoEntity> tipoContactoRepository;
        private IRepository<ContactoPersonaEntity> contactoPersonaRepository;
        
        #endregion


        #region Members
        public IRepository<PersonaEntity> PersonaRepository
        {
            get
            {
                if (this.personaRepository == null)
                    this.personaRepository = new Repository<PersonaEntity>(_context);

                return personaRepository;
            }
        }
        public IRepository<TipoContactoEntity> TipoContactoRepository
        {
            get
            {
                if (this.tipoContactoRepository == null)
                    this.tipoContactoRepository = new Repository<TipoContactoEntity>(_context);

                return tipoContactoRepository;
            }
        }
        public IRepository<ContactoPersonaEntity> ContactoPersonaRepository
        {
            get
            {
                if (this.contactoPersonaRepository == null)
                    this.contactoPersonaRepository = new Repository<ContactoPersonaEntity>(_context);

                return contactoPersonaRepository;
            }
        }

       
        #endregion

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
        //public int SavE() => _context.SaveChanges();
    }
}
