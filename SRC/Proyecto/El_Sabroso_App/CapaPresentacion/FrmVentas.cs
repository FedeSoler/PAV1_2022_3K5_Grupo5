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
            cargarProductoInicial();
            string productoSelect = comboProducto.SelectedText.ToString();
           
            
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
       private void cargarComboProductos(string productoSelect)
        {

          

            

            String consultasql2 =  
                "SELECT pr.Id_producto, pr.nombre, p.Id_proveedor,p.nombre" +
                " FROM PRODUCTOS pr" +
                " LEFT JOIN PROVEEDORES p" +
                " ON pr.id_proveedor = p.Id_proveedor" +
                " LEFT JOIN CATEGORIAS_PROD c" +
                " ON pr.id_categoria = c.id_categoria"+
                " WHERE pr.nombre = " + "'" + productoSelect + "'" 
                ;
            DataTable resultado2 = DataManager.GetInstance().ConsultaSQL(consultasql2);
            //carga proveedor
            comboProveedor.DataSource = resultado2;
            comboProveedor.DisplayMember = "nombre";
            comboProveedor.ValueMember = "Id_proveedor";
            //carga categoria
            //comboCategoria.DataSource = resultado2;
            //comboCategoria.DisplayMember = "c.nombre";
            //comboCategoria.ValueMember = "c.id_categoria";


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

            if (comboProveedor.Text.Trim() == "")
            {
                MessageBox.Show("Se debe elegir un proveedor");
                return ;
            }


        }

        private void cargarProductoInicial()
        {
            String consultaSql = string.Concat("" +
              "SELECT * from PRODUCTOS " +
              " ");

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            comboProducto.DataSource = resultado;
            comboProducto.DisplayMember = "nombre";
            comboProducto.ValueMember = "nombre";
            comboProducto.SelectedValue = "";
            
        }

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProducto.SelectedValue != null)
            {
                string productoSelect = comboProducto.SelectedValue.ToString();

                if (productoSelect != "" && productoSelect != "System.Data.DataRowView")
                {
                    cargarComboProductos(productoSelect);
                }
            }
            
        /*    if (productoSelect != "")
            {
                cargarComboProductos(productoSelect);
            }*/
        }
    }
}
