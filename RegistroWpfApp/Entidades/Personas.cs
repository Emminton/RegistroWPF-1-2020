using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroWpfApp.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Personas(int personaId, string nombre, string telefono, string celular, string direccion, DateTime fechaNacimiento)
        {
            PersonaId = personaId;
            Nombre = nombre;
            Telefono = telefono;
            Cedula = celular;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
        }
    }
}