using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using El_Sabroso_App.CapaDatos;
using El_Sabroso_App.CapaEntidades;

namespace El_Sabroso_App.CapaPresentacion
{
    public partial class FrmAltaProducto : Form
    {
        private int v;
        private int accion;
        private FrmAltaProducto alta_Producto;
        private Producto producto;
        private Producto oProducto;
        private string estado;



        public FrmAltaProducto(int accion,Producto oProducto)
        {
            InitializeComponent();
            this.accion = accion;
            this.oProducto = oProducto;

        }

        public FrmAltaProducto(int v, FrmAltaProducto alta_Producto)
        {
            this.v = v;
            this.alta_Producto = alta_Producto;
        }

        public FrmAltaProducto()
        {
        }

        //public FrmAltaProducto(int v, Producto producto)
        // {
        //    this.v = v;
        //    this.producto = producto;
        // }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Campo Nombre es requerido", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   
            
            }


            if (String.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("Campo Categoría es requerido", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
         
            if (checkActivo.Checked)
            {
                estado= "S";
            }
            else
            {
                estado = "N";
            }


            String consultaSql = string.Concat(" INSERT INTO PRODUCTOS " +
                "(nombre,descripcion,categoria,precio,id_proveedor,activo) " +
                "VALUES ('" + txtNombre.Text + "'," +
                "'"+txtDescripcion.Text+"'" +
                ",'"+txtCategoria.Text+"'" +
                ",'" + nudPrecio.Value+ "'" +
                ",'" +comboProveedor.SelectedValue+"'" +
                ",'"+estado+"')");

            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);
            MessageBox.Show("Producto ingresado exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Se setean todos los campos
            resultado.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCategoria.Clear();
            nudPrecio.Value = 0;
            checkActivo.Checked = false;



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



        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmAltaProducto_Load(object sender, EventArgs e)
        {
            cargarComboProveedores();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

  
        
    }
