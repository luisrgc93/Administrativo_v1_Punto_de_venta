using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.herramientas
{
    public partial class Form_BuscaProducto : Form
    {
        string textoBuscar = "";

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public Form_BuscaProducto(string textoBuscar)
        {
            InitializeComponent();
            this.textoBuscar = textoBuscar;
        }

        private void Form_BuscaProducto_Load(object sender, EventArgs e)
        {
            CargaFiltro();/*
            if (textoBuscar != "")
                CargaFiltro();
            else
                CargaFiltro();*/
        }
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            if (textBox_Buscar.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un criterio de busqueda");
                return;
            }

            CargaFiltro();
        }
        private void CargaFiltro()
        {
            string filtro = "";
            if (textoBuscar != "")
            {
                filtro = " AND vchCodigo + ' ' + vchDescripcion LIKE '%" + textoBuscar.Replace(" ", "%") + "%' ";
                textoBuscar = "";
            }
            else
            {
                if (textBox_Buscar.Text.Trim() != "")
                {
                    filtro = " AND vchCodigo + ' ' + vchDescripcion LIKE '%" + textBox_Buscar.Text.Trim().Replace(" ", "%") + "%' ";
                    textBox_Buscar.Text = "";
                }
            }
            


            string sql = " SELECT iidMateriPrima, vchCodigo Codigo, vchDescripcion Producto " +
            " FROM catMateriaPrima (NOLOCK) " +
            " WHERE  iidEstatus = 1 AND siInventariar = 1 " + filtro + 
            " ORDER BY dfechaUp DESC " ;
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidMateriPrima"].Visible = false;
                dataGridView_Lista.Columns["Codigo"].ReadOnly = true;
                dataGridView_Lista.Columns["Producto"].ReadOnly = true;
            }
            catch
            {
            }
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string iidMateriPrima = row.Cells["iidMateriPrima"].Value.ToString();
                if (iidMateriPrima != "")
                {
                    try
                    {
                        Classes.Class_Session.IdBuscador = Convert.ToInt32(iidMateriPrima);
                        this.Close();
                    }
                    catch { }
                }
            }
        }

        private void textBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargaFiltro();
            }
        }

        
    }
}
