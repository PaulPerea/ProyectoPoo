using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Proyecto.Models
{
    public class Alumno
    {
        [Display(Name = "ID"), Required] public int idAlumno { get; set; }
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }
        [Display(Name = "Apellido"), Required] public string apellido { get; set; }
        [Display(Name = "Dni"), Required] public string dni { get; set; }
        [Display(Name = "Correo"), Required] public string correo { get; set; }
        [Display(Name = "Direccion"), Required] public string direccion { get; set; }
        [Display(Name = "IDCurso"), Required] public int curso { get; set; }
        [Display(Name = "IDSede"), Required] public int sede { get; set; }

        public Alumno()
        {
        }

        public Alumno(int idAlumno, string nombre, string apellido, string dni, string correo, string direccion, int curso, int sede)
        {
            this.idAlumno = idAlumno;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
            this.direccion = direccion;
            this.curso = curso;
            this.sede = sede;
        }
    }
}