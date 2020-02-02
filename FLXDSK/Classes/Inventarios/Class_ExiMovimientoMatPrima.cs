using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Inventarios
{
    class Class_ExiMovimientoMatPrima
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();
        Classes.Inventarios.Class_DetalleAjuste ClsDetAJuste = new Class_DetalleAjuste();
        Classes.Inventarios.Class_DetalleCompra ClsDetCompra = new Class_DetalleCompra();

        Classes.Inventarios.Class_ExistenciaMP ClsExistencia = new Class_ExistenciaMP();
        



        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidMovimiento, iidAlmacen, dfechaIn, dfechaUp, iidUsuario, vchTipo, vchComentario, iNumRegistros, iidEstatus " +
            " FROM exiMovimientoMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " SELECT M.iidMovimiento, CONVERT(varchar(10),M.dfechaIn,103)dfechaIn103, " +
                " CONVERT(varchar(10),M.dfechaUp,103)dfechaUp103,  " +
                " M.iidAlmacen, A.vchNombre Almacen, " +
                " M.iidUsuario, U.vchNombre Usuario, " +
                " M.vchTipo, M.vchComentario, M.iNumRegistros, M.iidEstatus " +
            " FROM exiMovimientoMateriaPrima (NOLOCK) M , catAlmacenes A (NOLOCK), catUsuarios U (NOLOCK) " +
            " WHERE M.iidAlmacen = A.iidAlmacen " +
            " AND M.iidUsuario = U.iidUsuario " + filtro;
            return Conexion.Consultasql(sql);
        }
        public bool Eliminar(string Id, string Tipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE exiMovimientoMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMovimiento = " + Id + " AND  vchTipo='" + Tipo + "' ";
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

        public string getNextId(string vchTipo)
        {
            string sql = "SELECT CASE WHEN MAX(iidMovimiento) IS NULL THEN 1 ELSE MAX(iidMovimiento) + 1 END Idfolio FROM exiMovimientoMateriaPrima(NOLOCK) WHERE vchTipo='" + vchTipo + "'  ";
            DataTable dt = Conexion.Consultasql(sql);
            if(dt.Rows.Count == 0)
                return "0";

            return dt.Rows[0]["Idfolio"].ToString();
        }
        public bool InsertaInformacion(string iidMovimiento, string vchTipo, string vchComentario, string iNumRegistros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO exiMovimientoMateriaPrima " +
            " (iidMovimiento, dfechaIn, dfechaUp, iidUsuario, vchTipo, vchComentario, iNumRegistros, iidEstatus ) " +
            " VALUES (@iidMovimiento, GETDATE(), GETDATE(), @iidUsuario, @vchTipo, @vchComentario, @iNumRegistros, 1 )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidMovimiento", SqlDbType.Int).Value = iidMovimiento;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@vchTipo", SqlDbType.Int).Value = vchTipo;
            cmd.Parameters.Add("@vchComentario", SqlDbType.SmallInt).Value = vchComentario;
            cmd.Parameters.Add("@iNumRegistros", SqlDbType.Int).Value = iNumRegistros;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "ExiMovimientoMatPrima.Insertar");
                return false;
            }
        }

        public bool ActualizaInformacion(string iidMovimiento, string vchTipo, string vchComentario, string iNumRegistros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE exiMovimientoMateriaPrima SET vchComentario = @vchComentario, dfechaUp = GETDATE(), iidUsuario = @iidUsuario, " +
            " iNumRegistros = @iNumRegistros " +
            " WHERE iidMovimiento = " + iidMovimiento +
            " AND vchTipo = '" + vchTipo + "'";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidMovimiento", SqlDbType.Int).Value = iidMovimiento;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@vchTipo", SqlDbType.Int).Value = vchTipo;
            cmd.Parameters.Add("@vchComentario", SqlDbType.SmallInt).Value = vchComentario;
            cmd.Parameters.Add("@iNumRegistros", SqlDbType.Int).Value = iNumRegistros;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "ExiMovimientoMatPrima.Actualizar");
                return false;
            }
        }


        public bool ProcesaMovimiento(string iidMovimiento, string vchTipo, string iidAlmacen)
        {
            string sql = " UPDATE exiMovimientoMateriaPrima SET iidEstatus = 1, dfechaUp = GETDATE(), iidUsuario = " + Class_Session.Idusuario.ToString() + " " +
            " WHERE iidMovimiento = " + iidMovimiento +" AND vchTipo = '" + vchTipo + "'";
            if (!Conexion.InsertaSql(sql))
                return false;


            DataTable dtalle = ClsDetAJuste.getLista(" AND D.iidMovimiento = " + iidMovimiento + " AND D.vchTipo = '" + vchTipo + "' ");
            foreach (DataRow Row in dtalle.Rows)
            {
                ///Metemos a Existencias
                if (!ClsExistencia.InsertaInformacion(Row["iidMateriPrima"].ToString(), iidAlmacen, Row["fCantidad"].ToString(), Row["iidUnidad"].ToString(), Row["iEquivalencia"].ToString()))
                {
                    ClsLog.InsertaInformacion("iidMateriPrima: " + Row["iidMateriPrima"].ToString() + " iidAlmacen: " + iidAlmacen + " fCantidad:" + Row["fCantidad"].ToString() + " iidUnidad:" + Row["iidUnidad"].ToString() + " iEquivalencia:" + Row["iEquivalencia"].ToString(), "Problema Al inventariar ajuste");
                }
            }
            return true;
        }


    }
}
