using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Catalogos.Administracion
{

    class Class_Sucursales
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public bool inserta_num_sucursal(string NoSursal,string empresa, string nombreSucursal)
        { 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexion.ConexionSQL();
                string sql = " UPDATE catEmpresas SET iNumSucursal="+NoSursal+" , vchNombreSucursal='"+nombreSucursal+"' WHERE iidEmpresa=" + empresa;
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

        public bool siExisteSucursal(string NoSursal,string empresa)
        {
            string sql = " SELECT iidSucursal " +
          " FROM catSucursales " +
          " WHERE iNumeroSucursal=" + NoSursal +
          " AND iIdEmpresa=" + empresa;

           

              DataTable dt=  Conexion.Consultasql(sql);
              if (dt.Rows.Count==0)
              {
                  return false;
              }
              else if (dt.Rows.Count > 0)
              {
                  return true;
              }
              return false;
        }
       


    }
}
