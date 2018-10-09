using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResgistroPersonaDetalle.Entidades
{
   public class TelefonoDetalle
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        public TelefonoDetalle()
        {
            Id = 0;
            PersonaId = 0;
            TipoTelefono = string.Empty;
            Telefono = string.Empty;

        }
        public TelefonoDetalle(int Id,string TipoTelefono,string Telefono, int PersonaID)
        {
            this.Id = Id;
             this.PersonaId = PersonaID;
            this.TipoTelefono =TipoTelefono;
            this.Telefono =Telefono;

        }
    }
}
