using MedidorEnergia.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.Modelo.EntityConfig
{
    // essas configuraçãoes são para o entity entender que o usuario.cs é apenas uma represetanção de dominio do applicationUser.cs do identity para quando ele mapear não alterar nada
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);
            

            ToTable("AspNetUsers");
        }
    }
}
