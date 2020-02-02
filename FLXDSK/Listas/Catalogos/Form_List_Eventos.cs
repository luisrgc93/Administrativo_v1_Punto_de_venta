using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Catalogos
{
    public partial class Form_List_Eventos : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Class_Eventos ClsEventos = new Classes.Catalogos.Class_Eventos();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Eventos()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Eventos frm = new Formularios.Catalogos.Form_Eventos("");
            frm.Lista_Eventos += new Form1.MessageHandler(Lista_Eventos);
            frm.ShowDialog();
        }
        private void Lista_Eventos()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " " +
            " SELECT iidEvento ID, vchNombre Nombre, vchDescripcion Descripcion, dfechaEventoInicia Inicio, dfechaEventoTermina Fin" +
            " FROM catEventos (NOLOCK) " +
            " WHERE iidEstatus = 1 " +
            " ORDER BY dfechaEventoInicia ASC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Nombre"].Width = 190;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Descripcion"].Width = 300;
                dataGridView1.Columns["Descripcion"].ReadOnly = true;
                dataGridView1.Columns["Inicio"].Width = 150;
                dataGridView1.Columns["Inicio"].ReadOnly = true;
                dataGridView1.Columns["Fin"].Width = 150;
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
                resultado = MessageBox.Show(@"Esta seguro de eliminar este Evento", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                resultado = MessageBox.Show(@"Esta seguro de eliminar estos Eventos", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            ClsEventos.borrar_Evento(registro.Cells["ID"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Eventos();
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
                            string iidEvento = registro.Cells["ID"].Value.ToString();
                            Formularios.Catalogos.Form_Eventos frm = new Formularios.Catalogos.Form_Eventos(iidEvento);
                            frm.Lista_Eventos += new Form1.MessageHandler(Lista_Eventos);
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

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format("ID+' '+Nombre+' '+Inicio+' '+Fin+' '+Descripcion LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void Form_List_Eventos_Load(object sender, EventArgs e)
        {
            Lista_Eventos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string iidEvento = row.Cells["ID"].Value.ToString();
                Formularios.Catalogos.Form_Eventos frm = new Formularios.Catalogos.Form_Eventos(iidEvento);
                frm.Lista_Eventos += new Form1.MessageHandler(Lista_Eventos);
                frm.ShowDialog();
            }
        }
    }
}
