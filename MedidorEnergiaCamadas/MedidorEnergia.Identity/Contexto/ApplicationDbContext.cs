using MedidorEnergia.Identity.Modelo;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.Identity.Contexto
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IDisposable
    {
        public ApplicationDbContext()
            : base("Contexto", throwIfV1Schema:false)
        
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
       