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
    public partial class Form_TraspasoMp : Form
    {

        string IdPasstext = "";
        DataTable dtListaProd = null;
        bool LoadComplete = false;

        Classes.Inventarios.Class_Traspasos ClsTraspasos = new Classes.Inventarios.Class_Traspasos();
        Classes.Inventarios.Class_DetalleTraspasos ClsDetalleTraspasos = new Classes.Inventarios.Class_DetalleTraspasos();

        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMatPrim = new Classes.Catalogos.Mercancia.Class_Materia_Prima();
        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();
        Classes.Catalogos.Administracion.Class_Usuarios ClsUsuarios = new Classes.Catalogos.Administracion.Class_Usuarios();

        //Classes.Inventarios.Class_ProcesoAjuste ClsProceso = new Classes.Inventarios.Class_ProcesoAjuste();

        public event Form1.MessageHandler CargaLista;


        public Form_TraspasoMp(string id)
        {
            IdPasstext = id;
            InitializeComponent();

            dtListaProd = new DataTable();
            dtListaProd.Columns.Add("iidMateriPrima", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Codigo", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Existencia", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("MedidaExistencia", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Envia", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("Medida", System.Type.GetType("System.String"));
        }
        private void CargaCombos()
        {
            DataTable dtOrigen = ClsAlmacen.getAlmacenesAll();
            comboBox_Origen.DataSource = dtOrigen;
            comboBox_Origen.DisplayMember = "nombre";
            comboBox_Origen.ValueMember = "id";


            DataTable dtDestino = ClsAlmacen.getAlmacenesAll();
            comboBox_Destino.DataSource = dtDestino;
            comboBox_Destino.DisplayMember = "nombre";
            comboBox_Destino.ValueMember = "id";
        }

        private void Form_TraspasoMp_Load(object sender, EventArgs e)
        {
            CargaCombos();

            if (IdPasstext != "")
                CargaInfoId();


            label_UsuarioEnvia.Text = "";
            DataTable dtUsuario = ClsUsuarios.getInfoByID(Classes.Class_Session.Idusuario.ToString());
            if(dtUsuario.Rows.Count > 0)
                label_UsuarioEnvia.Text = dtUsuario.Rows[0]["vchUsuario"].ToString();
            

            LoadComplete = true;
        }
        private void CargaInfoId()
        {
            DataTable dtExis = ClsTraspasos.getListaWhere(" WHERE iidFolio = " + IdPasstext);
            if (dtExis.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontrada");
                this.Close();
                return;
            }
            string IdAlmacenOrigen = dtExis.Rows[0]["iidAlmacen_Origen"].ToString();
            string IdAlmacenDestino = dtExis.Rows[0]["iidAlmacen_Destino"].ToString();


            textBox_Comentario.Text = dtExis.Rows[0]["vchcomentario"].ToString();
            try
            {
                comboBox_Origen.SelectedValue = dtExis.Rows[0]["iidAlmacen_Origen"].ToString();
                comboBox_Origen.Enabled = false;
            }
            catch { }
            try
            {
                comboBox_Destino.SelectedValue = dtExis.Rows[0]["iidAlmacen_Destino"].ToString();
            }
            catch { }
            
            //" SELECT D.iidFolio, D., D.fCantidad_Enviada, D.fCantidad_Recibida, " +
            //" M.vchCodigo, M.vchDescripcion, M.fCosto, M.iidUnidad, M.siInventariar " +

            //CargaDetalle
            DataTable dtDetalle = ClsDetalleTraspasos.getListaExistencias(" AND  D.iidFolio = " + IdPasstext, IdAlmacenOrigen);
            if (dtDetalle.Rows.Count > 0)
                foreach (DataRow Row in dtDetalle.Rows)
                {
                    string iidMateriPrima = Row["iidMateriPrima"].ToString();
                    double fCantidad_Enviada = Convert.ToDouble(Row["Envia"].ToString());
                    string vchCodigo = Row["vchCodigo"].ToString();
                    string vchDescripcion = Row["vchDescripcion"].ToString();
                    string Medida = Row["Medida"].ToString();
                    //string UnidadMinima = Row["Kilos"].ToString();

                    double ExistenciaGroup = Convert.ToDouble(Row["ExistenciaGroup"].ToString());




                    AgregaProducto(iidMateriPrima, vchCodigo, vchDescripcion, ExistenciaGroup, Medida, fCantidad_Enviada, Medida);
                }
        }

        private void textBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_Buscar.Text.Trim() != "")
                    ValidaBuscar();
            }
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            string IdAlmacenSelec = "";
            try
            {
                IdAlmacenSelec = comboBox_Origen.SelectedValue.ToString();
            }
            catch { }
            if (IdAlmacenSelec == "" || IdAlmacenSelec == "0")
            {
                MessageBox.Show("Seleccione el Almacen Origen");
                return;
            }

            Classes.Class_Session.IdBuscador = 0;

            herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto("");
            FormBProd.ShowDialog();

            if (Classes.Class_Session.IdBuscador != 0)
            {
                string IDMateriaSelc = Classes.Class_Session.IdBuscador.ToString();



                //
                DataTable dtInfo = ClsDetalleTraspasos.ProcesoGeneraTrasPaso(" AND M.siInventariar = 1 AND M.iidMateriPrima =  " + IDMateriaSelc, IdAlmacenSelec);
                if (dtInfo.Rows.Count > 0)
                {
                    double Existencia = 0;
                    try
                    {
                        Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                    }
                    catch { }
                    string vchCodigo = dtInfo.Rows[0]["vchCodigo"].ToString();
                    string vchDescripcion = dtInfo.Rows[0]["vchDescripcion"].ToString();
                    string iidMateriPrima = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                    string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();

                    Classes.Class_Session.fNewExistencia = 0;
                    Classes.Class_Session.NameMedida = "";


                    herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                    FormCant.ShowDialog();

                    double CantidaAEnviar = Classes.Class_Session.fNewExistencia;
                    double CantValida = Classes.Class_Session.fNewExistencia;

                    if (CantidaAEnviar <= 0)
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }
                    if (Classes.Class_Session.NameMedida == "")
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }

                    
                    ////Depente de la Unidad ago la ,multiplicacion
                    if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                        CantValida = CantValida * 1000;



                    if (CantValida > Existencia)
                    {
                        MessageBox.Show("La cantidad a Enviar es mayor a la que se tiene ");
                        return;
                    }

                    AgregaProducto(iidMateriPrima, vchCodigo, vchDescripcion, Existencia, UnidadMinima, CantidaAEnviar, Classes.Class_Session.NameMedida);

                }
                else
                {
                    MessageBox.Show("Producto sin existencias");
                }
            }
        }

        private void ValidaBuscar()
        {
            string IdAlmacenSelec = "";
            try
            {
                IdAlmacenSelec = comboBox_Origen.SelectedValue.ToString();
            }
            catch { }
            if (IdAlmacenSelec == "" || IdAlmacenSelec == "0")
            {
                MessageBox.Show("Seleccione el Almacen Origen");
                return;
            }

            string txtBuscar = textBox_Buscar.Text.Trim();

            DataTable dtInfo = ClsDetalleTraspasos.ProcesoGeneraTrasPaso(" AND M.siInventariar = 1 AND M.vchCodigo + ' ' + M.vchDescripcion LIKE '%" + txtBuscar.Replace(" ", "%") + "%'   ", IdAlmacenSelec);
            if (dtInfo.Rows.Count == 1)
            {
                string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                double Existencia = 0;
                try
                {
                    Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                }
                catch { }
                string vchCodigo = dtInfo.Rows[0]["vchCodigo"].ToString();
                string vchDescripcion = dtInfo.Rows[0]["vchDescripcion"].ToString();
                string iidMateriPrima = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();


                Classes.Class_Session.fNewExistencia = 0;
                Classes.Class_Session.NameMedida = "";

                herramientas.Inventarios.Form_Cantidad Formulario = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                Formulario.ShowDialog();

                double CantidaAEnviar = Classes.Class_Session.fNewExistencia;
                double CantValida = Classes.Class_Session.fNewExistencia;

                if (CantidaAEnviar <= 0)
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }
                if (Classes.Class_Session.NameMedida == "")
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }

                
                ////Depente de la Unidad ago la ,multiplicacion
                if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                    CantValida = CantValida * 1000;
                


                if (CantValida > Existencia)
                {
                    MessageBox.Show("La cantidad a Enviar es mayor a la que se tiene ");
                    return;
                }

                AgregaProducto(iidMateriPrima, vchCodigo, vchDescripcion, Existencia, UnidadMinima, CantidaAEnviar, Classes.Class_Session.NameMedida);



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
                        dtInfo = ClsDetalleTraspasos.ProcesoGeneraTrasPaso(" AND M.siInventariar = 1 AND M.iidMateriPrima = " + Classes.Class_Session.IdBuscador.ToString(), IdAlmacenSelec);
                        if (dtInfo.Rows.Count > 0)
                        {
                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                            double Existencia = 0;
                            try
                            {
                                Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                            }
                            catch { }
                            string vchCodigo = dtInfo.Rows[0]["vchCodigo"].ToString();
                            string vchDescripcion = dtInfo.Rows[0]["vchDescripcion"].ToString();
                            string iidMateriPrima = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                            string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();

                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            double CantidaAEnviar = Classes.Class_Session.fNewExistencia;
                            double CantValida = Classes.Class_Session.fNewExistencia;

                            if (CantidaAEnviar <= 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }


                            ////Depente de la Unidad ago la ,multiplicacion
                            if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                                CantValida = CantValida * 1000;


                            if (CantValida > Existencia)
                            {
                                MessageBox.Show("La cantidad a Enviar es mayor a la que se tiene ");
                                return;
                            }

                            AgregaProducto(iidMateriPrima, vchCodigo, vchDescripcion, Existencia, UnidadMinima, CantidaAEnviar, Classes.Class_Session.NameMedida);

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
                        dtInfo = ClsMatPrim.getListaWhere(" WHERE iidMateriPrima =  " + Classes.Class_Session.IdBuscador.ToString());
                        if (dtInfo.Rows.Count > 0)
                        {
                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                            double Existencia = 0;
                            try
                            {
                                Existencia = Convert.ToDouble(dtInfo.Rows[0]["Existencia"].ToString());
                            }
                            catch { }
                            string vchCodigo = dtInfo.Rows[0]["vchCodigo"].ToString();
                            string vchDescripcion = dtInfo.Rows[0]["vchDescripcion"].ToString();
                            string iidMateriPrima = dtInfo.Rows[0]["iidMateriPrima"].ToString();
                            string UnidadMinima = dtInfo.Rows[0]["UnidadMinima"].ToString();

                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            double CantidaAEnviar = Classes.Class_Session.fNewExistencia;
                            double CantValida = Classes.Class_Session.fNewExistencia;

                            if (CantidaAEnviar <= 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }


                            ////Depente de la Unidad ago la ,multiplicacion
                            if (Classes.Class_Session.NameMedida == "Kilos" || Classes.Class_Session.NameMedida == "Litros")
                                CantValida = CantValida * 1000;

                            if (CantValida > Existencia)
                            {
                                MessageBox.Show("La cantidad a Enviar es mayor a la que se tiene ");
                                return;
                            }


                            AgregaProducto(iidMateriPrima, vchCodigo, vchDescripcion, Existencia, UnidadMinima, CantidaAEnviar,  Classes.Class_Session.NameMedida);

                            textBox_Buscar.Text = "";
                            textBox_Buscar.Focus();
                        }
                    }
                }
            }
        }


        private void AgregaProducto(string IdProd, string Codigo, string Producto, double Existencia, string UnidadExis, double fCantidad, string Medida)
        {
            DataRow Drw = dtListaProd.NewRow();
            Drw["iidMateriPrima"] = IdProd;
            Drw["Codigo"] = Codigo;
            Drw["Descripcion"] = Producto;
            Drw["Existencia"] = Existencia;
            Drw["MedidaExistencia"] = UnidadExis;
            Drw["Envia"] = fCantidad;
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
            dataGridView_Lista.Columns["Envia"].ReadOnly = true;
        }

        private void comboBox_Origen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {
                string valSelec = "";
                try
                {
                    valSelec = comboBox_Origen.SelectedValue.ToString();
                }
                catch { }
                if (valSelec != "" & valSelec != "0")
                {
                    comboBox_Origen.Enabled = false;
                }
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (dtListaProd.Rows.Count == 0)
            {
                MessageBox.Show("Agregue almenos un producto");
                return;
            }

            string IdAlmOrigen = "";
            string IdAlmDestino = "";
            try
            {
                IdAlmOrigen = comboBox_Origen.SelectedValue.ToString();
            }
            catch { }
            try
            {
                IdAlmDestino = comboBox_Destino.SelectedValue.ToString();
            }
            catch { }


            if (IdAlmOrigen == "" || IdAlmOrigen == "0")
            {
                MessageBox.Show("Seleccione un almacen Origen");
                return;
            }
            if (IdAlmDestino == "" || IdAlmDestino == "0")
            {
                MessageBox.Show("Seleccione un almacen Destino");
                return;
            }
            if (IdAlmDestino == IdAlmOrigen)
            {
                MessageBox.Show("Almacen Origen debe ser diferente al destino");
                return;
            }



            if (IdPasstext == "")
            {

                if (ClsTraspasos.InsertaInformacion(IdAlmOrigen, IdAlmDestino,textBox_Comentario.Text.Trim()))
                {
                    string IdTraspaso = ClsTraspasos.getIdCrado();

                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double Enviar = 0;
                        try
                        {
                            Enviar = Convert.ToDouble(Row["Envia"].ToString());
                        }
                        catch { }
                        if (Row["Medida"].ToString() == "Kilos")
                        {
                            Enviar = Enviar * 1000;
                        }
                        else
                        {
                            if (Row["Medida"].ToString() == "Litros")
                            {
                                Enviar = Enviar * 1000;
                            }
                        }

                        ClsDetalleTraspasos.InsertaInformacion(IdTraspaso, Row["iidMateriPrima"].ToString(), Enviar.ToString());
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
                if (ClsTraspasos.ActualizaInformacion(IdPasstext, IdAlmDestino, textBox_Comentario.Text.Trim()))
                {
                    //Borramos todos
                    ClsDetalleTraspasos.ClearMovimiento(IdPasstext);

                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double Enviar = 0;
                        try
                        {
                            Enviar = Convert.ToDouble(Row["Envia"].ToString());
                        }
                        catch { }
                        if (Row["Medida"].ToString() == "Kilos")
                        {
                            Enviar = Enviar * 1000;
                        }
                        else
                        {
                            if (Row["Medida"].ToString() == "Litros")
                            {
                                Enviar = Enviar * 1000;
                            }
                        }

                        ClsDetalleTraspasos.InsertaInformacion(IdPasstext, Row["iidMateriPrima"].ToString(), Enviar.ToString());
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
