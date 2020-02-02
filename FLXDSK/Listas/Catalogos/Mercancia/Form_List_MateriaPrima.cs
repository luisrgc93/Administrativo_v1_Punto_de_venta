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
    public partial class Form_List_MateriaPrima : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMateriaPrima =  new Classes.Catalogos.Mercancia.Class_Materia_Prima();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_MateriaPrima()
        {
            InitializeComponent();
        }
        private void Form_List_MateriaPrima_Load(object sender, EventArgs e)
        {
            CargaLista();
        }
        public void CargaLista()
        {
            dataGridView1.DataSource = null;
            string sql = " SELECT M.iidMateriPrima ID, C.vchDescripcion Categoría, M.vchCodigo Código, M.vchDescripcion Materia_Prima, M.fCosto Costo, M.fContenido Contenido,  " +
                " CASE siInventariar WHEN 1 THEN 'SI' ELSE 'NO' END Inventariar,  " +
                " u.vchNombre Medida,  " +
                " Convert(VARCHAR(10),M.dfechaIn,103) Actualización  " +
            " FROM catMateriaPrima M (NOLOCK), catCategoriasMateriaPrima C (NOLOCK), catUnidadesMetricas U   " +
            " WHERE M.iidCategoriaMateriPrima = C.iidCategoriaMateriPrima  " +
            " AND M.iidUnidad = U.iidUnidad  " +
            " AND M.iidEstatus = 1 " +
            " ORDER BY M.dfechaIn DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = true;
                dataGridView1.Columns["Categoría"].Width = 200;
                dataGridView1.Columns["Categoría"].ReadOnly = true;
                dataGridView1.Columns["Código"].Width = 100;
                dataGridView1.Columns["Código"].ReadOnly = true;
                dataGridView1.Columns["Materia_Prima"].Width = 200;
                dataGridView1.Columns["Materia_Prima"].ReadOnly = true;
                dataGridView1.Columns["Costo"].Width = 100;
                dataGridView1.Columns["Costo"].ReadOnly = true;
                dataGridView1.Columns["Actualización"].Width = 100;
                dataGridView1.Columns["Actualización"].ReadOnly = true;
                dataGridView1.Columns["Contenido"].Width = 100;
                dataGridView1.Columns["Contenido"].ReadOnly = true;

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

        

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+Código+' '+Categoría+' '+Costo+' '+Materia_Prima LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            int contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["ID"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }


            Formularios.Catalogos.Mercancia.Form_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_MateriaPrima(IdRegistro);
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            int contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["ID"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if(ClsMateriaPrima.Eliminar(IdRegistro))
                {
                    MessageBox.Show("Eliminado con exito");
                    CargaLista();
                }
                else{
                    MessageBox.Show("Problema al eliminar, contacte al administrador");
                }
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_MateriaPrima("");
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idMateriaPrima = row.Cells["ID"].Value.ToString();
                Formularios.Catalogos.Mercancia.Form_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_MateriaPrima(idMateriaPrima);
                frm.CargaLista += new Form1.MessageHandler(CargaLista);
                frm.ShowDialog();
            }
        }

        
    }
}
