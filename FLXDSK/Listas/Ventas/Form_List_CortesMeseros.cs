using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Ventas
{
    public partial class Form_List_CortesMeseros : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Cortes.Class_CorteMesero fnCorte = new Classes.Cortes.Class_CorteMesero();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_CortesMeseros()
        {
            InitializeComponent();
        }

        private void Form_List_CortesMeseros_Load(object sender, EventArgs e)
        {
            dateTimePicker_FI.Value = DateTime.Now.AddDays(-5);
            dateTimePicker_FF.Value = DateTime.Now.AddDays(1);

            dateTimePicker_FI.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FI.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_FF.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FF.CustomFormat = "dd/MM/yyyy";


            CargaLista();
        }
        public void CargaLista()
        {
            string filtro = "";
            string[] val = dateTimePicker_FI.Text.Split('/');
            string FI = val[2] + "-" + val[1] + "-" + val[0] + "T00:00:00";

            val = dateTimePicker_FF.Text.Split('/');
            string FF = val[2] + "-" + val[1] + "-" + val[0] + "T23:59:59";

            if (FI == "" || FF == "") { MessageBox.Show("Informacion de fechas requerida"); return; }
            filtro = " AND C.dfechaIn between '" + FI + "' AND '" + FF + "' ";



            dataGridView1.DataSource = null;
            string sql = "SELECT C.iidCorteMesero, C.iidPersonal, CONVERT(varchar(10),C.dfechaIn,103)Fecha, " +
	            " P.vchNombres + ' ' + P.vchApellidoPat + ' ' + P.vchApellidoMat as Nombre,  " +
	            " C.fVentaTotal Venta_Total, C.fPropinaObjetivo Propina_Objetivo, C.fPropinaReal Propina_Real, " +
	            " C.fPromedioPersonas Promedio_Personas, C.iNumPedidos Numero_Pedidos " +
            " FROM catCortesMeseros C (NOLOCK), catPersonal  P (NOLOCK) " +
            " WHERE C.iidPersonal = P.iidPersonal  " +
            " AND C.iidEstatus = 1 " + filtro +
            " ORDER by iidCorteMesero DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["iidCorteMesero"].Visible = false;
                dataGridView1.Columns["iidPersonal"].Visible = false;
                dataGridView1.Columns["Fecha"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Venta_Total"].ReadOnly = true;
                dataGridView1.Columns["Propina_Objetivo"].ReadOnly = true;
                dataGridView1.Columns["Propina_Real"].ReadOnly = true;
                dataGridView1.Columns["Promedio_Personas"].ReadOnly = true;
                dataGridView1.Columns["Numero_Pedidos"].ReadOnly = true;

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
            Formularios.Ventas.Form_CorteMeseros from = new Formularios.Ventas.Form_CorteMeseros();
            from.CargaLista += new Form1.MessageHandler(CargaLista);
            from.ShowDialog();
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            CargaLista();
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
                        IdCortes += "," + registro.Cells["iidCorteMesero"].Value.ToString();
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
                        Classes.Print.Class_CorteMesero ClsPrint = new Classes.Print.Class_CorteMesero(IdCorte);
                        ClsPrint.Imprimir();
                    }
                }
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

    }
}
