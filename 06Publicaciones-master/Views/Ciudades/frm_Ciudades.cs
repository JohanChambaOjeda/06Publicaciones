using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.config;
using _06Publicaciones.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _06Publicaciones.Views.Ciudades
{
    public partial class frm_Ciudades : Form
    {
        private string id;

        public frm_Ciudades(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void frm_Ciudades_Load(object sender, EventArgs e)
        {
            // Cargar los países en el comboBox
            PaisesController _paises = new PaisesController();
            comboBox1.DataSource = _paises.todos();
            comboBox1.DisplayMember = "Detalle";
            comboBox1.ValueMember = "IdPais";

            // Cargar la ciudad en el formulario
            CargarCiudad();
        }

        private void CargarCiudad()
        {
            CiudadesController _ciudadesController = new CiudadesController();
            DataTable dtCiudad = _ciudadesController.ObtenerCiudadPorId(int.Parse(this.id));
            if (dtCiudad.Rows.Count > 0)
            {
                DataRow row = dtCiudad.Rows[0];
                textBox1.Text = row["Ciudad"].ToString();
                comboBox1.SelectedValue = row["IdPais"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Obtener datos
            string detalle = textBox1.Text;
            int idPais = (int)comboBox1.SelectedValue;

            // Llamar al controlador para actualizar la ciudad
            CiudadesController controller = new CiudadesController();
            bool exito = controller.ActualizarCiudad(int.Parse(this.id), detalle, idPais);

            if (exito)
            {
                MessageBox.Show("Ciudad actualizada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la ciudad.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Cancelar y cerrar el formulario
        }
    }
}