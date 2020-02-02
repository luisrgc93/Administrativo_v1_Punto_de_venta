using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Administracion
{
    public partial class Form_List_TipoMovimiento : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Configuracion.Class_TipoMovimiento ClsTipoMov = new Classes.Configuracion.Class_TipoMovimiento();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_TipoMovimiento()
        {
            InitializeComponent();
        }

        private void Form_List_TipoMovimiento_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        public void CargarLista()
        {

            string sql = " SELECT T.iidTipoMovimiento, CONVERT(VARCHAR(10), T.dfechaIn, 103) AS Creado, T.vchNombre Nombre, " +
                " CASE siEntrada WHEN 1 THEN 'ENTRADA' ELSE 'SALIDA' END Tipo " +
            " FROM CatTipoMovimiento T (NOLOCK) " +
            " WHERE T.iidEstatus  = 1 ORDER BY T.dfechaIn desc ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];
                
                //Se define el tamaño de las columnas
                dataGridView_Lista.Columns["iidTipoMovimiento"].Visible = false;
                dataGridView_Lista.Columns["Creado"].ReadOnly = true;
                dataGridView_Lista.Columns["Tipo"].ReadOnly = true;
                dataGridView_Lista.Columns["Nombre"].ReadOnly = true;

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
                MessageBox.Show("No hay Informacion");
            }
            bs.DataSource = dataGridView_Lista.DataSource;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Administracion.Form_TipoMovimiento frm = new Formularios.Administracion.Form_TipoMovimiento("");
            frm.CargarLista += new Form1.MessageHandler(CargarLista);
            frm.ShowDialog();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdBorrar = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdBorrar = registro.Cells["iidTipoMovimiento"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar al solo un registro.");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if (ClsTipoMov.Borrar(IdBorrar))
                {
                    MessageBox.Show("Eliminado con exito");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Problema al eliminar");
                }
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["iidTipoMovimiento"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }



            Formularios.Administracion.Form_TipoMovimiento frm = new Formularios.Administracion.Form_TipoMovimiento(IdRegistro);
            frm.CargarLista += new Form1.MessageHandler(CargarLista);
            frm.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string IdRegistro = row.Cells["iidTipoMovimiento"].Value.ToString();
                Formularios.Administracion.Form_TipoMovimiento frm = new Formularios.Administracion.Form_TipoMovimiento(IdRegistro);
                frm.CargarLista += new Form1.MessageHandler(CargarLista);
                frm.ShowDialog();
            }
        }
    }
}
