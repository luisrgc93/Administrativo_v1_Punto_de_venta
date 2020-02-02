using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos.Local
{
    class Class_AreasLocation
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        
        public DataTable getListaAreas(string id)
        {
            string sql = "select iidArea, vchNombre from catAreas where iidArea >= " + id;
            return conx.Consultasql(sql);
        }
        public DataTable GetListaMesas(int id, string idMesa)
        {
            string sql = " select distinct M.iidMesa, M.vchDescripcion + ' (' + cast(iTamanoX as varchar(10)) +', '+ cast(iTamanoY as varchar(10)) + ') ' as descripcion, Count(P.iidPedido) siPedido, M.iPosicionX, M.iPosicionY, M.iTamanoX, M.iTamanoY from catMesas M " +
                         " left outer join catPedidos P on P.iidMesa = M.iidMesa and P.SiPagado != 1 where M.iidArea = " + id +
                         " and M.iidEstatus = 1 and M.iidMesa >= " + idMesa + " group by M.iidMesa, M.vchDescripcion, P.iidPedido, M.iPosicionX, M.iPosicionY, M.iTamanoX, M.iTamanoY";
            return conx.Consultasql(sql);
        }
        public bool existePedido(int idMesa)
        {
            string sql = "select iidPedido from catPedidos where iidMesa = " + idMesa;
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }

        public bool tieneMeseroAtendiendo(int idMesa)
        {
            string sql = "select top 1 iidPersonal from catPedidos where iidMesa = " + idMesa;
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }

        public bool atendidoEsteMesero(int idMesa, string idMesero)
        {
            string sql = "select top 1 iidPersonal from catPedidos where iidMesa = " + idMesa + " and iidPersonal = " + idMesero;
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }

        public string getidArea(int id)
        {
            string sql = "select iidArea from catMesas where iidMesa = " + id;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidArea"].ToString();
            }
            catch
            {
                return "";
            }
        }
        
        public string getNombreMesa(int id)
        {
            string sql = "select vchDescripcion from catMesas where iidMesa = " + id;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["vchDescripcion"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public string getNombreArea(int id)
        {
            string sql = "select vchNombre from catAreas where iidArea = " + id;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["vchNombre"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool restaurarPosicionMesas(int idArea)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "update catMesas set iPosicionX = '', iPosicionY='' where iidArea = " + idArea;

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
        public bool tieneAreaImagen(int idArea)
        {
            string sql = "select * from catAreas where iidArea = " + idArea;
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }
        public bool nuevoTamano(string idMesa, string idTamanox, string idTamanoY)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "update catMesas set iTamanoX = " + idTamanox + ", iTamanoY =" + idTamanoY + " where iidMesa = " + idMesa;

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
        public string getTamanoX(string idTamano)
        {
            string sql = "select iTamanoX from catTamanoMesas where iidTamano =  " + idTamano;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iTamanoX"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public string getTamanoY(string idTamano)
        {
            string sql = "select iTamanoY from catTamanoMesas where iidTamano =  " + idTamano;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iTamanoY"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public string getImagenArea(int id)
        {
            string sql = "select vchRuta from catAreas where iidArea = " + id;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["vchRuta"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public DataTable getTamanossAll()
        {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidTamano AS id, vchDescripcion + ' (' + cast(iTamanoX as varchar(10)) +', '+ cast(iTamanoY as varchar(10)) + ') ' AS nombre FROM catTamanoMesas ";

            return conx.Consultasql(sql);
        }
    }
}
