using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroWpfApp.BLL;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.BLL.Tests
{
    [TestClass()]
    public class InscripcionBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {

            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            Estudiantes estudiantes = new Estudiantes();

            estudiantes = EstudianteBLL.Buscar(1);

            decimal BalanceInicial = estudiantes.EstudianteBalance;

            decimal BalanceEsperado = BalanceInicial + 3000;

            inscripciones.InscripcionId = 0;
            inscripciones.EstudianteId = 1;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.Comentario = "Usted lo hizo bien";
            inscripciones.Monto = 4000;
            inscripciones.InscripcionBalance = 1000;

            paso = InscripcionBLL.Guardar(inscripciones);

            decimal BalancePrueba = InscripcionBLL.Buscar(inscripciones.EstudianteId).InscripcionBalance;

            if (BalanceEsperado == BalancePrueba)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            Estudiantes p = new Estudiantes();

            p = EstudianteBLL.Buscar(1);

            decimal BalanceInicial = p.EstudianteBalance;

            decimal BalanceEsperado = BalanceInicial - 1000;

            inscripciones.InscripcionId = 1;
            inscripciones.EstudianteId = 1;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.Comentario = "El paso se realizo con Exito";
            inscripciones.Monto = 3000;
            inscripciones.InscripcionBalance = 1000;

            paso = InscripcionBLL.Modificar(inscripciones);

            decimal BalancePrueba = InscripcionBLL.Buscar(inscripciones.EstudianteId).InscripcionBalance;

            if (BalanceEsperado == BalancePrueba)
                paso = true;
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;

            Inscripciones inscripciones = new Inscripciones();
            Estudiantes estudiantes;
            Inscripciones i;

            decimal BalanceEsperado = 0;

            paso = InscripcionBLL.Eliminar(1, 1);
            estudiantes = EstudianteBLL.Buscar(1);
            i = InscripcionBLL.Buscar(1);

            if (i.InscripcionBalance == BalanceEsperado && estudiantes.EstudianteBalance == BalanceEsperado)
                paso = true;


            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscr;
            inscr = InscripcionBLL.Buscar(1);
            Assert.AreEqual(inscr, inscr);
        }
        

        [TestMethod()]
        public void GetLisTest()
        {
            var  listado = new List<Inscripciones>();
            listado = InscripcionBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}