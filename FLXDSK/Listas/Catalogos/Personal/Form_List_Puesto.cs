using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Catalogos.Personal
{
    public partial class Form_List_Puesto : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Puesto()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Personal.Form_Puestos frm = new Formularios.Catalogos.Personal.Form_Puestos("");
            frm.CargaListaPuesto += new Form1.MessageHandler(CargaListaPuesto);
            frm.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void CargaListaPuesto()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT P.iidPuesto idPuesto, convert(varchar(10),P.dFechaUp,103) Actualizacion," +
                         "  P.vchNombre Nombre, P.fPropina Propina,   E.vchEstaus Estatus " +  
                         " FROM catPuestos P, catEstatus E " +
                         " WHERE P.iidEstatus = E.iidEstatus " +  
                         " AND P.iidEstatus in (0,1) " + 
                         " ORDER BY P.dFechaIn DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL()); 
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["idPuesto"].Width = 80;
                dataGridView1.Columns["idPuesto"].Visible = false;
                dataGridView1.Columns["Nombre"].Width = 190;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Estatus"].Width = 300;
                dataGridView1.Columns["Estatus"].ReadOnly = true;
                dataGridView1.Columns["Propina"].ReadOnly = true;
                dataGridView1.Columns["Actualizacion"].Width = 150;
                dataGridView1.Columns["Actualizacion"].ReadOnly = true;

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

        private void Form_List_Puesto_Load(object sender, EventArgs e)
        {
            CargaListaPuesto();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idPuesto = row.Cells["idPuesto"].Value.ToString();
                if (idPuesto == "1")
                {
                    MessageBox.Show("Este Puesto no puede editarse");
                }
                else
                {
                    Formularios.Catalogos.Personal.Form_Puestos frmPuesto = new Formularios.Catalogos.Personal.Form_Puestos(idPuesto);
                    frmPuesto.CargaListaPuesto += new Form1.MessageHandler(CargaListaPuesto);
                    frmPuesto.Show();
                }
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
                            //Elimina
                            ClsPue.BorrarPuestoXId(registro.Cells["idPuesto"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                CargaListaPuesto();
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
                            string idPuesto = registro.Cells["idPuesto"].Value.ToString();
                            if (idPuesto == "1")
                            {
                                MessageBox.Show("Este puesto no se puede editar");
                            }else{
                                Formularios.Catalogos.Personal.Form_Puestos frmPuesto = new Formularios.Catalogos.Personal.Form_Puestos(idPuesto);
                                frmPuesto.CargaListaPuesto += new Form1.MessageHandler(CargaListaPuesto);
                                frmPuesto.Show();
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Nombre LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}
