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
    public partial class Form_List_Empresas : Form
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        BindingSource bs = new BindingSource();

        public Form_List_Empresas()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            Formularios.Administracion.Form_Empresas frm = new Formularios.Administracion.Form_Empresas("");
            frm.ShowDialog();
        }

        private void Form_List_Empresas_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 6;
            CargaListaAllEmpre();
        }

        private void CargaListaAllEmpre()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " " +
                " SELECT iidEmpresa Id, vchAlias [Nombre Comercial], "+
	            " vchRazon [Razon Social], vchRFC RFC, vchCalle+' '+vchNumExt+' '+vchNumInt as Domicilio, "+
	            " vchColonia Colonia, vchMunicipio Municipio, vchCP CP, vchTelefono Telefono "+
                " FROM catEmpresas " +
                " ORDER BY dFechaIn DESC";

            SqlDataAdapter areas = new SqlDataAdapter(sql, conx.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Nombre Comercial"].Width = 150;
                dataGridView1.Columns["Razon Social"].Width = 150;
                dataGridView1.Columns["RFC"].Width = 130;
                dataGridView1.Columns["Domicilio"].Width = 150;
                dataGridView1.Columns["Colonia"].Width = 150;
                dataGridView1.Columns["Municipio"].Width = 150;
                dataGridView1.Columns["CP"].Width = 50;
                dataGridView1.Columns["Telefono"].Width = 130;

                dataGridView1.Columns["Nombre Comercial"].ReadOnly = true;
                dataGridView1.Columns["Razon Social"].ReadOnly = true;
                dataGridView1.Columns["RFC"].ReadOnly = true;
                dataGridView1.Columns["Domicilio"].ReadOnly = true;
                dataGridView1.Columns["Colonia"].ReadOnly = true;
                dataGridView1.Columns["Municipio"].ReadOnly = true;
                dataGridView1.Columns["Telefono"].ReadOnly = true;
                dataGridView1.Columns["CP"].ReadOnly = true;


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

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Administracion.Form_Empresas frm = new Formularios.Administracion.Form_Empresas("");
            frm.CargaListaAllEmpre += new Form1.MessageHandler(CargaListaAllEmpre);
            frm.ShowDialog();
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
                            string id = registro.Cells[1].Value.ToString();
                            Formularios.Administracion.Form_Empresas frm = new Formularios.Administracion.Form_Empresas(id);
                            frm.CargaListaAllEmpre += new Form1.MessageHandler(CargaListaAllEmpre);
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
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string id = row.Cells["Id"].Value.ToString();
                Formularios.Administracion.Form_Empresas frm = new Formularios.Administracion.Form_Empresas(id);
                frm.CargaListaAllEmpre += new Form1.MessageHandler(CargaListaAllEmpre);
                frm.ShowDialog();
            }
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow iRow in dataGridView1.Rows){
                iRow.Cells[0].Value = false;
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" [Nombre Comercial]+' '+[Razon Social]+' '+RFC+' '+Regimen+' '+Domicilio+' '+Colonia+' '+Municipio+' '+Municipio+' '+CP+' '+Telefono LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}

