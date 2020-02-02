using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Inventarios
{
    public partial class Form_Ajuste : Form
    {
        string vchTipo = "";
        string IdPasstext = "";

        bool LoadComplete = false;

        string IdAlmacenSelec = "";

        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();
        Classes.Inventarios.Class_ProcesoAjuste ClsProceso = new Classes.Inventarios.Class_ProcesoAjuste();
        Classes.Inventarios.Class_Ajuste ClsAjuste = new Classes.Inventarios.Class_Ajuste();
        Classes.Inventarios.Class_DetalleAjuste ClsDetAjuste = new Classes.Inventarios.Class_DetalleAjuste();

        public event Form1.MessageHandler CargaLista;
        DataTable dtListaProd = null;

        public Form_Ajuste(string Id, string tipo)
        {
            InitializeComponent();
            vchTipo = tipo;
            IdPasstext = Id;

            dtListaProd = new DataTable();
            dtListaProd.Columns.Add("iidMateriPrima", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Codigo", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Existencia", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("MedidaExistencia", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Exi_Nueva", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("Medida", System.Type.GetType("System.String"));
        }

        private void CargaComboAlmacenes()
        {
            DataTable dtInfo = ClsAlmacen.getAlmacenesAll();
            comboBox_Almacen.DataSource = dtInfo;
            comboBox_Almacen.DisplayMember = "nombre";
            comboBox_Almacen.ValueMember = "id";
        }
        
        private void Form_Ajuste_Load(object sender, EventArgs e)
        {
            CargaComboAlmacenes();

            if (vchTipo == "")
            {
                MessageBox.Show("Información Incorrecta");
                this.Close();
                return;
            }

            label_Tipo.Text = vchTipo;
            if (IdPasstext != "")
                CargaInfoId();
            else
            {
                button_Buscar.Enabled = false;
                button_guardar.Enabled = false;
            }
            LoadComplete = true;
        }
        private void comboBox_Almacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {
                string valSelec = "";
                try
                {
                    valSelec = comboBox_Almacen.SelectedValue.ToString();
                }
                catch { }
                if (valSelec != "" & valSelec != "0")
                {
                    IdAlmacenSelec = valSelec;
                    button_Buscar.Enabled = true;
                    button_guardar.Enabled = true;
                    comboBox_Almacen.Enabled = false;
                }
            }
        }

        private void CargaInfoId()
        {
            DataTable dtExis = ClsAjuste.getListaWhere(" WHERE iidMovimiento = " + IdPasstext + " AND vchTipo = '" + vchTipo + "' ");
            if (dtExis.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontrada");
                this.Close();
                return;
            }

            textBox_Comentario.Text = dtExis.Rows[0]["vchComentario"].ToString();
            comboBox_Almacen.SelectedValue = dtExis.Rows[0]["iidAlmacen"].ToString();
            IdAlmacenSelec = dtExis.Rows[0]["iidAlmacen"].ToString();
            comboBox_Almacen.Enabled = false;

            //CargaDetalle
            DataTable dtDetalle = ClsDetAjuste.getListaCnExistencia(" AND D.iidMovimiento = " + IdPasstext + " AND D.vchTipo = '" + vchTipo + "' ", IdAlmacenSelec);
            if(dtDetalle.Rows.Count > 0)
            foreach(DataRow Row in dtDetalle.Rows)
            {
                string iidMateriPrima = Row["iidMateriPrima"].ToString();
                double fCantidad = Convert.ToDouble(Row["fCantidad"].ToString());
                string Existencia = Row["Existencia"].ToString();
                string vchCodigo = Row["vchCodigo"].ToString();
                string vchDescripcion = Row["vchDescripcion"].ToString();
                string Medida = Row["Medida"].ToString();
                string UnidadMinima = Row["UnidadMinima"].ToString();


                AgregaProducto(iidMateriPrima, Medida, fCantidad, vchCodigo, vchDescripcion, Existencia, UnidadMinima);
            }
        }

        private void textBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if(textBox_Buscar.Text.Trim()!="")
                    ValidaBuscar();
            }
        }
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;
            herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto("");
            FormBProd.ShowDialog();

            if (Classes.Class_Session.IdBuscador != 0)
            {
                string IDMateriaSelc = Classes.Class_Session.IdBuscador.ToString();

                DataTable dtInfo = ClsProceso.getListaProdExis(" AND M.siInventariar = 1 AND M.iidMateriPrima =  " + IDMateriaSelc, IdAlmacenSelec);
                if (dtInfo.Rows.Count > 0)
                {
                    

                    Classes.Class_Session.fNewExistencia = 0;
                    Classes.Class_Session.NameMedida = "";

                    double Existencia = 0;
                    try
                    {
                        Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                    }
                    catch { }
                    string UnidadExistencia = dtInfo.Rows[0]["UnidadMinima"].ToString();

                    herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                    FormCant.ShowDialog();

                    if (Classes.Class_Session.fNewExistencia < 0)
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }
                    if (Classes.Class_Session.NameMedida == "")
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }
                    
                    double CantidaAEnviar = Classes.Class_Session.fNewExistencia;

                    ////Depente de la Unidad ago la ,multiplicacion
                    //if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                    //CantidaAEnviar = CantidaAEnviar * 1000;



                    AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, CantidaAEnviar, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), dtInfo.Rows[0]["Existencia"].ToString(), UnidadExistencia);

                }
            }
        }
        private void ValidaBuscar()
        {
            string txtBuscar = textBox_Buscar.Text.Trim();

            DataTable dtInfo = ClsProceso.getListaProdExis(" AND M.siInventariar = 1 AND M.vchCodigo + ' ' + M.vchDescripcion LIKE '%" + txtBuscar.Replace(" ", "%") + "%' ", IdAlmacenSelec);
            if (dtInfo.Rows.Count == 1)
            {
                string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                double Existencia = 0;
                try
                {
                    Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                }
                catch { }
                string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();

                Classes.Class_Session.fNewExistencia = 0;
                Classes.Class_Session.NameMedida = "";

                herramientas.Inventarios.Form_Cantidad Formulario = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                Formulario.ShowDialog();

                if (Classes.Class_Session.fNewExistencia < 0)
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }
                if (Classes.Class_Session.NameMedida == "")
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }
                double CantidaAEnviar = Classes.Class_Session.fNewExistencia;

                ////Depente de la Unidad ago la ,multiplicacion
                //if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                    //CantidaAEnviar = CantidaAEnviar * 1000;


                AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, CantidaAEnviar, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), dtInfo.Rows[0]["Existencia"].ToString(), UnidadMinima);

                textBox_Buscar.Text = "";
                textBox_Buscar.Focus();
            }
            else
            {
                Classes.Class_Session.IdBuscador = 0;
            
                if (dtInfo.Rows.Count > 0)
                {
                    herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto(txtBuscar);
                    FormBProd.ShowDialog();
                    if (Classes.Class_Session.IdBuscador != 0)
                    {
                        dtInfo = ClsProceso.getListaProdExis(" AND M.siInventariar = 1 AND M.iidMateriPrima =  " + Classes.Class_Session.IdBuscador.ToString(), IdAlmacenSelec);
                        if (dtInfo.Rows.Count > 0)
                        {
                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";

                            double Existencia = 0;
                            try
                            {
                                Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                            }
                            catch { }
                            string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();


                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            if (Classes.Class_Session.fNewExistencia < 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }

                            double CantidaAEnviar = Classes.Class_Session.fNewExistencia;

                            ////Depente de la Unidad ago la ,multiplicacion
                            //if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                            //CantidaAEnviar = CantidaAEnviar * 1000;


                            AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, CantidaAEnviar, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), dtInfo.Rows[0]["Existencia"].ToString(), UnidadMinima);

                            textBox_Buscar.Text = "";
                            textBox_Buscar.Focus();
                        }
                    }
                }
                else
                {
                    herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto("");
                    FormBProd.ShowDialog();

                    if (Classes.Class_Session.IdBuscador != 0)
                    {
                        dtInfo = ClsProceso.getListaProdExis(" AND M.siInventariar = 1 AND M.iidMateriPrima =  " + Classes.Class_Session.IdBuscador.ToString(), IdAlmacenSelec);
                        if (dtInfo.Rows.Count > 0)
                        {
                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";
                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();


                            double Existencia = 0;
                            try
                            {
                                Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                            }
                            catch { }
                            string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            if (Classes.Class_Session.fNewExistencia < 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            double CantidaAEnviar = Classes.Class_Session.fNewExistencia;

                            ////Depente de la Unidad ago la ,multiplicacion
                            //if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                            //CantidaAEnviar = CantidaAEnviar * 1000;



                            AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, Classes.Class_Session.fNewExistencia, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), dtInfo.Rows[0]["Existencia"].ToString(), UnidadMinima);

                            textBox_Buscar.Text = "";
                            textBox_Buscar.Focus();
                        }
                    }
                }
            }
        }
        private void AgregaProducto(string IdProd,  string Medida, double fCantidad, string Codigo, string Producto, string Existencia, string MedidaExistencia)
        {
            DataRow Drw = dtListaProd.NewRow();
            Drw["iidMateriPrima"] = IdProd;
            Drw["Codigo"] = Codigo;
            Drw["Descripcion"] = Producto;
            Drw["Existencia"] = Existencia;
            Drw["MedidaExistencia"] = MedidaExistencia;
            Drw["Exi_Nueva"] = fCantidad;
            Drw["Medida"] = Medida;
            dtListaProd.Rows.Add(Drw);

            CargaCarrito();
        }
        private void CargaCarrito()
        {
            dataGridView_Lista.DataSource = dtListaProd;
            dataGridView_Lista.Columns["iidMateriPrima"].Visible = false;
            dataGridView_Lista.Columns["Codigo"].ReadOnly = true;
            dataGridView_Lista.Columns["Descripcion"].ReadOnly = true;
            dataGridView_Lista.Columns["Existencia"].ReadOnly = true;
            dataGridView_Lista.Columns["Medida"].ReadOnly = true;
            //Drw["Medida"] = fCantidad;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (dtListaProd.Rows.Count == 0)
            {
                MessageBox.Show("Agregue almenos un producto");
                return;
            }

            string IdAlmacen = "";
            try
            {
                IdAlmacen = comboBox_Almacen.SelectedValue.ToString();
            }
            catch { }

            if (IdAlmacen == "" || IdAlmacen == "0" )
            {
                MessageBox.Show("Seleccione un almacen");
                return;
            }

            if (IdPasstext == "")
            {
                string IdMovimiento = ClsAjuste.getIdNext(vchTipo);
                if(IdMovimiento=="0")
                {
                    MessageBox.Show("Problema al crear el folio, contacte al administrador");
                    return;
                }


                if (ClsAjuste.InsertaInformacion(IdMovimiento, vchTipo, IdAlmacen, textBox_Comentario.Text.Trim(), dataGridView_Lista.Rows.Count))
                {
                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double fValorCant = Convert.ToDouble(Row["Exi_Nueva"].ToString());
                        double Existencia = 0;
                        try
                        {
                            Existencia = Convert.ToDouble(Row["Existencia"].ToString());
                        }
                        catch { } 
                        if (Row["Medida"].ToString() == "Kilos")
                        {
                            fValorCant = fValorCant * 1000;
                        }
                        else
                        {
                            if (Row["Medida"].ToString() == "Litros")
                            {
                                fValorCant = fValorCant * 1000;
                            }
                        }
                        
                        ClsDetAjuste.InsertaInformacion(IdMovimiento, vchTipo, Row["iidMateriPrima"].ToString(), fValorCant.ToString(), Row["Existencia"].ToString());
                    }


                    MessageBox.Show("Guardado Correctamente");
                    this.Close();

                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }
            else
            {
                if (ClsAjuste.ActualizaInformacion(IdPasstext, vchTipo, textBox_Comentario.Text.Trim(), dataGridView_Lista.Rows.Count))
                {
                    //Borramos todos
                    ClsDetAjuste.ClearMovimiento(IdPasstext, vchTipo);

                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double fValorCant = Convert.ToDouble(Row["Exi_Nueva"].ToString());
                        if (Row["Medida"].ToString() == "Kilos")
                            fValorCant = fValorCant * 1000;
                        else
                            if (Row["Medida"].ToString() == "Litros")
                                fValorCant = fValorCant * 1000;

                        ClsDetAjuste.InsertaInformacion(IdPasstext, vchTipo, Row["iidMateriPrima"].ToString(), fValorCant.ToString(), Row["Existencia"].ToString());
                    }


                    MessageBox.Show("Guardado Correctamente");
                    this.Close();

                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }


            
        }

    }
}
