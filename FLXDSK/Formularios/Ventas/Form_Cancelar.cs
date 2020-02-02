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
    public partial class Form_Cancelar : Form
    {
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();
        Classes.Ventas.Class_Cancelacion ClsCancela = new Classes.Ventas.Class_Cancelacion();
        string IdPedido = "";

        public Form_Cancelar(string id)
        {
            InitializeComponent();
            IdPedido = id;
        }

        private void Form_Cancelar_Load(object sender, EventArgs e)
        {
            if(IdPedido=="")
            {
                MessageBox.Show("Informacion incorrecta");
                this.Close();
                return;
            }


            DataTable dtInfo = ClsPedidos.getLista(" AND  P.iidPedido = " + IdPedido);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Pedido no encontrado");
                this.Close();
                return;
            }

            if (dtInfo.Rows[0]["dfechaIn103"].ToString() == "1")
            {
                MessageBox.Show("El pedido ya se encuentra pagado");
                this.Close();
                return;
            }


            label_Fecha.Text = dtInfo.Rows[0]["dfechaIn103"].ToString();
            label_Pedido.Text = IdPedido;
            label_Total.Text = string.Format("{0:c}",Convert.ToDouble(dtInfo.Rows[0]["fTotal"].ToString()));
            textBox_Comentario.Focus();
        }
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            if (textBox_Comentario.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el motivo de la cancelación");
                return;
            }

            if (ClsCancela.InsertaInformacion(IdPedido, textBox_Comentario.Text.Trim()))
            {
                MessageBox.Show("Cancelado correctamente");
                this.Close();
                return;
            }

            MessageBox.Show("Problema al cancelar contacte al administrador");
            return;
        }

        
    }
}
