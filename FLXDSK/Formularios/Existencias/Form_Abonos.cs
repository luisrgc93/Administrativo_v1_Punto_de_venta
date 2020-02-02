using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Existencias
{
    public partial class Form_Abonos : Form
    {
        string iidCompra = "";
        double TotalCompra = 0;
        double TotalAbonado = 0;

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Inventarios.Class_Compras ClsCom = new Classes.Inventarios.Class_Compras();
        Classes.Catalogos.Proveedores.Class_Proveedores ClsProveedor = new Classes.Catalogos.Proveedores.Class_Proveedores();

        
        Classes.Existencias.Class_Abonos ClsAbo = new Classes.Existencias.Class_Abonos();
        
        
        Classes.SAT.Class_FormasPago ClsFormaPago = new Classes.SAT.Class_FormasPago();

        BindingSource bs = new BindingSource();
        public event Form1.MessageHandler CargaListaAll;

        public Form_Abonos(string iidCompra)
        {
            InitializeComponent();
            this.iidCompra = iidCompra;
        }
        public void ListaComboFormas()
        {
            DataTable dtInfo = ClsFormaPago.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_FormaPago.DataSource = dtInfo;
            comboBox_FormaPago.DisplayMember = "vchDescripcion";
            comboBox_FormaPago.ValueMember = "iidFormaPago";
        }

        private void Form_Abonos_Load(object sender, EventArgs e)
        {
            DataTable dtCompra = ClsCom.getListaWhere(" WHERE iidCompra  = " + iidCompra);
            if (dtCompra.Rows.Count == 0)
            {
                MessageBox.Show("Compra no encontrada");
                this.Close();
                return;
            }

            ListaComboFormas();

            TotalCompra = Convert.ToDouble(dtCompra.Rows[0]["fTotal"].ToString());
            label_FolioCompra.Text = dtCompra.Rows[0]["vchSerie"].ToString() + "-" + dtCompra.Rows[0]["iFolio"].ToString();
            label_FechaCompra.Text = dtCompra.Rows[0]["dfechaCompra103"].ToString();
            label_TotalCompra.Text = string.Format("{0:c}", TotalCompra);
            
            //Proveedor
            DataTable dtProveedor = ClsProveedor.getListaWhere(" WHERE iidProveedor =" + dtCompra.Rows[0]["iidProveedor"].ToString());
            if (dtProveedor.Rows.Count == 0)
            {
                MessageBox.Show("Proveedor no encontrado");
                this.Close();
                return;
            }


            label_proveedor.Text = dtProveedor.Rows[0]["vchNombreComercial"].ToString() + "\n\r" +
            "R.F.C. " + dtProveedor.Rows[0]["vhcRFC"].ToString() + " " + dtProveedor.Rows[0]["vchRazonSocial"].ToString();
            ListaAbonos();
        }


        private void ListaAbonos()
        {
            dataGridView_Lista.DataSource = null;
            string sql = " " +
            " SELECT A.iidAbono, f.vchDescripcion FormaPago, " +
	            " CONVERT(VARCHAR(10),A.dfechaAbono,103) AS Fecha, A.fAbono Abonado  " +
            " FROM catCompras C (NOLOCK), catAbonos A (NOLOCK), int_satFormaPago F (NOLOCK) " +
            " WHERE A.iidCompra = C.iidCompra  " +
            " AND A.iidFormaPago = F.iidFormaPago " +
            " AND A.iidEstatus = 1  " +
            " AND  A.iidCompra = " + iidCompra;
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidAbono"].Visible = false;
                dataGridView_Lista.Columns["Fecha"].Width = 150;
                dataGridView_Lista.Columns["Fecha"].ReadOnly = true;
                dataGridView_Lista.Columns["Abonado"].Width = 150;
                dataGridView_Lista.Columns["Abonado"].ReadOnly = true;
                dataGridView_Lista.Columns["FormaPago"].Width = 150;
                dataGridView_Lista.Columns["FormaPago"].ReadOnly = true;
            }
            catch
            {
               
            }
            bs.DataSource = dataGridView_Lista.DataSource;
            CartaTotales();
        }

        public void CartaTotales()
        {
            TotalAbonado = 0;
            foreach (DataGridViewRow row in dataGridView_Lista.Rows)
                TotalAbonado += Convert.ToDouble(row.Cells["Abonado"].Value);
            

            label_abonado.Text = string.Format("{0:c}", TotalAbonado);
            label_SaldoPediente.Text = string.Format("{0:c}", TotalCompra - TotalAbonado);
        }


        private void button_abonar_Click(object sender, EventArgs e)
        {
            string iidFormaPago = "";
            try
            {
                iidFormaPago = comboBox_FormaPago.SelectedValue.ToString();
            }
            catch { }

            double Abono = 0;
            try
            {
                Abono = Convert.ToDouble(textBox_Abono.Text);
            }
            catch 
            {
                MessageBox.Show("Favor de ingresar un monto correcto.");
                return;
            }

            if (iidFormaPago == "0" || iidFormaPago == "")
            {
                MessageBox.Show("Favor de seleccionar la forma de pago.");
                return;
            }

            double AbonadoTotal = TotalAbonado + Abono;
            double Resta = TotalCompra - AbonadoTotal;

            if(Resta != 0)
                if (Resta < 1)
                {
                    MessageBox.Show("La suma de la cantidad abonada y lo abonado excede el total de la compra.");
                    return;
                }
            

            if (ClsAbo.InsertaInformacion(iidCompra, Abono.ToString(), iidFormaPago))
            {
                MessageBox.Show("Abono realizado con exito.");
                ListaAbonos();


                textBox_Abono.Text = "";

                if (Resta <= 0.5)
                {
                    ClsCom.SetCompraPagada(iidCompra);
                    try
                    {
                        CargaListaAll();
                    }
                    catch { }
                    this.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Problemas al realizar el abono. Intente mas tarde");
            }
        }
        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string iidAbono = row.Cells["iidAbono"].Value.ToString();

                DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ClsAbo.borrar_abono(iidCompra, iidAbono))
                {
                    MessageBox.Show("Eliminado con exito");
                    ListaAbonos();
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al eliminar contacte al administador");
                }
            }
        }
    }
}
