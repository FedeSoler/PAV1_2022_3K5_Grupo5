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


            
            DataTable tabla = cargarTabla(productoSelect);
            //carga proveedor
            comboProveedor.DataSource = tabla;
            comboProveedor.DisplayMember = "proveedor";
            comboProveedor.ValueMember = "Id_proveedor";
            //carga categoria
            comboCategoria.DataSource = tabla;
            comboCategoria.DisplayMember = "categoria";
            comboCategoria.ValueMember = "c.id_categoria";


        }

        private void calcularMonto()
        {





        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Fecha ingresada incorrecta");
                return;

            }

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
                return;
            }

            dataGridView1.Rows.Add(comboProducto.Text, comboProveedor.Text, comboCategoria.Text, CantProd.Value, txtNombreCliente.Text, textBox2.Text, textBox4.Text, textBox3.Text);
            // int a = Int32.Parse(MontoTotal.Text);
            int resultado = 0;
            
            
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[3] != null)
                {
                    int a = Int32.Parse(row.Cells[3].Value.ToString());
                    DataTable tabla = cargarTabla(row.Cells[0].Value.ToString());
                    int b = Int32.Parse(tabla.Rows[0][2].ToString());
                    resultado += a * b;

                }
              

            }
            MontoTotal.Text = resultado.ToString();


        }






        private DataTable cargarTabla(string productoSelect)
        {

            String consultasql2 =
                "SELECT pr.Id_producto, pr.nombre,pr.precio,c.id_categoria,c.nombre as categoria, p.Id_proveedor ,p.nombre as proveedor" +
                " FROM PRODUCTOS pr" +
                " LEFT JOIN PROVEEDORES p" +
                " ON pr.id_proveedor = p.Id_proveedor" +
                " LEFT JOIN CATEGORIAS_PROD c" +
                " ON pr.id_categoria = c.id_categoria" +
                " WHERE pr.nombre = " + "'" + productoSelect + "'"
                ;
            DataTable resultado2 = DataManager.GetInstance().ConsultaSQL(consultasql2);
            return resultado2;

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboProveedores();
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboCategoria();
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlTransaction objTransaction = null;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO[dbo].[VENTAS]" +
           "([Id_venta]" +
           ",[fecha]"+
           ",[monto]"+
           ",[nombre_cliente]"+
           ",[apellido_cliente]"+
           ",[email_cliente]" +
           ",[telefono_cliente]" +
     "VALUES" +
           ",@fecha" +
           ",@monto" +
           ",@nombreCliente" +
           ",@ApellidoCliente" +
           ",@emailCliente" +
           ",@telefono";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@monto", MontoTotal.Text);
                cmd.Parameters.AddWithValue("@ApellidoCliente", textBox2.Text);
                cmd.Parameters.AddWithValue("@emailCliente", textBox3.Text);
                cmd.Parameters.AddWithValue("@nombreCliente",(txtNombreCliente.Text));
                cmd.Parameters.AddWithValue("@telefono", (textBox4.Text));
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                objTransaction = cn.BeginTransaction("serviciosXcontrato");
                
                cmd.Transaction = objTransaction;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                int numerofactura = buscar_numfactura();
                foreach (DataGridViewRow item in dgvAsignar.Rows)
                {
                    if(item.Cells[1].Value == null){ break; }
                    string consultaserviciosxcliente = "INSERT INTO[dbo].[Servicios_Contratados]"
                                                       + "([nro_telefono]"
                                                     + ",[fecha_desde]"
                                                     + ",[fecha_hasta]"
                                                     + ",[id_servicio])"
                                             + "VALUES"
                                                + "(@numeroteledono"
                                               + ", @datedesde"
                                                + ", @datehasta"
                                                + ", @idservicio)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@numeroteledono", int.Parse(item.Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@datedesde", DateTime.Now);
                    cmd.Parameters.AddWithValue("@datehasta", item.Cells[2].Value);
                    cmd.Parameters.AddWithValue("@idservicio", Int32.Parse(item.Cells[1].Value.ToString()));
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = consultaserviciosxcliente;
                    cmd.ExecuteNonQuery();

                    string consultaDetalleFactura = "INSERT INTO[dbo].[Detalle_factura_servicios]"
                                                                + "([nrofactura]"
                                                                + ",[id_servicios_contratados])"
                                                            + "VALUES"
                                                                + "(@numerofactura "
                                                                + ", @id_servicio )";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@numerofactura", numerofactura);
                    cmd.Parameters.AddWithValue("@id_servicio", Int32.Parse(item.Cells[1].Value.ToString()));
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = consultaDetalleFactura;
                    cmd.ExecuteNonQuery();
                    
                }
                objTransaction.Commit();
                MessageBox.Show("Se genero la la factura con sus detalles");

            }
            catch (Exception)
            {
                objTransaction.Rollback();
                MessageBox.Show("La transaccion no se pudo completar");

                throw;
            }



        }
    }
}
