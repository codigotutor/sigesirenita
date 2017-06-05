using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{


    [Table("Prestamos")]
    public class Prestamo
    {

        public int Id { get; set; }
        [Required]
        public Tipo? Tipo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }


        public int RecursoId { get; set; }
        public int AmbienteId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Recurso Recurso { get; set; }
        public virtual Ambiente Ambiente { get; set; }
        //guardar el id del usuario al que se le presto
        //luego en el reporte se mostrara que se ingreso.
        //no se haria eliminar usuario, modificar usuario, solo creacion
        //se puede cambiar contraseña, se puede listar todos los usuarios
        //y mostrar sus prestamos.
        public virtual Usuario Usuario { get; set; }



    }
}