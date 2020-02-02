using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Catalogos.Local
{
    public partial class Form_List_Areas : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Local.Class_Areas ClsAre = new Classes.Catalogos.Local.Class_Areas();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public Form_List_Areas()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Local.Form_Areas frm = new Formularios.Catalogos.Local.Form_Areas("");
            frm.Lista_Areas += new Form1.MessageHandler(Lista_Areas);
            frm.ShowDialog();
        }

        private void Lista_Areas()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT iidArea Id, convert(varchar(10),dfechaIn,103)Creado, vchNombre Nombre, vchDescripcion Descripcion " +
                         " FROM catAreas " +
                         " WHERE iidEstatus = 1 " +
                         " ORDER BY dfechain DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["Id"].Width = 80;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Creado"].Width = 100;
                dataGridView1.Columns["Creado"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].Width = 190;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Descripcion"].Width = 300;
                dataGridView1.Columns["Descripcion"].ReadOnly = true;

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
            catch (Exception exp)
            {
                MessageBox.Show("No hay Información Disponible");
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Form_List_Areas";
                row_Excepcion["vchAccion"] = "Cargar lista_areas()";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
            }
            bs.DataSource = dataGridView1.DataSource;

        }

        private void Form_List_Areas_Load(object sender, EventArgs e)
        {
            Lista_Areas();
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
                            ClsAre.borrar_area(registro.Cells["Id"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Areas();
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
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

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar un campo para su edicion. ");
            }
            else
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string iidArea = registro.Cells["Id"].Value.ToString();
                            Formularios.Catalogos.Local.Form_Areas frm = new Formularios.Catalogos.Local.Form_Areas(iidArea);
                            frm.Lista_Areas += new Form1.MessageHandler(Lista_Areas);
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                }
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string iidArea = row.Cells["Id"].Value.ToString();
                Formularios.Catalogos.Local.Form_Areas frm = new Formularios.Catalogos.Local.Form_Areas(iidArea);
                frm.Lista_Areas += new Form1.MessageHandler(Lista_Areas);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Nombre+' '+Descripcion LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
