using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroWpfApp.BLL;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroWpfApp.BLL.Tests
{
    [TestClass()]
    public class EstudianteBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.EstudianteId = 0;
            estudiantes.Nombre = "Emminton Manuel Ureña Santana ";
            estudiantes.Telefono = "8090888";
            estudiantes.Cedula = "056";
            estudiantes.Direccion = "calle nosotros";
            estudiantes.FechaNacimiento = DateTime.Now;
            paso = EstudianteBLL.Guardar(estudiantes);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.EstudianteId = 2;
            estudiantes.Nombre = "Emminton Manuel Ureña Santana ";
            estudiantes.Telefono = "8090888";
            estudiantes.Cedula = "056";
            estudiantes.Direccion = "calle nosotros";
            estudiantes.FechaNacimiento = DateTime.Now;
            paso = EstudianteBLL.Modificar(estudiantes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = EstudianteBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Estudiantes estudiantes;
            estudiantes = EstudianteBLL.Buscar(2);

            Assert.AreEqual(estudiantes, estudiantes);
        }

        [TestMethod()]
        public void GetLisTest()
        {
            var listado = new List<Estudiantes>();
            listado = EstudianteBLL.GetLis(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}