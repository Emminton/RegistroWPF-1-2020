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
   public  class EstudianteBLL
    {
        public static bool Guardar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Estudiante.Add(estudiante) != null)
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
        public static bool Modificar(Estudiantes estudiantes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiantes).State = EntityState.Modified;
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
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Estudiante.Find(id);
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
        public static Estudiantes Buscar(int id)
        {
            Contexto db = new Contexto();
            Estudiantes estudiante = new Estudiantes();
            try
            {
                estudiante = db.Estudiante.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return estudiante;
        }
        public static List<Estudiantes>GetLis(Expression<Func<Estudiantes,bool>> estudiante)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
           Contexto db = new Contexto();
            try
            {
                lista = db.Estudiante.Where(estudiante).ToList(); 
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
    }
}
