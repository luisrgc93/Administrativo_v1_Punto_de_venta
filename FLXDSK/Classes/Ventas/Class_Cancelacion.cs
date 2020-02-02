using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Ventas
{
    class Class_Cancelacion
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool InsertaInformacion(string iidPedido, string vchComentario)
        {
            DataTable dtRow = getListaWhere(" WHERE iidPedido = "+ iidPedido);
            if (dtRow.Rows.Count > 0)
                return CancelaVenta(iidPedido);


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = " INSERT INTO catMotivosCancelacion (iidPedido,vchComentario) VALUES (@iidPedido, @vchComentario)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidPedido", SqlDbType.Int).Value = iidPedido;
            cmd.Parameters.Add("@vchComentario", SqlDbType.VarChar).Value = vchComentario;
            try
            {
                cmd.ExecuteNonQuery();
                CancelaVenta(iidPedido);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidPedido,vchComentario FROM catMotivosCancelacion " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        private bool CancelaVenta(string iidPedido)
        {
            string sql = " UPDATE catPedidos SET iidEstatus =  2 WHERE iidPedido = " + iidPedido;
            return Conexion.InsertaSql(sql);
        }

    }
}
