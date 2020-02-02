using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_Composicion
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidProducto, iidMateriPrima, iidUsuario, dfechaIn, dfechaUp, fCantidad, iidUnidadMetrica " +
            " FROM RelProductoMateriaprima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }


        public DataTable getListaComboWhere(string filtroWhere)
        {
            string sql = "SELECT iidProducto, iidTipoProducto, siProductoDefinido, fCantidad " +
            " FROM catCombosMateriaPri (NOLOCK) " + filtroWhere;

            return Conexion.Consultasql(sql);
        }

        public bool SumaInformacion(string iidProducto, string iidMateriPrima, double fCantidad, string iidUnidadMetrica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE RelProductoMateriaprima iidUsuario = @iidUsuario,  dfechaUp = GETDATE(), fCantidad = fCantidad + @fCantidad " +
            " WHERE iidProducto = " + iidProducto + " AND iidMateriPrima =  " + iidMateriPrima;

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float);
            //
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
            cmd.Parameters["@fCantidad"].Value = fCantidad;
            
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertaInformacion(string iidProducto, string iidMateriPrima, double fCantidad, string iidUnidadMetrica)
        {
            DataTable dtExis = getListaWhere(" WHERE iidProducto = " + iidProducto + " AND iidMateriPrima = " + iidMateriPrima);
            if(dtExis.Rows.Count > 0)
                return SumaInformacion(iidProducto, iidMateriPrima, fCantidad, iidUnidadMetrica);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO RelProductoMateriaprima (iidProducto, iidMateriPrima, iidUsuario, dfechaIn, dfechaUp, fCantidad, iidUnidadMetrica) " +
            " VALUES  (@iidProducto,@iidMateriPrima, @iidUsuario, GETDATE(),GETDATE(),@fCantidad,@iidUnidadMetrica)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidProducto", SqlDbType.Int);
            cmd.Parameters.Add("@iidMateriPrima", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float);
            cmd.Parameters.Add("@iidUnidadMetrica", SqlDbType.Int);

            ///
            cmd.Parameters["@iidProducto"].Value = iidProducto;
            cmd.Parameters["@iidMateriPrima"].Value = iidMateriPrima;
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
            cmd.Parameters["@fCantidad"].Value = fCantidad;
            cmd.Parameters["@iidUnidadMetrica"].Value = iidUnidadMetrica;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Clear_Composicion(string iidProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "DELETE FROM RelProductoMateriaprima WHERE iidProducto = " + iidProducto;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CrearCombo(string id, string idProductocombo, string productoDefinido,string cantidad)
        {
             

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO catCombosMateriaPri(iidProducto, iidTipoProducto, siProductoDefinido, fCantidad) VALUES (" +
               id + "," + idProductocombo + "," + productoDefinido + ","+cantidad+")";
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

       
       
        public bool Clear_Combo(string iidProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "DELETE FROM catCombosMateriaPri WHERE iidProducto = " + iidProducto;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        
        /*
        public bool GuardarTemporalRelProductoMateriaPrima(DataTable Info)
        {
            DataRow Row = Info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = " insert into tempProductoMateriaPrima values (@idProducto,@idMateriaPrima)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idProducto", SqlDbType.Int);
            cmd.Parameters.Add("@idMateriaPrima", SqlDbType.Int);

            ///
            cmd.Parameters["@idProducto"].Value = Row["idProducto"].ToString();            
            cmd.Parameters["@idMateriaPrima"].Value = Row["idMateriaPrima"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }*/

    }
}
