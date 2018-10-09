using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResgistroPersonaDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResgistroPersonaDetalle.Entidades;

namespace ResgistroPersonaDetalle.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Persona personas = new Persona();
            personas.PersonaID = 0;
            personas.Nombre = "danny";
            personas.Cedula = "056-008965";
            personas.Direccion = "Livertad";
            personas.FechaNacmineto = DateTime.Now;
            paso = PersonasBLL.Guardar(personas);
          
           // personas.Telefonos = new List<TelefonoDetalle>();
            Assert.Fail();
        }
    }
}