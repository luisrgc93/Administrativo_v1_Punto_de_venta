using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO.Ports;
using System.Drawing.Printing;

namespace FLXDSK.Listas.Ventas
{
    public partial class Form_List_Cortes : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_MateriaPrima fnMateriaPrima = new Classes.Class_MateriaPrima();
        Classes.Cortes.Class_Corte fnCorte = new Classes.Cortes.Class_Corte();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Cortes()
        {
            InitializeComponent();
        }

        private void Form_List_Cortes_Load(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
           // bs.Filter = string.Format("Venta_Total+' '+Monto_Efectivo+' '+Monto_TarjetaCredito+' '+Monto_Otros+' '+Ganancias+' '+Total_Descuento+' '+Total_Propinas+' '+Cantidad_Personas+' '+Promedio_ConsumoPersona LIKE '%{0}%'", textBox_Buscar.Text);
           // dataGridView1.DataSource = bs;
        }

        public void CargaLista()
        {
            dataGridView1.DataSource = null;
            string sql = "SELECT iidCorte Folio,  CONVERT(varchar(10),dfechaIn,103)Fecha, CONVERT(varchar(5),dfechaIn,108)Hora,  " +
            " fVentaTotal Venta_Total, " +
            " fMontoSalidaDinero Salidas, fMontoEntradaDinero Entradas,  fMontoInicial Inicial , fPropinaTotal Propinas, fTotalFinal Venta_Final, fTotalEntregado Entregado" +
            " FROM catCortes (NOLOCK) " +
            " WHERE iidCorte >= 0 " +
            " order by dfechaIn desc ";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["Folio"].Width = 50;
                dataGridView1.Columns["Folio"].Visible = true;
                dataGridView1.Columns["Hora"].Width = 100;
                dataGridView1.Columns["Hora"].ReadOnly = true;
                dataGridView1.Columns["Fecha"].Width = 100;
                dataGridView1.Columns["Fecha"].ReadOnly = true;
                dataGridView1.Columns["Venta_Total"].Width = 100;
                dataGridView1.Columns["Venta_Total"].ReadOnly = true;
                dataGridView1.Columns["Salidas"].Width = 100;
                dataGridView1.Columns["Salidas"].ReadOnly = true;
                dataGridView1.Columns["Entradas"].Width = 150;
                dataGridView1.Columns["Entradas"].ReadOnly = true;
                dataGridView1.Columns["Inicial"].Width = 100;
                dataGridView1.Columns["Inicial"].ReadOnly = true;
                dataGridView1.Columns["Propinas"].Width = 100;
                dataGridView1.Columns["Propinas"].ReadOnly = true;
                dataGridView1.Columns["Venta_Final"].Width = 100;
                dataGridView1.Columns["Venta_Final"].ReadOnly = true;
                dataGridView1.Columns["Entregado"].Width = 150;
                dataGridView1.Columns["Entregado"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
            }
            bs.DataSource = dataGridView1.DataSource;
        }

        private void toolStripButton_Cerrar_Corte_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Form_CorteCaja from = new Formularios.Ventas.Form_CorteCaja();
            from.CargaLista += new Form1.MessageHandler(CargaLista);
            from.ShowDialog();
        }

        private void toolStripButton_reeimprimir_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdCortes = "0";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        IdCortes += "," + registro.Cells["Folio"].Value.ToString();
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            DialogResult res = MessageBox.Show(@"Esta usted seguro de imprimir los registros seleccionados?", "Confirmar", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string[] valores = IdCortes.Split(',');
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] != "0")
                    {
                        string IdCorte = valores[i];
                        //Imprimimos
                        Classes.Print.Class_Corte ClsPrint = new Classes.Print.Class_Corte(IdCorte);
                        ClsPrint.Imprimir();
                    }
                }
            }

        }

        private void toolStripButton_EnviarMail_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdCortes = "0";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        IdCortes += "," + registro.Cells["Folio"].Value.ToString();
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            DialogResult res = MessageBox.Show(@"Esta usted seguro de cancelar las ventas seleccionadas?", "Confirmar", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                ///correo notificacion
                string CorreoEnvio = "";
                DataRow[] RowVal;
                if (Classes.Class_Session.dtParamConf != null)
                {
                    RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Notificación Corte'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                            CorreoEnvio = RowVal[0]["vchConfiguracion"].ToString();

                }

                if (CorreoEnvio == "")
                {
                    MessageBox.Show("No existe Correo Configurado para el envio del corte");
                    return;
                }

                ////
                string[] valores = IdCortes.Split(',');
                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] != "0")
                    {
                        string IdCorte = valores[i];

                        //Enviamos
                        Classes.Correo.Class_EnviaCorte ClsSendCorte = new Classes.Correo.Class_EnviaCorte();
                        if (ClsSendCorte.EnviaCorreo(IdCorte, CorreoEnvio))
                        {
                            MessageBox.Show("Correo enviado con exito");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Problema al enviar, intente mas tarde");
                            return;
                        }
                    }
                }
            }
        }

        private void toolStripButton_Propinas_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdCortes = "0";
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        IdCortes = registro.Cells["Folio"].Value.ToString();
                        contador++;
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            string[] valores = IdCortes.Split(',');
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] != "0")
                {
                    string IdCorte = valores[i];
                    Reportes.Ventas.Reporte_RepartoPropina formPropina = new Reportes.Ventas.Reporte_RepartoPropina(valores[i]);
                    formPropina.Show();
                }
            }
        }
        
    }
}
