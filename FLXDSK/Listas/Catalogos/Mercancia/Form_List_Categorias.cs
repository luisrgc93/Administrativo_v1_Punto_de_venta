using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FLXDSK.Listas
{
    public partial class Form_List_Categorias : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Mercancia.Class_Categorias ClsCat = new Classes.Catalogos.Mercancia.Class_Categorias();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Categorias()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Categorias frm = new Formularios.Catalogos.Mercancia.Form_Categorias("");
            frm.Lista_Categoria += new Form1.MessageHandler(Lista_Categoria);
            frm.ShowDialog();
        }

        private void Lista_Categoria()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView_Lista.DataSource = null;
            string sql = " SELECT iidCategoria ID, CONVERT(varchar(10),dfechaIn,103)Creado, vchNombre Nombre, vchDescripcion Descripcion " +
                         " FROM catCategorias (NOLOCK) " +
                         " WHERE iidEstatus = 1 " +
                         " ORDER BY dfechaUp DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["ID"].Width = 80;
                dataGridView_Lista.Columns["ID"].Visible = false;
                dataGridView_Lista.Columns["Creado"].Width = 150;
                dataGridView_Lista.Columns["Creado"].ReadOnly = true;
                dataGridView_Lista.Columns["Nombre"].Width = 190;
                dataGridView_Lista.Columns["Nombre"].ReadOnly = true;
                dataGridView_Lista.Columns["Descripcion"].Width = 300;
                dataGridView_Lista.Columns["Descripcion"].ReadOnly = true;

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
                row_Excepcion["vchLugar"] = "Form_List_Categorias";
                row_Excepcion["vchAccion"] = "Cargar lista_Categorias()";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
            }
            bs.DataSource = dataGridView_Lista.DataSource;

        }

        private void Form_List_Categorias_Load(object sender, EventArgs e)
        {
            Lista_Categoria();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            //Valida que haya mas de un registro seleccionado  
            int contador = 0;
            //Finaliza modo de edicion
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
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
                dataGridView_Lista.EndEdit();
                foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            ClsCat.borrar_categoria(registro.Cells["ID"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Categoria();
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;

            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
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
                dataGridView_Lista.EndEdit();
                foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string iidCategoria = registro.Cells["ID"].Value.ToString();
                            Formularios.Catalogos.Mercancia.Form_Categorias frm = new Formularios.Catalogos.Mercancia.Form_Categorias(iidCategoria);
                            frm.Lista_Categoria += new Form1.MessageHandler(Lista_Categoria);
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
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string iidCategoria = row.Cells["ID"].Value.ToString();
                Formularios.Catalogos.Mercancia.Form_Categorias frm = new Formularios.Catalogos.Mercancia.Form_Categorias(iidCategoria);
                frm.Lista_Categoria += new Form1.MessageHandler(Lista_Categoria);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Nombre+' '+Descripcion LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }
    }
}
