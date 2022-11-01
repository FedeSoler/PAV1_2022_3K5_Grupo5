using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Sabroso_App.CapaPresentacion
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            cargarComboCategoria();
            cargarComboProveedores();
            cargarComboProductos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarComboCategoria()
        {
            String consultaSql = string.Concat("" +
                "SELECT * from CATEGORIAS_PROD ");

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            comboCategoria.DataSource = resultado;
            comboCategoria.DisplayMember = "nombre";
            comboCategoria.ValueMember = "id_categoria";

        }

        private void cargarComboProveedores()
        {

            String consultaSql = string.Concat("" +
                "SELECT * from PROVEEDORES ");

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            comboProveedor.DataSource = resultado;
            comboProveedor.DisplayMember = "nombre";
            comboProveedor.ValueMember = "Id_proveedor";


        }
        private void cargarComboProductos()
        {

            String consultaSql = string.Concat("" +
                "SELECT * from PRODUCTOS ");

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            comboProducto.DataSource = resultado;
            comboProducto.DisplayMember = "nombre";
            comboProducto.ValueMember = "Id_Proveedor";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboProducto.Text.Trim() == "")
            {
                MessageBox.Show("Se debe ingresar un producto");
                return;
            }

            if (CantProd.Value == 0)
            {
                MessageBox.Show("Se debe ingresar una cantidad mayor a 0");
                return;
            }
        }
    }
}
