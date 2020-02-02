using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
// ReSharper disable PossibleNullReferenceException

namespace FLXDSK.Listas.Ventas
{
    public partial class Form_List_Pedidos : Form
    {
        private readonly Conexion.Class_Conexion _conexion = new Conexion.Class_Conexion();

        private readonly BindingSource _bs = new BindingSource();

        public Form_List_Pedidos()
        {
            InitializeComponent();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void LlenaEstatus()
        {
            DataTable dt = new DataTable("TablaTipos");
            dt.Columns.Add("tipo");
            dt.Columns.Add("idtipo");
            DataRow dr;
            dr = dt.NewRow();
            dr[1] = "0";
            dr[0] = "PENDIENTES DE PAGO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[1] = "1";
            dr[0] = "PAGADOS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[1] = "2";
            dr[0] = "CANCELADOS";
            dt.Rows.Add(dr);

            comboBox_Estatus.DataSource = dt;
            comboBox_Estatus.DisplayMember = "tipo";
            comboBox_Estatus.ValueMember = "idtipo";
        }
        private void Form_List_Pedidos_Load(object sender, EventArgs e)
        {
            dateTimePicker_FI.Value = DateTime.Now.AddDays(-2);
            dateTimePicker_FF.Value = DateTime.Now.AddDays(1);
            dateTimePicker_FI.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FI.CustomFormat = @"dd/MM/yyyy";
            dateTimePicker_FF.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FF.CustomFormat = @"dd/MM/yyyy";

            LlenaEstatus();
            MuestraPedidos();
        }

        public void MuestraPedidos()
        {
            var filtro = "";
            try
            {
                var tipo = comboBox_Estatus.SelectedValue.ToString();
                if (tipo != "")
                    switch (tipo)
                    {
                        case "1":
                        case "0":
                            filtro = " AND c.SiPagado = " + tipo+" AND c.iidEstatus = 1 ";
                            break;
                        case "2":
                            filtro = " AND c.iidEstatus = 2 ";
                            break;
                    }
            }
            catch (Exception)
            {
                // ignored
            }

            var valor = dateTimePicker_FI.Text.Split('/');
            var fi = valor[2] + "-" + valor[1] + "-" + valor[0] + "T00:00:00";
            valor = dateTimePicker_FF.Text.Split('/');
            var ff = valor[2] + "-" + valor[1] + "-" + valor[0] + "T23:59:59";

            filtro += " AND c.dfechain BETWEEN '" + fi + "' AND '" + ff + "'  ";


            dataGridView1.DataSource = null;
            var sql = " SELECT c.iidPedido ID, " +
                " c.fSubtotal Subtotal, c.fDescuento Descuento, c.fTotal Total, " +
                " CASE siFacturado WHEN 0 THEN 'NO' ELSE 'SI' END Facturado, " +
                " Convert(VARCHAR(13),c.dfechain,103) Fecha, P.vchNombres + ' ' + P.vchApellidoPat + ' ' + P.vchApellidoMat Atendio, " +
                " case c.siPagado when 0 then 'No' when 1 then 'Si' end as Pagado " +
            " FROM catPedidos c (NOLOCK), catPersonal P  (NOLOCK) " +
            " WHERE P.iidPersonal = c.iidPersonal " + filtro;

            var areas = new SqlDataAdapter(sql, _conexion.ConexionSQL());
            var dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                // ReSharper disable once PossibleNullReferenceException
                dataGridView1.Columns["ID"].Width = 80;
                dataGridView1.Columns["ID"].Visible = true;
                dataGridView1.Columns["ID"].ReadOnly = true;
                dataGridView1.Columns["Facturado"].ReadOnly = true;
                dataGridView1.Columns["Subtotal"].Width = 200;
                dataGridView1.Columns["Subtotal"].ReadOnly = true;
                dataGridView1.Columns["Subtotal"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["Descuento"].Width = 200;
                dataGridView1.Columns["Descuento"].ReadOnly = true;
                dataGridView1.Columns["Descuento"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["Total"].Width = 200;
                dataGridView1.Columns["Total"].ReadOnly = true;
                dataGridView1.Columns["Total"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["Pagado"].Width = 100;
                dataGridView1.Columns["Pagado"].ReadOnly = true;
                dataGridView1.Columns["Fecha"].Width = 100;
                dataGridView1.Columns["Fecha"].ReadOnly = true;
                dataGridView1.Columns["Atendio"].Width = 200;
                dataGridView1.Columns["Atendio"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = @"Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
                throw new NullReferenceException("Uno de los campos se encuentra nulo");
            }
            _bs.DataSource = dataGridView1.DataSource;
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            _bs.Filter = string.Format(" ID+' '+Area+' '+Mesa+' '+Subtotal+' '+Total+' '+Pagado+' '+Atendio LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = _bs;
        }
        private void toolStripButton_Pagar_Click(object sender, EventArgs e)
        {
            var numPedido = "";
            var contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if (!(bool) registro.Cells["Seleccionar"].Value) continue;
                    contador++;
                    numPedido = registro.Cells["ID"].Value.ToString();
                }
                catch
                {
                    // ignored
                }
            }

            if (contador != 1)
            {
                //MessageBox.Show("Debe seleccionar solo un registro.");
                //return;
                var frm = new Formularios.Ventas.Form_CobrarVenta("");
                frm.lista_pedidos += MuestraPedidos;
                frm.ShowDialog();
            }
            else
            {
                var frm = new Formularios.Ventas.Form_CobrarVenta(numPedido);
                frm.lista_pedidos += MuestraPedidos;
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            var numPedido = row.Cells["ID"].Value.ToString();
            var frm = new Formularios.Ventas.Form_CobrarVenta(numPedido);
            frm.lista_pedidos += MuestraPedidos;
            frm.ShowDialog();
        }

        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            MuestraPedidos();
        }

        private void toolStripButton_Reeimprimir_Click(object sender, EventArgs e)
        {
            var idTickets = "0";
            var contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean) registro.Cells["Seleccionar"].Value != true) continue;
                    contador++;
                    idTickets += "," + registro.Cells["ID"].Value;
                }
                catch
                {
                    // ignored
                }
            }

            if (contador == 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos un pedido.");
                return;
            }

            var parts = idTickets.Split(',');
            foreach (string part in parts)
            {
                if (part == "0" || part == "") continue;
                var clPrinPedido = new Classes.Print.Class_Pedido(part);
                clPrinPedido.Imprimir();
            }
        }
        private void toolStripButton_Editar_Click(object sender, EventArgs e)
        {
            var idTicket = "";
            var contador = 0;
            dataGridView1.EndEdit();

            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if (!(bool) registro.Cells["Seleccionar"].Value) continue;
                    contador++;
                    idTicket = registro.Cells["ID"].Value.ToString();
                }
                catch
                {
                    // ignored
                }
            }

            if (contador != 1)
            {
                MessageBox.Show(@"Debe seleccionar Solo un Pedido.");
                return;
            }

            var res = MessageBox.Show(@"Esta usted seguro de editar el pedido?", @"Confirmar", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;
            var form = new Formularios.Ventas.Form_EditaPedido(idTicket);
            form.ShowDialog();
            MuestraPedidos();
        }
        private void toolStripButton_Cancelar_Click(object sender, EventArgs e)
        {
            var idTicket = "";
            var contador = 0;
            dataGridView1.EndEdit();

            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((bool) registro.Cells["Seleccionar"].Value != true) continue;
                    contador++;
                    idTicket = registro.Cells["ID"].Value.ToString();
                }
                catch
                {
                    // ignored
                }
            }

            if (contador != 1)
            {
                MessageBox.Show(@"Debe seleccionar Solo un Pedido.");
                return;
            }

            var res = MessageBox.Show(@"Esta usted seguro de cancelar las ventas seleccionadas?", @"Confirmar", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;
            var form = new Formularios.Ventas.Form_Cancelar(idTicket);
            form.ShowDialog();
            MuestraPedidos();
        }


        private void comboBox_Estatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MuestraPedidos();
        }

/*
        private void toolStripButton_Propina_Click(object sender, EventArgs e)
        {
            var form = new Formularios.Ventas.Form_AddPropina();
            form.ShowDialog();
        }
*/

/*
        private void toolStripButton_Facturar_Click(object sender, EventArgs e)
        {
            var idTickets = "0";
            var contador = 0;
            dataGridView1.EndEdit();

            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((bool) registro.Cells["Seleccionar"].Value != true ||
                        registro.Cells["Facturado"].Value.ToString() != "NO") continue;
                    contador++;
                    idTickets += "," + registro.Cells["ID"].Value;
                }
                catch
                {
                    // ignored
                }
            }

            if (contador <= 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos un Pedido sin facturar.");
                return;
            }

            var res = MessageBox.Show(@"Esta usted seguro de facturar las ventas seleccionadas?", @"Confirmar", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;
            var form = new Formularios.Facturacion.Form_FacTicket(idTickets);
            form.ShowDialog();
            MuestraPedidos();
        }
*/
    }
}
