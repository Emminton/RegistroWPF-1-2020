using Microsoft.EntityFrameworkCore;
using RegistroWpfApp.DAL;
using RegistroWpfApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroWpfApp.BLL
{
    public class InscripcionBLL
    {
        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Inscripcion.Add(inscripcion) != null)
                    paso = (db.SaveChanges() > 0 && AfectarBalanceEstudiante(inscripcion));
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (inscripcion.Pago > 0)
                {
                    db.Entry(inscripcion).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0 && AfectarBalanceEstudianteAlModificar(inscripcion));
                }
                else
                {
                    db.Entry(inscripcion).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }
            }
            
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }
        public static bool Eliminar(int id, int estudianteId )
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Inscripcion.Find(id).InscripcionBalance = 0;
                var Eliminar = db.Estudiante.Find(estudianteId).EstudianteBalance = 0;

                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Inscripciones Buscar(int id)
        {
            Contexto db = new Contexto();
            Inscripciones inscripcion = new Inscripciones();
            try
            {
                inscripcion = db.Inscripcion.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return inscripcion;
        }
        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripcion)
        {
            List<Inscripciones> lista = new List<Inscripciones>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Inscripcion.Where(inscripcion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
        //este metodo refleja el Balance en la tabla de el estudiante
        private static bool AfectarBalanceEstudiante(Inscripciones inscripcion)
        {
            bool paso = false; 
             Contexto db = new Contexto();
            try
            {
                db.Estudiante.Find(inscripcion.EstudianteId).EstudianteBalance += inscripcion.InscripcionBalance;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool AfectarBalanceEstudianteAlModificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Estudiante.Find(inscripcion.EstudianteId).EstudianteBalance -= inscripcion.Pago;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
    }
}
