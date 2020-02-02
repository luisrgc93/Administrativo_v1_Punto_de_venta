using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Catalogos.Personal
{
    public partial class Form_List_Personal : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Personal.Class_Personal ClsPer = new Classes.Catalogos.Personal.Class_Personal();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Personal()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Personal.Form_Personal frm = new Formularios.Catalogos.Personal.Form_Personal("");
            frm.lista_personal += new Form1.MessageHandler(lista_personal);
            frm.ShowDialog();
        }

        public void lista_personal()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT  iidPersonal id, PU.vchNombre Puesto, " +
                         " CONVERT(VARCHAR(10),dfechaIngreso,103) AS [Fecha de Ingreso] ,  " +
                         " CONVERT(VARCHAR(10),dfechaNacimiento,103) AS [Fecha de Nacimiento] , " +
                         " vchNombres + ' ' +  vchApellidoPat + ' '  + vchApellidoMat AS Nombre, vchDomicilio + ' '  +  " +
                         " vchNumExt + ' '  + vchNumInt + ' '  + vchColonia AS Direccion,   " +
                         " vchTelefono Telefono, " +
                         " vchSexo Sexo " +
                         " FROM CatPersonal P " +
                         " INNER JOIN catEstados E ON P.iidEstado = E.iidEstado " +
                         " INNER JOIN catPuestos PU ON P.iidPuesto = PU.iidPuesto " + 
                         " AND P.iidEstatus = 1 " +
                         " ORDER BY P.dFechaIn DESC ";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["id"].Width = 80;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["Puesto"].Width = 100;
                dataGridView1.Columns["Puesto"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].Width = 250;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Direccion"].Width = 250;
                dataGridView1.Columns["Direccion"].ReadOnly = true;
                dataGridView1.Columns["Fecha de Ingreso"].Width = 100;
                dataGridView1.Columns["Fecha de Ingreso"].ReadOnly = true;
                dataGridView1.Columns["Fecha de Nacimiento"].Width = 100;
                dataGridView1.Columns["Fecha de Nacimiento"].ReadOnly = true;
                dataGridView1.Columns["Telefono"].Width = 100;
                dataGridView1.Columns["Telefono"].ReadOnly = true;
                dataGridView1.Columns["Sexo"].Width = 100;
                dataGridView1.Columns["Sexo"].ReadOnly = true;

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

        private void Form_List_Personal_Load(object sender, EventArgs e)
        {
            lista_personal();
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
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
                            string idpersona = registro.Cells["id"].Value.ToString();
                            Formularios.Catalogos.Personal.Form_Personal frm = new Formularios.Catalogos.Personal.Form_Personal(idpersona);
                            frm.lista_personal += new Form1.MessageHandler(lista_personal);
                            frm.ShowDialog();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idpersona = row.Cells["id"].Value.ToString();
                Formularios.Catalogos.Personal.Form_Personal frm = new Formularios.Catalogos.Personal.Form_Personal(idpersona);
                frm.lista_personal += new Form1.MessageHandler(lista_personal);
                frm.ShowDialog();
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
                            ClsPer.borrar_personal(registro.Cells["id"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                lista_personal();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Puesto+' '+Correo+' '+Nombre+' '+Direccion+' '+[Codigo de Empleado]+' '+Localidad+' '+Municipio+' '+Estado+' '+[C.P.]+' '+Telefono+' '+[Estado Civil]+' '+RFC+' '+Sexo+' '+CURP LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
