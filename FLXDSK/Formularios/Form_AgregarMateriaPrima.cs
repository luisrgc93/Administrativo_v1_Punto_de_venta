using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios
{
    public partial class Form_AgregarMateriaPrima : Form
    {
        
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public event Form1.MessageHandler AgregaTempMateriaPrima;
        public Form_AgregarMateriaPrima()
        {
            InitializeComponent();
        }

        private void Form_AgregarMateriaPrima_Load(object sender, EventArgs e)
        {
            CargaLista();
            Classes.Class_Session.MateriaPrima = "";
        }
        private void CargaLista()
        {
            dataGridView1.DataSource = null;
            string sql = " " +
            " SELECT iidMateriPrima ID, vchCodigo Codigo, vchDescripcion Materia_Prima   " +
            " FROM catMateriaPrima (NOLOCK) " +
            " WHERE iidEstatus = 1 " +
            " ORDER BY dfechaUp DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Codigo"].Width = 100;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["Materia_Prima"].ReadOnly = true;
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

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Codigo+' '+Materia_Prima LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void button_CrearMP_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_MateriaPrima frm = new Formularios.Catalogos.Mercancia.Form_MateriaPrima("");
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
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


            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        Classes.Class_Session.MateriaPrima = registro.Cells["ID"].Value.ToString();
                        if (Classes.Class_Session.MateriaPrima != "")
                            AgregaTempMateriaPrima();
                        
                    }
                }
                catch { }
            }

            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Classes.Class_Session.MateriaPrima = row.Cells["ID"].Value.ToString();
                if (Classes.Class_Session.MateriaPrima != "")
                    AgregaTempMateriaPrima();
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
