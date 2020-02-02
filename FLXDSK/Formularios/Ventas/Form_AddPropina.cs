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
    public partial class Form_AddPropina : Form
    {
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();

        public Form_AddPropina()
        {
            InitializeComponent();
        }

        private void CargaUltimosPedidos()
        {
            DataTable dtPedidos = ClsPedidos.getLista(" AND P.siPagado = 1 AND P.fPropina = 0 AND P.iidEstatus = 1 AND P.iidCorte = 0 AND P.iidCorteMesero = 0 ORDER BY P.iidPedido ASC ");
            if (dtPedidos.Rows.Count > 0)
            {
                groupBox_Ultimos.Controls.Clear();
                int LocationX = 5;
                int LocationY = 20;

                foreach (DataRow Row in dtPedidos.Rows)
                {
                    Label labInfo = new Label();
                    labInfo.Text = "Folio. " + Row["iidPedido"].ToString() + " // Mesa: " + Row["Mesa"].ToString() + " // Monto: " + string.Format("{0:c}", Convert.ToDouble(Row["fTotal"].ToString())) + " // Atendio: " + Row["Mesero"].ToString();
                    labInfo.AutoSize = false;
                    labInfo.Width = groupBox_Ultimos.Width-10;
                    labInfo.Height = 20;
                    labInfo.Name = Row["iidPedido"].ToString();
                    labInfo.Font = new Font("Arial", 10);
                    labInfo.Location = new Point(LocationX, LocationY);
                    labInfo.BackColor =Color.AliceBlue;
                    labInfo.Click += new EventHandler(click_SelecPedido);

                    groupBox_Ultimos.Controls.Add(labInfo);

                    LocationY += 25;

                }
            }
        }
        private void click_SelecPedido(Object sender, EventArgs e)
        {
            Label btn_Cliked = (Label)sender;
            string idPedido = btn_Cliked.Name;
            textBox_Folio.Text = idPedido;
            textBox_Monto.Focus();
        }

        private void Form_AddPropina_Load(object sender, EventArgs e)
        {
            CargaUltimosPedidos();
            textBox_Folio.Focus();
        }

        private void textBox_Folio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==Convert.ToChar(Keys.Enter))
                textBox_Monto.Focus();
        }
        private void textBox_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                AgregaPropina();
        }
        private void button_Agregar_Click(object sender, EventArgs e)
        {
            AgregaPropina();
        }
        private void AgregaPropina()
        {
            if (textBox_Folio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un folio de venta");
                textBox_Folio.Focus();
                return;
            }
            if (textBox_Monto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el monto de la propina");
                textBox_Monto.Focus();
                return;
            }

            int Folio = 0;
            double Monto = 0;
            try
            {
                Folio = Convert.ToInt32(textBox_Folio.Text.Trim());
            }
            catch {
                MessageBox.Show("Ingrese un folio de venta correcto");
                textBox_Folio.Focus();
                return;
            }
            try
            {
                Monto = Convert.ToDouble(textBox_Monto.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Ingrese un monto de propina correcto");
                textBox_Monto.Focus();
                return;
            }

            DataTable dtInfo = ClsPedidos.getListaWhere(" WHERE iidPedido = " + Folio);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Folio de venta no encontrado");
                textBox_Folio.Focus();
                return;
            }

            if (dtInfo.Rows[0]["siPagado"].ToString() == "0")
            {
                MessageBox.Show("Pedido Pendiente de Pago");
                textBox_Folio.Focus();
                return;
            }

            if (dtInfo.Rows[0]["fPropina"].ToString() != "0" && dtInfo.Rows[0]["fPropina"].ToString() != "")
            {
                MessageBox.Show("El Pedido ya cuenta con una Propina");
                textBox_Folio.Focus();
                return;
            }

            if (ClsPedidos.ActualizaPropina(Folio.ToString(), Monto))
            {
                MessageBox.Show("Propina Guardada");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Problema al Guardar la Propina, contacte al administrador");
                return;
            }
        

        }

        
    }
}
