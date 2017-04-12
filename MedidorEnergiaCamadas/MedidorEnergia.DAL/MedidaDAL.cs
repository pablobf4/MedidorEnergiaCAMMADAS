using MedidorEnergia.DTO;
using MedidorEnergia.Modelo;
using MedidorEnergia.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.DAL
{
    public class MedidaDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public MedidaDTO ConverterParaDTO(Medida medida)
        {
            if (medida == null)
                return null;
            var medidaDTO = new MedidaDTO();
            medidaDTO.Id = medida.Id;
            medidaDTO.IDObjeto = medida.IDObjeto;
            medidaDTO.Potencia = medida.Potencia;
            medidaDTO.Horario = medida.Horario;
            medidaDTO.Corrente = medida.Corrente;

            return medidaDTO;
            
        }

        public Medida ConverterParaDAL(MedidaDTO medidaDTO) 
        {
            if (medidaDTO == null)
                return null;

            var medida = new Medida();
            medida.IDObjeto =  medidaDTO.IDObjeto;
            medida.Potencia =  medidaDTO.Potencia;
            medida.Horario  =  medidaDTO.Horario;
            medida.Corrente =  medidaDTO.Corrente;

            return medida;
        }
        public void Inserir(MedidaDTO medidaDTO) 
        {
            var  medida = ConverterParaDAL(medidaDTO);
            db.Medidas.Add(medida);
            db.SaveChanges();
        }
        public List<MedidaDTO> Lista() 
        {
            var resultado = new List<MedidaDTO>();
            var lista = db.Medidas.ToList();
            foreach (var t in lista )
            {
                resultado.Add(ConverterParaDTO(t));
            }
            return resultado;    

        }
        public MedidaDTO BuscaPorId(int id)
        {
            
            var medida = db.Medidas.Find(id);
            return ConverterParaDTO(medida);
        }

        public void Deletar(int id ) 
        {
            var medida = db.Medidas.Find(id);
            db.Medidas.Remove(medida);
            db.SaveChanges();
            
        }
        public void Atualizar(MedidaDTO medidaDTO) 
        {
            var medida = db.Medidas.Find(medidaDTO.Id);
            medida.IDObjeto =  medidaDTO.IDObjeto;
            medida.Potencia =  medidaDTO.Potencia;
            medida.Horario  =  medidaDTO.Horario;
            medida.Corrente =  medidaDTO.Corrente;
            db.Medidas.Attach(medida);
            db.Entry(medida).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }
        

       
    }
}
