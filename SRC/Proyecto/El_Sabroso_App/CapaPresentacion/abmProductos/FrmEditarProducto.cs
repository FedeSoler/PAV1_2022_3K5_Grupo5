using El_Sabroso_App.CapaEntidades;
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

namespace El_Sabroso_App.CapaPresentacion.abmProductos
{
    public partial class frmEditarProducto : Form
    {
        public frmEditarProducto()
        {
            InitializeComponent();
        }

        internal void incializar(Producto producto, string nombreProv, string nombreCat)
        {
            txtId.Text = producto.IdProducto.ToString();
            txtDescripcion.Text = producto.Descripcion.ToString();
            txtNombre.Text = producto.Nombre.ToString();
            txtPrecio.Text = producto.Precio.ToString();
            cboCategoria.Text = nombreCat;
            cboProveedor.Text = nombreProv;
        }

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            //cargar combo proveedores
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT Id_proveedor,nombre FROM PROVEEDORES";
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                cboProveedor.DataSource = tabla;
                cboProveedor.DisplayMember = "nombre";
                cboProveedor.ValueMember = "Id_proveedor";

            }
            catch (Exception)
            {

                throw;
            }

            //llenar combo categoria
            string cadenaConexion1 = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn1 = new SqlConnection(cadenaConexion1);
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                string consulta1 = "SELECT id_categoria,nombre FROM CATEGORIAS_PROD";
                cmd1.Parameters.Clear();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = consulta1;

                cn1.Open();
                cmd1.Connection = cn1;
                cmd1.ExecuteNonQuery();
                DataTable tabla1 = new DataTable();

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(tabla1);

                cboCategoria.DataSource = tabla1;
                cboCategoria.DisplayMember = "nombre";
                cboCategoria.ValueMember = "id_categoria";

            }
            catch (Exception)   
            {

                throw;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool van = Validador.Validador.validar(Controls);
            if (!van)
            {
                return;
            }
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE PRODUCTOS SET nombre = @nombre, descripcion = @descripcion, precio = @precio,id_categoria = @categoria,id_proveedor = @proveedor WHERE Id_producto = @codigo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", Int32.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@precio", Int32.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@categoria", cboCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@proveedor", cboProveedor.SelectedValue);


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se modifico con exito el producto");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
