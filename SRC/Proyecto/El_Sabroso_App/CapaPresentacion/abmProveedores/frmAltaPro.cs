using El_Sabroso_App.Validador;
using El_Sabroso_App.CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace El_Sabroso_App.CapaPresentacion.abmPro
{
    public partial class frmAltaPro : Form
    {
        public frmAltaPro()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            bool van = Validador.Validador.validar(Controls);
            if (!van) { return; }
            Proveedor prov = new Proveedor(txtNombre.Text, txtApeliido.Text, txtMail.Text, txtTelefono.Text, txtDireccion.Text, txtCiudad.Text, dtaFecha.Value);
            bool exist = Validador.Validador.validarExistenciaPro(prov.Nombre, prov.Apellido);
            if (!exist) {
                MessageBox.Show("El Proveedor ya existe");
                return; }

            bool agregado = darAlta(prov);
            if (!agregado)
            {
                MessageBox.Show("No se agrego el proveedor");
                return;
            }
            MessageBox.Show("Proveedor agregado con exito");
           
        }

        private bool darAlta(Proveedor prov)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO [dbo].[PROVEEDORES]"
                                        +"([nombre]"
                                        +",[apellido]"
                                        +",[email]"
                                        +",[telefono]"
                                        +",[direccion]"
                                        +",[ciudad]"
                                        +",[fecha_alta]"
                                        +",[activo])"
                                    +"VALUES"
                                        +"(@nombre"
                                        +",@apellido"
                                        +",@email"
                                        +",@telefono"
                                        +",@direccion"
                                        +",@ciudad"
                                        +",@fechaAlta"
                                        + ",@activo)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", prov.Nombre);
                cmd.Parameters.AddWithValue("@apellido", prov.Apellido);
                cmd.Parameters.AddWithValue("@email", prov.Email);
                cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                cmd.Parameters.AddWithValue("@direccion", prov.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", prov.Ciudad);
                cmd.Parameters.AddWithValue("@fechaAlta", prov.Fecha_Alta);
                cmd.Parameters.AddWithValue("@activo", 1);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }

        private void frmAltaPro_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
