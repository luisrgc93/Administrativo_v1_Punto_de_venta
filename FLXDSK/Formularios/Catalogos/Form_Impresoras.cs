using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_Impresoras : Form
    {
        string idImpresora = "";
        Classes.Herramientas.Class_ConfigImpresora ClsPort = new Classes.Herramientas.Class_ConfigImpresora();
        public event Form1.MessageHandler Lista_Impresoras;

        public Form_Impresoras(string temp)
        {
            InitializeComponent();
            idImpresora = temp;
        }

        private void Form_Impresoras_Load(object sender, EventArgs e)
        {
            cargaPuertos();
            cargaBaudRates();
            cargaDataBists();
            cargaPartys();
            cargaStopBist();
            cargaHandls();            

            if (idImpresora != "")
            {
                CargaInformacionAlmacenada(idImpresora);
            }
        }

        private void CargaInformacionAlmacenada(string iidImpresora)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = ClsPort.getInfoSerialPort(iidImpresora);
            DataRow RowInf = null;
            if (dtInfo.Rows.Count > 0)
            {
                RowInf = dtInfo.Rows[0];
                textBox_Nombre.Text = RowInf["vchDeviceUso"].ToString();
                textBox_DireccionRed.Text = RowInf["vchDireccionRed"].ToString();
                comboBox_PortPrint.SelectedValue = RowInf["vchPortName"].ToString();
                comboBox_BaudPrint.SelectedValue = RowInf["iBaudRate"].ToString();
                comboBox_HardPrint.SelectedValue = RowInf["Handshake"].ToString();
                comboBox_PartyPrint.SelectedValue = RowInf["Parity"].ToString();
                comboBox_DataPrint.SelectedValue = RowInf["DataBits"].ToString();
                comboBox_StopPrint.SelectedValue = RowInf["StopBits"].ToString();
            }
        }
        private void cargaHandls()
        {
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");
            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");

            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");

            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");

            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");

            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");

            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");

            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");

            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);

            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);

            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);

            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);

            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);

            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);

            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                string value = s.ToString();
                dr = dtRt.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtRt.Rows.Add(dr);
                dr = dtVe.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtVe.Rows.Add(dr);
                dr = dtAd.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtAd.Rows.Add(dr);
                dr = dtPrint.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtPrint.Rows.Add(dr);
                dr = dtTerme1.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme1.Rows.Add(dr);
                dr = dtTerme2.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme2.Rows.Add(dr);
                dr = dtTerme3.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme3.Rows.Add(dr);
            }
            comboBox_HardPrint.DataSource = dtPrint;
            comboBox_HardPrint.DisplayMember = "id";
            comboBox_HardPrint.ValueMember = "nombre";
        }
        private void cargaStopBist()
        {
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");
            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");

            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");

            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");

            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");

            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");

            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");

            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");

            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);
            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);
            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);
            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);
            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);
            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);
            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                string value = s.ToString();
                dr = dtRt.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtRt.Rows.Add(dr);
                dr = dtVe.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtVe.Rows.Add(dr);
                dr = dtAd.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtAd.Rows.Add(dr);
                dr = dtPrint.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtPrint.Rows.Add(dr);
                dr = dtTerme1.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme1.Rows.Add(dr);
                dr = dtTerme2.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme2.Rows.Add(dr);
                dr = dtTerme3.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme3.Rows.Add(dr);

            }
            comboBox_StopPrint.DataSource = dtPrint;
            comboBox_StopPrint.DisplayMember = "id";
            comboBox_StopPrint.ValueMember = "nombre";
        }
        private void cargaPartys()
        {
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");
            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");
            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");
            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");
            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");
            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");
            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");
            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");
            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);
            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);
            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);
            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);
            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);
            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);
            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                string value = s.ToString();
                dr = dtRt.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtRt.Rows.Add(dr);
                dr = dtVe.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtVe.Rows.Add(dr);
                dr = dtAd.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtAd.Rows.Add(dr);
                dr = dtPrint.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtPrint.Rows.Add(dr);
                dr = dtTerme1.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme1.Rows.Add(dr);
                dr = dtTerme2.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme2.Rows.Add(dr);
                dr = dtTerme3.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme3.Rows.Add(dr);
            }
            comboBox_PartyPrint.DataSource = dtPrint;
            comboBox_PartyPrint.DisplayMember = "id";
            comboBox_PartyPrint.ValueMember = "nombre";
        }
        private void cargaDataBists()
        {
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");
            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");

            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");

            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");

            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");

            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");

            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");

            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");
            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);

            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);

            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);

            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);

            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);

            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);

            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);

            for (int i = 5; i <= 8; i++)
            {
                dr = dtRt.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtRt.Rows.Add(dr);
                dr = dtVe.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtVe.Rows.Add(dr);
                dr = dtAd.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtAd.Rows.Add(dr);
                dr = dtPrint.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtPrint.Rows.Add(dr);
                dr = dtTerme1.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtTerme1.Rows.Add(dr);
                dr = dtTerme2.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtTerme2.Rows.Add(dr);

                dr = dtTerme3.NewRow();
                dr[1] = i;
                dr[0] = i;
                dtTerme3.Rows.Add(dr);
            }
            comboBox_DataPrint.DataSource = dtPrint;
            comboBox_DataPrint.DisplayMember = "id";
            comboBox_DataPrint.ValueMember = "nombre";
        }
        private void cargaBaudRates()
        {
            Int32[] baudRates = {
                100,300,600,1200,2400,4800,9600,14400,19200,
                38400,56000,57600,115200,128000,256000,0
            };
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");

            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");

            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");

            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");

            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");

            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");

            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");

            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");
            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);

            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);

            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);

            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);

            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);

            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);

            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);

            for (int i = 0; baudRates[i] != 0; ++i)
            {
                string value = baudRates[i].ToString();
                dr = dtRt.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtRt.Rows.Add(dr);

                dr = dtVe.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtVe.Rows.Add(dr);

                dr = dtAd.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtAd.Rows.Add(dr);

                dr = dtPrint.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtPrint.Rows.Add(dr);

                dr = dtTerme1.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme1.Rows.Add(dr);

                dr = dtTerme2.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme2.Rows.Add(dr);

                dr = dtTerme3.NewRow();
                dr[1] = value;
                dr[0] = value;
                dtTerme3.Rows.Add(dr);
            }
            comboBox_BaudPrint.DataSource = dtPrint;
            comboBox_BaudPrint.DisplayMember = "id";
            comboBox_BaudPrint.ValueMember = "nombre";
        }
        private void cargaPuertos()
        {
            DataTable dtRt = new DataTable("TablaTmes");
            DataTable dtVe = new DataTable("TablaTmes");
            DataTable dtAd = new DataTable("TablaTmes");
            DataTable dtPrint = new DataTable("TablaTmes");
            DataTable dtTerme1 = new DataTable("TablaTmes");
            DataTable dtTerme2 = new DataTable("TablaTmes");
            DataTable dtTerme3 = new DataTable("TablaTmes");

            dtRt.Columns.Add("nombre");
            dtRt.Columns.Add("id");

            dtVe.Columns.Add("nombre");
            dtVe.Columns.Add("id");

            dtAd.Columns.Add("nombre");
            dtAd.Columns.Add("id");

            dtPrint.Columns.Add("nombre");
            dtPrint.Columns.Add("id");

            dtTerme1.Columns.Add("nombre");
            dtTerme1.Columns.Add("id");

            dtTerme2.Columns.Add("nombre");
            dtTerme2.Columns.Add("id");

            dtTerme3.Columns.Add("nombre");
            dtTerme3.Columns.Add("id");
            DataRow dr;
            dr = dtRt.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtRt.Rows.Add(dr);

            dr = dtVe.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtVe.Rows.Add(dr);

            dr = dtAd.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtAd.Rows.Add(dr);

            dr = dtPrint.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtPrint.Rows.Add(dr);

            dr = dtTerme1.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme1.Rows.Add(dr);

            dr = dtTerme2.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme2.Rows.Add(dr);

            dr = dtTerme3.NewRow();
            dr[1] = "";
            dr[0] = "";
            dtTerme3.Rows.Add(dr);
            foreach (string s in SerialPort.GetPortNames())
            {
                dr = dtRt.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtRt.Rows.Add(dr);

                dr = dtVe.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtVe.Rows.Add(dr);

                dr = dtAd.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtAd.Rows.Add(dr);

                dr = dtPrint.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtPrint.Rows.Add(dr);

                dr = dtTerme1.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtTerme1.Rows.Add(dr);

                dr = dtTerme2.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtTerme2.Rows.Add(dr);

                dr = dtTerme3.NewRow();
                dr[1] = s;
                dr[0] = s;
                dtTerme3.Rows.Add(dr);
            }
            comboBox_PortPrint.DataSource = dtPrint;
            comboBox_PortPrint.DisplayMember = "id";
            comboBox_PortPrint.ValueMember = "nombre";
        }

        private void button_GuardarPrint_Click(object sender, EventArgs e)
        {
            string puerto = comboBox_PortPrint.SelectedValue.ToString();
            string baud = comboBox_BaudPrint.SelectedValue.ToString();
            string data = comboBox_DataPrint.SelectedValue.ToString();
            string party = comboBox_PartyPrint.SelectedValue.ToString();
            string stop = comboBox_StopPrint.SelectedValue.ToString();
            string hadr = comboBox_HardPrint.SelectedValue.ToString();
            string direccionRed = textBox_DireccionRed.Text;
            string nombre = textBox_Nombre.Text;

            if (puerto == "" || baud == "" || data == "" || party == "" || stop == "" || hadr == "" || direccionRed == "" || textBox_Nombre.Text == "")
            {
                MessageBox.Show("Selecccione toda la informacion");
                return;
            }

            if (ClsPort.exisIdNamePortconf(textBox_Nombre.Text))
            {
                if (ClsPort.ActualizaConfigPort(nombre, direccionRed, puerto, baud, stop, party, data, hadr, "true", "0"))
                {
                    MessageBox.Show("Guardado");
                    Lista_Impresoras();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Problema al Guardar");
                }
            }
            else
            {
                if (ClsPort.InsertaConfigPort(nombre, direccionRed, puerto, baud, stop, party, data, hadr, "true", "0"))
                {
                    MessageBox.Show("Guardado");
                    Lista_Impresoras();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Problema al Guardar");
                }
            }
        }

        private void limpiar()
        {
            textBox_Nombre.Text = "";
            textBox_DireccionRed.Text = "";
            comboBox_HardPrint.SelectedIndex = 0;
            comboBox_StopPrint.SelectedIndex = 0;
            comboBox_PartyPrint.SelectedIndex = 0;
            comboBox_DataPrint.SelectedIndex = 0;
            comboBox_BaudPrint.SelectedIndex = 0;
            comboBox_PortPrint.SelectedIndex = 0;
        }

        private void textBox_DireccionRed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_DireccionRed.Text.Length; i++)
            {
                if (textBox_DireccionRed.Text[i] == '.')
                    punto_decimales = false;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? false : false;
            else
                e.Handled = true;
        }
    }
}
