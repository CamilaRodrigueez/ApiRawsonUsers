using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using System.Xml;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {

        IRepository<PersonaEntity> PersonaRepository { get; }
        IRepository<TipoContactoEntity> TipoContactoRepository { get; }
        IRepository<ContactoPersonaEntity> ContactoPersonaRepository { get; }
        
        void Dispose();

        Task<int> Save();
        //int SavE();



    }
}
