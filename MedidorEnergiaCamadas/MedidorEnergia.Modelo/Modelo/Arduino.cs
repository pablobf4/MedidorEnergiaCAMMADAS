using MedidorEnergia.Identity.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.Modelo.Modelo
{
    public class Arduino
    {
        [Key]
        public int Id { get; set; }
        public string MacEndereco { get; set; }
        
        public virtual ApplicationUser Usuario { get; set; }
    }
}
