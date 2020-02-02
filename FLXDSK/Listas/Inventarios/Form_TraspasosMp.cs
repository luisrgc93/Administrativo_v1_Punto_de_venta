using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Inventarios
{
    public partial class Form_TraspasosMp : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        
        Classes.Inventarios.Class_Traspasos ClsTraspaso = new Classes.Inventarios.Class_Traspasos();
        Classes.Inventarios.Class_ProcesoTraspaso ClsProcesoTras = new Classes.Inventarios.Class_ProcesoTraspaso();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();


        public Form_TraspasosMp()
        {
            InitializeComponent();
        }

        private void Form_TraspasosMp_Load(object sender, EventArgs e)
        {
            dateTimePicker_FI.Value = DateTime.Now.AddDays(-10);
            dateTimePicker_FF.Value = DateTime.Now.AddDays(1);

            dateTimePicker_FI.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FI.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_FF.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FF.CustomFormat = "dd/MM/yyyy";

            CargaLista();
        }
        private void CargaLista()
        {
            dataGridView_Lista.DataSource = null;



            string filtro = "";
            string[] val = dateTimePicker_FI.Text.Split('/');
            string FI = val[2] + "-" + val[1] + "-" + val[0] + "T00:00:00";

            val = dateTimePicker_FF.Text.Split('/');
            string FF = val[2] + "-" + val[1] + "-" + val[0] + "T23:59:59";

            if (FI == "" || FF == "") { MessageBox.Show("Informacion de fechas requerida"); return; }

            filtro = " AND T.dfechaIn between '" + FI + "' AND '" + FF + "' ";


            string sql = " " +
            " SELECT Folio, Fecha [Fecha Creado], MAX(Recibido)[Fecha Recibido], " +
                " MAX(Estatus)Estatus, " +
                " MAX(iidAlmacen_Origen)iidAlmacen_Origen, " +
                " MAX(iidAlmacen_Destino)iidAlmacen_Destino, " +
                " MAX(iidUsuario_Origen)iidUsuario_Origen,  " +
                " MAx(iidUsuario_Destino)iidUsuario_Destino, " +
                 " " +
                " MAX(Almacen_Origen)[Almacen Envia],  " +
                " MAX(Almacen_Destino)[Almacen Recibe], " +
                " MAX(Envia)[Usuario Envia], " +
                " MAX(Recibe)[Usuario Recibe] " +
            " FROM( " +
                " SELECT T.iidFolio Folio,  " +
                    " CONVERT(varchar(10),T.dfechaIn,103)Fecha, " +
                    " CONVERT(varchar(10),T.dfechaRecepcion,103)Recibido, " +
                    " T.iidAlmacen_Origen, A.vchNombre Almacen_Origen, " +
                    " T.iidAlmacen_Destino,  '' Almacen_Destino, " +
                    " T.iidUsuario_Origen, U.vchUsuario  Envia, " +
                    " T.iidUsuario_Destino, '' Recibe, " +
                    " CASE  " +
                        " WHEN (T.iidEstatus = '0') AND (T.siEntregado = '0')  THEN 'PENDIENTE' " +
                        " WHEN (T.iidEstatus = '1') AND (T.siEntregado = '0')  THEN 'ENVIADO' " +
                        " WHEN (T.iidEstatus = '1') AND (T.siEntregado = '1')  THEN 'ENTREGADO' " +
                        " ELSE  'SIN ESTATUS' " +
                    " END  Estatus, " +
                    " T.vchcomentario " +
                " FROM catTraspasos (NOLOCK) T, catAlmacenes A (NOLOCK), catUsuarios U (NOLOCK) " +
                " WHERE T.iidAlmacen_Origen = A.iidAlmacen " +
                " AND T.iidUsuario_Origen = U.iidUsuario " +
                " AND T.iidEstatus IN (0,1) " + filtro +
                     " " +
                " UNION ALL " +
                     " " +
                " SELECT T.iidFolio Folio,  " +
                    " CONVERT(varchar(10),T.dfechaIn,103)Fecha, " +
                    " ''Recibido, " +
                    " T.iidAlmacen_Origen, '' Almacen_Origen, " +
                    " T.iidAlmacen_Destino, A.vchNombre Almacen_Destino, " +
                    " T.iidUsuario_Origen, '' Envia, " +
                    " T.iidUsuario_Destino, U.vchUsuario Recibe, " +
                    " ''  Estatus, " +
                    " T.vchcomentario " +
                " FROM catAlmacenes A(NOLOCK) , catTraspasos (NOLOCK) T LEFT OUTER JOIN catUsuarios U (NOLOCK) ON T.iidUsuario_Destino = U.iidUsuario " +
                " WHERE T.iidAlmacen_Destino = A.iidAlmacen " +
                " AND T.iidEstatus IN (0,1) " + filtro +
                     " " +
            " ) as T1 " +
            " GROUP BY Folio, Fecha " +
            " ORDER BY  Folio DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["Folio"].ReadOnly = true;
                dataGridView_Lista.Columns["Fecha Creado"].ReadOnly = true;
                dataGridView_Lista.Columns["Fecha Recibido"].ReadOnly = true;
                dataGridView_Lista.Columns["Estatus"].ReadOnly = true;

                dataGridView_Lista.Columns["iidAlmacen_Origen"].Visible = false;
                dataGridView_Lista.Columns["iidAlmacen_Destino"].Visible = false;
                dataGridView_Lista.Columns["iidUsuario_Origen"].Visible = false;
                dataGridView_Lista.Columns["iidUsuario_Destino"].Visible = false;

                dataGridView_Lista.Columns["Almacen Envia"].Width = 150;
                dataGridView_Lista.Columns["Almacen Envia"].ReadOnly = true;
                dataGridView_Lista.Columns["Almacen Recibe"].Width = 150;
                dataGridView_Lista.Columns["Almacen Recibe"].ReadOnly = true;

                dataGridView_Lista.Columns["Usuario Envia"].Width = 100;
                dataGridView_Lista.Columns["Usuario Envia"].ReadOnly = true;
                dataGridView_Lista.Columns["Usuario Recibe"].Width = 100;
                dataGridView_Lista.Columns["Usuario Recibe"].ReadOnly = true;

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
            Formularios.Inventarios.Form_TraspasoMp frm = new Formularios.Inventarios.Form_TraspasoMp("");
            frm.CargaLista += new Form1.MessageHandler(CargaLista);
            frm.ShowDialog();
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            CargaLista();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            string Estatus = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            if (Estatus == "ENVIADO" || Estatus == "ENTREGADO")
            {
                MessageBox.Show("No puedes eliminar un movimiento que ya esta en proceso.");
                return;
            }


            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if (ClsTraspaso.EliminaRegistro(IdRegistro))
                {
                    MessageBox.Show("Eliminado Correctamente.");
                    CargaLista();
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al Eliminar.");
                    return;
                }
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            string Estatus = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            if (Estatus == "ENVIADO" || Estatus == "ENTREGADO")
            {
                MessageBox.Show("No puedes Editar un movimiento que ya esta en proceso.");
                return;
            }

            Formularios.Inventarios.Form_TraspasoMp Form = new Formularios.Inventarios.Form_TraspasoMp(IdRegistro);
            Form.CargaLista += new Form1.MessageHandler(CargaLista);
            Form.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string IdRegistro = row.Cells["Folio"].Value.ToString();

                Formularios.Inventarios.Form_TraspasoMp frm = new Formularios.Inventarios.Form_TraspasoMp(IdRegistro);
                frm.CargaLista += new Form1.MessageHandler(CargaLista);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Folio+' '+[Almacen Envia] LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void toolStripButton_PDF_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            Reportes.Existencias.Form_Reporte_Traspaso Form = new Reportes.Existencias.Form_Reporte_Traspaso(IdRegistro);
            Form.ShowDialog();
        }

        private void toolStripButton_Procesar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            string Estatus = "";
            string IdOrigen = "";
            string IdDestino = "";
            string AlmacenRecibe = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();

            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                        IdOrigen = registro.Cells["iidAlmacen_Origen"].Value.ToString();
                        IdDestino = registro.Cells["iidAlmacen_Destino"].Value.ToString();
                        AlmacenRecibe = registro.Cells["Almacen Recibe"].Value.ToString();
                        
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            if (Estatus == "PENDIENTE")
            {
                ///Quito Existncia
                ///valido tenga aun existencias
                
                string Resp = ClsProcesoTras.CuentaConLaExistencia(IdRegistro, IdOrigen);
                if (Resp != "")
                {
                    MessageBox.Show("Los siguientes productos ya no tienen la existencia suficiente para realizar el traspaso:" + Resp);
                    return;
                }
                //Inicial
                DialogResult resultado = MessageBox.Show(@"Esta seguro de Procesar el Traspaso y Enviarlo?", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == resultado)
                {
                    ///se quitan
                    if (ClsProcesoTras.QuitaExistenciaTraspaso(IdRegistro, IdOrigen))
                    {
                        ClsTraspaso.CambiaEstatusEnviado(IdRegistro);
                        MessageBox.Show("Traspaso Enviado");
                        CargaLista();
                    }
                    else
                    {
                        MessageBox.Show("Problema al Enviar el traspaso, contacte al administrador");
                    }
                }
            }
            else
            {
                if (Estatus == "ENVIADO")
                {
                    //Pongo Existencia
                    DialogResult resultado = MessageBox.Show("Desa realizar la Recepción del Almacen " + AlmacenRecibe + "?", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == resultado)
                    {
                        //Agrega Existencias
                        ClsProcesoTras.ProcesaRecepcion(IdRegistro, IdDestino);

                        ClsTraspaso.CambiaEstatusRecibido(IdRegistro);
                        
                        MessageBox.Show("Traspaso Recibido");
                        CargaLista();
                        return;
                    }
                }
                else
                {
                    if (Estatus == "ENTREGADO")
                    {
                        MessageBox.Show("El Movimiento ya se encuentra finalizado");
                        return;
                    }
                }
            }


            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
