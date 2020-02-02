using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_Desgloce : Form
    {

        double TotalDesglosadoBilletes = 0.0;
        double TotalDesglosadoMonedas = 0.0;
        DataTable InfoEntrega = null;
        double MontoReportado = 0.0;
        string idCorte = "";

        public Form_Desgloce()
        {
            InitializeComponent();
        }

        private void Form_Desgloce_Load(object sender, EventArgs e)
        {
        }

        private void textBox_F_1000_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_500_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_200_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_100_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_50_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_20_Billete_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoBilletes();
        }

        private void textBox_F_20_Moneda_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_10_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_5_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_2_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_1_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_0_5_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_0_2_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void textBox_F_0_1_TextChanged(object sender, EventArgs e)
        {
            CalculaMontoTecleadoMonedas();
        }

        private void LimpiaCantidades()
        {
            InfoEntrega = new DataTable();
        }
        private void CalculaMontoTecleadoBilletes()
        {
            LimpiaCantidades();
            TotalDesglosadoBilletes = 0.0;
            foreach (Control control in groupBox_DesgloceBilletes.Controls)
            {
                string nombre = control.Name;

                switch (nombre)
                {
                    case "textBox_F_1000":
                        InfoEntrega.Columns.Add("textBox_F_1000", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 1000);
                                label_MF_1000.Text = string.Format("{0:0,0.000}", monto * 1000);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_1000.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_1000.Text = "00,00";
                        }
                        break;
                    case "textBox_F_500":
                        InfoEntrega.Columns.Add("textBox_F_500", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 500);
                                label_MF_500.Text = string.Format("{0:0,0.000}", monto * 500);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_500.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_500.Text = "00,00";
                        }
                        break;
                    case "textBox_F_200":
                        InfoEntrega.Columns.Add("textBox_F_200", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 200);
                                label_MF_200.Text = string.Format("{0:0,0.000}", monto * 200);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_200.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_200.Text = "00,00";
                        }
                        break;
                    case "textBox_F_100":
                        InfoEntrega.Columns.Add("textBox_F_100", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 100);
                                label_MF_100.Text = string.Format("{0:0,0.000}", monto * 100);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_100.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_100.Text = "00,00";
                        }
                        break;
                    case "textBox_F_50":
                        InfoEntrega.Columns.Add("textBox_F_50", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 50);
                                label_MF_50.Text = string.Format("{0:0,0.000}", monto * 50);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_50.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_50.Text = "00,00";
                        }
                        break;
                    case "textBox_F_20_Billete":
                        InfoEntrega.Columns.Add("textBox_F_20_Billete", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoBilletes += (Convert.ToDouble(control.Text) * 20);
                                label_MF_20.Text = string.Format("{0:0,0.000}", monto * 20);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_20.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_20.Text = "00,00";
                        }
                        break;


                }///siwch


            }
            InfoEntrega.Columns.Add("fMontoEfectivo", System.Type.GetType("System.String"));

            label_TotalEfectivoBilletes.Text = string.Format("{0:0,0.000}", TotalDesglosadoBilletes);
            label_TotalEfectivoBilletes.Update();

            InsertaEnTablaCantidadesBilletes();
        }
        private void CalculaMontoTecleadoMonedas()
        {
            LimpiaCantidades();
            TotalDesglosadoMonedas = 0.0;
            foreach (Control control in groupBox_desgloceMonedas.Controls)
            {
                string nombre = control.Name;

                switch (nombre)
                {
                    case "textBox_F_20_Moneda":
                        InfoEntrega.Columns.Add("textBox_F_20_Moneda", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 20);
                                label_MF_20_Moneda.Text = string.Format("{0:0,0.000}", monto * 20);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_20.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_20.Text = "00,00";
                        }
                        break;
                    case "textBox_F_10":
                        InfoEntrega.Columns.Add("textBox_F_10", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 10);
                                label_MF_10.Text = string.Format("{0:0,0.000}", monto * 10);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_10.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_10.Text = "00,00";
                        }
                        break;
                    case "textBox_F_5":
                        InfoEntrega.Columns.Add("textBox_F_5", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 5);
                                label_MF_5.Text = string.Format("{0:0,0.000}", monto * 5);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_5.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_5.Text = "00,00";
                        }
                        break;
                    case "textBox_F_2":
                        InfoEntrega.Columns.Add("textBox_F_2", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 2);
                                label_MF_2.Text = string.Format("{0:0,0.000}", monto * 2);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_2.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_2.Text = "00,00";
                        }
                        break;
                    case "textBox_F_1":
                        InfoEntrega.Columns.Add("textBox_F_1", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 1);
                                label_MF_1.Text = string.Format("{0:0,0.000}", monto * 1);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_1.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_1.Text = "00,00";
                        }
                        break;
                    case "textBox_F_0_5":
                        InfoEntrega.Columns.Add("textBox_F_0_5", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 0.5);
                                label_MF_0_5.Text = string.Format("{0:0,0.000}", monto * 0.5);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_0_5.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_0_5.Text = "00,00";
                        }
                        break;
                    case "textBox_F_0_2":
                        InfoEntrega.Columns.Add("textBox_F_0_2", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 0.2);
                                label_MF_0_2.Text = string.Format("{0:0,0.000}", monto * 0.2);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_0_2.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_0_2.Text = "00,00";
                        }
                        break;
                    case "textBox_F_0_1":
                        InfoEntrega.Columns.Add("textBox_F_0_1", System.Type.GetType("System.String"));
                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            double monto = 0;
                            try
                            {
                                monto = Convert.ToDouble(control.Text);
                                TotalDesglosadoMonedas += (Convert.ToDouble(control.Text) * 0.1);
                                label_MF_0_1.Text = string.Format("{0:0,0.000}", monto * 0.1);
                            }
                            catch
                            {
                                control.Text = "0";
                                label_MF_0_1.Text = "00,00";
                            }
                        }
                        else
                        {
                            label_MF_0_1.Text = "00,00";
                        }
                        break;


                }///siwch


            }
            InfoEntrega.Columns.Add("fMontoEfectivo", System.Type.GetType("System.String"));

            label_TotalEfectivoMonedas.Text = string.Format("{0:0,0.000}", TotalDesglosadoMonedas);
            label_TotalEfectivoMonedas.Update();
            
            
        }

       

        private void InsertaEnTablaCantidadesBilletes()
        {
            DataRow Drw;
            Drw = InfoEntrega.NewRow();

           foreach (Control control in groupBox_DesgloceBilletes.Controls)
                    {
                        string nombre = control.Name;
                        switch (nombre)
                        {
                            case "textBox_F_1000":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_1000"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_1000"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_1000"] = "0";
                                }
                                break;
                            case "textBox_F_500":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_500"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_500"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_500"] = "0";
                                }
                                break;
                            case "textBox_F_200":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_200"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_200"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_200"] = "0";
                                }
                                break;
                            case "textBox_F_100":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_100"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_100"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_100"] = "0";
                                }
                                break;
                            case "textBox_F_50":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_50"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_50"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_50"] = "0";
                                }
                                break;
                            case "textBox_F_20_Billete":
                                if (!string.IsNullOrEmpty(control.Text))
                                {
                                    try
                                    {
                                        double monto = Convert.ToDouble(control.Text);
                                        Drw["textBox_F_20_Billete"] = control.Text;
                                    }
                                    catch
                                    {
                                        Drw["textBox_F_20_Billete"] = "0";
                                    }

                                }
                                else
                                {
                                    Drw["textBox_F_20_Billete"] = "0";
                                }
                                break;
                            
                }
            }
            Drw["fMontoEfectivo"] = TotalDesglosadoBilletes.ToString();
            InfoEntrega.Rows.Add(Drw);
            double sumaMonto = TotalDesglosadoMonedas + TotalDesglosadoBilletes;
        }

        private void textBox_F_1000_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            { textBox_F_500.Focus(); }
        }

        private void textBox_F_500_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            { textBox_F_200.Focus(); }
        }
    }
}
