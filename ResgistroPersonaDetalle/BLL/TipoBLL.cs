using ResgistroPersonaDetalle.DAL;
using ResgistroPersonaDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        //public static List<TipoDeTelefono> TipoDeTelefono { get; private set; }

        public static List<TipoDeTelefono> GetList(Expression<Func<TipoDeTelefono, bool>> expression)
        {
            List<TipoDeTelefono> tipoDeTelefonos = new List<TipoDeTelefono>();
            Contexto contexto = new Contexto();

            try
            {
                tipoDeTelefonos = contexto.Tipo.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tipoDeTelefonos;
        }
    }
}
