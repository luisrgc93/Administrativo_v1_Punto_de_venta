using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Catalogos.Proveedores
{
    public partial class Form_List_Proveedor : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Proveedores.Class_Proveedores ClsPro = new Classes.Catalogos.Proveedores.Class_Proveedores();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Proveedor()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Proveedores.Form_Proveedores frm = new Formularios.Catalogos.Proveedores.Form_Proveedores("");
            frm.Lista_Proveedores += new Form1.MessageHandler(Lista_Proveedores);
            frm.ShowDialog();
        }

        private void Form_List_Proveedor_Load(object sender, EventArgs e)
        {
            Lista_Proveedores();
        }

        private void Lista_Proveedores()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT iidProveedor id, vchRazonSocial [Razon Social],vchNombreComercial [Nombre Comercial], " +
                         " vchObservaciones Observaciones,vchDomicilio + ' ' + vchNumExt + ' ' +vchNumInt + ' ' + vchColonia AS Direccion, " +
                         " vchTelefono Telefono,vchCorreo Correo" +
            " FROM catProveedores P  " +
            " WHERE P.iidEstatus = 1 " +
            " ORDER BY P.dfechIn DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["id"].Width = 80;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["Razon Social"].Width = 200;
                dataGridView1.Columns["Razon Social"].ReadOnly = true;
                dataGridView1.Columns["Nombre Comercial"].Width = 200;
                dataGridView1.Columns["Nombre Comercial"].ReadOnly = true;
                dataGridView1.Columns["Observaciones"].Width = 300;
                dataGridView1.Columns["Observaciones"].ReadOnly = true;
                dataGridView1.Columns["Direccion"].Width = 300;
                dataGridView1.Columns["Direccion"].ReadOnly = true;
                dataGridView1.Columns["Correo"].Width = 150;
                dataGridView1.Columns["Correo"].ReadOnly = true;
                dataGridView1.Columns["Telefono"].Width = 150;
                dataGridView1.Columns["Telefono"].ReadOnly = true;

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
                row_Excepcion["vchLugar"] = "Form_List_Clientes";
                row_Excepcion["vchAccion"] = "Cargar lista_clientes()";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
            }
            bs.DataSource = dataGridView1.DataSource;

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
                string id = row.Cells["id"].Value.ToString();
                Formularios.Catalogos.Proveedores.Form_Proveedores frm = new Formularios.Catalogos.Proveedores.Form_Proveedores(id);
                frm.Lista_Proveedores += new Form1.MessageHandler(Lista_Proveedores);
                frm.ShowDialog();
            }
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
                            ClsPro.borrar_proveedor(registro.Cells["id"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Proveedores();
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

            if (contador > 1)
            {
                MessageBox.Show("Para editar solo seleccione un registro.");
                return;
            }
            else
            {

                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string id = registro.Cells["id"].Value.ToString();
                            Formularios.Catalogos.Proveedores.Form_Proveedores frm = new Formularios.Catalogos.Proveedores.Form_Proveedores(id);
                            frm.Lista_Proveedores += new Form1.MessageHandler(Lista_Proveedores);
                            frm.ShowDialog();
                        }
                    }
                    catch
                    {

                    }
                }
            } 
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" [Razon Social]+' '+[Nombre Comercial]+' '+RFC+' '+Observaciones+' '+Direccion+' '+Municipio+' '+Estado+' '+Pais+' '+Telefono+' '+Correo LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton_Pdf_Click(object sender, EventArgs e)
        {
            toolStripButton_Add.Enabled = false;
            toolStripButton_Borrar.Enabled = false;
            toolStripButton_Edit.Enabled = false;

            splitContainer1.Panel2.Controls.Clear();
            Reportes.Catalogos.Reporte_Proveedores frmulario = new Reportes.Catalogos.Reporte_Proveedores();
            frmulario.TopLevel = false;
            frmulario.AutoScroll = true;
            frmulario.FormBorderStyle = FormBorderStyle.None;
            frmulario.WindowState = frmulario.WindowState;
            splitContainer1.Panel2.Controls.Add(frmulario);
            frmulario.Visible = true;
        }
    }
}
