using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FLXDSK.Listas.Inventarios
{
    public partial class Form_List_Compras : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Inventarios.Class_Compras ClsCom = new Classes.Inventarios.Class_Compras();
        
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public Form_List_Compras()
        {
            InitializeComponent();
        }

        private void Form_List_Compras_Load(object sender, EventArgs e)
        {
            dateTimePicker_FI.Value = DateTime.Now.AddDays(-10);
            dateTimePicker_FF.Value = DateTime.Now.AddDays(1);

            dateTimePicker_FI.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FI.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_FF.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FF.CustomFormat = "dd/MM/yyyy";

            CargaListaAll();
        }
        private void CargaListaAll()
        {
            dataGridView_Lista.DataSource = null;



            string filtro = "";
            string[] val = dateTimePicker_FI.Text.Split('/');
            string FI = val[2] + "-" + val[1] + "-" + val[0] + "T00:00:00";

            val = dateTimePicker_FF.Text.Split('/');
            string FF = val[2] + "-" + val[1] + "-" + val[0] + "T23:59:59";

            if (FI == "" || FF == "") { MessageBox.Show("Informacion de fechas requerida"); return; }
            filtro = " AND C.dFechaCompra between '" + FI + "' AND '" + FF + "' ";


            string sql = " " +
            " SELECT C.iidCompra, C.iidAlmacen, P.vchNombreComercial Proveedor, " +
                " CONVERT(VARCHAR(10), dFechaCompra, 103) AS [Fecha de Compra], " +
                    " CASE WHEN C.vchSerie != '' AND C.iFolio != 0 THEN C.vchSerie+'-'+CAST(C.iFolio as varchar(10)) " +
                    " ELSE C.vchSerie+' '+CAST(C.iFolio as varchar(10)) END Folio, " +
                " A.vchNombre Almacen, " +
                " CASE WHEN C.siTerminada = 0 THEN 'NO' ELSE 'SI' END AS Procesado,  " +
                " CASE WHEN C.siPagado = 0 THEN 'NO' ELSE 'SI' END AS Pagado,  " +
                " fTotal Total " +
            " FROM catCompras C (NOLOCK), catProveedores P (NOLOCK), catAlmacenes A (NOLOCK) " +
            " WHERE C.iidProveedor = P.iidProveedor  " +
            " AND A.iidAlmacen = C.iidAlmacen  " +
            " AND C.iidEstatus = 1 " +  filtro + 
            " ORDER BY C.dfechaIn DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidCompra"].Visible = false;
                dataGridView_Lista.Columns["iidAlmacen"].Visible = false;

                dataGridView_Lista.Columns["Proveedor"].Width = 200;
                dataGridView_Lista.Columns["Proveedor"].ReadOnly = true;
                dataGridView_Lista.Columns["Folio"].ReadOnly = true;
                dataGridView_Lista.Columns["Folio"].Width = 80;
                dataGridView_Lista.Columns["Total"].Width = 80;
                dataGridView_Lista.Columns["Total"].ReadOnly = true;
                dataGridView_Lista.Columns["Fecha de Compra"].Width = 150;
                dataGridView_Lista.Columns["Fecha de Compra"].ReadOnly = true;
                dataGridView_Lista.Columns["Almacen"].Width = 100;
                dataGridView_Lista.Columns["Almacen"].ReadOnly = true;
                dataGridView_Lista.Columns["Pagado"].Width = 100;
                dataGridView_Lista.Columns["Pagado"].ReadOnly = true;
                dataGridView_Lista.Columns["Procesado"].Width = 100;
                dataGridView_Lista.Columns["Procesado"].ReadOnly = true;

                if (!dataGridView_Lista.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView_Lista.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
            }
            bs.DataSource = dataGridView_Lista.DataSource;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Inventarios.Form_Compra frm = new Formularios.Inventarios.Form_Compra("");
            frm.CargaListaAll += new Form1.MessageHandler(CargaListaAll);
            frm.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            string StatusProcesado = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["iidCompra"].Value.ToString();
                        StatusProcesado = registro.Cells["Procesado"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro, que no este procesado");
                return;
            }

            if (StatusProcesado == "SI")
            {
                MessageBox.Show("No puede eliminar una compra ya ingresada");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if (ClsCom.EliminaRegistro(IdRegistro))
                {
                    MessageBox.Show("Eliminado con exito");
                    CargaListaAll();
                }
                else
                    MessageBox.Show("Problema al eliminar, contacte al administrador");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string idcompra = row.Cells["iidCompra"].Value.ToString();
                string Procesado = row.Cells["Procesado"].Value.ToString();
                if (Procesado == "SI")
                {
                    MessageBox.Show("No puede editar una compra ya ingresada");
                    return;
                }

                Formularios.Inventarios.Form_Compra frm = new Formularios.Inventarios.Form_Compra(idcompra);
                frm.CargaListaAll += new Form1.MessageHandler(CargaListaAll);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Proveedor+' '+Total+' '+[Fecha de Compra] LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void toolStripButton_Abonar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            dataGridView_Lista.EndEdit();
            string idcompra = "";
            string Procesado = "";
            string Pagado = "";
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        idcompra = registro.Cells["iidCompra"].Value.ToString();
                        Procesado = registro.Cells["Procesado"].Value.ToString();
                        Pagado = registro.Cells["Pagado"].Value.ToString();
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
            if (Procesado == "NO")
            {
                MessageBox.Show("La compra se requiere debidamente Ingresada/Procesada para añadirle pagos");
                return;
            }
            if (Pagado == "SI")
            {
                MessageBox.Show("La compra se encuentra pagada");
                return;
            }


            Formularios.Existencias.Form_Abonos frm = new Formularios.Existencias.Form_Abonos(idcompra);
            frm.CargaListaAll += new Form1.MessageHandler(CargaListaAll);
            frm.ShowDialog();
        }

        private void toolStripButton_Editar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "";
            string StatusProcesado = "";
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["iidCompra"].Value.ToString();
                        StatusProcesado = registro.Cells["Procesado"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar solo un registro");
            }

            if (StatusProcesado == "SI")
            {
                MessageBox.Show("No puede editar una compra ya ingresada");
                return;
            }



            Formularios.Inventarios.Form_Compra frm = new Formularios.Inventarios.Form_Compra(IdRegistro);
            frm.CargaListaAll += new Form1.MessageHandler(CargaListaAll);
            frm.ShowDialog();
            
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            CargaListaAll();
        }

        private void toolStripButton_Procesar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "";
            string StatusProcesado = "";
            string iidAlmacen = "";
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["iidCompra"].Value.ToString();
                        StatusProcesado = registro.Cells["Procesado"].Value.ToString();
                        iidAlmacen = registro.Cells["iidAlmacen"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar solo un registro");
            }

            if (StatusProcesado == "SI")
            {
                MessageBox.Show("No puede procesar una compra ya ingresada");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de terminar la procesar y cerrarla?", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {

                
                //Meto al Inventario
                //Actualizo Precios
                if (ClsCom.ProcesaCompra(IdRegistro, iidAlmacen))
                {
                    //Calculo Costo Promedio

                    MessageBox.Show("Procesado Correctamente.");
                    CargaListaAll();
                    return;
                }
                {
                    MessageBox.Show("Problema al Procesar, Contacte al Administrador.");
                    return;
                }

            }

        }

        private void toolStripButton_PDF_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string IdRegistro = "";
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["iidCompra"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar almenos un registro");
            }

            Reportes.Existencias.Form_Reporte_Compra FomrRemp = new Reportes.Existencias.Form_Reporte_Compra(IdRegistro);
            FomrRemp.Show();

        }
    }
}
