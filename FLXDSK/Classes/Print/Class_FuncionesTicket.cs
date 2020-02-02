using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLXDSK.Classes.Print
{
    class Class_FuncionesTicket
    {
        public string getLineasGuion(int charMaximoXLinea)
        {
            string lineas = "";
            for (int x = 0; x < charMaximoXLinea; x++)
                lineas += "-";

            return lineas;
        }
        public string getLiniasAteriscos(int charMaximoXLinea)
        {
            string lineas = "";
            for (int x = 0; x < charMaximoXLinea; x++)
                lineas += "*";

            return lineas;
        }
        public string LiniasIguals(int charMaximoXLinea)
        {
            string lineas = "";
            for (int x = 0; x < charMaximoXLinea; x++)
                lineas += "=";

            return lineas;
        }


        public string EspaciosCentrar(string cadenatexto, int charMaximoXLinea)
        {
            string espacios = "";
            int centrar = (charMaximoXLinea - cadenatexto.Length) / 2;
            for (int i = 0; i < centrar; i++)
            {
                espacios += " ";
            }
            return espacios;
        }
        public string EspaciosDerecha(string cadenatexto, int charMaximoXLinea)
        {
            string espacios = "";
            int numespaciosder = (charMaximoXLinea - cadenatexto.Length);
            for (int i = 0; i < numespaciosder; i++)
            {
                espacios += " ";
            }
            return espacios;
        }
        public string[] getLineasxEnter(string cadenatexto)
        {
            return cadenatexto.Trim().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }
    }
}
