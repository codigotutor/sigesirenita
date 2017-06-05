using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(120)]
        public string Correo { get; set; }
        public string Contraseña { get; set; }


        public int PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}