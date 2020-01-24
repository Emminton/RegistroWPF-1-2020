using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroWpfApp.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string  Nombre { get; set; }
        public string  Telefono{ get; set; }
        public string Celular { get; set; }
        public string  Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona(int personaId, string nombre, string telefono, string celular, string direccion, DateTime fechaNacimiento)
        {
            PersonaId = personaId;
            Nombre = nombre;
            Telefono = telefono;
            Celular = celular;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
