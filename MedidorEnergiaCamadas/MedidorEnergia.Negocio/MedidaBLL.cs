using MedidorEnergia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorEnergia.DAL;

namespace MedidorEnergia.BLL
{
    public class MedidaBLL
    {
        

        public void Inserir(MedidaDTO medida) 
        {
            MedidaDAL medidaObj = new MedidaDAL();
            medidaObj.Inserir(medida);
        }

        public List<MedidaDTO> Lista()
        {
            MedidaDAL medidaObj = new MedidaDAL();
            return medidaObj.Lista();
        }

        public MedidaDTO BuscaPorId(int id) 
        {
            MedidaDAL medidaObj = new MedidaDAL();
            return medidaObj.BuscaPorId(id);
        }
    }
}
