using Microsoft.EntityFrameworkCore;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= DESKTOP-Q0TL685; Database= TesTDb; Trusted_Conmection = True;");
            //aqui agregamo un string donde expesificar el servidor; la base de datos y el tipo de conexion
        }
    }
    
}
