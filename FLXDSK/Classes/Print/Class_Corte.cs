using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Data;

namespace FLXDSK.Classes.Print
{
    class Class_Corte
    {
        //configurador
        int charMaximoXLinea = 25;

        //generales
        private string fontName = "Lucida Console";
        private int fontSize = 10;
        StringBuilder sb;
        private Graphics DrawinGrafic;
        Image ImageLogo;
        int MaxWithlogo = 160;

        bool SiLogoTick = true;



        Class_FuncionesTicket ClsFn = new Class_FuncionesTicket();
        Classes.Cortes.Class_Corte ClsCorte = new Cortes.Class_Corte();

        public Class_Corte(string idCorte)
        {
            ImageLogo = null;///iNCLUIR iMAGEN
            if (SiLogoTick)
            {
                try
                {
                    //obtiene la imagen almacenada en la clase logo
                    Class_logo Cls_logo = new Class_logo();
                    ImageLogo = Image.FromHbitmap(Cls_logo.getLogo().GetHbitmap());
                }
                catch (Exception)
                {

                    ImageLogo = null;
                }
              
            }
            if (ImageLogo != null)
            {

                if (ImageLogo.Width > MaxWithlogo)
                {
                    int NewHeight = (ImageLogo.Height * MaxWithlogo) / ImageLogo.Width;
                    int NewWidth = MaxWithlogo;

                    System.Drawing.Image NewImage = ImageLogo.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
                    ImageLogo.Dispose();
                    ImageLogo = NewImage;
                }
            }

            sb = new StringBuilder();

            DataTable dtCorte = ClsCorte.getListaWhere(" WHERE iidCorte = " + idCorte);
            if (dtCorte.Rows.Count == 0)
                return;
            

            string MensajeTop = "";
            string MensajePie = "";
            string ShowTelefono = "";

            

            DataRow[] RowVal;
            if (Classes.Class_Session.dtParamConf != null)
            {
                RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Dirección local'");
                if (RowVal.Count() > 0)
                    if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                        MensajeTop = RowVal[0]["vchConfiguracion"].ToString();

                RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Telefono'");
                if (RowVal.Count() > 0)
                    if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                        ShowTelefono = RowVal[0]["vchConfiguracion"].ToString();

                ///Caracteres por linea
                try
                {
                    RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Caracteres x Linea'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                            charMaximoXLinea = Convert.ToInt32(RowVal[0]["vchConfiguracion"].ToString());
                }
                catch { }

                try
                {
                    RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Tamaño Fuente'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                            fontSize = Convert.ToInt32(RowVal[0]["vchConfiguracion"].ToString());
                }
                catch { }
            }

            
            DatosJustificado(" ");
            DatosJustificado(" ");
            DatosJustificado("Av. Vallarta 5145. Local L15, Iconia, Camino Real, 45040 Zapopan, Jal.");
            if(MensajeTop.Trim() !="")
                DatosJustificado("");
            if (ShowTelefono.Trim() != "")
                DatosJustificado("  TELEFONO: " + ShowTelefono.Trim());

           
	
	
	
	
            DatosJustificado(" ");
            DatosJustificado(" ");
            DatosJustificado("No Corte: " + Convert.ToInt32(idCorte).ToString("000000"));
            TextosExtremos(dtCorte.Rows[0]["dfechaIn103"].ToString(), dtCorte.Rows[0]["dfechaIn108"].ToString());
            DatosJustificado(" ");
            TextoCentro(" V E N T A   T O T A L ");
            TextoCentro(string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaTotal"].ToString())));
            DatosJustificado(" ");
            DatosJustificado(" ");
            Totales("Venta", Convert.ToDouble(dtCorte.Rows[0]["fVentaTotal"].ToString()));
            Totales("Salidas",Convert.ToDouble(dtCorte.Rows[0]["fMontoSalidaDinero"].ToString()));
            Totales("Entrada",Convert.ToDouble(dtCorte.Rows[0]["fMontoEntradaDinero"].ToString()));
            Totales("Inicial", Convert.ToDouble(dtCorte.Rows[0]["fMontoInicial"].ToString()));
            LineasGuiones("-");

            double fTotalFinal = Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString()) + Convert.ToDouble(dtCorte.Rows[0]["fMontoInicial"].ToString());

            Totales("Total Final", fTotalFinal);
            Totales("Entregado",Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()));

            

            if (fTotalFinal > Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()))
            {
                double Faltante = fTotalFinal - Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString());
                Totales("Faltante",Faltante);
            }
            else
            {
                if (Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()) > fTotalFinal)
                {
                    double Sobrante = Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()) - fTotalFinal;
                    Totales("Sobrante",Sobrante);
                }
            }
            DatosJustificado(" ");
            DatosJustificado(" ");
            TextoCentro("ENTREGAS");
            DatosJustificado(" ");
            Totales("Efectivo",Convert.ToDouble(dtCorte.Rows[0]["fEntregaEfectivo"].ToString()));
            Totales("Credito",Convert.ToDouble(dtCorte.Rows[0]["fEntregaCreditoTC"].ToString()));
            Totales("Debito",Convert.ToDouble(dtCorte.Rows[0]["fEntregaDebito"].ToString()));
            Totales("Vales",Convert.ToDouble(dtCorte.Rows[0]["fEntregaVales"].ToString()));
            Totales("Cheque",Convert.ToDouble(dtCorte.Rows[0]["fEntregaCheque"].ToString()));
            Totales("Otro",Convert.ToDouble(dtCorte.Rows[0]["fEntregaOtro"].ToString()));

            DatosJustificado(" ");
            DatosJustificado(" ");
            TextoCentro("VENTAS X FORMA DE PAGO");
            DatosJustificado(" ");
            Totales("Efectivo",Convert.ToDouble(dtCorte.Rows[0]["fVentaEfectivo"].ToString()));
            Totales("Credito",Convert.ToDouble(dtCorte.Rows[0]["fVentaCreditoTC"].ToString()));
            Totales("Debito",Convert.ToDouble(dtCorte.Rows[0]["fVentaDebito"].ToString()));
            Totales("Vales",Convert.ToDouble(dtCorte.Rows[0]["fVentaVales"].ToString()));
            Totales("Cheque",Convert.ToDouble(dtCorte.Rows[0]["fVentaCheque"].ToString()));
            Totales("Otro",Convert.ToDouble(dtCorte.Rows[0]["fVentaOtro"].ToString()));

            DatosJustificado(" ");
            DatosJustificado(" ");
            DatosJustificado(" ");
            DatosJustificado(" ");
           
            cortarTicket();

        }
        public bool Imprimir()
        {
            try
            {
                PrinterSettings printerSettings = new PrinterSettings();
                string NameImpresora = printerSettings.PrinterName;


                if (NameImpresora == "")
                    return false;


                //dibujamos el LOGO
                try
                {
                    PrintDocument pr = new PrintDocument();
                    pr.PrinterSettings.PrinterName = NameImpresora;
                    pr.PrintPage += new PrintPageEventHandler(PrintPageLogo);
                    pr.Print();
                    return true;
                }
                catch
                {
                    return false;
                }

                
            }
            catch
            {
                return false;
            }
        }



        //////Estructura Ticket
        public void TextoCentro(string textoAll)
        {
            string[] Lineas = ClsFn.getLineasxEnter(textoAll);
            for (int i = 0; i < Lineas.Length; i++)
            {
                string textoLinea = Lineas[i].Trim();

                int TamanoCadena = textoLinea.Length;
                if (TamanoCadena > charMaximoXLinea)
                {

                    string cadenaActual = textoLinea;

                    while (cadenaActual != "")
                    {
                        string valorLinea = "";

                        if (cadenaActual.Length > charMaximoXLinea)
                        {
                            valorLinea = cadenaActual.Substring(0, charMaximoXLinea);
                            cadenaActual = cadenaActual.Substring(charMaximoXLinea);
                        }
                        else
                        {
                            valorLinea = cadenaActual.Substring(0, cadenaActual.Length);

                            cadenaActual = cadenaActual.Substring(cadenaActual.Length);
                        }

                        string espacios = ClsFn.EspaciosCentrar(valorLinea, charMaximoXLinea);
                        sb.AppendLine(espacios + "" + valorLinea);
                    }
                }
                else
                {
                    string espacios = ClsFn.EspaciosCentrar(textoLinea, charMaximoXLinea);
                    sb.AppendLine(espacios + textoLinea);
                }

            }

        }
        public void TextoDerecha(string textoAll)
        {
            string[] Lineas = ClsFn.getLineasxEnter(textoAll);
            for (int i = 0; i < Lineas.Length; i++)
            {
                string textoLinea = Lineas[i].Trim();

                int TamanoCadena = textoLinea.Length;
                if (TamanoCadena > charMaximoXLinea)
                {

                    string cadenaActual = textoLinea;

                    while (cadenaActual != "")
                    {
                        string valorLinea = "";

                        if (cadenaActual.Length > charMaximoXLinea)
                        {
                            valorLinea = cadenaActual.Substring(0, charMaximoXLinea);
                            cadenaActual = cadenaActual.Substring(charMaximoXLinea);
                        }
                        else
                        {
                            valorLinea = cadenaActual.Substring(0, cadenaActual.Length);

                            cadenaActual = cadenaActual.Substring(cadenaActual.Length);
                        }

                        string espacios = ClsFn.EspaciosDerecha(valorLinea, charMaximoXLinea);
                        sb.AppendLine(espacios + valorLinea);
                    }
                }
                else
                {
                    string espacios = ClsFn.EspaciosDerecha(textoLinea, charMaximoXLinea);
                    sb.AppendLine(espacios + textoLinea);
                }

            }

        }
        public void DatosJustificado(string textoAll)
        {
            string[] Lineas = ClsFn.getLineasxEnter(textoAll);
            for (int i = 0; i < Lineas.Length; i++)
            {
                string textoLinea = Lineas[i].Trim();
                int TamanoCadena = textoLinea.Length;
                if (TamanoCadena > charMaximoXLinea)
                {

                    string cadenaActual = textoLinea;

                    while (cadenaActual != "")
                    {
                        string valorLinea = "";

                        if (cadenaActual.Length > charMaximoXLinea)
                        {
                            valorLinea = cadenaActual.Substring(0, charMaximoXLinea);
                            cadenaActual = cadenaActual.Substring(charMaximoXLinea);
                        }
                        else
                        {
                            valorLinea = cadenaActual.Substring(0, cadenaActual.Length);

                            cadenaActual = cadenaActual.Substring(cadenaActual.Length);
                        }

                        sb.AppendLine(valorLinea);
                    }
                }
                else
                {
                    sb.AppendLine(textoLinea);
                }

            }
        }

        public void TextosExtremos(string left, string right)
        {
            string LineaCompleta = left + "" + right;
            if (LineaCompleta.Length >= charMaximoXLinea)
            {
                int tamanomax = charMaximoXLinea - 10;
                if (tamanomax == 0) tamanomax = 10;//si el numero de lineas es menor o igual a 10
                int TamanoCadena = left.Length;////solo el Left
                if (TamanoCadena > tamanomax)
                {

                    string cadenaActual = left;

                    while (cadenaActual != "")
                    {
                        string valorLinea = "";

                        if (cadenaActual.Length > tamanomax)
                        {
                            ///existe para otra linea
                            valorLinea = cadenaActual.Substring(0, tamanomax);
                            cadenaActual = cadenaActual.Substring(tamanomax);
                            try
                            {
                                sb.AppendLine(valorLinea);
                            }
                            catch { }
                        }
                        else
                        {
                            ///ya no hay mas lineas.
                            valorLinea = cadenaActual.Substring(0, cadenaActual.Length);


                            ///
                            string cadenaConta = cadenaActual + "" + right;
                            string espacios = "";
                            int nroEspacios = (charMaximoXLinea - cadenaConta.Length) / 2;
                            for (int i = 0; i < nroEspacios; i++)
                            {
                                espacios += " ";
                            }

                            string cadena = cadenaActual + espacios + espacios + right;
                            sb.AppendLine(cadena);

                            cadenaActual = cadenaActual.Substring(cadenaActual.Length);
                        }


                    }//while
                }
                else
                {
                    string espacios = "";
                    int nroEspacios = (charMaximoXLinea - LineaCompleta.Length) / 2;
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }

                    string cadena = left + espacios + espacios + right;
                    sb.AppendLine(cadena);
                }

            }
            else
            {
                string espacios = "";
                int nroEspacios = (charMaximoXLinea - LineaCompleta.Length) / 2;
                for (int i = 0; i < nroEspacios; i++)
                {
                    espacios += " ";
                }

                string cadena = left + espacios + espacios + right;
                sb.AppendLine(cadena);
            }
        }
        public void LineasGuiones(string valor)
        {
            string lineas = "";
            for (int x = 0; x < charMaximoXLinea; x++)
            {
                lineas += "" + valor;
            }
            sb.AppendLine(lineas);
        }
        public void SaltodeLinea()
        {
            sb.AppendLine(" ");
        }

        public void AgregarProductos(double cantidad, string descripcion, double precio, double importe)
        {
            string linea = cantidad + " x " + string.Format("{0:C}", precio); 
            DatosJustificado(linea);
            ////detalle
            TextosExtremos(descripcion, " " + string.Format("{0:C}", importe)); 
        }
        public void Totales(string texto, double monto)
        {
            string importe = " " + string.Format("{0:C}", monto);
            string cadena = texto + "" + importe.PadLeft(18, '.');
            TextoDerecha(cadena);
        }
        public void TotalesInt(string texto, double numero)
        {
            string importe = " " + string.Format("{0:0,0}", Math.Round(numero,2));
            string cadena = texto + "" + importe.PadLeft(18, '.');
            TextoDerecha(cadena);
        }
        public void cortarTicket()
        {
            sb.AppendLine("\x1B" + "\x05");
            sb.AppendLine("\x1B");
        }





        public void PrintPageLogo(object sender, PrintPageEventArgs e)
        {
            float newHeight = 0;

            if (SiLogoTick)
            {
                if (ImageLogo!=null)
                {
                    /////////////////////////logotipo
                    ///logotipo
                    int pageW = e.PageSettings.PaperSize.Width;
                    int PosicionX = (pageW - ImageLogo.Width) / 2;


                    float newWidth = ImageLogo.Width * 100 / ImageLogo.HorizontalResolution;
                    newHeight = ImageLogo.Height * 100 / ImageLogo.VerticalResolution;

                    float widthFactor = newWidth / e.MarginBounds.Width;
                    float heightFactor = newHeight / e.MarginBounds.Height;

                    if (widthFactor > 1 | heightFactor > 1)
                    {
                        if (widthFactor > heightFactor)
                        {
                            newWidth = newWidth / widthFactor;
                            newHeight = newHeight / widthFactor;
                        }
                        else
                        {
                            newWidth = newWidth / heightFactor;
                            newHeight = newHeight / heightFactor;
                        }
                    }
                    //e.Graphics.DrawImage(ImageLogo, PosicionX, 0, (int)newWidth, (int)newHeight);
                    e.Graphics.DrawImage(ImageLogo, PosicionX, 0, (int)ImageLogo.Width, (int)ImageLogo.Height);
                }
            }

            ///contenido

            System.Drawing.Font fnt = new Font(this.fontName, (float)this.fontSize, FontStyle.Regular);
            //System.Drawing.Font fnt = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, 10);
            e.Graphics.DrawString(sb.ToString(), fnt, System.Drawing.Brushes.Black, 0.0F, newHeight + 5);

            int tamanofuente = fnt.Height;
            string[] val = ClsFn.getLineasxEnter(sb.ToString());


            //logo qr
            /*
            float posicionY = (tamanofuente * val.Count()) + 50 + newHeight;


            newWidth = ImageLogo.Width * 100 / ImageLogo.HorizontalResolution;
            newHeight = ImageLogo.Height * 100 / ImageLogo.VerticalResolution;

            widthFactor = newWidth / e.MarginBounds.Width;
            heightFactor = newHeight / e.MarginBounds.Height;

            if (widthFactor > 1 | heightFactor > 1)
            {
                if (widthFactor > heightFactor)
                {
                    newWidth = newWidth / widthFactor;
                    newHeight = newHeight / widthFactor;
                }
                else
                {
                    newWidth = newWidth / heightFactor;
                    newHeight = newHeight / heightFactor;
                }
            }
            e.Graphics.DrawImage(ImageLogo, PosicionX, posicionY, (int)newWidth, (int)newHeight);


            ///espacios
            e.Graphics.DrawString(".".ToString(), fnt, System.Drawing.Brushes.Black, 0.0F, newHeight + posicionY + 25);
            */
        }





        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "ticket";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }
    }
}
