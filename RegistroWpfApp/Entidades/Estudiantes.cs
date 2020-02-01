using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.OData.Edm;

namespace RegistroWpfApp.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
       // public decimal Balance { get; set; }

        public Estudiantes()
        {

        }

        public Estudiantes(int estudianteId, string nombre, string telefono, string cedula, string direccion, DateTime fechaNacimiento, decimal balance)
        {
            EstudianteId = estudianteId;
            Nombre = nombre;
            Telefono = telefono;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
           // Balance = balance;
        }
    }
}