using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Catalogos
{
    public partial class Form_List_Insumos : Form
    {
        BindingSource bs = new BindingSource();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Class_Insumos ClsIns = new Classes.Catalogos.Class_Insumos();

        public Form_List_Insumos()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Insumos frm = new Formularios.Catalogos.Form_Insumos("","");
            frm.Lista_Insumos += new Form1.MessageHandler(Lista_Insumos);
            frm.ShowDialog();
        }

        private void Form_List_Insumos_Load(object sender, EventArgs e)
        {
            Lista_Insumos();
        }

        private void Lista_Insumos()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT I.iidInsumos id, T.vchNombre Categoria, I.vchCodigo Codigo, I.vchNombre Nombre, " +
                         " I.fCantidad Cantidad, I.fCostoUnitario [Costo Unitario], ROUND((fCantidad * fCostoUnitario),2) AS Total " +
                         " FROM catInsumos I " +
                         " INNER JOIN catTiposInsumos T ON I.iidTipoInsumo = T.iidTipoInsumo " +
                         " WHERE I.iidEstatus = 1 " +
                         " ORDER BY I.dfechaIn DESC ";
            SqlDataAdapter mesas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                mesas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["id"].Width = 80;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["Categoria"].Width = 90;
                dataGridView1.Columns["Categoria"].ReadOnly = true;
                dataGridView1.Columns["Codigo"].Width = 90;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].Width = 200;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Cantidad"].Width = 90;
                dataGridView1.Columns["Cantidad"].ReadOnly = true;
                dataGridView1.Columns["Costo Unitario"].Width = 150;
                dataGridView1.Columns["Costo Unitario"].ReadOnly = true;
                dataGridView1.Columns["Total"].Width = 90;
                dataGridView1.Columns["Total"].ReadOnly = true;

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
            { }
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
                            ClsIns.borrar_insumo(registro.Cells["id"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Insumos();
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
                            string idinsumo = registro.Cells["id"].Value.ToString();
                            Formularios.Catalogos.Form_Insumos frm = new Formularios.Catalogos.Form_Insumos(idinsumo,"");
                            frm.Lista_Insumos += new Form1.MessageHandler(Lista_Insumos);
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idinsumo = row.Cells["id"].Value.ToString();
                Formularios.Catalogos.Form_Insumos frm = new Formularios.Catalogos.Form_Insumos(idinsumo,"");
                frm.Lista_Insumos += new Form1.MessageHandler(Lista_Insumos);
                frm.ShowDialog();
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Categoria+' '+Codigo+' '+Nombre+' '+Cantidad+' '+[Costo Unitario]+' '+Total LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}
