using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Inventarios
{
    public partial class Form_List_Almacenes : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Inventarios.Class_Almacen ClsAlm = new Classes.Inventarios.Class_Almacen();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Almacenes()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Inventarios.Form_Almacenes frm = new Formularios.Inventarios.Form_Almacenes("");
            frm.Lista_Almacenes += new Form1.MessageHandler(Lista_Almacenes);
            frm.ShowDialog();
        }

        private void Lista_Almacenes()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT S.iidAlmacen, S.vchNombre Nombre, " +
                         " S.vchDomicilio + ' ' + S.vchNumExt + ' ' + S.vchNumInt + ' ' +  S.vchColonia AS Domicilio, " +
                         " S.vchLocalidad Localidad, S.vchCP [C.P.], S.vchMunicipio Municipio, S.vchCorreo Correo, " +
                         " S.vchTelefono Telefono, E.vchNombre Estado, P.vchNombre Pais " +
                         " FROM catAlmacenes (NOLOCK)  S, catEstados E, catPaises P " +
                         " WHERE  E.iidEstado = S.iidEstado " +
                         " AND P.iidPais = E.iidPais " +
                         " AND S.iidEstatus = 1 " +
                         " ORDER BY S.vchNombre DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["iidAlmacen"].Width = 80;
                dataGridView1.Columns["iidAlmacen"].Visible = false;
                dataGridView1.Columns["Nombre"].Width = 190;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Domicilio"].Width = 300;
                dataGridView1.Columns["Domicilio"].ReadOnly = true;
                dataGridView1.Columns["Localidad"].Width = 190;
                dataGridView1.Columns["Localidad"].ReadOnly = true;
                dataGridView1.Columns["C.P."].Width = 100;
                dataGridView1.Columns["C.P."].ReadOnly = true;
                dataGridView1.Columns["Municipio"].Width = 190;
                dataGridView1.Columns["Municipio"].ReadOnly = true;
                dataGridView1.Columns["Correo"].Width = 180;
                dataGridView1.Columns["Correo"].ReadOnly = true;
                dataGridView1.Columns["Telefono"].Width = 100;
                dataGridView1.Columns["Telefono"].ReadOnly = true;
                dataGridView1.Columns["Estado"].Width = 130;
                dataGridView1.Columns["Estado"].ReadOnly = true;
                dataGridView1.Columns["Pais"].Width = 120;
                dataGridView1.Columns["Pais"].ReadOnly = true;

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

        private void Form_List_Almacenes_Load(object sender, EventArgs e)
        {
            Lista_Almacenes();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
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
                            ClsAlm.borrar_almacen(registro.Cells["iidAlmacen"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Almacenes();
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
                            string iidAlmacen = registro.Cells["iidAlmacen"].Value.ToString();
                            Formularios.Inventarios.Form_Almacenes frm = new Formularios.Inventarios.Form_Almacenes(iidAlmacen);
                            frm.Lista_Almacenes += new Form1.MessageHandler(Lista_Almacenes);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string iidAlmacen = row.Cells["iidAlmacen"].Value.ToString();
                Formularios.Inventarios.Form_Almacenes frm = new Formularios.Inventarios.Form_Almacenes(iidAlmacen);
                frm.Lista_Almacenes += new Form1.MessageHandler(Lista_Almacenes);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Nombre+' '+Domicilio+' '+Localidad+' '+[C.P.]+' '+Municipio+' '+Correo+' '+Telefono+' '+Estado+' '+Pais LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}
