using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas
{
    public partial class Form_List_Composicion : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Composicion fnComposicion = new Classes.Class_Composicion();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Composicion()
        {
            InitializeComponent();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            //Valida que haya mas de un registro seleccionado  
            int contador = 0;
            //Finaliza modo de edicion
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

            DialogResult resultado;

            if (contador <= 1)
            {
                resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                resultado = MessageBox.Show(@"Esta seguro de eliminar estos registros", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }


            if (DialogResult.OK == resultado)
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            //fnComposicion.borrar_Composicion(registro.Cells["ID"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                lista_Composicion();
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            /*Formularios.Form_Composicion frm = new Formularios.Form_Composicion("");
            frm.lista_Composicion += new Form1.MessageHandler(lista_Composicion);
            frm.ShowDialog();*/
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+Producto+' '+Tiempo+' '+Fecha LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void Form_List_Composicion_Load(object sender, EventArgs e)
        {
            lista_Composicion();
        }

        public void lista_Composicion()
        {
            dataGridView1.DataSource = null;
            string sql = "  select C.iidComposicion ID, P.vchDescripcion Producto, C.iTiempo Tiempo, Convert(VARCHAR(10),C.dfechain,103) Fecha, "+ 
                         "  Convert(VARCHAR(10),C.dfechaup,103) FechaActualización  "+
                         "  from catComposicion C, catProductos P "+
                         "  where C.iidProducto = P.iidProducto  "+
                         "  and C.iidEstatus = 1 " +
                         "  order by C.dfechain desc";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = true;
                dataGridView1.Columns["Producto"].Width = 100;
                dataGridView1.Columns["Producto"].ReadOnly = true;
                dataGridView1.Columns["Tiempo"].Width = 200;
                dataGridView1.Columns["Tiempo"].ReadOnly = true;
                dataGridView1.Columns["Fecha"].Width = 200;
                dataGridView1.Columns["Fecha"].ReadOnly = true;
                dataGridView1.Columns["FechaActualización"].Width = 200;
                dataGridView1.Columns["FechaActualización"].ReadOnly = true;

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
            }
            bs.DataSource = dataGridView1.DataSource;
        }
    }
}
