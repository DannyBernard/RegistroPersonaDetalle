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
    class TelefonoBll
    {
        public static List<TipoDeTelefono> TipoDeTelefono { get; private set; }

        public static List<TipoDeTelefono> GetList(Expression<Func<TipoDeTelefono, bool>> expression)
        {
            List<TelefonoDetalle> telefonoDetalles = new List<TelefonoDetalle>();
            Contexto contexto = new Contexto();

            try
            {
             TipoDeTelefono= contexto.Tipo.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return TipoDeTelefono;
        }

    }
}
