using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Ventas
{
    class Class_ObjPedido
    {
        public string KEY="";
        public string RFC="";

        public string RFC_CLIENTE="";
        public string Id="";
        public string Fecha="";
        public string SubTotal="";
        public string Descuento="";
        public string IVA="";
        public string Total="";

        public DataTable Productos = null;

    }
}
