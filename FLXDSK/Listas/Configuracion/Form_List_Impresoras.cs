using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Configuracion
{
    public partial class Form_List_Impresoras : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Configuracion.Class_Impresoras ClsConfigImpresora = new Classes.Configuracion.Class_Impresoras();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Impresoras()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.Form_Impresoras frm = new Formularios.Configuracion.Form_Impresoras("");
            frm.Lista_Impresoras += new Form1.MessageHandler(Lista_Impresoras);
            frm.ShowDialog();
        }
        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            dataGridView2.EndEdit();
            string Nombre = "";
            foreach (DataGridViewRow registro in dataGridView2.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        Nombre = registro.Cells["Nombre"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
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
                ClsConfigImpresora.BorrarImpresora(Nombre);
                Lista_Impresoras();
            }
        }
        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string Nombre = "";

            dataGridView2.EndEdit();
            foreach (DataGridViewRow registro in dataGridView2.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        Nombre = registro.Cells["Nombre"].Value.ToString();
                        contador++;
                    }
                }
                catch { }
            }


            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar un campo para su edicion. ");
                return ;
            }



            Formularios.Configuracion.Form_Impresoras frm = new Formularios.Configuracion.Form_Impresoras(Nombre);
            frm.Lista_Impresoras += new Form1.MessageHandler(Lista_Impresoras);
            frm.ShowDialog();
            
            
        }
        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Nombre+' '+Impresora LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView2.DataSource = bs;
        }
        private void Form_List_Impresoras_Load(object sender, EventArgs e)
        {
            Lista_Impresoras();
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                string Nombre = row.Cells["Nombre"].Value.ToString();
                Formularios.Configuracion.Form_Impresoras frm = new Formularios.Configuracion.Form_Impresoras(Nombre);
                frm.Lista_Impresoras += new Form1.MessageHandler(Lista_Impresoras);
                frm.ShowDialog();
            }
        }
        private void Lista_Impresoras()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView2.DataSource = null;
            string sql = " SELECT convert(varchar(10),dfechaIn,103)Creado, vchImpresora Nombre,  vchPrinterUSB Impresora " +
                         " FROM catImpresoras  (NOLOCK) " + 
                         " ORDER BY dfechaIn DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView2.DataSource = dstConsulta.Tables[0];

                dataGridView2.Columns["Creado"].Width = 100;
                dataGridView2.Columns["Creado"].ReadOnly = true;
                dataGridView2.Columns["Nombre"].Width = 190;
                dataGridView2.Columns["Nombre"].ReadOnly = true;
                dataGridView2.Columns["Impresora"].Width = 300;
                dataGridView2.Columns["Impresora"].ReadOnly = true;

                if (!dataGridView2.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView2.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
            }
            bs.DataSource = dataGridView2.DataSource;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
