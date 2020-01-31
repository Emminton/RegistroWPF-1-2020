using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.OData.Edm;

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
        public double Inscripcion { get; set; }
        public double Pago { get; set; }
        public double Balance { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = Date.Now;
            Inscripcion = 0;
            Pago = 0;
            Balance = 0;
        }
    }
}