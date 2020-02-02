using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Catalogos
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
                    SQL = "select P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp "+
                          " from CatPersonal P (NOLOCK) "+
                          " where P.iidEmpresa=" + empresa + " and  P.vchNombres+' '+P.vchApPaterno+' '+P.vchApMaterno+' '+P.vchCurp like '%" + texto + "%' and iidEstatus = 1";
                    break;
                case "Meseros":
                    string idpuesto = ClsPue.getName(nombre);
                    SQL = "select P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp " +
                          " from CatPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and  P.vchNombres+' '+P.vchApPaterno+' '+P.vchApMaterno+' '+P.vchCurp like '%" + texto + "%' and iidEstatus = 1 and iidPuesto = " + idpuesto;
                    break;
                case "Clientes":
                    SQL = "SELECT iidCliente,vchAlias, vchRFC, vchRazon " + 
                          "  FROM catClientes (NOLOCK) C " +
                          "  WHERE iidEstatus = 1 " +
                          "  AND vchAlias+' '+vchRFC+' '+vchRazon like '%" + texto + "%' " +
                          "  order by iidCliente desc " ;
                    break;
                case "Productos":
                    SQL = "SELECT iidProducto ID, vchDescripcion as Descripcion, fPrecio Precio " +
                          "  FROM catProductos (NOLOCK) C " +
                          "  WHERE iidEstatus = 1 " +
                          "  AND vchDescripcion+' '+vchCodigo like '%" + texto + "%' " +
                          "  order by iidProducto desc ";
                    break;
                case "Categorias":
                    SQL = "SELECT iidCategoria ID, vchNombre as Descripcion " +
                          "  FROM catCategorias (NOLOCK) C " +
                          "  WHERE iidEstatus = 1 " +
                          "  AND vchNombre like '%" + texto + "%' " +
                          "  order by iidCategoria desc ";
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
                    SQL = "select P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp " +
                          " from catPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and iidEstatus  =  1 ";
                    break;
                case "Meseros":
                    string idpuesto = ClsPue.getName(nombre);
                    SQL = "select P.iidPersonal ID, P.[vchNombres] +' '+ P.[vchApPaterno] +' '+ P.[vchApMaterno] as Nombre, " +
                          " P.vchcurp Curp " +
                          " from catPersonal P (NOLOCK) " +
                          " where P.iidEmpresa=" + empresa + " and iidPuesto = " + idpuesto + " and iidEstatus  =  1 ";
                    break;
                case "Clientes":
                    SQL = "SELECT iidCliente ID, vchAlias, vchRFC, vchRazon " +
                            " FROM catClientes (NOLOCK) C " +
                            " WHERE iidEstatus = 1 " +
                            " order by iidCliente desc ";
                    break;
                case "Productos":
                    SQL = "SELECT iidProducto ID, vchDescripcion as Descripcion, fPrecio Precio  " +
                            " FROM catProductos (NOLOCK) C " +
                            " WHERE iidEstatus = 1 " +
                            " order by iidProducto desc ";
                    break;
                case "Categorias":
                    SQL = "SELECT iidCategoria ID, vchNombre as Descripcion   " +
                            " FROM catCategorias (NOLOCK) C " +
                            " WHERE iidEstatus = 1 " +
                            " order by iidCategoria desc ";
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
