using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace FLXDSK.Classes.XML
{
    class Class_LectorXML
    {
        public string folio = "";
        public string serie = "";
        public string version = "";
        public string fecha = "";
        public string Moneda = "";
        public string formaDePago = "";
        public string metodoDePago = "";
        public string noCertificado = "";
        public string tipoDeComprobante = "";
        public double total = 0;
        public double subTotal = 0;
        public double descuento = 0;
        public double IVA = 0;
        public double IVA_RET = 0;
        public double ISR = 0;
        public double IEPS = 0;
        public string sello = "";
        public string cuenta = "";
        public string importeLetra = "";

        //Emisor
        public string rfc_emisor = "";
        public string razon_emisor = "";
        public string regimen = "";

        public string calle_DomFiscal = "";
        public string noExterior_DomFiscal = "";
        public string noInterior_DomFiscal = "";
        public string codigoPostal_DomFiscal = "";
        public string colonia_DomFiscal = "";
        public string municipio_DomFiscal = "";
        public string estado_DomFiscal = "";
        public string pais_DomFiscal = "";

        //Expedido       
        public string LugarExpedicion = "";

        public string calle_Expedido = "";
        public string noExterior_Expedido = "";
        public string noInterior_Expedido = "";
        public string codigoPostal_Expedido = "";
        public string colonia_Expedido = "";
        public string municipio_Expedido = "";
        public string estado_Expedido = "";
        public string pais_Expedido = "";

        //Receptor
        public string rfc_Receptor = "";
        public string razon_Receptor = "";
        public string UsoCFDI = "";

        public string calle_domRecep = "";
        public string noExterior_domRecep = "";
        public string noInterior_domRecep = "";
        public string codigoPostal_domRecep = "";
        public string colonia_domRecep = "";
        public string municipio_domRecep = "";
        public string localidad_domRecep = "";
        public string estado_domRecep = "";
        public string pais_domRecep = "";

        //TIMBRADO
        public string FechaTimbrado = "";
        public string noCertificadoSAT = "";
        public string version_timbre = "";
        public string selloCFD = "";
        public string selloSAT = "";
        public string UUID = "";

        ////ComplementoPago
        /*public double ImpSaldoInsoluto = 0;
        public double ImpSaldoAnt = 0;
        public double ImpPagado = 0;
        public string IdDocumento = "";*/


        //productos
        public DataTable dtProductos = null;
        public DataTable dtComplementoPagos = null;

        XmlDocument xml = null;
        Classes.Herramientas.Class_Conversiones ClsConver = new Classes.Herramientas.Class_Conversiones();

        Classes.SAT.Class_MetodoPago ClsMetdoSAT = new Classes.SAT.Class_MetodoPago();
        Classes.SAT.Class_FormasPago ClsFormaPago = new Classes.SAT.Class_FormasPago();
        Classes.SAT.Class_Regimen ClsRegimen = new Classes.SAT.Class_Regimen();
        Classes.SAT.Class_TiposCFDI ClsTipoCFDI = new Classes.SAT.Class_TiposCFDI();
        Classes.SAT.Class_TipoUso ClsTipoUSO = new Classes.SAT.Class_TipoUso();


        public bool ExtraXML(string XML)
        {
            xml = new XmlDocument();
            xml.LoadXml(XML);

            ////Creamos la tabla productos
            dtProductos = new DataTable();
            dtProductos.Columns.Add("CodigoSAT");
            dtProductos.Columns.Add("MedidaSAT");
            dtProductos.Columns.Add("codigo");
            dtProductos.Columns.Add("unidad");
            dtProductos.Columns.Add("cantidad");
            dtProductos.Columns.Add("descripcion");
            dtProductos.Columns.Add("precio");
            dtProductos.Columns.Add("importe");


            dtComplementoPagos = new DataTable();
            dtComplementoPagos.Columns.Add("ImpSaldoInsoluto");
            dtComplementoPagos.Columns.Add("ImpSaldoAnt");
            dtComplementoPagos.Columns.Add("ImpPagado");
            dtComplementoPagos.Columns.Add("IdDocumento");


            XmlElement Comprobante = xml.DocumentElement;
            try
            {
                version = Comprobante.Attributes["version"].Value;
            }
            catch
            {
                try
                {
                    version = Comprobante.Attributes["Version"].Value;
                }
                catch
                {
                    return false;
                }

            }

            if (version == "3.2")
                return setXML32();
            else
                if (version == "3.3")
                    return setXML33();

            return false;
        }
        private bool setXML32()
        {
            XmlElement Comprobante = xml.DocumentElement;
            folio = "";
            serie = "";
            try
            {
                //opcionales
                folio = Comprobante.Attributes["folio"].Value;
            }
            catch { }
            try
            {
                serie = Comprobante.Attributes["serie"].Value;
            }
            catch { }

            //atributos
            version = Comprobante.Attributes["version"].Value;
            fecha = Comprobante.Attributes["fecha"].Value;
            Moneda = Comprobante.Attributes["Moneda"].Value;
            formaDePago = Comprobante.Attributes["formaDePago"].Value;
            metodoDePago = Comprobante.Attributes["metodoDePago"].Value;
            noCertificado = Comprobante.Attributes["noCertificado"].Value;
            tipoDeComprobante = Comprobante.Attributes["tipoDeComprobante"].Value;
            total = Convert.ToDouble(Comprobante.Attributes["total"].Value);
            subTotal = Convert.ToDouble(Comprobante.Attributes["subTotal"].Value);
            sello = Comprobante.Attributes["sello"].Value;
            cuenta = "";
            try
            {
                cuenta = Comprobante.Attributes["NumCtaPago"].Value;
            }
            catch { }
            descuento = 0;
            try
            {
                descuento = Convert.ToDouble(Comprobante.Attributes["descuento"].Value);
            }
            catch { }

            //contacatenamos el codigo sat al metodo de pago
            metodoDePago = metodoDePago + " " + ClsMetdoSAT.getNameByCodigo(metodoDePago);
            metodoDePago = metodoDePago + " " + ClsFormaPago.getNameByCodigo(metodoDePago);


            XmlNamespaceManager cfdi = new XmlNamespaceManager(xml.NameTable);
            cfdi.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");

            //XmlNodeList Emisor = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Emisor", cfdi);
            XmlNode Emisor = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Emisor", cfdi);
            rfc_emisor = Emisor.Attributes["rfc"].Value;
            razon_emisor = Emisor.Attributes["nombre"].Value;

            //expedido
            XmlNode DomFiscal = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Emisor/cfdi:DomicilioFiscal", cfdi);
            try
            {
                calle_DomFiscal = DomFiscal.Attributes["calle"].Value;
            }
            catch { }
            try
            {
                noExterior_DomFiscal = DomFiscal.Attributes["noExterior"].Value;
            }
            catch { }
            try
            {
                noInterior_DomFiscal = DomFiscal.Attributes["noInterior"].Value;
            }
            catch { }
            try
            {
                codigoPostal_DomFiscal = DomFiscal.Attributes["codigoPostal"].Value;
            }
            catch { }
            try
            {
                colonia_DomFiscal = DomFiscal.Attributes["colonia"].Value;
            }
            catch { }
            try
            {
                municipio_DomFiscal = DomFiscal.Attributes["municipio"].Value;
            }
            catch { }
            try
            {
                estado_DomFiscal = DomFiscal.Attributes["estado"].Value;
            }
            catch { }
            try
            {
                pais_DomFiscal = DomFiscal.Attributes["pais"].Value;
            }
            catch { }

            ///Expedido en
            ///
            XmlNode Expedido = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Emisor/cfdi:ExpedidoEn", cfdi);
            try
            {
                calle_Expedido = Expedido.Attributes["calle"].Value;
            }
            catch { }
            try
            {
                noExterior_Expedido = Expedido.Attributes["noExterior"].Value;
            }
            catch { }
            try
            {
                noInterior_Expedido = Expedido.Attributes["noInterior"].Value;
            }
            catch { }
            try
            {
                codigoPostal_Expedido = Expedido.Attributes["codigoPostal"].Value;
            }
            catch { }
            try
            {
                colonia_Expedido = Expedido.Attributes["colonia"].Value;
            }
            catch { }
            try
            {
                municipio_Expedido = Expedido.Attributes["municipio"].Value;
            }
            catch { }
            try
            {
                estado_Expedido = Expedido.Attributes["estado"].Value;
            }
            catch { }
            try
            {
                pais_Expedido = Expedido.Attributes["pais"].Value;
            }
            catch { }


            //REGIMEN
            XmlNode Regimen = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Emisor/cfdi:RegimenFiscal", cfdi);
            regimen = Regimen.Attributes["Regimen"].Value;



            ///RECEPTOR
            XmlNode Receptor = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Receptor", cfdi);
            rfc_Receptor = Receptor.Attributes["rfc"].Value;
            razon_Receptor = Receptor.Attributes["nombre"].Value;
            rfc_Receptor = rfc_Receptor.Replace("&amp;", "&");
            razon_Receptor = razon_Receptor.Replace("&amp;", "&");

            XmlNode DomicilioReceptor = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Receptor/cfdi:Domicilio", cfdi);
            try
            {
                calle_domRecep = DomicilioReceptor.Attributes["calle"].Value;
            }
            catch { }
            try
            {
                noExterior_domRecep = DomicilioReceptor.Attributes["noExterior"].Value;
            }
            catch { }
            try
            {
                noInterior_domRecep = DomicilioReceptor.Attributes["noInterior"].Value;
            }
            catch { }
            try
            {
                codigoPostal_domRecep = DomicilioReceptor.Attributes["codigoPostal"].Value;
            }
            catch { }
            try
            {
                colonia_domRecep = DomicilioReceptor.Attributes["colonia"].Value;
            }
            catch { }
            try
            {
                municipio_domRecep = DomicilioReceptor.Attributes["municipio"].Value;
            }
            catch { }
            try
            {
                estado_domRecep = DomicilioReceptor.Attributes["estado"].Value;
            }
            catch { }
            try
            {
                pais_domRecep = DomicilioReceptor.Attributes["pais"].Value;
            }
            catch { }


            //IMPUESTOS
            /*XmlNode Impuestos = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Impuestos", cfdi);
            try
            {
                IVA = Convert.ToDouble(Impuestos.Attributes["totalImpuestosTrasladados"].Value);
            }
            catch
            {
            }*/
            IVA = 0;
            ////
            //retenciones
            try
            {
                XmlNodeList taslados = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", cfdi);
                foreach (XmlElement tras in taslados)
                {
                    try
                    {
                        if (tras.Attributes["impuesto"].Value == "IVA")
                        {
                            IVA += Convert.ToDouble(tras.Attributes["importe"].Value);
                        }
                    }
                    catch { }
                }



            }
            catch { }


            //retenciones
            try
            {
                XmlNodeList retenciones = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion", cfdi);
                int contador = 0;
                foreach (XmlElement retencion in retenciones)
                {
                    contador++;
                    try
                    {
                        if (contador == 1)
                        {
                            if (retencion.Attributes["impuesto"].Value == "ISR")
                                ISR = Convert.ToDouble(retencion.Attributes["importe"].Value);
                        }
                        if (contador == 2)
                        {
                            if (retencion.Attributes["impuesto"].Value == "IVA")
                                IVA_RET = Convert.ToDouble(retencion.Attributes["importe"].Value);
                        }
                    }
                    catch { }
                }



            }
            catch { }



            cfdi.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            XmlNode timbre = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", cfdi);
            FechaTimbrado = timbre.Attributes["FechaTimbrado"].Value;
            noCertificadoSAT = timbre.Attributes["noCertificadoSAT"].Value;
            version_timbre = timbre.Attributes["version"].Value;
            selloCFD = timbre.Attributes["selloCFD"].Value;
            selloSAT = timbre.Attributes["selloSAT"].Value;
            UUID = timbre.Attributes["UUID"].Value;






            DataRow drow;
            //////detalle del producto.
            XmlNodeList conceptos = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", cfdi);
            foreach (XmlElement category in conceptos)
            {
                drow = dtProductos.NewRow();
                try
                {
                    drow["codigo"] = category.Attributes["noIdentificacion"].Value;
                }
                catch { }
                drow["descripcion"] = category.Attributes["descripcion"].Value;
                drow["cantidad"] = category.Attributes["cantidad"].Value;
                drow["unidad"] = category.Attributes["unidad"].Value;
                drow["precio"] = category.Attributes["valorUnitario"].Value;
                drow["importe"] = category.Attributes["importe"].Value;

                dtProductos.Rows.Add(drow);

            }

            string total_Formateado = string.Format("{0:00.00}", total);
            importeLetra = ClsConver.Convertir(total_Formateado, true, "Pesos") + " MXN";




            return true;
        }
        private bool setXML33()
        {
            XmlElement Comprobante = xml.DocumentElement;
            folio = "";
            serie = "";
            try
            {
                folio = Comprobante.Attributes["Folio"].Value;
            }
            catch { }
            try
            {
                serie = Comprobante.Attributes["Serie"].Value;
            }
            catch { }

            //atributos
            version = Comprobante.Attributes["Version"].Value;
            fecha = Comprobante.Attributes["Fecha"].Value;
            try
            {
                Moneda = Comprobante.Attributes["Moneda"].Value;
            }
            catch { }
            try
            {
                formaDePago = Comprobante.Attributes["FormaPago"].Value;
            }
            catch { }
            try
            {
                metodoDePago = Comprobante.Attributes["MetodoPago"].Value;
            }
            catch { }
            noCertificado = Comprobante.Attributes["NoCertificado"].Value;
            tipoDeComprobante = Comprobante.Attributes["TipoDeComprobante"].Value;
            total = Convert.ToDouble(Comprobante.Attributes["Total"].Value);
            subTotal = Convert.ToDouble(Comprobante.Attributes["SubTotal"].Value);
            sello = Comprobante.Attributes["Sello"].Value;
            LugarExpedicion = Comprobante.Attributes["LugarExpedicion"].Value;

            double descuento = 0;
            try
            {
                descuento = Convert.ToDouble(Comprobante.Attributes["Descuento"].Value);
            }
            catch { }


            ///
            XmlNamespaceManager cfdi = new XmlNamespaceManager(xml.NameTable);
            cfdi.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");

            //XmlNodeList Emisor = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Emisor", cfdi);
            XmlNode Emisor = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Emisor", cfdi);
            rfc_emisor = Emisor.Attributes["Rfc"].Value;
            try
            {
                razon_emisor = Emisor.Attributes["Nombre"].Value;
            }
            catch { }
            regimen = Emisor.Attributes["RegimenFiscal"].Value;

            ///Expedido en
            LugarExpedicion = " C.P. " + LugarExpedicion;



            ///RECEPTOR
            XmlNode Receptor = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Receptor", cfdi);
            rfc_Receptor = Receptor.Attributes["Rfc"].Value;
            try
            {
                razon_Receptor = Receptor.Attributes["Nombre"].Value;
            }
            catch { }
            UsoCFDI = Receptor.Attributes["UsoCFDI"].Value;
            rfc_Receptor = rfc_Receptor.Replace("&amp;", "&");
            razon_Receptor = razon_Receptor.Replace("&amp;", "&");


            //IMPUESTOS
            XmlNode Impuestos = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Impuestos", cfdi);
            try
            {
                IVA = Convert.ToDouble(Impuestos.Attributes["TotalImpuestosTrasladados"].Value);
            }
            catch
            {
            }
            //retenciones
            try
            {
                XmlNodeList retenciones = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion", cfdi);
                int contador = 0;
                foreach (XmlElement retencion in retenciones)
                {
                    contador++;

                    try
                    {
                        if (contador == 1)
                        {
                            if (retencion.Attributes["Impuesto"].Value == "002")
                                IVA_RET = Convert.ToDouble(retencion.Attributes["Importe"].Value);
                        }
                        if (contador == 2)
                        {
                            if (retencion.Attributes["Impuesto"].Value == "001")
                                ISR = Convert.ToDouble(retencion.Attributes["Importe"].Value);
                        }
                    }
                    catch { }
                }



            }
            catch { }


            DataRow drow;


            cfdi.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            XmlNode timbre = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", cfdi);
            FechaTimbrado = timbre.Attributes["FechaTimbrado"].Value;
            noCertificadoSAT = timbre.Attributes["NoCertificadoSAT"].Value;
            version_timbre = timbre.Attributes["Version"].Value;
            selloCFD = timbre.Attributes["SelloCFD"].Value;
            selloSAT = timbre.Attributes["SelloSAT"].Value;
            UUID = timbre.Attributes["UUID"].Value;


            ///////////////////complemento de PAGO
            try
            {
                cfdi.AddNamespace("pago10", "http://www.sat.gob.mx/Pagos");
                XmlNode ComPago = (XmlElement)xml.SelectSingleNode(@"/cfdi:Comprobante/cfdi:Complemento/pago10:Pagos/pago10:Pago/pago10:DoctoRelacionado", cfdi);
                XmlNodeList Pagos = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Complemento/pago10:Pagos/pago10:Pago/pago10:DoctoRelacionado", cfdi);
                foreach (XmlElement Pag in Pagos)
                {
                    try
                    {
                        drow = dtComplementoPagos.NewRow();
                        drow["ImpSaldoInsoluto"] = Pag.Attributes["ImpSaldoInsoluto"].Value;
                        drow["ImpSaldoAnt"] = Pag.Attributes["ImpSaldoAnt"].Value;
                        drow["IdDocumento"] = Pag.Attributes["IdDocumento"].Value;
                        drow["ImpPagado"] = Pag.Attributes["ImpPagado"].Value;

                        dtComplementoPagos.Rows.Add(drow);
                    }
                    catch { }
                }
            }
            catch { }



            //////detalle del producto.
            XmlNodeList conceptos = xml.SelectNodes(@"/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", cfdi);
            foreach (XmlElement category in conceptos)
            {
                drow = dtProductos.NewRow();
                try
                {
                    drow["codigo"] = category.Attributes["NoIdentificacion"].Value;
                }
                catch { }
                drow["CodigoSAT"] = category.Attributes["ClaveProdServ"].Value;
                drow["MedidaSAT"] = category.Attributes["ClaveUnidad"].Value;

                try
                {
                    drow["descripcion"] = category.Attributes["Descripcion"].Value;
                }
                catch { }
                drow["cantidad"] = category.Attributes["Cantidad"].Value;
                try
                {
                    drow["unidad"] = category.Attributes["Unidad"].Value;
                }
                catch { }
                drow["precio"] = category.Attributes["ValorUnitario"].Value;
                drow["importe"] = category.Attributes["Importe"].Value;

                dtProductos.Rows.Add(drow);

            }

            formaDePago = formaDePago + " " + ClsFormaPago.getNameByCodigo(formaDePago);
            metodoDePago = metodoDePago + " " + ClsMetdoSAT.getNameByCodigo(metodoDePago);
            tipoDeComprobante = tipoDeComprobante + " " + ClsTipoCFDI.getNameByCodigo(tipoDeComprobante);
            regimen = regimen + " " + ClsRegimen.getNameByCodigo(regimen);
            UsoCFDI = UsoCFDI + " " + ClsTipoUSO.getName(UsoCFDI);

            string total_Formateado = string.Format("{0:00.00}", total);
            importeLetra = ClsConver.Convertir(total_Formateado, true, "Pesos") + " " + Moneda;

            return true;
        }
    }
}
