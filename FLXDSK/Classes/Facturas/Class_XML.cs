using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.IO;
using Chilkat;

namespace FLXDSK.Classes.Facturas
{
    class Class_XML
    {
        Classes.Class_Logs ClsLogs = new Classes.Class_Logs();
        Classes.Facturas.Class_Factura ClsFac = new Facturas.Class_Factura();
        Classes.Facturas.Class_TmpFac ClsTmp = new Class_TmpFac();

        /// Nuevos
        public string xmlgenerado = "";
        public DataTable dtEmpresa;
        public DataTable dtCliente;
        public DataTable dtCripto;
        public DataTable dtSeries;


        public string CveTipoCfdi, CveMoneda, CveMetodo, CveForma, CveUso = "";
        public string idSerie, idForma, idMetodo, IdTipoCfdi, IdDivisa = "";

        public string CondicionPago = "";
        public string CveTipoRelacion = "";
        public string vchUUIDRel = "";


        public bool genXML(double subtotal, double total, double iva, string comentario)
        {
            bool correcto = false;

            try
            {
                string fecha = ClsFac.getFecha();

                int folio = ClsFac.getFolio(idSerie);
                string VarCharserie = "";
                if (dtSeries.Rows.Count > 0)
                    VarCharserie = dtSeries.Rows[0]["vchSerie"].ToString();

                correcto = true;

                XmlDocument doc = new XmlDocument();

                XmlElement Comprobante = doc.CreateElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/3");
                Comprobante.SetAttribute("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3");
                doc.AppendChild(Comprobante);

                XmlAttribute atrib_schemaLocation = doc.CreateAttribute("schemaLocation");
                atrib_schemaLocation.Value = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd";


                Comprobante.Attributes.Append(atrib_schemaLocation);
                XmlAttribute atrib_atrib_xmlns = doc.CreateAttribute("xsi");
                atrib_atrib_xmlns.Value = "http://www.w3.org/2001/XMLSchema-instance";
                Comprobante.Attributes.Append(atrib_atrib_xmlns);


                XmlAttribute atrib_version = doc.CreateAttribute("Version");
                atrib_version.Value = "3.3";
                Comprobante.Attributes.Append(atrib_version);
                XmlAttribute atrib_fecha = doc.CreateAttribute("Fecha");
                atrib_fecha.Value = fecha;
                Comprobante.Attributes.Append(atrib_fecha);
                if (folio != 0)
                {
                    XmlAttribute atribute_folio = doc.CreateAttribute("Folio");
                    atribute_folio.Value = folio.ToString();
                    Comprobante.Attributes.Append(atribute_folio);
                }
                if (VarCharserie != "")
                {
                    XmlAttribute atribute_serie = doc.CreateAttribute("Serie");
                    atribute_serie.Value = VarCharserie;
                    Comprobante.Attributes.Append(atribute_serie);
                }

                XmlAttribute atribute_subtotal = doc.CreateAttribute("SubTotal");
                atribute_subtotal.Value = string.Format("{0:0.00}", subtotal);
                Comprobante.Attributes.Append(atribute_subtotal);

                XmlAttribute atribute_moneda = doc.CreateAttribute("Moneda");
                atribute_moneda.Value = CveMoneda;
                Comprobante.Attributes.Append(atribute_moneda);

                XmlAttribute atribute_formadepago = doc.CreateAttribute("FormaPago");
                atribute_formadepago.Value = CveForma;
                Comprobante.Attributes.Append(atribute_formadepago);



                XmlAttribute atribute_metodopago = doc.CreateAttribute("MetodoPago");
                atribute_metodopago.Value = CveMetodo;
                Comprobante.Attributes.Append(atribute_metodopago);


                XmlAttribute atribute_numCer = doc.CreateAttribute("NoCertificado");
                atribute_numCer.Value = dtCripto.Rows[0]["vchnumcertificado"].ToString();
                Comprobante.Attributes.Append(atribute_numCer);

                XmlAttribute atribute_Cer = doc.CreateAttribute("Certificado");
                atribute_Cer.Value = dtCripto.Rows[0]["vchtextcer"].ToString();
                Comprobante.Attributes.Append(atribute_Cer);

                XmlAttribute atribute_tipocomprobante = doc.CreateAttribute("TipoDeComprobante");
                atribute_tipocomprobante.Value = CveTipoCfdi;
                Comprobante.Attributes.Append(atribute_tipocomprobante);

                //string totalX = "100";
                XmlAttribute atribute_total = doc.CreateAttribute("Total");
                atribute_total.Value = string.Format("{0:0.00}", total);
                Comprobante.Attributes.Append(atribute_total);

                //LugarExpedicion
                if (dtSeries.Rows[0]["vchcp"].ToString().Trim() != "")
                {
                    XmlAttribute atribute_LugarExpedicion = doc.CreateAttribute("LugarExpedicion");
                    atribute_LugarExpedicion.Value = dtSeries.Rows[0]["vchcp"].ToString();
                    Comprobante.Attributes.Append(atribute_LugarExpedicion);
                }
                else
                {
                    XmlAttribute atribute_LugarExpedicion = doc.CreateAttribute("LugarExpedicion");
                    atribute_LugarExpedicion.Value = dtEmpresa.Rows[0]["vchcp"].ToString();
                    Comprobante.Attributes.Append(atribute_LugarExpedicion);
                }

                if (CondicionPago != "")
                {
                    XmlAttribute atribute_CondicionPago = doc.CreateAttribute("CondicionesDePago");
                    atribute_CondicionPago.Value = CondicionPago;
                    Comprobante.Attributes.Append(atribute_CondicionPago);
                }


                ///Relacion CFDI
                if (CveTipoRelacion != "" && vchUUIDRel != "")
                {
                    XmlElement CfdiRelacionados = doc.CreateElement("cfdi", "CfdiRelacionados", "http://www.sat.gob.mx/cfd/3");
                    Comprobante.AppendChild(CfdiRelacionados);

                    XmlAttribute Rel_Tipo = doc.CreateAttribute("TipoRelacion");
                    Rel_Tipo.Value = CveTipoRelacion;
                    CfdiRelacionados.Attributes.Append(Rel_Tipo);

                    XmlElement CfdiRel = doc.CreateElement("cfdi", "CfdiRelacionado", "http://www.sat.gob.mx/cfd/3");
                    CfdiRelacionados.AppendChild(CfdiRel);

                    XmlAttribute Rel_UUID = doc.CreateAttribute("UUID");
                    Rel_UUID.Value = vchUUIDRel;
                    CfdiRel.Attributes.Append(Rel_UUID);
                }



                ///////emisor----------------------------------------------------------
                XmlElement Emisor = doc.CreateElement("cfdi", "Emisor", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Emisor);

                XmlAttribute emi_rfc = doc.CreateAttribute("Rfc");
                emi_rfc.Value = dtEmpresa.Rows[0]["vchRFC"].ToString().Trim();
                Emisor.Attributes.Append(emi_rfc);
                XmlAttribute emi_nombre = doc.CreateAttribute("Nombre");
                emi_nombre.Value = dtEmpresa.Rows[0]["vchRazon"].ToString().Trim();
                Emisor.Attributes.Append(emi_nombre);
                XmlAttribute emi_Regimen = doc.CreateAttribute("RegimenFiscal");
                emi_Regimen.Value = dtEmpresa.Rows[0]["vchRegimen"].ToString().Trim();
                Emisor.Attributes.Append(emi_Regimen);


                ///////RECEPTOR----------------------------------------------------------
                XmlElement Receptor = doc.CreateElement("cfdi", "Receptor", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Receptor);

                XmlAttribute recp_rfc = doc.CreateAttribute("Rfc");
                recp_rfc.Value = dtCliente.Rows[0]["vchRFC"].ToString().Trim();
                Receptor.Attributes.Append(recp_rfc);
                XmlAttribute recp_nombre = doc.CreateAttribute("Nombre");
                recp_nombre.Value = dtCliente.Rows[0]["vchRazon"].ToString().Trim();
                Receptor.Attributes.Append(recp_nombre);
                XmlAttribute recp_uso = doc.CreateAttribute("UsoCFDI");
                recp_uso.Value = CveUso;
                Receptor.Attributes.Append(recp_uso);


                ////////////productos------------------------------
                ///////RECEPTOR----------------------------------------------------------
                XmlElement Conceptos = doc.CreateElement("cfdi", "Conceptos", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Conceptos);

                //Data Impuestos
                DataTable dtImpuestos = new DataTable();

                bool siExistioTasa16 = false;
                double TOTAL_Traslado = 0;

                DataTable dtVentas = ClsTmp.getListaWhere("");
                foreach (DataRow row in dtVentas.Rows)
                {
                    string codigo = row["Codigo"].ToString().Trim();
                    string unidad = row["Unidad"].ToString();
                    string nombre = row["Producto"].ToString().Trim();
                    double precio = Convert.ToDouble(row["Precio"].ToString().Trim());
                    double cantidad = Convert.ToDouble(row["Cantidad"].ToString().Trim());
                    double importe = Convert.ToDouble(row["Importe"].ToString().Trim());
                    double Iva = Convert.ToDouble(row["Iva"].ToString().Trim());
                    string ClaveProdServ = row["vchCodigoSat"].ToString();
                    string ClaveUnidad = row["vchClave"].ToString();
                    double Base = Convert.ToDouble(row["Base"].ToString().Trim());


                    XmlElement Concepto = doc.CreateElement("cfdi", "Concepto", "http://www.sat.gob.mx/cfd/3");
                    Conceptos.AppendChild(Concepto);

                    XmlAttribute CodSat_prod = doc.CreateAttribute("ClaveProdServ");
                    CodSat_prod.Value = ClaveProdServ;
                    Concepto.Attributes.Append(CodSat_prod);
                    XmlAttribute Medida_prod = doc.CreateAttribute("ClaveUnidad");
                    Medida_prod.Value = ClaveUnidad;
                    Concepto.Attributes.Append(Medida_prod);

                    XmlAttribute noIdentificacion_prod = doc.CreateAttribute("NoIdentificacion");
                    noIdentificacion_prod.Value = codigo;
                    Concepto.Attributes.Append(noIdentificacion_prod);
                    XmlAttribute descripcion_prod = doc.CreateAttribute("Descripcion");
                    descripcion_prod.Value = nombre;
                    Concepto.Attributes.Append(descripcion_prod);
                    XmlAttribute cantidad_prod = doc.CreateAttribute("Cantidad");
                    cantidad_prod.Value = string.Format("{0:0.000000}", cantidad);
                    Concepto.Attributes.Append(cantidad_prod);
                    XmlAttribute unidad_prod = doc.CreateAttribute("Unidad");
                    unidad_prod.Value = unidad;
                    Concepto.Attributes.Append(unidad_prod);
                    XmlAttribute precio_prod = doc.CreateAttribute("ValorUnitario");
                    precio_prod.Value = string.Format("{0:0.000000}", precio);
                    Concepto.Attributes.Append(precio_prod);
                    XmlAttribute importe_prod = doc.CreateAttribute("Importe");
                    importe_prod.Value = string.Format("{0:0.000000}", importe);
                    Concepto.Attributes.Append(importe_prod);

                    if (Iva > 0)
                    {
                        siExistioTasa16 = true;
                        string vchCodigoImpuesto = "002";

                        XmlElement Impuestos = doc.CreateElement("cfdi", "Impuestos", "http://www.sat.gob.mx/cfd/3");
                        Concepto.AppendChild(Impuestos);
                        XmlElement Traslados = doc.CreateElement("cfdi", "Traslados", "http://www.sat.gob.mx/cfd/3");
                        Impuestos.AppendChild(Traslados);

                        XmlElement Traslado = doc.CreateElement("cfdi", "Traslado", "http://www.sat.gob.mx/cfd/3");
                        Traslados.AppendChild(Traslado);

                        XmlAttribute Imp_Base = doc.CreateAttribute("Base");
                        Imp_Base.Value = string.Format("{0:0.000000}", Base);
                        Traslado.Attributes.Append(Imp_Base);

                        XmlAttribute Imp_Impuesto = doc.CreateAttribute("Impuesto");
                        Imp_Impuesto.Value = vchCodigoImpuesto;
                        Traslado.Attributes.Append(Imp_Impuesto);

                        XmlAttribute Imp_Factor = doc.CreateAttribute("TipoFactor");
                        Imp_Factor.Value = "Tasa";
                        Traslado.Attributes.Append(Imp_Factor);

                        XmlAttribute Imp_TasaOCuota = doc.CreateAttribute("TasaOCuota");
                        Imp_TasaOCuota.Value = string.Format("{0:0.000000}", "0.160000");
                        Traslado.Attributes.Append(Imp_TasaOCuota);

                        XmlAttribute Imp_Importe = doc.CreateAttribute("Importe");
                        Imp_Importe.Value = string.Format("{0:0.000000}", Iva);
                        Traslado.Attributes.Append(Imp_Importe);

                        TOTAL_Traslado += Iva;
                    }
                }

                ////importes y traspasos.
                XmlElement Impuestos_Totales = doc.CreateElement("cfdi", "Impuestos", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Impuestos_Totales);



                if (TOTAL_Traslado > 0)
                {
                    XmlAttribute impuetrasladados = doc.CreateAttribute("TotalImpuestosTrasladados");
                    impuetrasladados.Value = string.Format("{0:0.00}", TOTAL_Traslado);
                    Impuestos_Totales.Attributes.Append(impuetrasladados);

                    XmlElement Traslados = doc.CreateElement("cfdi", "Traslados", "http://www.sat.gob.mx/cfd/3");
                    Impuestos_Totales.AppendChild(Traslados);


                    if (TOTAL_Traslado > 0)
                    {

                        XmlElement Traslado = doc.CreateElement("cfdi", "Traslado", "http://www.sat.gob.mx/cfd/3");
                        Traslados.AppendChild(Traslado);

                        XmlAttribute importeTraslado = doc.CreateAttribute("Importe");
                        importeTraslado.Value = string.Format("{0:0.00}", TOTAL_Traslado);
                        Traslado.Attributes.Append(importeTraslado);


                        XmlAttribute tasaTrasladox = doc.CreateAttribute("TasaOCuota");
                        tasaTrasladox.Value = "0.160000";
                        Traslado.Attributes.Append(tasaTrasladox);

                        XmlAttribute impuestoTraslado = doc.CreateAttribute("Impuesto");
                        impuestoTraslado.Value = "002";
                        Traslado.Attributes.Append(impuestoTraslado);

                        XmlAttribute impuestoTipoFactor = doc.CreateAttribute("TipoFactor");
                        impuestoTipoFactor.Value = "Tasa";
                        Traslado.Attributes.Append(impuestoTipoFactor);

                    }


                }




                ///////////////////AccesoDisco.total = subtotal + total_iva - retencion_fle;
                XmlAttribute atribute_total2 = doc.CreateAttribute("Total");
                atribute_total2.Value = string.Format("{0:0.00}", total);
                Comprobante.Attributes.Append(atribute_total2);
                XmlAttribute atribute_subtotal2 = doc.CreateAttribute("SubTotal");
                atribute_subtotal2.Value = string.Format("{0:0.00}", subtotal);
                Comprobante.Attributes.Append(atribute_subtotal2);

                //////Impuesto HOTELES aqui va


                ///hacemos el remplace.
                string Xmlstring = doc.OuterXml;
                Xmlstring = Xmlstring.Replace("xsi=", "xmlns:xsi=");
                Xmlstring = Xmlstring.Replace("schemaLocation=", "xsi:schemaLocation=");

                //general el sello.
                string CO = GetCadenaOrignal_byxml(Xmlstring);
                if (CO == "")
                {
                    correcto = false;
                }
                string sello = ObtenerSello(CO.Trim());
                if (sello == "")
                {
                    correcto = false;
                }

                XmlAttribute atribute_sello = doc.CreateAttribute("Sello");
                atribute_sello.Value = sello;
                Comprobante.Attributes.Append(atribute_sello);

                Xmlstring = doc.OuterXml;
                Xmlstring = Xmlstring.Replace("xsi=", "xmlns:xsi=");
                Xmlstring = Xmlstring.Replace("schemaLocation=", "xsi:schemaLocation=");

                xmlgenerado = Xmlstring;


                if (correcto == true)
                {

                    double retencion_importe = 0;
                    DataTable Info = new DataTable();
                    DataRow Drw;
                    Info.Columns.Add("idSerie", System.Type.GetType("System.String"));
                    Info.Columns.Add("idDivisa", System.Type.GetType("System.String"));
                    Info.Columns.Add("idMetodo", System.Type.GetType("System.String"));
                    Info.Columns.Add("idForma", System.Type.GetType("System.String"));
                    Info.Columns.Add("idCfdi", System.Type.GetType("System.String"));
                    Info.Columns.Add("idCliente", System.Type.GetType("System.String"));
                    Info.Columns.Add("comentario", System.Type.GetType("System.String"));
                    Drw = Info.NewRow();
                    Drw["idSerie"] = idSerie;
                    Drw["idDivisa"] = IdDivisa;
                    Drw["idMetodo"] = idMetodo;
                    Drw["idForma"] = idForma;
                    Drw["idCfdi"] = IdTipoCfdi;
                    Drw["idCliente"] = dtCliente.Rows[0]["iidcliente"].ToString();
                    Drw["comentario"] = comentario;
                    Info.Rows.Add(Drw);



                    if (!ClsFac.InsertaDb(subtotal, total, iva, retencion_importe, VarCharserie, folio, xmlgenerado, fecha, Info))
                    {
                        correcto = false;
                    }
                }
            }
            catch (Exception erroxml)
            {
                ClsLogs.InsertaInformacion("Error XML", erroxml.ToString());
                correcto = false;
            }
            return correcto;
        }
        public static string GetCadenaOrignal_byxml(string xml)
        {
            string cadena_origina = "";

            try
            {
                XmlDocument myXMLPath = new XmlDocument();
                myXMLPath.LoadXml(xml);

                XslCompiledTransform myXSLTrans = new XslCompiledTransform();

                myXSLTrans.Load("xslt/cadenaoriginal_3_3.xslt");//////////////// ///////////////////////////////////////////////////////////////////////////load the Xsl 


                //string reader = myWriter.ToString();
                StringWriter sr = new StringWriter();

                myXSLTrans.Transform(myXMLPath, null, sr);
                cadena_origina = sr.ToString();
                return cadena_origina;
            }
            catch
            {
                return cadena_origina;
            }

        }
        private string ObtenerSello(string CadenaOriginal)
        {
            DataRow Drow;
            Drow = dtCripto.Rows[0];

            try
            {
                string result = "";
                string RutaArchivoCer = Drow["vchrutacer"].ToString();
                string RutaArchivoKey = Drow["vchrutakey"].ToString();
                string Contrasena = Drow["vchpass"].ToString();

                byte[] KeyByteArray = null;
                try
                {
                    KeyByteArray = (byte[])Drow["fileKey"];
                }
                catch
                {
                }


                Chilkat.PrivateKey llave = new PrivateKey();
                Chilkat.Rsa algoritmoRSA = new Rsa();
                //llave.LoadPkcs8EncryptedFile(RutaArchivoKey, Contrasena);
                llave.LoadPkcs8Encrypted(KeyByteArray, Contrasena);
                string keyPM = llave.GetXml();
                algoritmoRSA.ImportPrivateKey(keyPM);
                algoritmoRSA.LittleEndian = false;
                algoritmoRSA.Charset = "utf-8";
                algoritmoRSA.EncodingMode = "base64";

                bool numeroSerie1 = false; //RSAT34MB34N_7F1CD986683M
                bool numeroSerie2 = false; //RSAT34MB34N_2637664B634J
                bool numeroSerie3 = false; //RSAT34MB34N_3F0D2D9C642S
                bool numeroSerie4 = false; //RSAT34MB34N_7A2D7D1A680G
                bool numeroSerie5 = false; //RSAT34MB34N_7F1CD986683M

                //algoritmoRSA.UnlockComponent("RSAT34MB34N_2637664B 634J");
                //string xmltoText = fnObtenxml(RutaXML);
                //string CadenaOriginal = fnCadenaOriginal(xmltoText);
                //string CadenaOriginal = "||3.0|2012-03-08T13:23:18|ingreso|Pago en una sola exhibición|38.5208|USD|44.6841|ABC010203ABC|Juan y Asociados|Hidalgo|1589|A|Centro|BENITO JUAREZ|Quintana Roo|México|47789|TEQUILA|102|VALLARTA PTE|GUADALAJARA|Jalisco|Mexico|44110|IDE110221ID8|ITROL DEVELOPMENT SA DE CV|TEQUILA|102|VALLARTA PONIENTE|GUADALAJARA|Jalisco|México|44110|1|PZ|CAMARA|38.5208|38.5208|IVA|16.00|6.1633|6.1633||";
                string cadenaOriginalFormateada = CadenaOriginal;

                if (numeroSerie1 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7F1CD986683M"))
                {
                    //cadenaOriginalFormateada = CadenaOriginal.ToString().Replace(System.Environment.NewLine, string.Empty).Replace("\t", string.Empty);
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha256");
                    //result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else if (numeroSerie2 = algoritmoRSA.UnlockComponent("RSAT34MB34N_2637664B634J"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha256");
                }
                else if (numeroSerie3 = algoritmoRSA.UnlockComponent("RSAT34MB34N_3F0D2D9C642S"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha256");
                }
                else if (numeroSerie4 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7A2D7D1A680G"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha256");
                }
                else if (numeroSerie5 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7F1CD986683M"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha256");
                }
                else
                {
                    result = "";
                }

                result = result.Replace(System.Environment.NewLine, string.Empty).Replace("\t", string.Empty);

                return result;

            }
            catch
            {
                return "";
            }
        }


        /*
        public bool genXML(DataGridView dataGridView1, DataTable InfoFac, double Subtotal, double IVA, double Total)
        {
            bool correcto = false;

            try
            {
               
                ///Recuperando datos
                string tipoComprobante = InfoFac.Rows[0]["tipoComprobante"].ToString();
                string serie = InfoFac.Rows[0]["serie"].ToString();
                string moneda = InfoFac.Rows[0]["moneda"].ToString();
                string formdePago = InfoFac.Rows[0]["formdePago"].ToString();
                string metodoPago = InfoFac.Rows[0]["metodoPago"].ToString();
                string banco = InfoFac.Rows[0]["banco"].ToString();
                string cuenta = InfoFac.Rows[0]["cuenta"].ToString();
                string comentario = InfoFac.Rows[0]["comentario"].ToString();
                string idCliente = InfoFac.Rows[0]["idCliente"].ToString();

                string fecha = ClsFac.getFecha();
                int folio =0;
                string vchserie = "";
                if (serie != "")
                {
                    folio = ClsFac.getFolio(serie);
                    vchserie = "";// ClsSer.getMeSerieChar(serie);
                    
                }

                

                XmlDocument doc = new XmlDocument();
                //XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);//
                //doc.AppendChild(docNode);

                XmlElement Comprobante = doc.CreateElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/3");
                Comprobante.SetAttribute("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3");
                doc.AppendChild(Comprobante);

                //xsi:schemaLocation="http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv3.xsd"
                //xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"


                XmlAttribute atrib_schemaLocation = doc.CreateAttribute("schemaLocation");
                atrib_schemaLocation.Value = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd http://www.sat.gob.mx/donat http://www.sat.gob.mx/sitio_internet/cfd/donat/donat.xsd";


                Comprobante.Attributes.Append(atrib_schemaLocation);
                XmlAttribute atrib_atrib_xmlns = doc.CreateAttribute("xsi");
                atrib_atrib_xmlns.Value = "http://www.w3.org/2001/XMLSchema-instance";
                Comprobante.Attributes.Append(atrib_atrib_xmlns);


                XmlAttribute atrib_version = doc.CreateAttribute("version");
                atrib_version.Value = "3.2";
                Comprobante.Attributes.Append(atrib_version);
                XmlAttribute atrib_fecha = doc.CreateAttribute("fecha");
                atrib_fecha.Value = fecha.Replace(" ", "T");
                Comprobante.Attributes.Append(atrib_fecha);
                if (folio != 0)
                {
                    XmlAttribute atribute_folio = doc.CreateAttribute("folio");
                    atribute_folio.Value = folio.ToString();
                    Comprobante.Attributes.Append(atribute_folio);
                }
                if (serie != "")
                {
                    XmlAttribute atribute_serie = doc.CreateAttribute("serie");
                    atribute_serie.Value = "";//ClsSer.getMeSerieChar(serie);
                    Comprobante.Attributes.Append(atribute_serie);
                }
                //string subtotalx = "100";
                XmlAttribute atribute_subtotal = doc.CreateAttribute("subTotal");
                atribute_subtotal.Value = string.Format("{0:00.0000}", Subtotal);
                Comprobante.Attributes.Append(atribute_subtotal);

                XmlAttribute atribute_moneda = doc.CreateAttribute("Moneda");
                atribute_moneda.Value = "";
                Comprobante.Attributes.Append(atribute_moneda);

                XmlAttribute atribute_formadepago = doc.CreateAttribute("formaDePago");
                atribute_formadepago.Value = "";//ClsFrmPago.getMeFormaPago(formdePago);
                Comprobante.Attributes.Append(atribute_formadepago);

                XmlAttribute atribute_metodopago = doc.CreateAttribute("metodoDePago");
                atribute_metodopago.Value = "";// ClsMPago.getMeMetodoPago(metodoPago);
                Comprobante.Attributes.Append(atribute_metodopago);

                XmlAttribute atribute_numCer = doc.CreateAttribute("noCertificado");
                atribute_numCer.Value = "";//ClsCer.getMeNumCertificado();
                Comprobante.Attributes.Append(atribute_numCer);

                XmlAttribute atribute_Cer = doc.CreateAttribute("certificado");
                atribute_Cer.Value = "";//ClsCer.getMeCertificado();
                Comprobante.Attributes.Append(atribute_Cer);

                XmlAttribute atribute_tipocomprobante = doc.CreateAttribute("tipoDeComprobante");
                atribute_tipocomprobante.Value = "";// ClsTpCfdi.getMeTipoComprobante(tipoComprobante);
                Comprobante.Attributes.Append(atribute_tipocomprobante);

                //string totalX = "100";
                XmlAttribute atribute_total = doc.CreateAttribute("total");
                atribute_total.Value = string.Format("{0:00.0000}", Total);
                Comprobante.Attributes.Append(atribute_total);

                ///EMISOR
                DataTable dtEmisor = new DataTable();
                dtEmisor = null;// ClsEmp.getInfoByID(Classes.Class_Session.IDEMPRESA.ToString());
                DataRow rowEmp = dtEmisor.Rows[0];


                //LugarExpedicion
                //Informacion Expedido
                string vchCalle_Exp = "";
                string vchNumExt_Exp = "";
                string vchNumInt_Exp = "";
                string vchCP_Exp = "";
                string vchColonia_Exp = "";
                string vchMunicipio_Exp = "";
                string Pais_Exp = "";
                string Estado_Exp = "";
                if (serie != "" && serie != "0")
                {
                    DataTable dtExpedido = new DataTable();
                    dtExpedido = null;// ClsSer.getInfoExpedido(serie);
                    DataRow rowExp = dtExpedido.Rows[0];

                    XmlAttribute atribute_LugarExpedicion = doc.CreateAttribute("LugarExpedicion");
                    atribute_LugarExpedicion.Value = rowExp["vchMunicipio"].ToString() + ", " + rowExp["Estado"].ToString();
                    Comprobante.Attributes.Append(atribute_LugarExpedicion);


                    vchCalle_Exp = rowExp["vchCalle"].ToString().Trim();
                    vchNumExt_Exp = rowExp["vchNumExt"].ToString().Trim();
                    vchNumInt_Exp = rowExp["vchNumInt"].ToString().Trim();
                    vchCP_Exp = rowExp["vchCP"].ToString().Trim();
                    vchColonia_Exp = rowExp["vchColonia"].ToString().Trim();
                    vchMunicipio_Exp = rowExp["vchMunicipio"].ToString().Trim();
                    Pais_Exp = rowExp["Pais"].ToString().Trim();
                    Estado_Exp = rowExp["Estado"].ToString().Trim();
                }
                else {

                    vchCalle_Exp = rowEmp["vchCalle"].ToString().Trim();
                    vchNumExt_Exp = rowEmp["vchNumExt"].ToString().Trim();
                    vchNumInt_Exp = rowEmp["vchNumInt"].ToString().Trim();
                    vchCP_Exp = rowEmp["vchCP"].ToString().Trim();
                    vchColonia_Exp = rowEmp["vchColonia"].ToString().Trim();
                    vchMunicipio_Exp = rowEmp["vchMunicipio"].ToString().Trim();
                    Pais_Exp = rowEmp["Pais"].ToString().Trim();
                    Estado_Exp = rowEmp["Estado"].ToString().Trim();

                    XmlAttribute atribute_LugarExpedicion = doc.CreateAttribute("LugarExpedicion");
                    atribute_LugarExpedicion.Value = vchMunicipio_Exp + ", " + Estado_Exp;
                    Comprobante.Attributes.Append(atribute_LugarExpedicion);

                }
                if (cuenta != "")
                {
                    XmlAttribute atribute_NumCtaPago = doc.CreateAttribute("NumCtaPago");
                    atribute_NumCtaPago.Value = cuenta;
                    Comprobante.Attributes.Append(atribute_NumCtaPago);
                }


                



                ///////emisor----------------------------------------------------------
                XmlElement Emisor = doc.CreateElement("cfdi", "Emisor", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Emisor);

                XmlAttribute emi_rfc = doc.CreateAttribute("rfc");
                emi_rfc.Value = rowEmp["vchRFC"].ToString().Trim();
                Emisor.Attributes.Append(emi_rfc);
                if (rowEmp["vchRazon"].ToString().Trim() != "")
                {
                    XmlAttribute emi_nombre = doc.CreateAttribute("nombre");
                    emi_nombre.Value = rowEmp["vchRazon"].ToString().Trim();
                    Emisor.Attributes.Append(emi_nombre);
                }

                XmlElement DomFiscal = doc.CreateElement("cfdi", "DomicilioFiscal", "http://www.sat.gob.mx/cfd/3");
                Emisor.AppendChild(DomFiscal);

                if (rowEmp["vchCalle"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_calle = doc.CreateAttribute("calle");
                    DomFis_calle.Value = rowEmp["vchCalle"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_calle);
                }
                if (rowEmp["vchNumExt"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_numext = doc.CreateAttribute("noExterior");
                    DomFis_numext.Value = rowEmp["vchNumExt"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_numext);
                }
                if (rowEmp["vchNumInt"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_numint = doc.CreateAttribute("noInterior");
                    DomFis_numint.Value = rowEmp["vchNumInt"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_numint);
                }
                if (rowEmp["vchCP"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_cp = doc.CreateAttribute("codigoPostal");
                    DomFis_cp.Value = rowEmp["vchCP"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_cp);
                }
                if (rowEmp["vchColonia"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_colonia = doc.CreateAttribute("colonia");
                    DomFis_colonia.Value = rowEmp["vchColonia"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_colonia);
                }
                if (rowEmp["vchMunicipio"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_municipio = doc.CreateAttribute("municipio");
                    DomFis_municipio.Value = rowEmp["vchMunicipio"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_municipio);
                }
                if (rowEmp["vchLocalidad"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_localidad = doc.CreateAttribute("localidad");
                    DomFis_localidad.Value = rowEmp["vchLocalidad"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_localidad);
                }
                if (rowEmp["Estado"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_edo = doc.CreateAttribute("estado");
                    DomFis_edo.Value = rowEmp["Estado"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_edo);
                }
                if (rowEmp["Pais"].ToString().Trim() != "")
                {
                    XmlAttribute DomFis_pais = doc.CreateAttribute("pais");
                    DomFis_pais.Value = rowEmp["Pais"].ToString().Trim();
                    DomFiscal.Attributes.Append(DomFis_pais);
                }

                //Informacion Expedido
                ///////Expedido en-----------------------------------------------
                XmlElement Expedido = doc.CreateElement("cfdi", "ExpedidoEn", "http://www.sat.gob.mx/cfd/3");
                Emisor.AppendChild(Expedido);
                if (vchCalle_Exp.Trim() != "")
                {
                    XmlAttribute Exp_calle = doc.CreateAttribute("calle");
                    Exp_calle.Value = vchCalle_Exp.Trim();
                    Expedido.Attributes.Append(Exp_calle);
                }
                if (vchNumExt_Exp.Trim() != "")
                {
                    XmlAttribute Exp_numext = doc.CreateAttribute("noExterior");
                    Exp_numext.Value = vchNumExt_Exp.Trim();
                    Expedido.Attributes.Append(Exp_numext);
                }
                if (vchNumInt_Exp.Trim() != "")
                {
                    XmlAttribute Exp_numint = doc.CreateAttribute("noInterior");
                    Exp_numint.Value = vchNumInt_Exp.Trim();
                    Expedido.Attributes.Append(Exp_numint);
                }
                if (vchCP_Exp.Trim() != "")
                {
                    XmlAttribute Exp_cp = doc.CreateAttribute("codigoPostal");
                    Exp_cp.Value = vchCP_Exp.Trim();
                    Expedido.Attributes.Append(Exp_cp);
                }
                if (vchColonia_Exp.Trim() != "")
                {
                    XmlAttribute Exp_colonia = doc.CreateAttribute("colonia");
                    Exp_colonia.Value = vchColonia_Exp.Trim();
                    Expedido.Attributes.Append(Exp_colonia);
                }
                if (vchMunicipio_Exp.Trim() != "")
                {
                    XmlAttribute Exp_municipio = doc.CreateAttribute("municipio");
                    Exp_municipio.Value = vchMunicipio_Exp.ToString();
                    Expedido.Attributes.Append(Exp_municipio);
                }
                if (Estado_Exp.Trim() != "")
                {
                    XmlAttribute Exp_edo = doc.CreateAttribute("estado");
                    Exp_edo.Value = Estado_Exp.Trim();
                    Expedido.Attributes.Append(Exp_edo);
                }
                if (Pais_Exp.Trim() != "")
                {
                    XmlAttribute Exp_pais = doc.CreateAttribute("pais");
                    Exp_pais.Value = Pais_Exp.Trim();
                    Expedido.Attributes.Append(Exp_pais);
                }

                ////////TIPO DE REGIMEN
                XmlElement Regimen = doc.CreateElement("cfdi", "RegimenFiscal", "http://www.sat.gob.mx/cfd/3");
                Emisor.AppendChild(Regimen);
                XmlAttribute Regimen_Reg = doc.CreateAttribute("Regimen");
                Regimen_Reg.Value = rowEmp["vchRegimen"].ToString().Trim();//////////////////////////////////////////////////////regimen
                Regimen.Attributes.Append(Regimen_Reg);

                ///receptor cliente
                DataTable dtCliente = new DataTable();
                dtCliente = null;// ClsCli.getInfoByID(idCliente);
                DataRow rowCli = dtCliente.Rows[0];
                ///////RECEPTOR----------------------------------------------------------
                XmlElement Receptor = doc.CreateElement("cfdi", "Receptor", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Receptor);

                XmlAttribute recp_rfc = doc.CreateAttribute("rfc");
                recp_rfc.Value = rowCli["vchRFC"].ToString().Trim();
                Receptor.Attributes.Append(recp_rfc);
                if (rowCli["vchRazon"].ToString().Trim() != "")
                {
                    XmlAttribute recp_nombre = doc.CreateAttribute("nombre");
                    recp_nombre.Value = rowCli["vchRazon"].ToString().Trim();
                    Receptor.Attributes.Append(recp_nombre);
                }

                XmlElement Domicilio = doc.CreateElement("cfdi", "Domicilio", "http://www.sat.gob.mx/cfd/3");
                Receptor.AppendChild(Domicilio);

                if (rowCli["vchCalle"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_calle = doc.CreateAttribute("calle");
                    Dom_calle.Value = rowCli["vchCalle"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_calle);
                }
                if (rowCli["vchNumExt"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_numext = doc.CreateAttribute("noExterior");
                    Dom_numext.Value = rowCli["vchNumExt"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_numext);
                }
                if (rowCli["vchNumInt"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_numint = doc.CreateAttribute("noInterior");
                    Dom_numint.Value = rowCli["vchNumInt"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_numint);
                }
                if (rowCli["vchCP"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_cp = doc.CreateAttribute("codigoPostal");
                    Dom_cp.Value = rowCli["vchCP"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_cp);
                }
                if (rowCli["vchColonia"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_colonia = doc.CreateAttribute("colonia");
                    Dom_colonia.Value = rowCli["vchColonia"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_colonia);
                }
                if (rowCli["vchMunicipio"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_municipio = doc.CreateAttribute("municipio");
                    Dom_municipio.Value = rowCli["vchMunicipio"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_municipio);
                }
                if (rowCli["vchLocalidad"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_localidad = doc.CreateAttribute("localidad");
                    Dom_localidad.Value = rowCli["vchLocalidad"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_localidad);
                }
                if (rowCli["vchEstado"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_edo = doc.CreateAttribute("estado");
                    Dom_edo.Value = rowCli["vchEstado"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_edo);
                }
                if (rowCli["vchPais"].ToString().Trim() != "")
                {
                    XmlAttribute Dom_pais = doc.CreateAttribute("pais");
                    Dom_pais.Value = rowCli["vchPais"].ToString().Trim();
                    Domicilio.Attributes.Append(Dom_pais);
                }

                ////////////productos------------------------------
                ///////RECEPTOR----------------------------------------------------------
                XmlElement Conceptos = doc.CreateElement("cfdi", "Conceptos", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Conceptos);
                //Data Impuestos
                DataTable dtImpuestos = new DataTable();


                ///DataTable dtProd = new DataTable();
                //dtProd = Clstmp.getCarritoXml();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string codigo = "";
                    string unidad = "";
                    string nombre = "";
                    double precio = 0;
                    double cantidad = 0;
                    string impuesto = "";
                    double importe = 0;
                    ///ID - Codigo - Unidad - Impuesto -  Descripcion - Precio - Cantidad - Importe - siglas - tasa_traslado - traslado_importe

                    impuesto = row.Cells["siglas"].Value.ToString().Trim();
                    codigo = row.Cells["Codigo"].Value.ToString().Trim();
                    unidad = row.Cells["Unidad"].Value.ToString().Trim();
                    nombre = row.Cells["Descripcion"].Value.ToString().Trim();
                    precio = Convert.ToDouble(row.Cells["Precio"].Value.ToString().Trim());
                    cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value.ToString().Trim());
                    importe = Convert.ToDouble(row.Cells["Importe"].Value.ToString().Trim());

                    if (unidad == "") unidad = "SN";

                    XmlElement Concepto = doc.CreateElement("cfdi", "Concepto", "http://www.sat.gob.mx/cfd/3");
                    Conceptos.AppendChild(Concepto);

                    XmlAttribute noIdentificacion_prod = doc.CreateAttribute("noIdentificacion");
                    noIdentificacion_prod.Value = codigo;
                    Concepto.Attributes.Append(noIdentificacion_prod);
                    XmlAttribute descripcion_prod = doc.CreateAttribute("descripcion");
                    descripcion_prod.Value = nombre;
                    Concepto.Attributes.Append(descripcion_prod);
                    XmlAttribute cantidad_prod = doc.CreateAttribute("cantidad");
                    cantidad_prod.Value = string.Format("{0:00.0000}", cantidad);
                    Concepto.Attributes.Append(cantidad_prod);
                    XmlAttribute unidad_prod = doc.CreateAttribute("unidad");
                    unidad_prod.Value = unidad;
                    Concepto.Attributes.Append(unidad_prod);
                    XmlAttribute precio_prod = doc.CreateAttribute("valorUnitario");
                    precio_prod.Value = string.Format("{0:00.0000}", precio);
                    Concepto.Attributes.Append(precio_prod);
                    XmlAttribute importe_prod = doc.CreateAttribute("importe");
                    importe_prod.Value = string.Format("{0:00.0000}", importe);
                    Concepto.Attributes.Append(importe_prod);
                }

                ////importes y traspasos.
                XmlElement Impuestos = doc.CreateElement("cfdi", "Impuestos", "http://www.sat.gob.mx/cfd/3");
                Comprobante.AppendChild(Impuestos);



                ///tasa TRASLADOS----------------------
                string traslado_importe_get = getSuma("traslado_importe", dataGridView1).ToString();
                string tasa_trsalado = "16";


                double traslado_importeX = 0.0;
                try
                {
                    traslado_importeX = Convert.ToDouble(traslado_importe_get);
                }
                catch (Exception exp)
                {
                    traslado_importeX = 0;
                }

                if (traslado_importeX > 0)
                {

                    XmlAttribute impuetrasladados = doc.CreateAttribute("totalImpuestosTrasladados");
                    impuetrasladados.Value = string.Format("{0:00.0000}", traslado_importeX);///traslado_importeX.ToString(); //
                    Impuestos.Attributes.Append(impuetrasladados);

                    XmlElement Traslados = doc.CreateElement("cfdi", "Traslados", "http://www.sat.gob.mx/cfd/3");
                    Impuestos.AppendChild(Traslados);

                    //foreach (DataRow Drw in dtTraslado.Rows)
                    //{

                    XmlElement Traslado = doc.CreateElement("cfdi", "Traslado", "http://www.sat.gob.mx/cfd/3");
                    Traslados.AppendChild(Traslado);
                    XmlAttribute importeTraslado = doc.CreateAttribute("importe");
                    importeTraslado.Value = string.Format("{0:00.0000}", Convert.ToDouble(traslado_importeX));  //traslado_importe.ToString();
                    Traslado.Attributes.Append(importeTraslado);
                    /////////////////
                    XmlAttribute tasaTrasladox = doc.CreateAttribute("tasa");
                    tasaTrasladox.Value = string.Format("{0:00.0000}", Convert.ToDouble("16"));
                    Traslado.Attributes.Append(tasaTrasladox);
                    XmlAttribute impuestoTraslado = doc.CreateAttribute("impuesto");
                    impuestoTraslado.Value = "IVA";
                    Traslado.Attributes.Append(impuestoTraslado);
                    //}

                }




                ///////////////////AccesoDisco.total = subtotal + total_iva - retencion_fle;
                XmlAttribute atribute_total2 = doc.CreateAttribute("total");
                atribute_total2.Value = string.Format("{0:00.0000}", Total);
                Comprobante.Attributes.Append(atribute_total2);
                XmlAttribute atribute_subtotal2 = doc.CreateAttribute("subTotal");
                atribute_subtotal2.Value = string.Format("{0:00.0000}", Subtotal);
                Comprobante.Attributes.Append(atribute_subtotal2);

               

                ///hacemos el remplace.
                string Xmlstring = doc.OuterXml;
                Xmlstring = Xmlstring.Replace("xsi=", "xmlns:xsi=");
                Xmlstring = Xmlstring.Replace("schemaLocation=", "xsi:schemaLocation=");




                //general el sello.
                string CO = GetCadenaOrignal_byxml(Xmlstring);
                if (CO == "")
                {
                    correcto = false;
                    ClsLogs.InsertaInformacion("Cadena Original" + CO, "Crear XML");
                }
                ClsLogs.InsertaInformacion("deBUG CO", CO);
                string sello = ObtenerSello(CO.Trim());
                if (sello == "")
                {
                    correcto = false;
                    ClsLogs.InsertaInformacion("Sello " + CO, "Crear XML Sello " + sello);
                }



                XmlAttribute atribute_sello = doc.CreateAttribute("sello");
                atribute_sello.Value = sello;
                Comprobante.Attributes.Append(atribute_sello);

                Xmlstring = doc.OuterXml;
                Xmlstring = Xmlstring.Replace("xsi=", "xmlns:xsi=");
                Xmlstring = Xmlstring.Replace("schemaLocation=", "xsi:schemaLocation=");


                xmlgenerado = Xmlstring;

                if (!ClsFac.InsertaDb(Subtotal, Total, traslado_importeX, 0, vchserie, folio, xmlgenerado, fecha, dataGridView1, InfoFac))
                    {
                        ClsLogs.InsertaInformacion("CREAR XML insertar", xmlgenerado);
                        return false;
                    }
                
            }
            catch (Exception erroxml)
            {
                ClsLogs.InsertaInformacion("Crear XML", erroxml.ToString());
                return false;
            }
            return true;
        }


        private bool existTasaCero(DataGridView dataGridView1)
        {
            bool retorno = false;
            float suma = 0;
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string tipo = row.Cells["tipo"].Value.ToString();
                    if (tipo.Equals("TRASLADO"))
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }
        private float getSuma(string columna, DataGridView dataGridView1)
        {
            float suma = 0;
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    float importe = 0;
                    float.TryParse(row.Cells[columna].Value.ToString(), out importe);
                    suma += importe;
                }
            }
            return suma;
        }

        private string GetCadenaOrignal_byxml(string xml)
        {
            string cadena_origina = "";

            try
            {
                XmlDocument myXMLPath = new XmlDocument();
                myXMLPath.LoadXml(xml);

                XslCompiledTransform myXSLTrans = new XslCompiledTransform();
                myXSLTrans.Load("xslt/cadenaoriginal_3_2.xslt");//////////////////////////////////////////load the Xsl 
                //string reader = myWriter.ToString();
                StringWriter sr = new StringWriter();

                myXSLTrans.Transform(myXMLPath, null, sr);
                cadena_origina = sr.ToString();
                return cadena_origina;
            }
            catch (Exception e)
            {
                ClsLogs.InsertaInformacion(e.ToString(), "no se pudo crear cadeja original");
                return cadena_origina;
            }

        }
        private string ObtenerSello(string CadenaOriginal)
        {
            
            DataTable dt = new DataTable();
            dt = null;// ClsCer.GerInfoCertByEmpresa(Classes.Class_Session.IDEMPRESA.ToString());
            DataRow Drow;
            Drow = dt.Rows[0];

            try
            {
                string result = "";
                //string CertificadoSelloDigital = ConfigurationManager.AppSettings["CertificadoSelloDigital"];
                string RutaArchivoCer = Drow["vchrutacer"].ToString();
                string RutaArchivoKey = Drow["vchrutakey"].ToString();
                string Contrasena = Drow["vchpass"].ToString();


                Chilkat.PrivateKey llave = new PrivateKey();
                Chilkat.Rsa algoritmoRSA = new Rsa();
                byte[] KeyByteArray = null;
                try
                {
                    KeyByteArray = (byte[])Drow["fileKey"];


                    //llave.LoadPkcs8EncryptedFile(RutaArchivoKey, Contrasena);
                    llave.LoadPkcs8Encrypted(KeyByteArray, Contrasena);
                    string keyPM = llave.GetXml();
                    algoritmoRSA.ImportPrivateKey(keyPM);
                    algoritmoRSA.LittleEndian = false;
                    algoritmoRSA.Charset = "utf-8";
                    algoritmoRSA.EncodingMode = "base64";

                }
                catch (Exception exp)
                {
                    llave.LoadPkcs8EncryptedFile(RutaArchivoKey, Contrasena);
                    //llave.LoadPkcs8Encrypted(KeyByteArray, Contrasena);
                    string keyPM = llave.GetXml();
                    algoritmoRSA.ImportPrivateKey(keyPM);
                    algoritmoRSA.LittleEndian = false;
                    algoritmoRSA.Charset = "utf-8";
                    algoritmoRSA.EncodingMode = "base64";
                }

                bool numeroSerie1 = false; //RSAT34MB34N_7F1CD986683M
                bool numeroSerie2 = false; //RSAT34MB34N_2637664B634J
                bool numeroSerie3 = false; //RSAT34MB34N_3F0D2D9C642S
                bool numeroSerie4 = false; //RSAT34MB34N_7A2D7D1A680G
                bool numeroSerie5 = false; //RSAT34MB34N_7F1CD986683M

                //algoritmoRSA.UnlockComponent("RSAT34MB34N_2637664B 634J");
                //string xmltoText = fnObtenxml(RutaXML);
                //string CadenaOriginal = fnCadenaOriginal(xmltoText);
                string cadenaOriginalFormateada = CadenaOriginal;

                if (numeroSerie1 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7F1CD986683M"))
                {
                    //cadenaOriginalFormateada = CadenaOriginal.ToString().Replace(System.Environment.NewLine, string.Empty).Replace("\t", string.Empty);
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                    //result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else if (numeroSerie2 = algoritmoRSA.UnlockComponent("RSAT34MB34N_2637664B634J"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else if (numeroSerie3 = algoritmoRSA.UnlockComponent("RSAT34MB34N_3F0D2D9C642S"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else if (numeroSerie4 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7A2D7D1A680G"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else if (numeroSerie5 = algoritmoRSA.UnlockComponent("RSAT34MB34N_7F1CD986683M"))
                {
                    result = algoritmoRSA.SignStringENC(cadenaOriginalFormateada, "sha1");
                }
                else
                {
                    result = "";
                }

                result = result.Replace(System.Environment.NewLine, string.Empty).Replace("\t", string.Empty);

                return result;

            }
            catch (Exception exc)
            {
                ClsLogs.InsertaInformacion(exc.ToString(), "Al generar el sello");
                return "";
            }
        }

        */
    }
}
