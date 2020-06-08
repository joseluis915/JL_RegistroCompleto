using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;///Agregar este using para que funcione el [Key]
using System.ComponentModel.DataAnnotations.Schema;

namespace JL_RegistroCompleto.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }/// prop + tab + tab (para insertar automatico)
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    }
}
