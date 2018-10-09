using ResgistroPersonaDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ResgistroPersonaDetalle.DAL;
using ResgistroPersonaDetalle.BLL;

namespace ResgistroPersonaDetalle.UI
{
   public partial class RPersonaDetalle : Form
    {
        public List<TelefonoDetalle> detalle { get; set; }
        public RPersonaDetalle()
        {
            InitializeComponent();
            this.detalle = new List<TelefonoDetalle>();
            LlenarComboBOx();
        }
      private void LlenarComboBOx()
        {
            TipocomboBox.DataSource = TipoBLL.GetList(x => true);
           // TipocomboBox.ValueMember = "Id";
            TipocomboBox.ValueMember = "Tipo";
        }
        private void Limpiar()
        {
            errorProvider1.Clear();
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            FNacimientodateTimePicker.Value = DateTime.Now;

            this.detalle = new List<TelefonoDetalle>();
            CargarGrid();

        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaID = Convert.ToInt32(IDnumericUpDown.Value);
            persona.Nombre = NombretextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Direccion = DirecciontextBox.Text;
            persona.FechaNacmineto = FNacimientodateTimePicker.Value;

            persona.telefonos = this.detalle;

            return persona;
        }

        private void LlenaCampo(Persona persona)
        {
            IDnumericUpDown.Value = persona.PersonaID;
            NombretextBox.Text = persona.Nombre;
            CedulamaskedTextBox.Text = persona.Cedula;
            DirecciontextBox.Text = persona.Direccion;
            FNacimientodateTimePicker.Value = persona.FechaNacmineto;

           this.detalle = persona.telefonos;
            CargarGrid();
        }
        private void CargarGrid()
        {
            TelefonosdataGridView.DataSource = null;
            TelefonosdataGridView.DataSource = this.detalle;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();
            if(string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Campo esta vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider1.SetError(DirecciontextBox, "Campo esta vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider1.SetError(CedulamaskedTextBox, "Campo esta vacio");
            }
            if (this.detalle.Count == 0)
            {
                errorProvider1.SetError(TelefonosdataGridView, "Debe Agregar algun telefono");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            RPersonaDetalle rPersona = new RPersonaDetalle();

            if(TelefonosdataGridView.DataSource != null)
            
                this.detalle = (List<TelefonoDetalle>)TelefonosdataGridView.DataSource;

                this.detalle.Add(
                    new TelefonoDetalle(
                         Id : 0,
                         PersonaID: (int)IDnumericUpDown.Value,
                        Telefono: TelefonomaskedTextBox.Text,
                        TipoTelefono : TipocomboBox.Text
                        )
                        );
                  CargarGrid();
                TelefonomaskedTextBox.Focus();
                TelefonomaskedTextBox.Clear();
                
            
        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            if (TelefonosdataGridView.Rows.Count > 0 && TelefonosdataGridView.CurrentRow != null)
            {
                detalle.RemoveAt(TelefonosdataGridView.CurrentRow.Index);

                CargarGrid();

            }
        }
        private bool ExiteEnLaBaseDeDatos()
        {
            Persona persona = PersonasBLL.Buscar((int)IDnumericUpDown.Value);
            return (persona != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Persona persona;
            if (!Validar())
                return;
            persona = LlenaClase();

            if (IDnumericUpDown.Value == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExiteEnLaBaseDeDatos())
                {
                    MessageBox.Show("Nose puede Modificar No Exite", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }
            Limpiar();

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
          
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int id;

            int.TryParse(IDnumericUpDown.Text, out id);

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
            }
            else
                errorProvider1.SetError(IDnumericUpDown, "Persona no Exite");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int id;
            Persona persona = new Persona();
            int.TryParse(IDnumericUpDown.Text, out id);

            persona = PersonasBLL.Buscar(id);

            if(persona != null)
            {
                errorProvider1.Clear();
                this.LlenaCampo(persona);
                MessageBox.Show("Persona Encotrada");
             
            }
            else
            {
                MessageBox.Show("Persona no Encotrada");
            }
            
        }

        private void NuevoTipobutton_Click(object sender, EventArgs e)
        {
            TipoTelefonoNuevo tipo = new TipoTelefonoNuevo();
            tipo.ShowDialog();
            tipo.Close();
           

            }



        
    }
}