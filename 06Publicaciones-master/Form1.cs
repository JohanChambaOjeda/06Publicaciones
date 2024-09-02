using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.Views;
namespace _06Publicaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General _General = new General();
            _General.Show();
            this.Hide();
            /*
            //admin=> usuarios   
                      lectores / puerto com6 => garita
                      lectores / puerto com6 => bodega

            //garita
            //bodega
            //envios

            base datos
            usuarios
            roles
            productos
            categoriaproductos
            vehiculos
            cliente
            conductorvehiculo
            stock
            ordendespacho
            lectores
            departamento =->bodega
                            garita
                            despachos

            */
        }
    }
}
