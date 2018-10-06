using System.ComponentModel.DataAnnotations;

namespace ResgistroPersonaDetalle.Entidades
{
    public class TelefonoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PersonaID { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        public TelefonoDetalle(int Id, int PersonaID, string Telefono, string TipoTelefono)
        {
            Id = 0;
            PersonaID = 0;
            TipoTelefono = string.Empty;
            Telefono = string.Empty;
        }
    }
}