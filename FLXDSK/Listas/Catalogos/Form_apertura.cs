using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Catalogos
{
    public partial class Form_apertura : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public Form_apertura()
        {
            InitializeComponent();
        }

        private void Lista_Aperturas()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView_Lista.DataSource = null;
            string sql = " " +

            "     SELECT iidApertura ID , dFechaApertura Fecha, dFechaCierre cierre,   CASE   WHEN siAbierta = 1 THEN 'SI' ELSE 'NO '  END as siAbierta , fMontoInicial Monto  ,vchNombres+' '+vchApellidoPat+' '+ vchApellidoMat Empleado ,"+
            " a.vchObservacion Comentario FROM catAperturass a, CatPersonal  p where a.iidPersonal=p.iidPersonal    ORDER BY siAbierta DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];
                dataGridView_Lista.Columns["ID"].Visible = false;
               dataGridView_Lista.Columns["Fecha"].Width = 180;
               dataGridView_Lista.Columns["cierre"].Width = 180;
               dataGridView_Lista.Columns["siAbierta"].Width = 100;
               dataGridView_Lista.Columns["Empleado"].Width = 200;
               dataGridView_Lista.Columns["Comentario"].Width = 180;
               dataGridView_Lista.Columns["Monto"].Width = 100;
               
               

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
            catch (Exception exp)
            {
                MessageBox.Show("No hay Información Disponible");
                

                
            }
            bs.DataSource = dataGridView_Lista.DataSource;

        }

        private void Form_apertura_Load(object sender, EventArgs e)
        {
            Lista_Aperturas();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;

            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
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

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar un campo para su edicion. ");
            }
            else
            {
                dataGridView_Lista.EndEdit();
                foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string iid = registro.Cells["ID"].Value.ToString();
                            string empleado = registro.Cells["Empleado"].Value.ToString();
 
                            Formularios.Form_editarSaldoInicial frm = new Formularios.Form_editarSaldoInicial(iid,empleado);
                            frm.ShowDialog();
                        }
                    }
                    catch  { }
                }
            }
        }



        



    }
}
