using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Infraestructure.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<PersonaEntity> PersonaEntity { get; set; }
        public DbSet<TipoContactoEntity> TipoContactoEntity { get; set; }
        public DbSet<ContactoPersonaEntity> ContactoPersonaEntity { get; set; }
      
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaEntity>()
               .HasIndex(b => b.Identificacion)
               .IsUnique()
               .HasName("Index_Identificacion");

            modelBuilder.Entity<ContactoPersonaEntity>()
                   .HasIndex(b => new { b.IdTipoContacto, b.IdPersona })
                   .IsUnique();

            modelBuilder.Entity<TipoContactoEntity>().Property(t => t.IdTipoContacto).ValueGeneratedNever();
        }
    }
}
