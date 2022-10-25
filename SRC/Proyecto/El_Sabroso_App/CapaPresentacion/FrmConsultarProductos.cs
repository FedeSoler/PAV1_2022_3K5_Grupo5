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

            if (resultado.Rows.Count > 0)
            {
                foreach (DataRow fila in resultado.Rows)
                {
                    bool activo = fila["activo"].ToString().Equals("S");

                    int id = (int)fila["Id_producto"];
                    dgbProductos.Rows.Add(new object[] { fila["nombre"].ToString(), fila["Descripcion"], fila["Precio"], fila["nombre1"]/*aca es el proveedor*/, activo, fila["Id_producto"].ToString() });
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
            FrmAltaProducto formulario = new FrmAltaProducto();
            var producto = (Producto)dgbProductos.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(FrmAltaProducto.FormMode.actualizar, producto);
            formulario.ShowDialog();
            button1_Click(sender, e);
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
                int id = Int32.Parse(dgbProductos.Rows[dgbProductos.CurrentRow.Index].Cells[5].Value.ToString());
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
