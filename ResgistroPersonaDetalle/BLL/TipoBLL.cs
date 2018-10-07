using ResgistroPersonaDetalle.DAL;
using ResgistroPersonaDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResgistroPersonaDetalle.BLL
{
    class TipoBLL
    {
        public static bool Guardar(TipoDeTelefono tipo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Tipo.Add(tipo) != null)
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
    }
}
