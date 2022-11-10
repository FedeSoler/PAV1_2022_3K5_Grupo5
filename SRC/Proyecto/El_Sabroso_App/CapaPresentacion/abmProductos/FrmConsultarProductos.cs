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
using El_Sabroso_App.CapaPresentacion.abmProductos;

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
            ConsultarProductos();




        }
        private void ConsultarProductos()
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT P.*, Pro.nombre,cp.nombre ",
                                                   "   FROM PRODUCTOS P ",
                                                   "LEFT JOIN PROVEEDORES Pro on ",
                                                   "P.Id_proveedor = Pro.Id_Proveedor " +
                                                   "LEFT JOIN CATEGORIAS_PROD CP ON p.id_categoria = cp.id_categoria where 1=1");


            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                consultaSql += " AND P.nombre LIKE '" + txtNombre.Text + "%'";
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

            if (resultado.Rows.Count > 0)
            {
                foreach (DataRow fila in resultado.Rows)
                {
                    bool activo = fila["activo"].ToString().Equals("S");

                    int id = (int)fila["Id_producto"];
                    dgbProductos.Rows.Add(new object[] { fila["nombre"].ToString(), fila["Descripcion"], fila["Precio"], fila["nombre1"] /*aca es el proveedor*/,fila["nombre2"].ToString(), activo, fila["Id_producto"].ToString() });
                }
                habilitarControles(true);
            }
            else
            {
                habilitarControles(false);
            }
            // desactivar botones eliminar y editar si no se elige estado activo
            if (resultado.Rows.Count > 0)
            {
                if (!chkActivo.Checked)
                {
                    habilitarControles(false);
                }

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
            Producto producto = new Producto();
            DataGridViewRow grid = dgbProductos.SelectedRows[0];
            producto.Nombre = (string)grid.Cells[0].Value;
            producto.Descripcion = (string)grid.Cells[1].Value;
            producto.Precio = Int32.Parse((string)grid.Cells[2].Value.ToString());
            producto.IdProducto = Int32.Parse((string)grid.Cells[6].Value);
            string nombre_cat = (string)grid.Cells[4].Value;
            string nombreProv = (string)grid.Cells[3].Value;
            frmEditarProducto ventana = new frmEditarProducto();
            ventana.incializar(producto,nombreProv,nombre_cat);
            ventana.ShowDialog();

        }











        private Producto mapper(DataGridViewRow fila)
        {
            Producto oSeleted = new Producto();
            oSeleted.Nombre = fila.Cells["Colnombre"].Value.ToString();
            oSeleted.Activo = (bool)fila.Cells["colActivo"].Value;
            return oSeleted;
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarProducto();
            ConsultarProductos();
        }


        private void eliminarProducto()
        {
            int? id = obtenerId();
            //MessageBox.Show("se obtuvo el valor  ", id.ToString());
            String deleteSQL = string.Concat("  update  PRODUCTOS  " +
                " set  activo = 'N' " +
                " where Id_producto = " + id);

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(deleteSQL);
        }

        private int? obtenerId()
        {
            try
            {
                int id = Int32.Parse(dgbProductos.Rows[dgbProductos.CurrentRow.Index].Cells[6].Value.ToString());
                return id;
            }
            catch
            {
                return null;
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new FrmAltaProducto(1, new Producto()).ShowDialog();
            this.button1_Click(null, null);
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
