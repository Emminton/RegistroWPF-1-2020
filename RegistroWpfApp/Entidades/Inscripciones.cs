using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroWpfApp.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public string Comentario { get; set; }
        public decimal Pago { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        public Inscripciones()
        {

        }

        public Inscripciones(int inscripcionId, DateTime fecha, int estudianteId, string comentario, decimal pago, decimal monto,decimal balance)
        {
            InscripcionId = inscripcionId;
            Fecha = fecha;
            EstudianteId = estudianteId;
            Comentario = comentario;
            Pago = pago;
            Monto = monto;
            Balance = balance;
        }
    }
}
