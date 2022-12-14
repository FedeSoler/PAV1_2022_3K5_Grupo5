using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using El_Sabroso_App.CapaEntidades;
using El_Sabroso_App.CapaDatos;
using El_Sabroso_App.CapaPresentacion;
using El_Sabroso_App.CapaPresentacion.abmPro;

namespace El_Sabroso_App.CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void FrmPrincipal_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmLogin Login = new frmLogin();
            Login.ShowDialog();
            lblUsuario.Text = "Usuario: " + Login.retornarNombre();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAltaProducto(1, new Producto()).ShowDialog();
            
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarProductos consulta = new FrmConsultarProductos();
            consulta.ShowDialog();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas Venta = new FrmVentas();
            Venta.ShowDialog();
        }

        private void nuevaVentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVentas Venta = new FrmVentas();
            Venta.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaPro ventana = new frmConsultaPro();
            ventana.ShowDialog();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAltaPro alta = new frmAltaPro();
            alta.ShowDialog();
        }
    }
}
