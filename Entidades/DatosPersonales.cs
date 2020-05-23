using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;///Agregar este using para que funcione el [Key]
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea2_RegistroCompleto.Entidades
{
    class DatosPersonales
    {
        [Key]
        public int DatosPersonalesId { get; set; }/// prop + tab + tab (para insertar automatico)
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        ///[ForeignKey("PersonaId")]
        ///public virtual DatosPersonales { get; set; }
    }
}
