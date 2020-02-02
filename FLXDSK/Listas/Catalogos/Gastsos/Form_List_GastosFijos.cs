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
    public partial class Form_List_GastosFijos : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_GastosFijos fnGastosFijos = new Classes.Class_GastosFijos();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_GastosFijos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idGasto = row.Cells["ID"].Value.ToString();
                Formularios.Form_GastosFijos frm = new Formularios.Form_GastosFijos(idGasto);
                frm.lista_Gastos += new Form1.MessageHandler(lista_Gastos);
                frm.ShowDialog();
            }
        }
        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+Tipo+' '+Descripcion+' '+Monto+' '+Inicio+' '+Fin LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
        private void Form_List_GastosFijos_Load(object sender, EventArgs e)
        {
            lista_Gastos();
        }
        public void lista_Gastos()
        {
            dataGridView1.DataSource = null;
            string sql = "  select G.iidGasto ID, G.vchTipo Tipo, G.vchDescripcion Descripcion, G.fMonto Monto, Convert(VARCHAR(10),G.dFechaInicio,103) Inicio, Convert(VARCHAR(10),G.dFechaFin,103) Fin " +
                         "  from catGastosFijos G " + 
                         "  where G.iidEstatus = 1 " +
                         "  order by G.dfechaIn desc";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Tipo"].Width = 150;
                dataGridView1.Columns["Tipo"].ReadOnly = true;
                dataGridView1.Columns["Descripcion"].Width = 200;
                dataGridView1.Columns["Descripcion"].ReadOnly = true;
                dataGridView1.Columns["Monto"].Width = 100;
                dataGridView1.Columns["Monto"].ReadOnly = true;
                dataGridView1.Columns["Inicio"].Width = 100;
                dataGridView1.Columns["Inicio"].ReadOnly = true;
                dataGridView1.Columns["Fin"].Width = 100;
                dataGridView1.Columns["Fin"].ReadOnly = true;

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

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Form_GastosFijos frm = new Formularios.Form_GastosFijos("");
            frm.lista_Gastos += new Form1.MessageHandler(lista_Gastos);
            frm.ShowDialog();
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
                            fnGastosFijos.borrar_Gasto(registro.Cells["ID"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                lista_Gastos();
            }
        }
        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
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

            if (contador > 1)
            {
                MessageBox.Show("Para editar solo seleccione un registro.");
                return;
            }
            else
            {

                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string idGasto = registro.Cells["ID"].Value.ToString();
                            Formularios.Form_GastosFijos frm = new Formularios.Form_GastosFijos(idGasto);
                            frm.lista_Gastos += new Form1.MessageHandler(lista_Gastos);
                            frm.ShowDialog();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
    }
}
