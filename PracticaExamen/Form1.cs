using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DO;

namespace PracticaExamen
{
    public partial class Form1 : Form
    {

        #region Atributos
        private Persona persona;
        #endregion

       


        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTabla_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTabla.SelectedRows)
            {
                int value1 = Convert.ToInt32(row.Cells[0].Value.ToString());
                string value2 = row.Cells[1].Value.ToString();
                string value3 = row.Cells[2].Value.ToString();
                //bool value3 = Convert.ToBoolean(row.Cells[2].Value.ToString());
                //DateTime value4 = Convert.ToDateTime(row.Cells[3].Value.ToString());
                string value4 = row.Cells[3].Value.ToString();
                decimal value5 = Convert.ToDecimal(row.Cells[4].Value.ToString());
                bool value6 = Convert.ToBoolean(row.Cells[5].Value.ToString());
                

                txtID.Text = value1.ToString();
                txtNombre.Text = value2;
                cGenero.Text = value3.ToString();
                cCategoria.Text = value4;
                txt_Valor.Text = value5.ToString();
                cbDisponible.Checked = value6;

                if (cGenero.Text == "Masculino")
                {
                    txtGenero.Text = 0.ToString();

                }
                else
                {
                    txtGenero.Text = 1.ToString();

                }


            }
        }

        #region Metodos

        private void cargarPersona()
        {

            persona = new Persona();

         
            persona.IId = Convert.ToInt32(txtID.Text);
            persona.VNombre = txtNombre.Text;
            //persona.IGenero = cGenero.Text;
            persona.IGenero = txtGenero.Text;
            persona.VCategoria = cCategoria.Text;
            persona.IValor = Convert.ToInt32(txt_Valor.Text);
            persona.BDisponible = cbDisponible.Checked;
        }

        private void mostrarGrid()
        {
            try
            {
                dgvTabla.DataSource = BS.Mantenimiento.Instancia.Mostrar();
            }
            catch (Exception ee)
            {

                throw;
            }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Insertar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {

                throw;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cGenero_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cGenero.Text == "Masculino")
            {
                txtGenero.Text = 0.ToString();

            }
            else
            {
                txtGenero.Text = 1.ToString();

            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Actualizar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {

                throw;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Borrar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {

                throw;
            }
        }
    }

}
