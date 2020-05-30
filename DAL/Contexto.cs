using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;///Para poder usar DbContext
using Tarea2_RegistroCompleto.Entidades;

namespace Tarea2_RegistroCompleto.DAL
{
    class Contexto : DbContext
    {
        public DbSet<DatosPersonales> DatosPersonales { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\BaseDeDatos.db");
        }
    }
}
