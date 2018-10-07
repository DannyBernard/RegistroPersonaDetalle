using ResgistroPersonaDetalle.BLL;
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

namespace ResgistroPersonaDetalle.UI
{
    public partial class TipoTelefonoNuevo : Form
    {
        public TipoTelefonoNuevo()
        {
            InitializeComponent();
        }

        private TipoDeTelefono LlenaClase()
        {
            TipoDeTelefono tipo = new TipoDeTelefono();
              tipo.Id = Convert.ToInt32(IDnumericUpDown.Value);
              tipo.Tipo = TipotextBox.Text;


            return tipo; 
        }

        private void LlenaCampo(TipoDeTelefono tipo)
        {
            IDnumericUpDown.Value = tipo.Id;
            TipotextBox.Text = tipo.Tipo;
            

            
        }
       

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(TipotextBox.Text))
            {
                errorProvider1.SetError(TipotextBox, "Campo esta vacio");
                paso = false;
            }
          
            return paso;
        }

       
    

        private void Guardarbutton_Click_1(object sender, EventArgs e)
        {
            bool paso = false;
            TipoDeTelefono tipo;
            if (!Validar())
                return;
            tipo = LlenaClase();

            if (IDnumericUpDown.Value == 0)
                paso = TipoBLL.Guardar(tipo);


            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
    }
