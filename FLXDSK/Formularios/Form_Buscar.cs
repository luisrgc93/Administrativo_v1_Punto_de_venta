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
    public partial class Form_Buscar : Form
    {
        string nombre = "";

        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();
        

        //Se declara un evento de tipo MessageHandler
        //public event Form1.MessageHandler CargarFac;

        public Form_Buscar(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
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
                case "Personal":
                    SQL = "select top 100 P.iidPersonal ID, P.[vchNombres] +' '+ P.vchApellidoPat +' '+ P.vchApellidoMat as Nombre, " +
                          " P.vchcurp Curp "+
                          " from CatPersonal P (NOLOCK) "+
                          " where P.iidEmpresa=" + empresa + " and  P.vchNombres+' '+P.vchApellidoPat+' '+P.vchApellidoMat+' '+P.vchCurp like '%" + texto + "%' and iidEstatus = 1";
                    break;
                case "Meseros":
                    string idpuesto = ClsPue.getName(nombre);
                    SQL = "select P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp " +
                          " from CatPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and  P.vchNombres+' '+P.vchApPaterno+' '+P.vchApMaterno+' '+P.vchCurp like '%" + texto + "%' and iidEstatus = 1 and iidPuesto = " + idpuesto;
                    break;
                case "Materia Prima":
                    SQL = " SELECT iidMateriPrima, vchCodigo, vchDescripcion " +
                          " FROM catMateriaPrima " +
                          " WHERE iidEstatus = 1 AND vchCodigo+' '+vchDescripcion like '%" + texto + "%'";
                    break;
                case "Proveedores":
                    SQL = " SELECT P.iidProveedor, P.vchRazonSocial, P.vchNombreComercial " +
                          " FROM catProveedores P " +
                          " WHERE P.iidEstatus = 1 and P.vchRazonSocial+' '+P.vchNombreComercial like '%" + texto + "%'";
                    break;
                case "Productos":
                    SQL = " SELECT iidProducto, vchCodigo, vchDescripcion " +
                          " FROM catProductos " +
                          " WHERE iidEstatus = 1 AND vchCodigo+' '+vchDescripcion LIKE '%" + texto + "%'";
                    break;
                case "Existencias Productos":
                    SQL = " E.iidProducto ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistencias E " +
                          " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND P.vchDescripcion+' '+P.vchCodigo+' '+A.vchNombre like '%" + texto + "%' ";
                    break;
                case "Existencias Materia Prima":
                    SQL = " SELECT E.iidMateriPrima ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistenciasMateriaPrima E " +
                          " INNER JOIN catMateriaPrima P ON E.iidMateriPrima = P.iidMateriPrima " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                          " AND P.vchDescripcion+' '+P.vchCodigo+' '+A.vchNombre like '%" + texto + "%'";
                    break;
                case "Clientes":
                    SQL = " SELECT iidCliente ID, vchAlias Alias, vchRazon Razon " +
                          " FROM catClientes  (NOLOCK) " +
                          " WHERE iidEstatus = 1 AND vchAlias+' '+vchRazon LIKE '%" + texto + "%' order by vchAlias asc ";
                    break;
                case "Categorias":
                    SQL = " SELECT iidCategoria ID, vchNombre Nombre " +
                          " FROM catCategorias  (NOLOCK) " +
                          " WHERE iidEstatus = 1 AND vchNombre LIKE '%" + texto + "%' order by iidCategoria asc ";
                    break;
                case "Medida SAT":
                    SQL = " SELECT iidUnidadMedida ID,vchClave+' - '+vchNombre Nombre " +
                          " FROM int_satUnidadMedida  (NOLOCK) " +
                          " WHERE iidEstatus = 1 AND vchClave+' '+vchNombre LIKE '%" + texto + "%' order by iidUnidadMedida asc ";
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
                case "Personal":
                    SQL = "select top 100 P.iidPersonal ID, P.[vchNombres] +' '+ P.vchApellidoPat +' '+ P.vchApellidoMat as Nombre, " +
                          " P.vchcurp Curp " +
                          " from catPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and iidEstatus  =  1 ORDER BY P.iidPersonal  DESC ";
                    break;
                case "Meseros":
                    string idpuesto = ClsPue.getName(nombre);
                    SQL = "select top 100 P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp " +
                          " from catPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and iidPuesto = " + idpuesto + " and iidEstatus  =  1 ORDER BY P.iidPersonal DESC ";
                    break;
                case "Materia Prima":
                    SQL = " SELECT top 100 iidMateriPrima, vchCodigo, vchDescripcion " +
                          " FROM catMateriaPrima " +
                          " WHERE iidEstatus = 1 ORDER BY iidMateriPrima DESC ";
                    break;
                case "Proveedores":
                    SQL = " SELECT top 100 P.iidProveedor, P.vchRazonSocial, P.vchNombreComercial " +
                          " FROM catProveedores P " +
                          " WHERE P.iidEstatus = 1 ORDER BY P.iidProveedor DESC ";
                    break;
                case "Productos":
                    SQL = " SELECT top 100 iidProducto, vchCodigo, vchDescripcion " +
                          " FROM catProductos " +
                          " WHERE iidEstatus = 1 ORDER BY  iidProducto DESC ";
                    break;
                case "Existencias Productos":
                    SQL = " SELECT top 100 E.iidProducto ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistencias E " +
                          " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen ORDER BY  E.iidProducto DESC ";
                    break;
                case "Existencias Materia Prima":
                    SQL = " SELECT top 100 E.iidMateriPrima ID, P.vchDescripcion Nombre, P.vchCodigo Codigo, A.vchNombre Almacen " +
                          " FROM catExistenciasMateriaPrima E " +
                          " INNER JOIN catMateriaPrima P ON E.iidMateriPrima = P.iidMateriPrima " +
                          " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen ORDER BY E.iidMateriPrima DESC ";
                    break;
                case "Clientes":
                    SQL = " SELECT top 100 iidCliente ID, vchAlias Alias, vchRazon Razon " +
                          " FROM catClientes (NOLOCK) " +
                          " WHERE iidEstatus = 1 order by iidCliente desc ";
                    break;
                case "Categorias":
                    SQL = " SELECT top 100 iidCategoria ID, vchNombre Nombre " +
                          " FROM catCategorias (NOLOCK) " +
                          " WHERE iidEstatus = 1 order by iidCategoria desc ";
                    break;
                case "Medida SAT":
                    SQL = " SELECT iidUnidadMedida ID,vchClave+' - '+vchNombre Nombre " +
                          " FROM int_satUnidadMedida  (NOLOCK) " +
                          " WHERE iidEstatus = 1 ORDER BY iidUnidadMedida ASC ";
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
                try
                {
                    string id = col[0].Value.ToString();
                    Classes.Class_Session.IdBuscador = Convert.ToInt32(id);
                    this.Close();
                }
                catch { }
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
