using Microsoft.EntityFrameworkCore;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optiondBilder)
        {
            optiondBilder.UseSqlServer(@"Server =DESKTOP-Q0TL685; Database = PersonaDb;Trusted_Connection = True; ");
        }
    }
}
