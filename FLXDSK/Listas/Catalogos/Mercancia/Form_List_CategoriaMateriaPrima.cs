using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Catalogos.Mercancia
{
    public partial class Form_List_CategoriaMateriaPrima : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria ClsCategoriaMatPrim = new Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_CategoriaMateriaPrima()
        {
            InitializeComponent();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "";
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

           
            Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima(IdRegistro);
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistros = "0";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistros += ","+registro.Cells["ID"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador < 0)
            {
                MessageBox.Show("Debe seleccionar almenos un registro.");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar los registros seleccionados?", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                string[] valores = IdRegistros.Split(',');
                foreach(string linea in valores)
                {
                    if(linea != "")
                        ClsCategoriaMatPrim.Eliminar(linea);
                }

                MessageBox.Show("Eliminado(s) con exito");
                CargaLista();

            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima("");
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+Código+' '+Categoría+' '+Fecha LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        public void CargaLista()
        {
            dataGridView1.DataSource = null;
            string sql =" " +
            " SELECT iidCategoriaMateriPrima ID, vchCodigo Código, vchDescripcion Categoría, Convert(VARCHAR(10),dfechaIn,103) Fecha, Convert(VARCHAR(10),dfechaIn,103) FechaActualización  " +
            " FROM catCategoriasMateriaPrima (NOLOCK) " +
            " WHERE iidEstatus = 1 ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = true;
                dataGridView1.Columns["Código"].Width = 100;
                dataGridView1.Columns["Código"].ReadOnly = true;
                dataGridView1.Columns["Categoría"].Width = 200;
                dataGridView1.Columns["Categoría"].ReadOnly = true;
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

        private void Form_List_CategoriaMateriaPrima_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idCategoria = row.Cells["ID"].Value.ToString();
                Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima(idCategoria);
                frm.CargaLista += new Form1.MessageHandler(CargaLista);
                frm.ShowDialog();
            }
        }
    }
}
