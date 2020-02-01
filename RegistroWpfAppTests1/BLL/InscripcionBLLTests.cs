﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Inscripciones i = new Inscripciones();

            i.InscripcionId = 0;
            i.Fecha = DateTime.Now;
            i.EstudianteId = 0;
            i.Comentario = "hola comos estan.";
            i.Pago = 12334; ;
            i.Monto = 234;
            paso = InscripcionBLL.Guardar(i);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones i = new Inscripciones();

            i.InscripcionId = 2;
            i.Fecha = DateTime.Now;
            i.EstudianteId = 0;
            i.Comentario = "hola comos estan.";
            i.Pago = 12334; ;
            i.Monto = 234;
            paso = InscripcionBLL.Modificar(i);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscr;
            inscr = InscripcionBLL.Buscar(2);
            Assert.AreEqual(inscr, inscr);
        }

        [TestMethod()]
        public void GetLisTest()
        {
            var  listado = new List<Inscripciones>();
            listado = InscripcionBLL.GetLis(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}