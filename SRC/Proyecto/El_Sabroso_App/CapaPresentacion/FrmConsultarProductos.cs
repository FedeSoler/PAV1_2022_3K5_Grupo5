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
    public partial class FrmConsultarProductos : Form
    {
        public FrmConsultarProductos()
        {
            InitializeComponent();
        }

        private void FrmConsultarProductos_Load(object sender, EventArgs e)
        {
            habilitarControles(false);

        }


        private void button1_Click(object sender, EventArgs e)
        {


            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT P.*, Pro.nombre ",
                                                   "   FROM PRODUCTOS P ",
                                                   "LEFT JOIN PROVEEDORES Pro on ",
                                                   "P.Id_proveedor = Pro.Id_Proveedor where 1=1");


            if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    consultaSql += " AND P.nombre LIKE '%" + txtNombre.Text + "%'";
                }
                if (chkActivo.Checked)
                {
                    consultaSql += " AND P.activo = 'S'";
                }
                else
                {
                    consultaSql += " AND P.activo = 'N'";
                }
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            dgbProductos.Rows.Clear();
                
            if ( resultado.Rows.Count > 0)
            {
                foreach (DataRow fila in resultado.Rows)
                {
                    bool activo = fila["activo"].ToString().Equals("S");

                    int id = (int)fila["Id_producto"];
                    dgbProductos.Rows.Add(new object[] { fila["nombre"].ToString(), fila["Descripcion"], fila["Precio"], fila["nombre1"]/*aca es el proveedor*/, activo });
                }
                habilitarControles(true);
            }
            else
            {
                habilitarControles(false);
            }
           
            lblProducto.Text = "Total Registros: " + Convert.ToString(dgbProductos.Rows.Count);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void habilitarControles(bool v)
        {
            btnEditar.Enabled = v;
            btnEliminar.Enabled = v;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
