using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedidorEnergia.Modelo.Modelo
{
    public class Medida
    {
        [Key]
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public float Potencia { get; set; }
        public float Corrente { get; set; }
        public virtual Objeto Objeto { get; set; }
       
        [ForeignKey("Objeto")]
        public int IDObjeto { get; set; }
    }
}