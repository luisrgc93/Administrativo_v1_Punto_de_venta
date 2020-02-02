using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Listas.Administracion
{
    public partial class Form_List_Roles : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Herramientas.Class_Roles ClsRol = new Classes.Herramientas.Class_Roles();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public Form_List_Roles()
        {
            InitializeComponent();
        }

        public void CargarListaRoles()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT R.iidRol, R.vchNombre Nombre,  " +
                         " CONVERT(VARCHAR(10), R.dFechaIn, 103) AS Fecha " +
                         " FROM catRoles R, catUsuarios U " +
                         " WHERE U.iidUsuario = R.iidUsuario " +
                         " AND R.iidEstatus = 1 ORDER BY R.iidRol desc ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["iidRol"].Width = 80;
                dataGridView1.Columns["iidRol"].Visible = false;
                dataGridView1.Columns["Nombre"].Width = 300;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Fecha"].Width = 190;
                dataGridView1.Columns["Fecha"].ReadOnly = true;

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

        private void Form_List_Roles_Load(object sender, EventArgs e)
        {
            CargarListaRoles();
        }

        private void toolStripButton_Add_Click_1(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Roles frm = new Formularios.Catalogos.Form_Roles("");
            frm.CargarListaRoles += new Form1.MessageHandler(CargarListaRoles);
            frm.ShowDialog();
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
                            //Elimina apoyos
                            ClsRol.DeleteRol(registro.Cells["iidRol"].Value.ToString());
                            ClsRol.DeleteRelUsuarioOpcion(registro.Cells["iidRol"].Value.ToString());                        
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                CargarListaRoles();
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
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
                            string iidRol = registro.Cells["iidRol"].Value.ToString();
                            Formularios.Catalogos.Form_Roles frm = new Formularios.Catalogos.Form_Roles(iidRol);
                            frm.CargarListaRoles += new Form1.MessageHandler(CargarListaRoles);
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            string iidRol = row.Cells["iidRol"].Value.ToString();
            Formularios.Catalogos.Form_Roles frmApo = new Formularios.Catalogos.Form_Roles(iidRol);
            frmApo.CargarListaRoles += new Form1.MessageHandler(CargarListaRoles);
            frmApo.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
