using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Net.Mail;
using System.Collections;
using System.IO;
using System.Configuration;
using System.IO.Ports;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_CorteCaja : Form
    {
        Classes.Cortes.Class_Corte ClsCorte = new Classes.Cortes.Class_Corte();
        Classes.Cortes.Class_ProcesoCorte ClsProcesoCorte = new Classes.Cortes.Class_ProcesoCorte();
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();
        
        Classes.Class_ParametrosGenerales ClsConfig = new Classes.Class_ParametrosGenerales();
        Classes.Herramientas.Class_HostMails ClsHsMail = new Classes.Herramientas.Class_HostMails();


        public event Form1.MessageHandler CargaLista;

        public Form_CorteCaja()
        {
            InitializeComponent();
        }
        private void Form_CorteCaja_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtInfoPedidos = ClsProcesoCorte.getInfoPedidos();
                if (dtInfoPedidos.Rows.Count == 0)
                {
                    MessageBox.Show("No existen ventas registradas");
                    textBox_Efectivo.Enabled = false;
                    textBox_CreditoTC.Enabled = false;
                    textBox_DebitoT.Enabled = false;
                    textBox_Vales.Enabled = false;
                    textBox_Cheque.Enabled = false;
                    textBox_Otro.Enabled = false;

                    button_CerrarCorte.Enabled = false;
                }

                DataTable ExistenPendientesCobro = ClsPedidos.getListaWhere(" WHERE iidEstatus = 1 AND iidCorte= 0 AND siPagado = 0 ");
                if (ExistenPendientesCobro.Rows.Count > 0)
                {
                    DialogResult resp = MessageBox.Show(@"Existen ventas que estan pendientes de cobrar, aun asi desea realizarlo?", "Alerta", MessageBoxButtons.YesNo);
                    if (DialogResult.No == resp)
                    {
                        textBox_Efectivo.Enabled = false;
                        textBox_CreditoTC.Enabled = false;
                        textBox_DebitoT.Enabled = false;
                        textBox_Vales.Enabled = false;
                        textBox_Cheque.Enabled = false;
                        textBox_Otro.Enabled = false;

                        button_CerrarCorte.Enabled = false;
                    }
                }




                DataTable dtInfoTotales = ClsProcesoCorte.dtInfoPedidoTotales();
                foreach (DataRow Row in dtInfoTotales.Rows)
                {
                    ClsCorte.fVentaTotal = Convert.ToDouble(Row["VentaTotal"].ToString());
                    ClsCorte.fTotalDescuentos = Convert.ToDouble(Row["fDescuento"].ToString());
                    ClsCorte.fPropinaTotal = Convert.ToDouble(Row["fPropina"].ToString());
                    ClsCorte.fPromedioPersonas = Convert.ToDouble(Row["PromedioPersonas"].ToString());
                    ClsCorte.iPersonas = Convert.ToInt32(Row["PromedioPersonas"].ToString());
                    ClsCorte.fPromedioConsumo = Convert.ToDouble(Row["PromedioConsumo"].ToString());
                    ClsCorte.fMinPromedioEstancia = Convert.ToInt32(Row["minutos"].ToString());
                    ClsCorte.iNumPedidos = Convert.ToInt32(Row["NumPedidos"].ToString());
                }



                DataTable dtInfoEntregas = ClsProcesoCorte.getTotalesFormas();
                if (dtInfoEntregas.Rows.Count > 0)
                    foreach (DataRow Row in dtInfoEntregas.Rows)
                    {
                        try
                        {
                            //Efectivo - 1
                            if (Row["iidFormaPago"].ToString() == "1")
                                ClsCorte.fVentaEfectivo = Convert.ToDouble(Row["total"].ToString());
                            //TC credito - 4
                            if (Row["iidFormaPago"].ToString() == "4")
                                ClsCorte.fVentaCreditoTC= Convert.ToDouble(Row["total"].ToString());
                            //T Debito - 18 
                            if (Row["iidFormaPago"].ToString() == "18")
                                ClsCorte.fVentaDebito = Convert.ToDouble(Row["total"].ToString());
                            //Vales - 7 
                            if (Row["iidFormaPago"].ToString() == "7")
                                ClsCorte.fVentaVales = Convert.ToDouble(Row["total"].ToString());
                            //cheque - 2
                            if (Row["iidFormaPago"].ToString() == "2")
                                ClsCorte.fVentaCheque = Convert.ToDouble(Row["total"].ToString());

                            //otro - 20
                            if (Row["iidFormaPago"].ToString() == "20")
                                ClsCorte.fVentaOtro = Convert.ToDouble(Row["total"].ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Problema de conversion, contacte al administrador");
                        }
                    }


                //Saldo iniciales de caja
                DataTable saldosIniciales = ClsProcesoCorte.getMontosIniciales();

                dgv_saldosIniciales.Columns.Add("Fecha", "Fecha");
                dgv_saldosIniciales.Columns.Add("Personal", "Personal");
                dgv_saldosIniciales.Columns.Add("Monto","Monto");  
                dgv_saldosIniciales.Columns["Fecha"].Width = 110;


                float saldoInicialtotal = 0;
                foreach (DataRow row in saldosIniciales.Rows)
                {
                    dgv_saldosIniciales.Rows.Add(row["dFechaApertura"], row["nombre"], string.Format("{0:c}", row["fMontoInicial"]));
                    saldoInicialtotal += float.Parse(row["fMontoInicial"].ToString());

                   
                    
                 

                }
                
               ClsCorte.fMontoInicial=saldoInicialtotal; 



                ///Salidas y Entradas
                ClsCorte.fMontoEntradaDinero = 0;
                ClsCorte.fMontoSalidaDinero = 0;
                DataTable dtMovimientos = ClsProcesoCorte.dtMovimientos();
                if (dtMovimientos.Rows.Count > 0)
                {
                    ClsCorte.fMontoEntradaDinero = Convert.ToDouble(dtMovimientos.Rows[0]["Entrada"].ToString());
                    ClsCorte.fMontoSalidaDinero = Convert.ToDouble(dtMovimientos.Rows[0]["Salida"].ToString());
                }


                ClsCorte.fTotalFinal = ClsCorte.fVentaTotal + ClsCorte.fMontoEntradaDinero - ClsCorte.fMontoSalidaDinero;

                label_MontoCaja.Text = string.Format("{0:c}", ClsCorte.fTotalFinal+ ClsCorte.fMontoInicial );

                label_VentasTotales.Text = string.Format("{0:c}", ClsCorte.fVentaTotal);
                label_Entradas.Text = string.Format("{0:c}", ClsCorte.fMontoEntradaDinero);
                label_Salidas.Text ="- "+ string.Format("{0:c}", ClsCorte.fMontoSalidaDinero);

                                                                                                //informacion de corte    solo muestra ultima venta 

                txt_cheque.Text = string.Format("{0:c}", ClsCorte.fVentaCheque);
                txt_efectivo.Text = string.Format("{0:c}", ClsCorte.fVentaEfectivo);
                txt_otro.Text = string.Format("{0:c}", ClsCorte.fVentaOtro);
                txt_tc.Text = string.Format("{0:c}", ClsCorte.fVentaCreditoTC);
                txt_td.Text = string.Format("{0:c}", ClsCorte.fVentaDebito);
                txt_vales.Text = string.Format("{0:c}", ClsCorte.fVentaVales);
                label_total_caja.Text = string.Format("{0:c}", ClsCorte.fTotalFinal+ ClsCorte.fMontoInicial );
                label_inicial.Text = string.Format("{0:c}", ClsCorte.fMontoInicial);
                 

            }
            catch {
                MessageBox.Show("Problema al crear el corte, notificar al administrador");
            }

        }
        private void button_guardar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"¿Estas seguro de guardar el corte? 
 Tenga en cuenta que ya no se podra modificar ", "Confirmacion", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                if (!ClsCorte.InsertaInformacion())
                {
                    MessageBox.Show("Problema al crear el corte, notificar al administrador");
                    return;
                }

                if (!ClsCorte.cerrarCaja())
                {
                   MessageBox.Show("Problema al actualizar saldos iniciales, notificar al administrador"); 
                }


                string IdCorte = ClsCorte.getIdCreado();
                if (IdCorte == "")
                {
                    MessageBox.Show("Problema al obtener el corte creado");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                    return;
                }

                //Actualiza Pedidos
                ClsProcesoCorte.SetPedidosCorte(IdCorte);
                //Actualiza Movimientos
                ClsProcesoCorte.SetMovimientosCorte(IdCorte);

                dialogResult = MessageBox.Show(@"¿Desea Imprimir el corte?", "Confirmacion", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    //Imprimimos
                    Classes.Print.Class_Corte ClsPrint = new Classes.Print.Class_Corte(IdCorte);
                    ClsPrint.Imprimir();
                }

                //Vemos si tiene 
                if (Classes.Class_Session.dtParamConf != null)
                {
                    string CorreoEnvio = "";
                    DataRow[] RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Notificación Corte'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                            CorreoEnvio = RowVal[0]["vchConfiguracion"].ToString();


                    if (CorreoEnvio != "")
                    {
                        Classes.Correo.Class_EnviaCorte ClsSendCorte = new Classes.Correo.Class_EnviaCorte();
                        ClsSendCorte.EnviaCorreo(IdCorte, CorreoEnvio);
                    }
                }

                try
                {
                    CargaLista();
                }
                catch { }
                this.Close();

            }
        }

       
        private void textBox_Efectivo_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }

        private void textBox_CreditoTC_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }

        private void textBox_DebitoT_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }

        private void textBox_Vales_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }

        private void textBox_Cheque_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }

        private void textBox_Otro_TextChanged(object sender, EventArgs e)
        {
            CalculaEntregas();
        }
        private void CalculaEntregas()
        {
            try
            {
                ClsCorte.fEntregaEfectivo = Convert.ToDouble(textBox_Efectivo.Text.Trim());
            }
            catch
            {
                ClsCorte.fEntregaEfectivo = 0;
                textBox_Efectivo.Text = "";
            }
            try
            {
                ClsCorte.fEntregaCreditoTC = Convert.ToDouble(textBox_CreditoTC.Text.Trim());
            }
            catch {
                ClsCorte.fEntregaCreditoTC = 0;
            }
            try
            {
                ClsCorte.fEntregaDebito = Convert.ToDouble(textBox_DebitoT.Text.Trim());
            }
            catch {
                ClsCorte.fEntregaDebito = 0;
            }
            try
            {
                ClsCorte.fEntregaVales = Convert.ToDouble(textBox_Vales.Text.Trim());
            }
            catch 
            { 
                ClsCorte.fEntregaVales = 0;
            }
            try
            {
                ClsCorte.fEntregaCheque = Convert.ToDouble(textBox_Cheque.Text.Trim());
            }
            catch {
                ClsCorte.fEntregaCheque = 0;
            }
            try
            {
                ClsCorte.fEntregaOtro = Convert.ToDouble(textBox_Otro.Text.Trim());
            }
            catch
            {
                ClsCorte.fEntregaOtro = 0;
            }

           
            label_FaltanteSobrante.Text =string.Format("{0:c}",0);
            ClsCorte.fTotalEntregado = ClsCorte.fEntregaEfectivo + ClsCorte.fEntregaCreditoTC + ClsCorte.fEntregaDebito + ClsCorte.fEntregaVales + ClsCorte.fEntregaCheque + ClsCorte.fEntregaOtro+ClsCorte.fEntregaInicial;

            
            label_TotalEntrega.Text = string.Format("{0:c}", ClsCorte.fTotalEntregado);
            label_TipoFS.Text = "";


            if (ClsCorte.fTotalEntregado < (ClsCorte.fTotalFinal+ ClsCorte.fMontoInicial ))
            {
                label_FaltanteSobrante.Text = string.Format("{0:c}", (ClsCorte.fTotalFinal+ ClsCorte.fMontoInicial ) - ClsCorte.fTotalEntregado);
                label_TipoFS.Text = "Faltante";
            }
            else
            {
                label_FaltanteSobrante.Text = string.Format("{0:c}",( ClsCorte.fTotalEntregado  )- (ClsCorte.fTotalFinal+ ClsCorte.fMontoInicial ));
                label_TipoFS.Text = "Sobrante";
            }
        }

    
        
    }
}
