using ResgistroPersonaDetalle.DAL;
using ResgistroPersonaDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResgistroPersonaDetalle.BLL
{
   public class PersonasBLL
    {
        public static bool Guardar(Persona personas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Persona.Add(personas) != null)
                {
                    paso = db.SaveChanges() > 0;
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
        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
               persona = contexto.Persona.Find(persona.PersonaID);
                foreach (var item in persona.telefonos)
                {
                    if (!persona.telefonos.Exists(d => d.Id == item.Id))
                        contexto.Entry(item).State = EntityState.Deleted;
                }
                contexto.Entry(persona).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
   
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Persona persona = contexto.Persona.Find(id);
                contexto.Persona.Remove(persona);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }

            catch (Exception)
            {
                throw;
            }
        
            return paso;

        }
        public  static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona persona = new Persona();
            try
            {
                persona = contexto.Persona.Find(id);
               // persona.Telefonos.Count();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }
    
        public static List<Persona> GetList(Expression<Func<Persona,bool>> persona)
        {
            List<Persona> Lista = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Persona.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }


    

        }
    }

