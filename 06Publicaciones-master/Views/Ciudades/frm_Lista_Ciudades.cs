using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.config;
using _06Publicaciones.Controllers;
namespace _06Publicaciones.Views.Ciudades
{
    public partial class frm_Lista_Ciudades : Form
    {
        CiudadesController _ciudadesController = new CiudadesController();
        public frm_Lista_Ciudades()
        {
            InitializeComponent();
        }

        private void frm_Lista_Ciudades_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pubsDataSet.Paises' Puede moverla o quitarla según sea necesario.
            //this.paisesTableAdapter.Fill(this.pubsDataSet.Paises);
            // TODO: esta línea de código carga datos en la tabla 'pubsDataSet.Ciudades' Puede moverla o quitarla según sea necesario.
            //this.ciudadesTableAdapter.Fill(this.pubsDataSet.Ciudades);

            dgvCiudades.DataSource = _ciudadesController.todosconrelacion();
            /*dgvCiudades.Columns["Ciudad"].Visible = true;
            dgvCiudades.Columns["IdCiudad"].Visible = false;
            dgvCiudades.Columns["Pais"].Visible = true;
            dgvCiudades.Columns["IdPais"].Visible = false;*/

            dgvCiudades.Columns[0].Visible = false;
            dgvCiudades.Columns[1].Visible = true;
            dgvCiudades.Columns[2].Visible = false;
            dgvCiudades.Columns[3].Visible = true;

            // Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Paises.IdPais, Paises.Detalle AS 'Pais' FROM Ciudades 

            DataGridViewButtonColumn btnGrid = new DataGridViewButtonColumn();
            btnGrid.HeaderText = "Editar";
            btnGrid.Name = "Editar";
            btnGrid.Text = "Editar";
            btnGrid.UseColumnTextForButtonValue = true;
            dgvCiudades.Columns.Add(btnGrid);




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            MessageBox.Show(id);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCiudades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCiudades.Columns["Editar"].Index && e.RowIndex >= 0) {
                var id = dgvCiudades.Rows[e.RowIndex].Cells["IdCiudad"].Value.ToString();
                //MessageBox.Show(id);
                frm_Ciudades _Ciudades = new frm_Ciudades(id);
                _Ciudades.Show();
            }
        }
    }
}
