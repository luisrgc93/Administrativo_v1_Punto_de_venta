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
    public partial class Form_aperturass : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Class_Clientes ClsCli = new Classes.Class_Clientes();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_aperturass()
        {
            InitializeComponent();
        }

        private void Lista_Clientes()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView_Lista.DataSource = null;
            string sql = " "  +
            " SELECT C.iidCliente idCliente, C.vchAlias Alias, C.vchRFC RFC, " +
                " C.vchCalle + ' ' + C.vchNumExt + ' ' + C.vchColonia AS Direccion, " +
                " C.vchMunicipio Municipio, E.vchNombre Estado, C.vchCorreo Correo, " +
                " C.vchTelefono Telefono, C.vchNombreContacto Contacto " +
            " FROM  catClientes C, catEstados E " +
            " WHERE C.iidEstatus = 1 " +
            " AND E.iidEstado = C.iidEstado " +
            " ORDER BY C.dFechaIn DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["idCliente"].Width = 80;
                dataGridView_Lista.Columns["idCliente"].Visible = false;
                dataGridView_Lista.Columns["Alias"].Width = 200;
                dataGridView_Lista.Columns["Alias"].ReadOnly = true;
                dataGridView_Lista.Columns["RFC"].Width = 150;
                dataGridView_Lista.Columns["RFC"].ReadOnly = true;
                dataGridView_Lista.Columns["Direccion"].Width = 300;
                dataGridView_Lista.Columns["Direccion"].ReadOnly = true;
                dataGridView_Lista.Columns["Municipio"].Width = 150;
                dataGridView_Lista.Columns["Municipio"].ReadOnly = true;
                dataGridView_Lista.Columns["Estado"].Width = 150;
                dataGridView_Lista.Columns["Estado"].ReadOnly = true;
                dataGridView_Lista.Columns["Correo"].Width = 150;
                dataGridView_Lista.Columns["Correo"].ReadOnly = true;
                dataGridView_Lista.Columns["Telefono"].Width = 150;
                dataGridView_Lista.Columns["Telefono"].ReadOnly = true;
                dataGridView_Lista.Columns["Contacto"].Width = 150;
                dataGridView_Lista.Columns["Contacto"].ReadOnly = true;

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
                row_Excepcion["vchLugar"] = "Form_List_Clientes";
                row_Excepcion["vchAccion"] = "Cargar lista_clientes()";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
            }
            bs.DataSource = dataGridView_Lista.DataSource;

        }

        private void Form_List_Clientes_Load(object sender, EventArgs e)
        {
            Lista_Clientes();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Clientes frm = new Formularios.Catalogos.Form_Clientes("");
            frm.Lista_Clientes += new Form1.MessageHandler(Lista_Clientes);
            frm.ShowDialog();
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
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

            if (contador > 1)
            {
                MessageBox.Show("Para editar solo seleccione un registro.");
                return;
            }
            else
            {

                foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string idcliente = registro.Cells["idCliente"].Value.ToString();
                            Formularios.Catalogos.Form_Clientes frm = new Formularios.Catalogos.Form_Clientes(idcliente);
                            frm.Lista_Clientes += new Form1.MessageHandler(Lista_Clientes);
                            frm.ShowDialog();
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }  
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
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
                            ClsCli.deleteCliente(registro.Cells["IdCliente"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                Lista_Clientes();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string idCliente = row.Cells["idCliente"].Value.ToString();
                Formularios.Catalogos.Form_Clientes frm = new Formularios.Catalogos.Form_Clientes(idCliente);
                frm.Lista_Clientes += new Form1.MessageHandler(Lista_Clientes);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Alias+' '+RFC+' '+Direccion+' '+Municipio+' ' LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView_Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
