using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using System.IO;

namespace FLXDSK.Classes.DataSet
{
    class Class_Factura
    {
        public string MsgError = "";
        public DSCHEFCONTROL ds;
        DataTable dataProd, DtEmisor, DtHeaderFac, DtTimbre, DtReceptor, DtImpuestos;
        DataRow drow;
        public string NamePdf = "";
        public string Serie = "";
        public string Folio = "";

        Classes.XML.Class_LectorXML ClsLector = new Classes.XML.Class_LectorXML();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();

        public DataTable dtEmpresa = null;

        public bool LlenaDatos(string xmlrespuesta, string idEmpresa, string vchVersion, string vchComentario, string Banco)
        {
            if (!ClsLector.ExtraXML(xmlrespuesta))
            {
                MsgError = "No se puede leer el XML";
                return false;
            }

            ds = new DSCHEFCONTROL();
            dataProd = ds.DetalleCompras;
            DtEmisor = ds.Emisor;
            DtTimbre = ds.Timbre;
            
            DtHeaderFac = ds.Header;

            DtReceptor = ds.Receptor;
            DtImpuestos = ds.Impuestos;


            CargaEmisor(idEmpresa, vchVersion);
            CargaProductos();
            CargaDatosFactura(vchVersion, vchComentario, Banco);

            NamePdf = "FAC_" + ClsLector.rfc_Receptor + "_" + ClsLector.serie + ClsLector.folio;
            Serie = ClsLector.serie;
            Folio = ClsLector.folio;

            return true;
        }
        private void CargaEmisor(string idEmpresa, string vchVersion)
        {

            drow = DtEmisor.NewRow();
            ///Ifnormacion EMPRESA
            dtEmpresa = ClsEmp.GetInfoById(idEmpresa);
            DataRow DrEmp = dtEmpresa.Rows[0];

            string tel = "";
            if (DrEmp["vchTelefono"].ToString().Trim() != "") tel = "Tel." + DrEmp["vchTelefono"].ToString();
            string mailemp = "";
            if (DrEmp["vchCorreo"].ToString().Trim() != "") mailemp = " Correo " + DrEmp["vchCorreo"].ToString();


            string DomicilioDb = DrEmp["vchCalle"].ToString().Trim() + " " + DrEmp["vchNumExt"].ToString().Trim() + " " + DrEmp["vchNumInt"].ToString().Trim() + "\n\r" +
                    DrEmp["vchColonia"].ToString().Trim() + " " + DrEmp["vchCP"].ToString().Trim() + "\n\r" +
                    DrEmp["vchMunicipio"].ToString().Trim() + " " + DrEmp["Estado"].ToString().Trim();

            ///////EMPRESA
            drow["razon_emisor"] = ClsLector.rfc_emisor + " " + ClsLector.razon_emisor;
            drow["Domicilio_DomFiscal"] = DomicilioDb;
            DtEmisor.Rows.Add(drow);
        }
        private void CargaProductos()
        {
            foreach (DataRow Rowp in ClsLector.dtProductos.Rows)
            {
                drow = dataProd.NewRow();
                try
                {
                    if (Rowp["CodigoSAT"].ToString().Trim() == "")
                        drow["codigo"] = Rowp["codigo"].ToString();
                    else
                        drow["codigo"] = Rowp["codigo"].ToString() + " Cod SAT: " + Rowp["CodigoSAT"].ToString();
                }
                catch
                {
                    drow["codigo"] = Rowp["codigo"].ToString() + " Cod SAT: " + Rowp["CodigoSAT"].ToString();
                }

                if (Rowp["MedidaSAT"].ToString().Trim() == "")
                    drow["unidad"] = Rowp["unidad"].ToString();
                else
                    drow["unidad"] = Rowp["MedidaSAT"].ToString();


                drow["descripcion"] = Rowp["descripcion"].ToString();
                drow["cantidad"] = Rowp["cantidad"].ToString();
                //drow["lote"] = "";
                drow["precio"] = Rowp["precio"].ToString();
                drow["importe"] = Rowp["importe"].ToString();

                dataProd.Rows.Add(drow);
            }
        }
        private void CargaDatosFactura(string vchVersion, string vchComentario, string Banco)
        {
            ///////-///CLIENTE            
            drow = DtReceptor.NewRow();            
            drow["rfc_Receptor"] = "R.F.C. " + ClsLector.rfc_Receptor + "\n\r" + ClsLector.razon_Receptor;
            DtReceptor.Rows.Add(drow);
            
            //Impuestos
            drow = DtImpuestos.NewRow();
            drow["importe_iva"] = ClsLector.IVA;
            DtImpuestos.Rows.Add(drow);


            QRCodeEncoder codifica = new QRCodeEncoder();
            Bitmap qrcode = codifica.Encode("?re=" + ClsLector.rfc_emisor + "&rr=" + ClsLector.rfc_Receptor + "&tt=" + ClsLector.total + "&id=" + ClsLector.UUID);
            byte[] agg = BmpToBytes_MemStream(qrcode);


            byte[] dibujoByteArray = null;
            try
            {
                DataRow row = dtEmpresa.Rows[0];
                dibujoByteArray = (byte[])row["vchimagen"];
            }
            catch
            {
            }

            //Otros
            float total_ = System.Convert.ToSingle(ClsLector.total);
            drow = DtHeaderFac.NewRow();
            drow["folio"] = ClsLector.serie + " " + ClsLector.folio;
            drow["fecha"] = ClsLector.fecha; ;
            drow["formaDePago"] = ClsLector.formaDePago;
            drow["metodoDePago"] = ClsLector.metodoDePago;
            drow["noCertificado"] = ClsLector.noCertificado;
            drow["total"] = ClsLector.total;
            drow["subTotal"] = ClsLector.subTotal;
            drow["sello"] = ClsLector.sello;
            drow["regimen"] = ClsLector.regimen;
            drow["importe_letra"] = ClsLector.importeLetra;
            drow["comentarios"] = vchComentario;
            drow["qr"] = agg;
            drow["cuenta"] = ClsLector.UsoCFDI;
            drow["logo"] = dibujoByteArray;
            DtHeaderFac.Rows.Add(drow);


            
            //EXPEDIDO
            //drow["expedido"] = " " + ClsLector.LugarExpedicion;

            ///OTROS
            

           



            ///////Timbre
            drow = DtTimbre.NewRow();
            drow["UUID"] = ClsLector.UUID.ToUpper();
            drow["selloSAT"] = ClsLector.selloSAT;
            drow["noCertificadoSAT"] = ClsLector.noCertificadoSAT;
            drow["FechaTimbrado"] = ClsLector.FechaTimbrado;
            drow["co_timbre"] = "||1.0|" + ClsLector.UUID + "|" + ClsLector.FechaTimbrado + "|" + ClsLector.sello + "|" + ClsLector.noCertificadoSAT + "||";
            DtTimbre.Rows.Add(drow);

        }



        private static byte[] BmpToBytes_MemStream(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            // Save to memory using the Jpeg format
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            // read to end
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();
            return bmpBytes;
        }
    }
}
