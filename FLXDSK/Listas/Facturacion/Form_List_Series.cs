using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Facturacion
{
    public partial class Form_List_Series : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        BindingSource bs = new BindingSource();

        Classes.Facturas.Class_Series ClsSeries = new Classes.Facturas.Class_Series();


        public Form_List_Series()
        {
            InitializeComponent();
        }

        private void Form_List_Series_Load(object sender, EventArgs e)
        {
            CargaLista();
        }
        private void CargaLista()
        {
            dataGridView_Lista.DataSource = null;
            string sql = " SELECT S.iidSerie, CONVERT(varchar(10),dfechaIn,103)Creado, " +
	            " vchSerie Serie, iFolio Folio, vchCalle+' '+vchNumExt+' '+vchNumInt Calle, " +
	            " vchColonia Colonia " +
            " FROM catSeries (NOLOCK) S " +
            " WHERE S.iidEstatus = 1 " +
            " ORDER BY dfechain DESC";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidSerie"].Visible = false;
                dataGridView_Lista.Columns["Creado"].ReadOnly = true;
                dataGridView_Lista.Columns["Serie"].ReadOnly = true;
                dataGridView_Lista.Columns["Folio"].ReadOnly = true;
                dataGridView_Lista.Columns["Calle"].ReadOnly = true;
                dataGridView_Lista.Columns["Colonia"].ReadOnly = true;

                if (!dataGridView_Lista.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView_Lista.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
            }
            bs.DataSource = dataGridView_Lista.DataSource;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Facturacion.Form_Series from = new Formularios.Facturacion.Form_Series("");
            from.CargaLista += new Form1.MessageHandler(CargaLista);
            from.ShowDialog();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "0";
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        IdRegistro += "," + registro.Cells["iidSerie"].Value.ToString();
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

            DialogResult res = MessageBox.Show(@"Esta usted seguro de eliminar el registro seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string[] valores = IdRegistro.Split(',');
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] != "0")
                    {
                        string IdCorte = valores[i];

                        if (!ClsSeries.EliminaRegistro(IdCorte))
                        {
                            MessageBox.Show("Problema al eliminar la serie.");
                            return;
                        }
                    }
                }
                CargaLista();
            }

            
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "0";
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        IdRegistro =  registro.Cells["iidSerie"].Value.ToString();
                        contador++;
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }
            Formularios.Facturacion.Form_Series from = new Formularios.Facturacion.Form_Series(IdRegistro);
            from.CargaLista += new Form1.MessageHandler(CargaLista);
            from.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Serie+' '+Calle LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string IdRegistro = row.Cells["iidSerie"].Value.ToString();

                Formularios.Facturacion.Form_Series from = new Formularios.Facturacion.Form_Series(IdRegistro);
                from.CargaLista += new Form1.MessageHandler(CargaLista);
                from.ShowDialog();
            }
        }
    }
}
