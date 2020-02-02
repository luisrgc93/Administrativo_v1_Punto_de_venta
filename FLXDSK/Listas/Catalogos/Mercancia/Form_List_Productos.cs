using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Catalogos.Mercancia
{
    public partial class Form_List_Productos : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Mercancia.Class_Productos ClsPro = new Classes.Catalogos.Mercancia.Class_Productos();
        Classes.Catalogos.Class_Paquete fnPaquete = new Classes.Catalogos.Class_Paquete();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Productos()
        {
            InitializeComponent();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Producto2 frm = new Formularios.Catalogos.Mercancia.Form_Producto2("");
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void CargaLista()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " " + 
            " SELECT P.vchCodigo Codigo, P.vchDescripcion Descripcion,  " +
                " UP.vchNombre Unidad, P.fCosto Costo, P.fPrecio Precio, C.vchNombre Categoria,  " + 
	            " P.iidProducto  " + 
	            " FROM catProductos P, catCategorias C,catUnidadesProductos UP    " + 
            " WHERE C.iidCategoria = P.iidCategoria  " + 
            " AND P.iidUnidad = UP.iidUnidad  " + 
            " AND P.iidEstatus = 1  " + 
            " ORDER BY P.dFechaIn DESC" ;
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["iidProducto"].Visible = false;
                dataGridView1.Columns["Codigo"].Width = 100;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["Descripcion"].Width = 300;
                dataGridView1.Columns["Descripcion"].ReadOnly = true;
                dataGridView1.Columns["Unidad"].Width = 100;
                dataGridView1.Columns["Unidad"].ReadOnly = true;
                dataGridView1.Columns["Costo"].Width = 100;
                dataGridView1.Columns["Costo"].ReadOnly = true;
                dataGridView1.Columns["Precio"].Width = 100;
                dataGridView1.Columns["Precio"].ReadOnly = true;
                dataGridView1.Columns["Categoria"].Width = 200;
                dataGridView1.Columns["Categoria"].ReadOnly = true;

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

        private void Form_List_Productos_Load(object sender, EventArgs e)
        {            
            CargaLista();
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string idRegistro = "";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        idRegistro = registro.Cells["iidProducto"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            Formularios.Catalogos.Mercancia.Form_Producto2 frm = new Formularios.Catalogos.Mercancia.Form_Producto2(idRegistro);
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string iidProducto = row.Cells["iidProducto"].Value.ToString();
                Formularios.Catalogos.Mercancia.Form_Producto2 frm = new Formularios.Catalogos.Mercancia.Form_Producto2(iidProducto);
                frm.CargaLista += new Form1.MessageHandler(CargaLista);
                frm.ShowDialog();
            }
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string idRegistro = "0";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        idRegistro +=","+ registro.Cells["iidProducto"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador <= 0)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                string[] linea = idRegistro.Split(',');
                foreach (var substring in linea)
                {
                    if(substring!="" && substring!="0")
                        if (!ClsPro.EliminaRegistro(substring))
                            MessageBox.Show("Problema al eliminar el registro");
                        
                }

                MessageBox.Show("Eliminado con exito");
                CargaLista();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            //bs.Filter = string.Format(" Codigo+' '+Descripcion+' '+Unidad+' '+Precio+ '+Categoria LIKE '%"+textBox_Buscar.Text+"%'");
            //dataGridView1.DataSource = bs;


            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = dataGridView1.Columns[2].HeaderText.ToString() + " LIKE '%" + textBox_Buscar.Text + "%'";
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton_Pdf_Click(object sender, EventArgs e)
        {
            toolStripButton_Add.Visible = false;
            toolStripButton_Borrar.Visible = false;
            toolStripButton_Edit.Visible = false;
            toolStripButton_Pdf.Visible = false;
            textBox_Buscar.Visible = false;
            pictureBox_Serch.Visible = false;

            panel_Content.Controls.Clear();
            
            Reportes.Catalogos.Reporte_Productos frm = new Reportes.Catalogos.Reporte_Productos();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel_Content.Controls.Add(frm);
        }

        private void pictureBox_Serch_Click(object sender, EventArgs e)
        {

        }

    }
}
