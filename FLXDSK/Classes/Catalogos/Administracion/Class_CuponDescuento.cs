using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos.Administracion
{
    class Class_CuponDescuento
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool InsertCupon(DataTable info)
        {
            string idusuario = Class_Session.Idusuario.ToString();

            DataRow row = info.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string vence = row["vence"].ToString();
            string cupon = row["cupon"].ToString();
            string cantidad = row["cantidad"].ToString();
            string empresa = row["empresa"].ToString();
            string correo = row["correo"].ToString();

            string sql = " insert into catCuponDescuento (iidEmpresa, dfechain, dfechaup, dfechaVence, vchCodigo, "+
                         " iidEstatus, iidUsuario, SiUtilizado, fdescuento, vchCorreo, vchLugar) " +
                         " values (@empresa, getdate(),getdate(),@vence,@cupon,1,  " +
                         " " + idusuario + ", 0 , @cantidad, @correo, 'LOCAL')";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@vence", SqlDbType.DateTime).Value = vence;
            cmd.Parameters.Add("@cupon", SqlDbType.Text).Value = cupon;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.Add("@empresa", SqlDbType.Int).Value = empresa;
            cmd.Parameters.Add("@correo", SqlDbType.Text).Value = correo;
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

        public bool existeCupon(string cupon)
        {
            string sql = "select iidCupon from catCuponDescuento where vchCodigo = '" + cupon + "' and SiUtilizado = 0 and CONVERT(VARCHAR(10),dfechaVence,103) > GETDATE()";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }
        public bool EliminaCupon(string id) {
            string sql = "UPDATE catCuponDescuento SET iidEstatus = 2 WHERE iidCupon = "+id;
            return Conexion.InsertaSql(sql);
        }
    }
}
