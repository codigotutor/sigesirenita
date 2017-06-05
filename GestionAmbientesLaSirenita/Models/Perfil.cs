using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAmbientesLaSirenita.Models
{
    [Table("Perfiles")]
    public class Perfil
    {

        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }


        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}