using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLXDSK.Classes.Herramientas
{
    class Class_ConvertidoMedida
    {
        double fCandidaMinima = 0;
        double CantidadConvertir = 0;

        public string UnidadPone = "";
        public string UnidadProducto = "";
        

        Classes.Internos.Class_UnidadesMetricas ClsUnidadMetrica = new Internos.Class_UnidadesMetricas();

        public bool ProcesasaConversion(string UnidadProducto, string UnidadPone,  double fCantidad)
        {
            this.UnidadProducto = UnidadProducto.ToUpper();
            this.UnidadPone = UnidadPone;
            this.CantidadConvertir = fCantidad;


            if(!ValidaInfo())
                return false;

            if (!GetUnidades())
                return false;


            return true;
        }
        private bool ValidaInfo()
        {
            if (UnidadPone.Trim() == "" || UnidadProducto.Trim() == "")
                return false;


            if (UnidadProducto != "LT" && UnidadProducto != "OZ" && UnidadProducto != "GR" && UnidadProducto != "PZ" && UnidadProducto != "ML" && UnidadProducto != "KG")
                return false;

            if (UnidadPone != "LT" && UnidadPone != "OZ" && UnidadPone != "GR" && UnidadPone != "PZ" && UnidadPone != "ML" && UnidadPone != "KG")
                return false;



            return true;
        }


        private bool GetUnidades()
        {
            string UniProd_UniEntra = UnidadProducto+"-"+UnidadPone;

            switch (UniProd_UniEntra)
            {
                case "PZ-PZ":
                    {
                        fCandidaMinima = CantidadConvertir;
                        return true;
                    }
                ///Kilos
                case "KG-KG":
                    {
                        fCandidaMinima = CantidadConvertir * 1000;
                        return true;
                    }
                case "KG-GR":
                    {
                        fCandidaMinima = CantidadConvertir;
                        return true;
                    }
                ///Litros
                case "LT-LT":
                    {
                        fCandidaMinima = CantidadConvertir * 1000;
                        return true;
                    }
                case "LT-ML":
                    {
                        fCandidaMinima = CantidadConvertir;
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }

        }


        
    }
}
