using Microsoft.EntityFrameworkCore;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona>Personas { get; set; }

        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SqlExpress; Database= TesTDb; Trusted_Conmection = Tru;");
            //aqui agregamo un string donde expesificar el servidor; la base de datos y el tipo de conexion
        }
    }
    
}
