using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;///Agregar este using para que funcione el [Key]
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea2_RegistroCompleto.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }/// prop + tab + tab (para insertar automatico)
        public string PersonaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }

        ///[ForeignKey("PersonaId")]
        ///public virtual DatosPersonales { get; set; }
    }
}
