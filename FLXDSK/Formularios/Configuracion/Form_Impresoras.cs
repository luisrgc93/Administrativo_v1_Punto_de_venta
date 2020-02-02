using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Configuracion
{
    public partial class Form_Impresoras : Form
    {
        string vchNombre = "";
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Configuracion.Class_Impresoras ClsImpresoras = new Classes.Configuracion.Class_Impresoras();
        Classes.Configuracion.Class_CategoriaImpresoras ClsRelImpresoras = new Classes.Configuracion.Class_CategoriaImpresoras();

        public event Form1.MessageHandler Lista_Impresoras;


        public Form_Impresoras(string name)
        {
            InitializeComponent();
            vchNombre = name;
        }
        private void CargaImpresoras()
        {
            DataTable dtImpresoras = new DataTable("TablaTmes");
            dtImpresoras.Columns.Add("nombre");
            dtImpresoras.Columns.Add("id");
            DataRow dr;
            
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                dr = dtImpresoras.NewRow();
                dr[1] = strPrinter;
                dr[0] = strPrinter;
                dtImpresoras.Rows.Add(dr);
            }
            comboBox_Impresora.DataSource = dtImpresoras;
            comboBox_Impresora.DisplayMember = "nombre";
            comboBox_Impresora.ValueMember = "id";
        }
        private void Form_Impresoras_Load(object sender, EventArgs e)
        {
            CargaImpresoras();
            CargaInfoLoad();
        }

        private void CargaInfoLoad()
        {
            if (vchNombre == "")
            {
                button_Categoria.Visible = false;
                dataGridView_Lista.Enabled = false;
                textBox_Nombre.Focus();
            }
            else
            {
                DataTable dtExis = ClsImpresoras.getListaWhere(" WHERE vchImpresora ='" + vchNombre + "' ");
                if (dtExis.Rows.Count == 0)
                {
                    MessageBox.Show("Problema al obtener la informacion");
                    this.Close();
                    return;
                }

                textBox_Nombre.Text = vchNombre;
                try
                {
                    comboBox_Impresora.SelectedValue = dtExis.Rows[0]["vchPrinterUSB"].ToString();
                }
                catch { }
                CargaListaCategorias();
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Nombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un nombre para la impresora");
                return;
            }
            string IdImpresora="";
            try
            {
                IdImpresora = comboBox_Impresora.SelectedValue.ToString();
            }
            catch{}
            if(IdImpresora=="")
            {
                MessageBox.Show("Seleccione una impresora instalada");
                return;
            }

            if (vchNombre == "")
            {
                DataTable dtExis = ClsImpresoras.getListaWhere(" WHERE vchImpresora ='" + textBox_Nombre.Text.Trim() + "' ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El nombre ingresado ya existe, elige otro");
                    return;
                }

                if (ClsImpresoras.InsertaRegistro(textBox_Nombre.Text.Trim(), IdImpresora))
                {
                    MessageBox.Show("Guardada Correctamente");
                    vchNombre = textBox_Nombre.Text.Trim();

                    button_Categoria.Visible = true;
                    dataGridView_Lista.Enabled = true;

                    try
                    {
                        Lista_Impresoras();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }

            }
            else
            {
                DataTable dtExis = ClsImpresoras.getListaWhere(" WHERE vchImpresora ='" + textBox_Nombre.Text.Trim() + "' AND vchImpresora <> '" + vchNombre + "' ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El nombre ingresado ya existe, elige otro");
                    return;
                }

                if (ClsImpresoras.ActualizaRegistro(textBox_Nombre.Text.Trim(), vchNombre, IdImpresora))
                {
                    MessageBox.Show("Guardada Correctamente");
                    vchNombre = textBox_Nombre.Text.Trim();
                    try
                    {
                        Lista_Impresoras();
                    }
                    catch { }
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }

        }

        private void button_Categoria_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;
            Formularios.Form_Buscar Form = new Form_Buscar("Categorias");
            Form.ShowDialog();
            if (Classes.Class_Session.IdBuscador != 0)
            {
                DataTable Exis = ClsRelImpresoras.getListaWhere(" WHERE vchImpresora = '" + vchNombre + "' AND iidCategoria = " + Classes.Class_Session.IdBuscador);
                if (Exis.Rows.Count == 0)
                    ClsRelImpresoras.InsertaRegistro(vchNombre, Classes.Class_Session.IdBuscador.ToString());
                
                CargaListaCategorias();
            }
        }

        private void CargaListaCategorias()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView_Lista.DataSource = null;
            string sql = " SELECT R.iidCategoria, C.vchNombre " +
            " FROM RelImpresion (NOLOCK) R, catCategorias (NOLOCK) C " +
            " WHERE R.iidCategoria = C.iidCategoria " +
            " AND vchImpresora ='"+vchNombre+"' ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidCategoria"].Visible = false;
                dataGridView_Lista.Columns["vchNombre"].ReadOnly = true;
            }
            catch
            {
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string iidCategoria = row.Cells["iidCategoria"].Value.ToString();

                DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (DialogResult.OK == resultado)
                {
                    if (!ClsRelImpresoras.BorrarCategoria(vchNombre, iidCategoria))
                    {
                        MessageBox.Show("Problema al eliminar la categoria");
                        return;
                    }
                    CargaListaCategorias();
                }
            }
        }
    }
}
