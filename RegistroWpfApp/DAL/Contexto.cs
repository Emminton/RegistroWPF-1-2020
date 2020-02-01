using Microsoft.EntityFrameworkCore;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Inscripciones> Inscripcion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optiondBilder)
        {
            optiondBilder.UseSqlServer(@"Server =.\SqlExpress; Database = EstudianteDb;Trusted_Connection = True; ");
        }
    }
}
