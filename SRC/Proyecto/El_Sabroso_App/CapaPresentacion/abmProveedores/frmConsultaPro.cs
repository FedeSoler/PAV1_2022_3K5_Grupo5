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

namespace El_Sabroso_App.CapaPresentacion.abmPro
{
    public partial class frmConsultaPro : Form
    {
        public frmConsultaPro()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM PROVEEDORES WHERE 1=1";
                cmd.Parameters.Clear();
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    consulta += " AND nombre like '" + txtNombre.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtApellido.Text))
                {
                    consulta += " AND apellido like '" + txtApellido.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtCiudad.Text))
                {
                    consulta += " AND ciudad like '" + txtCiudad.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtTelefono.Text))
                {
                    consulta += " AND telefono like '" + txtTelefono.Text + "%'";
                }
                if (checkActivo.Checked)
                {
                    btnEditar.Enabled = Enabled;
                    consulta += " AND activo = 1";
                }
                else
                {
                    consulta += " AND activo = 0";
                    btnEditar.Enabled = false;
                }
                if (checkFecha.Checked) {
                    consulta += " AND fecha_alta = @fechaAlta";
                    cmd.Parameters.AddWithValue("@fechaAlta", dtpFechaAlta.Value);
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                DataTable tabla = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                dgvProv.DataSource = tabla;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProv.SelectedRows.Count <= 0) {
                return;
            }

            DataGridViewRow grid = dgvProv.SelectedRows[0];
            Proveedor prov = new Proveedor();
            prov.IdProveedor = (int)grid.Cells[0].Value;
            prov.Nombre = (string)grid.Cells[1].Value;
            prov.Apellido = (string)grid.Cells[2].Value;
            prov.Email= (string)grid.Cells[3].Value;
            prov.Telefono = (string)grid.Cells[4].Value;
            prov.Direccion = (string)grid.Cells[5].Value;
            prov.Ciudad = (string)grid.Cells[6].Value;
            prov.Fecha_Alta = (DateTime)grid.Cells[7].Value;

            frmEditarPro ventana = new frmEditarPro();
            ventana.inicializar(prov);
            ventana.ShowDialog();
        }

        private void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtCiudad.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            dtpFechaAlta.Value = DateTime.Now;
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvProv.SelectedRows.Count <= 0){
                MessageBox.Show("No se seleeciono nada del dataGrid");
                return;
            }

            Proveedor prove = new Proveedor();
            DataGridViewRow grid = dgvProv.SelectedRows[0];
            prove.IdProveedor = (int)grid.Cells[0].Value;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE PROVEEDORES SET activo = 0 WHERE Id_proveedor = @idProv";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProv", prove.IdProveedor);


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Proveedor dado de baja");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

