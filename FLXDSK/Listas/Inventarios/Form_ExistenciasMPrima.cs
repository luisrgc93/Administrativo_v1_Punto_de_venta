using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Inventarios
{
    public partial class Form_ExistenciasMPrima : Form
    {
        bool LoadComplete = false;
        BindingSource bs = new BindingSource();


        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();

        public Form_ExistenciasMPrima()
        {
            InitializeComponent();
        }

        private void CargaComboAlmacenes()
        {
            DataTable dtInfo = ClsAlmacen.getAlmacenesAll();
            comboBox_Almacen.DataSource = dtInfo;
            comboBox_Almacen.DisplayMember = "nombre";
            comboBox_Almacen.ValueMember = "id";
        }

        private void Form_ExistenciasMPrima_Load(object sender, EventArgs e)
        {
            CargaComboAlmacenes();
            LoadComplete = true;
        }
        private void CargaLista()
        {
            string IdAlmacen = "";
            try
            {
                IdAlmacen = comboBox_Almacen.SelectedValue.ToString();
            }
            catch { }

            if (IdAlmacen == "" || IdAlmacen == "0")
            {
                dataGridView_Lista.DataSource = null;
                return;
            }

            // " WHEN U.vchAbreviacion = 'Kg' THEN ROUND( (E.fCantidad/1000) * M.fCosto,  2) " +
              //      " WHEN U.vchAbreviacion = 'Lt' THEN ROUND( (E.fCantidad/1000) * M.fCosto,  2) " +


            string sql = " " +
            " SELECT C.vchDescripcion Categoria, M.vchCodigo Codigo, M.vchDescripcion Producto, " +
                " CASE " +
                    " WHEN U.vchAbreviacion = 'Kg' THEN E.fCantidad/1000 " +
		            " WHEN U.vchAbreviacion = 'Lt' THEN E.fCantidad/1000 " +
		            " ELSE E.fCantidad " +
                " END Existencia,  M.fContenido Contenido, " +
                " U.vchNombre Medida, " +
                " M.fCosto Costo, " +
                 " CASE " +
                    " WHEN U.vchAbreviacion = 'Kg' THEN ROUND( (E.fCantidad /  M.fContenido)* M.fCosto,  2) " +
                    " WHEN U.vchAbreviacion = 'Lt' THEN ROUND( (E.fCantidad / M.fContenido) *M.fCosto,  2) " +
                     " WHEN U.vchAbreviacion = 'Pz' THEN ROUND( (E.fCantidad / M.fContenido) *M.fCosto,  2) " +
                    " ELSE ROUND( E.fCantidad * M.fCosto , 2) " +
                " END Importe  " +
            " FROM catExistenciasMateriaPrima (NOLOCK) E, catMateriaPrima M (NOLOCK), catCategoriasMateriaPrima C (NOLOCK), catUnidadesMetricas U (NOLOCK) " +
            " WHERE E.iidMateriPrima = M.iidMateriPrima " +
            " AND C.iidCategoriaMateriPrima = M.iidCategoriaMateriPrima " +
            " AND M.iidUnidad = U.iidUnidad " +
            " AND E.iidAlmacen = " + IdAlmacen;
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["Categoria"].ReadOnly = true;
                dataGridView_Lista.Columns["Codigo"].ReadOnly = true;
                dataGridView_Lista.Columns["Producto"].ReadOnly = true;
                dataGridView_Lista.Columns["Existencia"].ReadOnly = true;
                dataGridView_Lista.Columns["Medida"].ReadOnly = true;
                dataGridView_Lista.Columns["Costo"].ReadOnly = true;
                dataGridView_Lista.Columns["Importe"].ReadOnly = true;
                dataGridView_Lista.Columns["Contenido"].ReadOnly = true;
            }
            catch
            { 
            }
            bs.DataSource = dataGridView_Lista.DataSource;
        }

        private void comboBox_Almacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {
                CargaLista();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Codigo+' '+Producto LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void toolStripButton_PDF_Click(object sender, EventArgs e)
        {
            string iidAlmacen = "";
            try
            {
                iidAlmacen = comboBox_Almacen.SelectedValue.ToString();
            }
            catch { }
            if (iidAlmacen == "" || iidAlmacen == "")
            {
                MessageBox.Show("Seleccione un almacen");
                return;
            }


            Reportes.Existencias.Reporte_Existencias form = new Reportes.Existencias.Reporte_Existencias(iidAlmacen);
            form.Show();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
