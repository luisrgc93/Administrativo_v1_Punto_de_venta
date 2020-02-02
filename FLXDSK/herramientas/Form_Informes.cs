using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.herramientas
{
    public partial class Form_Informes : Form
    {
        Classes.Class_Informe ClsInf = new Classes.Class_Informe();

        public Form_Informes()
        {
            InitializeComponent();
        }

        private void button_Comenzar_Click(object sender, EventArgs e)
        {
            button_Comenzar.Enabled = false;
            comenzar();
            button_Comenzar.Enabled = true;
        }
        private void comenzar()
        {
            string soft = "paga";
            string KeyLicencia = Classes.Class_Session.Serial;
            DataTable dt = new DataTable();
            dt = ClsInf.EnviaInforme();
            int NumeroTotal = dt.Rows.Count;

            /// 1(cuanto me representa una fila/registro
            ///  1 * 100 / NumeroTotal

            float Contador = (1 * 100) / NumeroTotal;


            try
            {
                foreach (DataRow Row in dt.Rows)
                {
                    string idError = Row["iidServicio"].ToString();
                    string fecha = Row["dfecha"].ToString();
                    fecha = fecha.Replace(".", "");
                    string xml = Row["vchXlm"].ToString();
                    string mensaje = Row["vchMesajeResp"].ToString();


                    string resp = "";// FlexSer.InsertaLogSistemFlex(KeyLicencia, soft, fecha, xml, mensaje, idError);

                    if (resp == "1")
                    {
                        ClsInf.EliminaLineaInforme(idError);
                    }


                    int Progres = Convert.ToInt32(Contador);
                    progressBar1.Value = Progres;
                    label_porcentaje.Text = Progres.ToString();
                    label_porcentaje.Update();

                    Contador++;
                }
            }
            catch{ }

            progressBar1.Value = 100;
            MessageBox.Show("Informe Enviado con exito");
            this.Close();

        }

        private void Form_Informes_Load(object sender, EventArgs e)
        {

        }

    }
}
