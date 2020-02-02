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
    public partial class Form_Buscar_mov : Form
    {
        string nombre = "";
        string almacen = "";

        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();

        public Form_Buscar_mov(string nombre, string almacen)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.almacen = almacen;
        }

        private void Form_Buscar_Load(object sender, EventArgs e)
        {
            label1.Text = "Buscar " + nombre;
            getMeLasInfo();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string texto = txt_buscar.Text;
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string SQL = "";
            switch (nombre)
            {                
                case "Existencias Productos":
                    SQL = " SELECT E.iidProducto ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistencias E " +
                          " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND P.vchDescripcion+' '+P.vchCodigo+' '+A.vchNombre like '%" + texto + "%' " +
                          " AND  E.iidAlmacen = " + almacen;
                    break;
                case "Existencias Materia Prima":
                    SQL = " SELECT E.iidMateriPrima ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistenciasMateriaPrima E " +
                          " INNER JOIN catMateriaPrima P ON E.iidMateriPrima = P.iidMateriPrima " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND P.vchDescripcion+' '+P.vchCodigo+' '+A.vchNombre like '%" + texto + "%'" +
                          " AND  E.iidAlmacen = " + almacen;
                    break;
            }
            
            SqlDataAdapter areas = new SqlDataAdapter(SQL, conx.ConexionSQL());
            DataSet ds = new DataSet();
            areas.Fill(ds, "Datos");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No hay Informacion");
            }
            else
            {
                dataGridView1.DataSource = ds.Tables[0];
            }

        }
        private void getMeLasInfo()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string SQL = "";
            switch (nombre)
            {
                case "Existencias Productos":
                    SQL = " SELECT E.iidProducto ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistencias E " +
                          " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND  E.iidAlmacen = " + almacen;
                    break;
                case "Existencias Materia Prima":
                    SQL = " SELECT E.iidMateriPrima ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistenciasMateriaPrima E " +
                          " INNER JOIN catMateriaPrima P ON E.iidMateriPrima = P.iidMateriPrima " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND  E.iidAlmacen = " + almacen;
                    break;
            }

            SqlDataAdapter areas = new SqlDataAdapter(SQL, conx.ConexionSQL());
            DataSet ds = new DataSet();
            areas.Fill(ds, "Datos");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No hay Informacion");

            }
            else
            {
                dataGridView1.DataSource = ds.Tables[0];

            }

        }
        private void dg_mesas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedCellCollection col = this.dataGridView1.SelectedCells;
            if (col[0].Value.ToString() != "")
            {
                string id = col[0].Value.ToString();
                switch (nombre)
                {
                    case "Existencias Productos":
                        Classes.Class_Session.IdBuscador = Convert.ToInt32(id);
                        this.Close();
                        break;
                    case "Existencias Materia Prima":
                        Classes.Class_Session.IdBuscador = Convert.ToInt32(id);
                        this.Close();
                        break;
                }
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
