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
    public partial class Form_CorteMeseros : Form
    {
        public event Form1.MessageHandler CargaLista;

        bool siLoadComplete = false;
        Classes.Cortes.Class_CorteMesero ClsCortesMeseros = new Classes.Cortes.Class_CorteMesero();
        Classes.Cortes.Class_DetalleCorteMesero ClsDetalleCortesMeseros = new Classes.Cortes.Class_DetalleCorteMesero();
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();
        Classes.Catalogos.Personal.Class_Personal ClsPersonal = new Classes.Catalogos.Personal.Class_Personal();
        Classes.Catalogos.Personal.Class_Puestos ClsPuestos = new Classes.Catalogos.Personal.Class_Puestos();


        double Porcentaj_PropinaObjetivo=0;
        double fPropina_Porcentaje = 0;

        double Objetivo = 0;
        double PropinaObtenida = 0;
        double PropinaCorresponde = 0;

        public Form_CorteMeseros()
        {
            InitializeComponent();
        }

        private void CargaComboMeseros()
        {
            DataTable dt = ClsCortesMeseros.getListaMeserosPendientes();
            comboBox_Mesero.DataSource = dt;
            comboBox_Mesero.DisplayMember = "Nombre";
            comboBox_Mesero.ValueMember = "Id";
        }
        private void comboBox_Mesero_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!siLoadComplete)
                return;

            try
            {
                DataRow[] RowVal;
                if (Classes.Class_Session.dtParamConf != null)
                {
                    RowVal = Classes.Class_Session.dtParamConf.Select("vchtipo = 'Propina'");
                    if (RowVal.Count() > 0)
                        if (RowVal[0]["vchTipo"].ToString().Trim() != "")
                            Porcentaj_PropinaObjetivo = Convert.ToDouble(RowVal[0]["vchConfiguracion"].ToString());
                }
            }
            catch { }


            CargaInfoCorte();
        }
        
        private void Form_CorteMeseros_Load(object sender, EventArgs e)
        {
            ////Verifica Calculo de Porcentajes de 100%
            double Tiene = ClsPuestos.getSumaPorcentajesActuales("");
            if (Tiene != 100)
            {
                MessageBox.Show("Es necesario configurar los porcentajes de reparto de propina en puestos que den el 100%");
                return;
            }


            CargaComboMeseros();

            siLoadComplete = true;
        }
        private void CargaInfoCorte()
        {
            string IdMesero = "";
            try
            {
                IdMesero = comboBox_Mesero.SelectedValue.ToString();
            }
            catch { }
            

            button_CrearCorte.Enabled = false;
            label_VentasTotales.Text = "$ 0.00";
            label_Objetivo.Text = "$ 0.00";
            label_Recaudado.Text = "$ 0.00";
            label_Propinas.Text = "$ 0.00";
            if (IdMesero == "0")
                return;

            DataTable dtPersonal = ClsPersonal.getLista(" AND P.iidPersonal = " + IdMesero);
            if(dtPersonal.Rows.Count == 0)
            {
                MessageBox.Show("Personal no encontrado");
                return;
            }

            fPropina_Porcentaje = Convert.ToDouble(dtPersonal.Rows[0]["fPropina"].ToString());

            DataTable dtPedidos = ClsPedidos.Rep_MeserosEnCortes(" AND P.iidPersonal = " + IdMesero + " AND P.siPagado = 1 AND P.iidCorteMesero = 0 ");
            if (dtPedidos.Rows.Count > 0)
            {
                button_CrearCorte.Enabled = true;

                double VentaTotal = Convert.ToDouble(dtPedidos.Rows[0]["fTotal"].ToString());
                double PropinaRecaudad = Convert.ToDouble(dtPedidos.Rows[0]["Propina"].ToString());

                Objetivo = Math.Round(  (Porcentaj_PropinaObjetivo * VentaTotal)  /100  );

                label_VentasTotales.Text = string.Format("{0:c}", Convert.ToDouble(dtPedidos.Rows[0]["fTotal"].ToString()));
                label_Objetivo.Text = string.Format("{0:c}", Objetivo);
                label_Recaudado.Text = string.Format("{0:c}", PropinaRecaudad);


                PropinaObtenida = Math.Round(   (fPropina_Porcentaje * PropinaRecaudad)/100  , 2);

                //Corresponde
                label_Propinas.Text = string.Format("{0:c}", PropinaObtenida);
            }


        }


        private void button_CrearCorte_Click(object sender, EventArgs e)
        {
            //Valido seleccione un Mesero
            string IdMesero = "";
            try
            {
                IdMesero = comboBox_Mesero.SelectedValue.ToString();
            }
            catch { }
            if (IdMesero == "0")
            {
                MessageBox.Show("Seleccione un mesero");
                return;
            }

            DataTable dtPersonal = ClsPersonal.getLista(" AND P.iidPersonal = " + IdMesero);
            if (dtPersonal.Rows.Count == 0)
            {
                MessageBox.Show("Personal no encontrado");
                return;
            }

            fPropina_Porcentaje = Convert.ToDouble(dtPersonal.Rows[0]["fPropina"].ToString());

            //valido que el mesero no tenga pedidos pendientes de cobrar.
            DataTable dtPedidosPendientes = ClsPedidos.Rep_MeserosEnCortes(" AND P.iidPersonal = " + IdMesero + " AND P.siPagado = 0 ");
            if (dtPedidosPendientes.Rows.Count > 0)
            {
                MessageBox.Show("Existen Pedidos Pendientes de Cerrar para este mesero");
                return;
            }
            
            
            double PropinaRecaudad = 0;

             DataTable dtPedidos = ClsPedidos.Rep_MeserosEnCortes(" AND P.iidPersonal = " + IdMesero + " AND P.siPagado = 1 AND P.iidCorteMesero = 0 ");
             if (dtPedidos.Rows.Count > 0)
                 PropinaRecaudad = Convert.ToDouble(dtPedidos.Rows[0]["Propina"].ToString());
            
            
            DialogResult  dialogEnd = MessageBox.Show(@"¿Desea crear corte?", "Confirmacion", MessageBoxButtons.YesNoCancel);
            if (dialogEnd == DialogResult.Yes)
            {

                if (ClsCortesMeseros.InsertaInformacion(IdMesero, Porcentaj_PropinaObjetivo, fPropina_Porcentaje))
                {
                    string IdCorteMesero = ClsCortesMeseros.getIdCorteCreado();

                    //Asigna
                    if (!ClsCortesMeseros.ProcesaCortesMesero(IdCorteMesero))
                    {
                        MessageBox.Show("Problema en la Asignacion de Pedidos para el Mesero");
                        return;
                    }

                    ///Crea Propina Proximas Areas
                    DataTable dtListaPuetosRepartir = ClsPuestos.getListaWhere(" WHERE siRepartoPropina = 1 AND iidEstatus = 1 ");
                    if (dtListaPuetosRepartir.Rows.Count > 0)
                        foreach (DataRow RowRep in dtListaPuetosRepartir.Rows)
                        {
                            double LeToca = Math.Round((Convert.ToDouble(RowRep["fPropina"].ToString()) * PropinaRecaudad) / 100, 2);
                            ClsDetalleCortesMeseros.InsertaInformacion(IdCorteMesero, RowRep["iidPuesto"].ToString(), LeToca);
                        }

                    DialogResult dialogResult = MessageBox.Show(@"¿Desea Imprimir el corte?", "Confirmacion", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Imprimimos
                        Classes.Print.Class_CorteMesero ClsPrint = new Classes.Print.Class_CorteMesero(IdCorteMesero);
                        ClsPrint.Imprimir();
                    }


                    this.Close();


                    MessageBox.Show("Creado Correctamente");
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al crear el corte");
                    return;
                }
            }

            //genero
        }

        

        
    }
}
