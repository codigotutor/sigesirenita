using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{
    [Table("Recursos")]
    public class Recurso
    {

        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public int Minimo { get; set; }
        [Required]
        public int Maximo { get; set; }


        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }



    }
}