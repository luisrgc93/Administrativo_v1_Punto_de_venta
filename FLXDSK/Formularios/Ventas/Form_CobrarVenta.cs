using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_CobrarVenta : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();
        Classes.Ventas.Class_DetallePedido ClsDetallePedidos = new Classes.Ventas.Class_DetallePedido();
        Classes.Ventas.Class_PagoPedido ClsPagoPedido = new Classes.Ventas.Class_PagoPedido();

        Classes.Ventas.Class_ProcesoRestaInventario ClsProcesoRestar = new Classes.Ventas.Class_ProcesoRestaInventario();


        

        DataTable dtInfoPedido = null;
        string IdPedido = "";
        public event Form1.MessageHandler lista_pedidos;

        double FPAGADO = 0;
        double FTOTAL = 0;

        double Efectivo = 0;
        double Credito = 0;
        double Debito = 0;
        double Vales = 0;
        double Cheque = 0;
        double Otro = 0;

        public Form_CobrarVenta(string id)
        {
            InitializeComponent();
            IdPedido = id;
        }
        private void DesabilitaCampos()
        {
            textBox_Efectivo.Enabled = false;
            textBox_CreditoTC.Enabled = false;
            textBox_DebitoT.Enabled = false;
            textBox_Vales.Enabled = false;
            textBox_Cheque.Enabled = false;
            textBox_Otro.Enabled = false;

            textBox_Efectivo.Text = "";
            textBox_CreditoTC.Text = "";
            textBox_DebitoT.Text = "";
            textBox_Vales.Text = "";
            textBox_Cheque.Text = "";
            textBox_Otro.Text = "";

            button_Cancelar.Enabled = false;

            textBox_NoPedido.Enabled = true;
            textBox_NoPedido.Text = "";
        }
        private void AbilitaCampos()
        {
            textBox_Efectivo.Enabled = true;
            textBox_CreditoTC.Enabled = true;
            textBox_DebitoT.Enabled = true;
            textBox_Vales.Enabled = true;
            textBox_Cheque.Enabled = true;
            textBox_Otro.Enabled = true;


            button_Cancelar.Enabled = true;

            textBox_NoPedido.Enabled = false;
        }

        private void Form_CobrarVenta_Load(object sender, EventArgs e)
        {
            button_Terminar.Enabled = false;

            if (IdPedido == "")
                DesabilitaCampos();
            else
                ValidaPedido(IdPedido);
        }

        private void textBox_NoPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///validamos
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                try
                {
                    Convert.ToInt32(textBox_NoPedido.Text.Trim());
                    ValidaPedido(textBox_NoPedido.Text.Trim());
                }
                catch {

                    MessageBox.Show("Formado incorrecto");
                    return;
                }
            }
        }
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            DesabilitaCampos();
        }
        private void ValidaPedido(string pedido)
        {
            dtInfoPedido = ClsPedidos.getLista(" AND P.iidPedido = " + pedido);
            if (dtInfoPedido.Rows.Count == 0)
            {
                MessageBox.Show("Pedido no encontrado");
                return;
            }

            if (dtInfoPedido.Rows[0]["siPagado"].ToString() == "1")
            {
                MessageBox.Show("El pedido ya fue pagado");
                return;
            }
            IdPedido = pedido;

            FTOTAL = Convert.ToDouble(dtInfoPedido.Rows[0]["fTotal"].ToString());
            FPAGADO = 0;



            AbilitaCampos();

            textBox_NoPedido.Text = IdPedido;

            
            

            try
            {
                label_Total.Text = string.Format("{0:c}", FTOTAL);
                label_Descuento.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fDescuento"].ToString()));
                label_Subtotal.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fSubtotal"].ToString()));
            }
            catch { }
        }

        private void textBox_Efectivo_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }

        private void textBox_CreditoTC_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }

        private void textBox_DebitoT_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }

        private void textBox_Vales_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }

        private void textBox_Cheque_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }

        private void textBox_Otro_TextChanged(object sender, EventArgs e)
        {
            CalculaPagos();
        }
        /// <summary>
        /// 
        private void textBox_Efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_CreditoTC.Focus();
        }

        private void textBox_CreditoTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_DebitoT.Focus();
        }

        private void textBox_DebitoT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_Vales.Focus();
        }

        private void textBox_Vales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_Cheque.Focus();
        }

        private void textBox_Cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_Otro.Focus();
        }

        private void textBox_Otro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textBox_Propina.Focus();
        }
        private void textBox_Propina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                button_Terminar.Focus();
        }


        private void CalculaPagos()
        {
            FPAGADO = 0;

            Efectivo = 0;
            Credito = 0;
            Debito = 0;
            Vales = 0;
            Cheque = 0;
            Otro = 0;
            try
            {
                Efectivo = Convert.ToDouble(textBox_Efectivo.Text.Trim());
            }
            catch {
                textBox_Efectivo.Text = "";
            }
            try {
                Credito = Convert.ToDouble(textBox_CreditoTC.Text.Trim());
            }
            catch { }
            try
            {
                Debito = Convert.ToDouble(textBox_DebitoT.Text.Trim());
            }
            catch { }
            try
            {
                Vales = Convert.ToDouble(textBox_Vales.Text.Trim());
            }
            catch { }
            try
            {
                Cheque = Convert.ToDouble(textBox_Cheque.Text.Trim());
            }
            catch { }
            try
            {
                Otro = Convert.ToDouble(textBox_Otro.Text.Trim());
            }
            catch { }

            FPAGADO = Efectivo + Credito + Debito + Vales + Cheque + Otro;

            if (FPAGADO > FTOTAL)
            {
                label_Resta.Text = string.Format("{0:c}", 0);
            }
            else
                label_Resta.Text = string.Format("{0:c}", FTOTAL - FPAGADO);


            if (FPAGADO >= FTOTAL)
            {
                label_Cambio.Text = string.Format("{0:c}", Math.Abs(FTOTAL - FPAGADO));
                button_Terminar.Enabled = true;
            }
            else
            {
                label_Cambio.Text = string.Format("{0:c}", 0);
                button_Terminar.Enabled = false;
            }
        }

        private void button_Terminar_Click(object sender, EventArgs e)
        {
            double fPropina = 0;
            if (textBox_Propina.Text.Trim() != "")
            {
                try
                {
                    fPropina = Convert.ToDouble(textBox_Propina.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("El monto ingresado como propina es incorrecto");
                    return;
                }
            }

            DialogResult Resp = MessageBox.Show(@"Esta usted seguro de cerrar la venta?","Confirmar", MessageBoxButtons.YesNo);
            if (Resp == DialogResult.Yes)
            {
                if (FPAGADO >= FTOTAL)
                {
                    if (Math.Abs(FTOTAL - FPAGADO) > Efectivo)
                    {
                        MessageBox.Show("El monto para dar cambio es mayor al que se tiene como efectivo");
                        button_Terminar.Enabled = false;
                        return;
                    }
                }

                double CambioReal = Math.Abs(FTOTAL - FPAGADO);
                double EfectivoReal = Efectivo - CambioReal;



                if (EfectivoReal > 0)
                {
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "1", EfectivoReal);//1	1	01	Efectivo
                }

                if (Credito > 0)
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "4", Credito);//4	1	04	Tarjeta de crédito
                if (Debito > 0)
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "18", Debito);//18	1	28	Tarjeta de débito
                if (Vales > 0)
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "7", Vales);//7	1	08	Vales de despensa
                if (Cheque > 0)
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "2", Cheque);//2	1	02	Cheque nominativo
                if (Otro > 0)
                    ClsPagoPedido.InsertaInformacionbyValor(IdPedido, "20", Otro);//20	1	99	Pordefinir



                ///Obtenemos la Ganancia
                object oGanancia= null;
                DataTable dtDetalle = ClsDetallePedidos.getDetallePedido(IdPedido);
                if (dtDetalle.Rows.Count > 0)
                    oGanancia = dtDetalle.Compute("Sum(fGanancia)", string.Empty);

                double fGanancia = 0;
                try
                {
                    if(oGanancia != null)
                        fGanancia = Convert.ToDouble(oGanancia);
                }
                catch { }

                ///Cerramos y
                if (!ClsPedidos.CierraVenta(IdPedido, FTOTAL.ToString(), CambioReal.ToString(), fPropina, fGanancia))
                {
                    MessageBox.Show("Problema al Cerrar la venta, contacte al administrador");
                    return;
                }
                
                
                /// Imprimimos.
                DialogResult RespPrin = MessageBox.Show(@"Desea Imprimir el ticket?","Confirmar", MessageBoxButtons.YesNo);
                if (RespPrin == DialogResult.Yes)
                {
                    Classes.Print.Class_Pedido ClsPrint = new Classes.Print.Class_Pedido(IdPedido);
                    ClsPrint.Imprimir();
                }

                ///Restamos Existencia
                ClsProcesoRestar.RestaExisteciaVenta(IdPedido);
                

                /////////Enviar ticket a la Nuve
                DataRow[] RowVal;
                if (Classes.Class_Session.dtParamConf != null)
                {
                    RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Utilizar Auto-Factura? (SI/NO)'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchConfiguracion"].ToString().Trim() == "SI")
                        {
                            try
                            {
                             DataTable dtPedido = ClsPedidos.getLista(" AND iidPedido = " + IdPedido);
                                if (dtPedido.Rows.Count > 0)
                                {
                                    DataTable pedido = new DataTable("pedido");


                                    pedido.Columns.Add("KEY", typeof(string));
                                    pedido.Columns.Add("Id", typeof(string));
                                    pedido.Columns.Add("SubTotal", typeof(float));
                                    pedido.Columns.Add("Descuento", typeof(float));
                                    pedido.Columns.Add("IVA", typeof(float));
                                    pedido.Columns.Add("Total", typeof(float));
                                    pedido.Columns.Add("ID_EMPRESA", typeof(string));
                                    pedido.Columns.Add("fechaTicket", typeof(string));
                                    DataRow ROW = pedido.NewRow();

                                    ROW["KEY"] = dtPedido.Rows[0]["vchkey"].ToString();
                                    ROW["Id"] = IdPedido;
                                    ROW["SubTotal"] = dtPedido.Rows[0]["fSubtotal"].ToString();
                                    ROW["Descuento"] = dtPedido.Rows[0]["fDescuento"].ToString();
                                    ROW["IVA"] = dtPedido.Rows[0]["IVA"].ToString();
                                    ROW["Total"] = dtPedido.Rows[0]["fTotal"].ToString();
                                    ROW["ID_EMPRESA"] = dtPedido.Rows[0]["ID_EMPRESA"].ToString();
                                    ROW["fechaTicket"] = dtPedido.Rows[0]["dfechaIn126"].ToString();
                                    pedido.Rows.Add(ROW);
                                     
                                    wschefControl.Service1 WebSer = new wschefControl.Service1();

                                    try
                                    {
                                        WebSer.Upticket(pedido); //se sube la factura
                                    }
                                    catch (System.Exception)
                                    {

                                        MessageBox.Show("Error al enviar información de autofactura.");
                                    }




                                }

                                
                                }
                            catch { }  
                        }
                }
                ///////////////

                this.Close();
                try
                {
                    lista_pedidos();
                }
                catch { }
            }
        }

       
        
        
       
    }
}
