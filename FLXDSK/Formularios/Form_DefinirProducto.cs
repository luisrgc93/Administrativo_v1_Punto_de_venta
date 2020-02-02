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
    public partial class Form_DefinirProducto : Form
    {
        public event Form1.MessageHandler AgregaproductoCombo;

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public Form_DefinirProducto()
        {
            InitializeComponent();
        }

        private void Form_DefinirProducto_Load(object sender, EventArgs e)
        {
            CargaLista();
        }


        private void CargaLista()
        {

            string sql = " " +
         "  select iidMateriPrima ID, vchDescripcion descripcion FROM catMateriaPrima where iidEstatus=1";
        
            dataGridView1.DataSource = null;

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["descripcion"].Width = 400;
                dataGridView1.Columns["descripcion"].FillWeight = 400;
                dataGridView1.Columns["descripcion"].ReadOnly = true;
                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";

                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }
            }
            catch(SyntaxErrorException e)
            {
                MessageBox.Show("error"+ e.ToString());
            }
            bs.DataSource = dataGridView1.DataSource;

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
           Classes.Class_Session.isDefinido = true;
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
                        Classes.Class_Session.Idproducto = registro.Cells["ID"].Value.ToString();
                        if (Classes.Class_Session.Idproducto != "")
                              AgregaproductoCombo();
                          

                    }
                }
                catch { }
            }

            this.Close();
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" ID+' '+descripcion LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

      
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Classes.Class_Session.Idproducto = row.Cells["ID"].Value.ToString();
                Classes.Class_Session.Isdefinido = true;
                if (Classes.Class_Session.Idproducto != "")
                    AgregaproductoCombo();
            }
        }
    }
}
