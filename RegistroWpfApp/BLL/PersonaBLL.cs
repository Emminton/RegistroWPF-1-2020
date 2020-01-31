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
   public  class PersonaBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Persona.Add(persona) != null)
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
        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
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
                var eliminar = db.Persona.Find(id);
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
        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = db.Persona.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return persona;
        }
        public static List<Personas>GetLis(Expression<Func<Personas,bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
           Contexto db = new Contexto();
            try
            {
                lista = db.Persona.Where(persona).ToList(); 
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
