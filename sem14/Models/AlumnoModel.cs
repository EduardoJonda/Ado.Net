using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sem14.Models
{
    public class AlumnoModel
    {
        [Display(Name = "Codigo")]
        public string codalu { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre Requerido")]
        public string nomalu { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Correo Requerido")]
        public string email { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Telefono Requerido")]
        public string telefono { get; set; }

        [Display(Name = "Carrera")]
        public int codcar { get; set; }

        [Display(Name = "Fecha de inscripcion")]
        public DateTime fecha_ins { get; set; }

        [Display(Name = "Estado")]
        public int estado { get; set; }

        [Display(Name = "Foto")]
        public string Fotoalu { get; set; }
    }
}