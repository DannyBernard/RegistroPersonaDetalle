﻿using ResgistroPersonaDetalle.DAL;
using ResgistroPersonaDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                foreach (var item in persona.Telefonos)
                {
                    if (!persona.Telefonos.Exists(d => d.Id = item.Id))
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
    

        }
    }
