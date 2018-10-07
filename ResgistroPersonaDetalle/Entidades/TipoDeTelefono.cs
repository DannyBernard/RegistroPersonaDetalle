using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResgistroPersonaDetalle.Entidades
{
    class TipoDeTelefono
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }

        public TipoDeTelefono()
        {
            Id = 0;
            Tipo = string.Empty;
        }
    }
}
