using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Inventarios
{
    class Class_ProcesoTraspaso
    {

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        Classes.Inventarios.Class_ExistenciaMP ClsExistencia = new Class_ExistenciaMP();

        public string  CuentaConLaExistencia(string IdTraspaso, string idOrigen)
        {
            string sql = "SELECT D.iidMateriPrima, D.fCantidad_Enviada, E.fCantidad, " +
                " M.vchCodigo, M.vchDescripcion " +
            " FROM DetalleTraspaso D (NOLOCK), catExistenciasMateriaPrima E (NOLOCK), catMateriaPrima M (NOLOCK) " +
            " WHERE D.iidMateriPrima = E.iidMateriPrima " +
            " AND D.iidMateriPrima = M.iidMateriPrima " +
            " AND E.iidAlmacen = " +idOrigen  +
            " AND D.iidFolio = " + IdTraspaso;
            DataTable dtTable = Conexion.Consultasql(sql);
            if (dtTable.Rows.Count == 0)
                return "";

            string Resp = "";
            foreach (DataRow Row in dtTable.Rows)
            {
                double Envia = Convert.ToDouble(Row["fCantidad_Enviada"].ToString());
                double Tiene = Convert.ToDouble(Row["fCantidad"].ToString());
                string Codigo = Row["vchCodigo"].ToString();
                string Descripcion = Row["vchDescripcion"].ToString();

                if (Envia > Tiene)
                {
                    Resp += Descripcion + ", sin existencias suficientes.\n\r";
                }
            }

            return Resp;
        }
        public bool QuitaExistenciaTraspaso(string IdTraspaso, string idOrigen)
        {
            string sql = "UPDATE  catExistenciasMateriaPrima SET fCantidad = E.fCantidad - D.fCantidad_Enviada " +
            " FROM DetalleTraspaso D (NOLOCK), catExistenciasMateriaPrima E (NOLOCK) " +
            " WHERE D.iidMateriPrima = E.iidMateriPrima " +
            " AND E.iidAlmacen = " + idOrigen +
            " AND D.iidFolio = " + IdTraspaso;
            return Conexion.InsertaSql(sql);
        }

        public bool ProcesaRecepcion(string IdTraspaso, string idDestino)
        {
            string sql = "SELECT D.iidMateriPrima, D.fCantidad_Enviada, M.iidUnidad, U.iEquivalencia " +
            " FROM DetalleTraspaso D (NOLOCK), catMateriaPrima M (NOLOCK), catUnidadesMetricas U (NOLOCK) " +
            " WHERE D.iidMateriPrima = M.iidMateriPrima " +
            " AND M.iidUnidad = U.iidUnidad " +
            " AND D.iidFolio = " + IdTraspaso;
            DataTable dtTable = Conexion.Consultasql(sql);
            if (dtTable.Rows.Count == 0)
                return true;

            
            foreach (DataRow Row in dtTable.Rows)
            {
                string Cantidad = Row["fCantidad_Enviada"].ToString();
                string iidMateriPrima = Row["iidMateriPrima"].ToString();
                string iidUnidad = Row["iidUnidad"].ToString();
                string iEquivalencia = Row["iEquivalencia"].ToString();

                ClsExistencia.InsertaInformacion(iidMateriPrima, idDestino, Cantidad, iidUnidad, iEquivalencia);
            }

            return true;
        }
    }
}
