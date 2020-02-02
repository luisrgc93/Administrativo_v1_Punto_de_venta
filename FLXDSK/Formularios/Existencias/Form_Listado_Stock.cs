using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FLXDSK.Formularios.Existencias
{
    public partial class Form_Listado_Stock : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        BindingSource bs = new BindingSource();
        public Form_Listado_Stock()
        {
            InitializeComponent();
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Listado_Stock_Load(object sender, EventArgs e)
        {
            lista_stock();
        }

        public void lista_stock()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT P.vchDescripcion Nombre, P.vchCodigo Codigo, " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " WHEN U.iidUnidad = 2 THEN SUM(E.fCantidad) / 29.574 " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " WHEN U.iidUnidad = 4 THEN SUM(E.fCantidad) / 1 " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " ELSE SUM(E.fCantidad) / 1000 END AS Cantidad,  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) < 1000 THEN 'Mililitros' " +
             " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) >= 1000 THEN 'Kilos' " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) >= 1000 THEN 'Litros' " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) < 1000 THEN 'Gramos' " +
             " END AS Unidad,  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
             " WHEN U.iidUnidad = 2 THEN P.fStockMinimo / 29.574 " +
             " WHEN U.iidUnidad = 3 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
             " WHEN U.iidUnidad = 4 THEN P.fStockMinimo / 1 " +
             " WHEN U.iidUnidad = 5 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
             " ELSE P.fStockMinimo / 1000 END AS [Stock Minimo],  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND P.fStockMinimo >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 1 AND P.fStockMinimo < 1000 THEN 'Mililitros' " +
             " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
             " WHEN U.iidUnidad = 3 AND P.fStockMinimo >= 1000 THEN 'Kilos' " +
             " WHEN U.iidUnidad = 3 AND P.fStockMinimo < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 5 AND P.fStockMinimo >= 1000 THEN 'Litros' " +
             " WHEN U.iidUnidad = 5 AND P.fStockMinimo < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND P.fStockMinimo >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND P.fStockMinimo < 1000 THEN 'Gramos' " +
             " END AS [Unidad Stock] " +
             " FROM catExistencias E " +
             " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
             " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " +
             " AND E.fCantidad < P.fStockMinimo " +
             " GROUP BY P.iidProducto, P.vchDescripcion, P.vchCodigo, U.iidUnidad, U.vchNombre, P.fStockMinimo " +
             " UNION ALL " +
             " SELECT M.vchDescripcion Nombre, M.vchCodigo Codigo, " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " WHEN U.iidUnidad = 2 THEN SUM(E.fCantidad) / 29.574 " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " WHEN U.iidUnidad = 4 THEN SUM(E.fCantidad) / 1 " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
             " ELSE SUM(E.fCantidad) / 1000 END AS Cantidad,  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) < 1000 THEN 'Mililitros' " +
             " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) >= 1000 THEN 'Kilos' " +
             " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) >= 1000 THEN 'Litros' " +
             " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) < 1000 THEN 'Gramos' " +
             " END AS Unidad,  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
             " WHEN U.iidUnidad = 2 THEN M.fStockMinimo / 29.574 " +
             " WHEN U.iidUnidad = 3 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
             " WHEN U.iidUnidad = 4 THEN M.fStockMinimo / 1 " +
             " WHEN U.iidUnidad = 5 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
             " ELSE M.fStockMinimo / 1000 END AS [Stock Minimo],  " +
             " CASE  " +
             " WHEN U.iidUnidad = 1 AND M.fStockMinimo >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 1 AND M.fStockMinimo < 1000 THEN 'Mililitros' " +
             " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
             " WHEN U.iidUnidad = 3 AND M.fStockMinimo >= 1000 THEN 'Kilos' " +
             " WHEN U.iidUnidad = 3 AND M.fStockMinimo < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 5 AND M.fStockMinimo >= 1000 THEN 'Litros' " +
             " WHEN U.iidUnidad = 5 AND M.fStockMinimo < 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND M.fStockMinimo >= 1000 THEN U.vchNombre " +
             " WHEN U.iidUnidad = 6 AND M.fStockMinimo < 1000 THEN 'Gramos' " +
             " END AS [Unidad Stock] " +
             " FROM catExistenciasMateriaPrima E " +
             " INNER JOIN catMateriaPrima M ON E.iidMateriPrima = M.iidMateriPrima " +
             " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " +
             " AND E.fCantidad < M.fStockMinimo " +
             " GROUP BY M.iidMateriPrima, M.vchDescripcion, M.vchCodigo, U.iidUnidad, U.vchNombre, M.fStockMinimo ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                
                dataGridView1.Columns["Codigo"].Width = 80;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].Width = 178;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Cantidad"].Visible = false;
                dataGridView1.Columns["Unidad"].Visible = false;
                dataGridView1.Columns["Stock Minimo"].Visible = false;
                dataGridView1.Columns["Unidad Stock"].Visible = false;

            }
            catch
            { }
            bs.DataSource = dataGridView1.DataSource;
        }

        private void Form_Listado_Stock_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
