using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios
{
    public partial class Form_AgregarProducto : Form
    {
        Classes.Class_Composicion fnComposicion = new Classes.Class_Composicion();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Class_Paquete fnPaquete = new Classes.Catalogos.Class_Paquete();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        string numPaquete = "";
        public event Form1.MessageHandler guardarProductosPaquete_Temp;
        public Form_AgregarProducto(string idPaquete)
        {
            InitializeComponent();
            numPaquete = idPaquete;
        }

        private void Form_AgregarProducto_Load(object sender, EventArgs e)
        {
            cargaProductos();
            Classes.Class_Session.producto = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargaProductos()
        {
            dataGridView1.DataSource = null;
            string sql = "select iidProducto ID, vchCodigo Codigo, vchDescripcion Producto, U.vchNombre Unidad, P.fPrecio Costo from catProductos P, catUnidadesProductos U where P.iidEstatus = 1 and P.iidUnidad = U.iidUnidad and P.iidUnidad != 3";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Codigo"].Width = 190;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["Producto"].Width = 100;
                dataGridView1.Columns["Producto"].ReadOnly = true;
                dataGridView1.Columns["Costo"].Width = 150;
                dataGridView1.Columns["Costo"].ReadOnly = true;
                dataGridView1.Columns["Unidad"].Width = 150;
                dataGridView1.Columns["Unidad"].ReadOnly = true;
                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }


            }
            catch
            {
                MessageBox.Show("No hay Informacion");
            }
            bs.DataSource = dataGridView1.DataSource;

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            int contador = 0;

            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            /*if (contador > 1)
            {
                MessageBox.Show("Favor de seleccionar un registro a la vez.");
                return;
            }*/

            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        string idProducto = registro.Cells["ID"].Value.ToString();
                        //if (!fnPaquete.existeProductoenPaquete(idProducto, numPaquete))
                        //{
                            Classes.Class_Session.producto = idProducto;
                            guardarProductosPaquete_Temp();
                            this.Close();
                            //Formularios.Form_AgregarTipoyCantidad frm = new Formularios.Form_AgregarTipoyCantidad(idMateriaPrima, numProducto);
                            //frm.salir += new Form1.MessageHandler(salir);
                            //frm.ShowDialog();
                        /*}
                        else
                        {
                            MessageBox.Show("Esa materia prima ya se encuentra agregada");
                        }*/
                    }
                }
                catch { }
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+Codigo+' '+Producto+' '+Costo+''+Unidad LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}
