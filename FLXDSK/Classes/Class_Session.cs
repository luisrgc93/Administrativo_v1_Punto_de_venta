using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_Session
    {

        private static int idusuario;
        private static int idEmpresa;
        private static string SessionAlias;
        private static string RFC_empresa;
        private static string vchKeytimbrado;
        private static string serial;
        private static string siPrimerIngreso;
        ///////////carrito
        public static string formapago;
        public static string metodopago;
        public static string tipocfdi;
        public static string serie;
        public static string divisa;
        public static string comentario;
        public static string banco;
        public static string cuenta;
        public static string producto;
        public static string cliente;
        public static string idtmp;
        public static int idbuscador;
        public static double fnewExistencia;
        public static string Namemedida;
        public static string MateriaPrima;
        public static string idProducto;
        public static bool Isdefinido;
        public static float fCantidad;
        private static string key_serie;
        private static bool siRegistroEmpresa;
        private static string noSucursal;


        public static string NoSucursal
        {
            get { return Class_Session.noSucursal; }
            set { Class_Session.noSucursal = value; }
        }
        public static bool SiRegistroEmpresa
        {
            get { return Class_Session.siRegistroEmpresa; }
            set { Class_Session.siRegistroEmpresa = value; }
        }

        public static string Key_serie
        {
            get { return Class_Session.key_serie; }
            set { Class_Session.key_serie = value; }
        }

        public static float FCantidad
        {
            get { return Class_Session.fCantidad; }
            set { Class_Session.fCantidad = value; }
        }


        public static bool isDefinido
        {
            get { return Class_Session.Isdefinido; }
            set { Class_Session.Isdefinido = value; }
        }

        public static string Idproducto
        {
            get { return Class_Session.idProducto; }
            set { Class_Session.idProducto = value; }
        }
        public static DataTable dtParametros;

        public static DataTable dtParamConf
        {
            get { return Class_Session.dtParametros; }
            set { Class_Session.dtParametros = value; }
        }

        public static int IdBuscador
        {
            get { return Class_Session.idbuscador; }
            set { Class_Session.idbuscador = value; }
        }
        public static double fNewExistencia
        {
            get { return Class_Session.fnewExistencia; }
            set { Class_Session.fnewExistencia = value; }
        }
        public static string NameMedida
        {
            get { return Class_Session.Namemedida; }
            set { Class_Session.Namemedida = value; }
        }

        public static int Idusuario
        {
            get { return Class_Session.idusuario; }
            set { Class_Session.idusuario = value; }
        }

        public static string siPrimeroIngreso
        {
            get { return Class_Session.siPrimerIngreso; }
            set { Class_Session.siPrimerIngreso = value; }
        }

        public static int IDEMPRESA
        {
            get { return Class_Session.idEmpresa; }
            set { Class_Session.idEmpresa = value; }
        }
        public static string SessAlias
        {
            get { return Class_Session.SessionAlias; }
            set { Class_Session.SessionAlias = value; }
        }
        public static string RFC_Empresa
        {
            get { return Class_Session.RFC_empresa; }
            set { Class_Session.RFC_empresa = value; }
        }
        public static string vchKeyTimbrado
        {
            get { return Class_Session.vchKeytimbrado; }
            set { Class_Session.vchKeytimbrado = value; }
        }
        

        public static string Composicion
        {
            get { return Class_Session.MateriaPrima; }
            set { Class_Session.MateriaPrima = value; }
        }
        /// serial
        public static string Serial
        {
            get { return Class_Session.serial; }
            set { Class_Session.serial = value; }
        }
        ////////////////////////////
        public static string Formapago
        {
            get { return Class_Session.formapago; }
            set { Class_Session.formapago = value; }
        }
        public static string Metodopago
        {
            get { return Class_Session.metodopago; }
            set { Class_Session.metodopago = value; }
        }
        public static string Tipocfdi
        {
            get { return Class_Session.tipocfdi; }
            set { Class_Session.tipocfdi = value; }
        }
        public static string Serie
        {
            get { return Class_Session.serie; }
            set { Class_Session.serie = value; }
        }
        public static string Divisa
        {
            get { return Class_Session.divisa; }
            set { Class_Session.divisa = value; }
        }
        public static string Comentario
        {
            get { return Class_Session.comentario; }
            set { Class_Session.comentario = value; }
        }
        public static string Banco
        {
            get { return Class_Session.banco; }
            set { Class_Session.banco = value; }
        }
        public static string Cuenta
        {
            get { return Class_Session.cuenta; }
            set { Class_Session.cuenta = value; }
        }
        public static string Productoroducto
        {
            get { return Class_Session.producto; }
            set { Class_Session.producto = value; }
        }
        public static string Cliente
        {
            get { return Class_Session.cliente; }
            set { Class_Session.cliente = value; }
        }
        public static string Idtmp
        {
            get { return Class_Session.idtmp; }
            set { Class_Session.idtmp = value; }
        }
       
    }
}
