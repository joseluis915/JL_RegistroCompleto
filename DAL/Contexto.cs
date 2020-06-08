﻿using System;
using System.Collections.Generic;
using System.Text;
//No olvidar Agregar los siguientes [using].
using JL_RegistroCompleto.Entidades; //Este using permite usar las clases de [Entidades]. (Nombre de la clase.Entidades)
using Microsoft.EntityFrameworkCore; //Este using permite usar [DbContext].

namespace JL_RegistroCompleto.DAL
{
    //Programar la clase para la base de datos.
    public class Contexto : DbContext  //No olvidar agregarle [public] a la clase
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; } //Esta es la que usaremos en este ejemplo.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\BaseDeDatos.db");
        }
    }
}
