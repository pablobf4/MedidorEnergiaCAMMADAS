using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.DTO
{
    public class MedidaDTO
    {
        public String NomeObjeto { get; set; }
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public float Potencia { get; set; }
        public float Corrente { get; set; }
        public int  IDObjeto { get; set; }


    }
}
