using MedidorEnergia.Modelo.EntityConfig;
using MedidorEnergia.Modelo.Modelo;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.Modelo
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext()
            : base("Contexto")
        {
        }
        public DbSet<Medida> Medidas { get; set; }
        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }

        static ApplicationDbContext()
        {
               
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}

