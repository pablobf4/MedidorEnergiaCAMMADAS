using MedidorEnergia.Modelo;
using MedidorEnergia.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorEnergia.DTO;

namespace MedidorEnergia.DAL
{
    public class UsuarioDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UsuarioDTO ConverterParaDTO(Usuario usuario)
        {
            if (usuario == null)
                return null;
            var usuarioDTO = new UsuarioDTO();
            usuarioDTO.Id = usuario.Id;
            usuarioDTO.Email = usuario.Email;
            usuarioDTO.EmailConfirmed = usuario.EmailConfirmed;
            usuarioDTO.PasswordHash = usuario.PasswordHash;
            usuarioDTO.SecurityStamp = usuario.SecurityStamp;
            usuarioDTO.PhoneNumber = usuario.PhoneNumber;
            usuarioDTO.PhoneNumberConfirmed = usuario.PhoneNumberConfirmed;
            usuarioDTO.TwoFactorEnabled = usuario.TwoFactorEnabled;
            usuarioDTO.LockoutEndDateUtc = usuario.LockoutEndDateUtc;
            usuarioDTO.LockoutEnabled = usuario.LockoutEnabled;
            usuarioDTO.AccessFailedCount = usuario.AccessFailedCount;
            usuarioDTO.UserName = usuario.UserName;
            return usuarioDTO;


        }
        public Usuario ConverterParaDAL(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return null;
            var usuario = new Usuario();
            usuario.Id = usuarioDTO.Id;
            usuario.Email = usuarioDTO.Email;
            usuario.EmailConfirmed = usuarioDTO.EmailConfirmed;
            usuario.PasswordHash = usuarioDTO.PasswordHash;
            usuario.SecurityStamp = usuarioDTO.SecurityStamp;
            usuario.PhoneNumber = usuarioDTO.PhoneNumber;
            usuario.PhoneNumberConfirmed = usuarioDTO.PhoneNumberConfirmed;
            usuario.TwoFactorEnabled = usuarioDTO.TwoFactorEnabled;
            usuario.LockoutEndDateUtc = usuarioDTO.LockoutEndDateUtc;
            usuario.LockoutEnabled = usuarioDTO.LockoutEnabled;
            usuario.AccessFailedCount = usuarioDTO.AccessFailedCount;
            usuario.UserName = usuarioDTO.UserName;
            return usuario;
        }
        public void Inserir(UsuarioDTO usuarioDTO)
        {
            var usuario = ConverterParaDAL(usuarioDTO);
            db.Usuario.Add(usuario);
            db.SaveChanges();
        }
        public List<UsuarioDTO> Lista()
        {
            var resultado = new List<UsuarioDTO>();
            var lista = db.Usuario.ToList();
            foreach (var t in lista)
            {
                resultado.Add(ConverterParaDTO(t));
            }
            return resultado;
        }
        public UsuarioDTO BuscarPorId(int id)
        {
            var usuario = db.Usuario.Find(id);
            return ConverterParaDTO(usuario);
        }
        public void Deletar(int id)
        {
            var usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
        }
        public void Atualizar(UsuarioDTO usuarioDTO)
        {
            var usuario = db.Usuario.Find(usuarioDTO.Id);
            usuario.Id = usuarioDTO.Id;
            usuario.Email = usuarioDTO.Email;
            usuario.EmailConfirmed = usuarioDTO.EmailConfirmed;
            usuario.PasswordHash = usuarioDTO.PasswordHash;
            usuario.SecurityStamp = usuarioDTO.SecurityStamp;
            usuario.PhoneNumber = usuarioDTO.PhoneNumber;
            usuario.PhoneNumberConfirmed = usuarioDTO.PhoneNumberConfirmed;
            usuario.TwoFactorEnabled = usuarioDTO.TwoFactorEnabled;
            usuario.LockoutEndDateUtc = usuarioDTO.LockoutEndDateUtc;
            usuario.LockoutEnabled = usuarioDTO.LockoutEnabled;
            usuario.AccessFailedCount = usuarioDTO.AccessFailedCount;
            usuario.UserName = usuarioDTO.UserName;
            db.Usuario.Attach(usuario);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }


}

