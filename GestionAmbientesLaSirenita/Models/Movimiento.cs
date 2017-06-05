using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{


    [Table("Movimientos")]
    public class Movimiento
    {

        public int Id { get; set; }
        [Required]
        public Tipo? Tipo { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public int RecursoId { get; set; }
        public int AmbienteId { get; set; }

        public virtual Recurso Recurso { get; set; }
        public virtual Ambiente Ambiente { get; set; }


    }
}