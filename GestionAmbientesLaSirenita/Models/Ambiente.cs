using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{
    [Table("Ambientes")]
    public class Ambiente
    {

       public int Id { get; set; }
       [Required]
       [StringLength(120)]
       public string Nombre { get; set; }
       [Required]
       public string Descripcion { get; set; }
       [Required]
       public int Ubicacion { get; set; }


       public virtual ICollection<Movimiento> Movimientos { get; set; }
       public virtual ICollection<Prestamo> Prestamos { get; set; }

    }
}