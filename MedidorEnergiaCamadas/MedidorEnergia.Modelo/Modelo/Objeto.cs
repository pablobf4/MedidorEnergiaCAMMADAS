using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedidorEnergia.Modelo.Modelo
{
    public class Objeto 
    {
       [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Medida> Medidas { get; set; }

        public virtual Arduino Arduino { get; set; }
    
        public bool Ativo { get; set; }

     }
}
