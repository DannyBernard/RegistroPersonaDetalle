using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ResgistroPersonaDetalle.Entidades;

namespace ResgistroPersonaDetalle.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
