using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using aejw.Network;

namespace FLXDSK.herramientas
{
    public partial class Form_Config_PosicionMesas : Form
    {
        Classes.Catalogos.Local.Class_AreasLocation fnAreas = new Classes.Catalogos.Local.Class_AreasLocation();
        Classes.Catalogos.Local.Class_Mesas fnMesas = new Classes.Catalogos.Local.Class_Mesas();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        Button btn;
        Button btn1;

        string id = "''";
        string posx = "";
        string posy = "";
        string tamx = "";
        string tamy = "";
        int numPagina = 1;
        string idTamano = "";
    
        /*---------------- Mover Botones -----------------*/
        int posMouseFormX, posMouseFormY;
        int posMouseBotonX, posMouseBotonY;
        int posMouseActX, posMouseActY;
        bool botonPresonado = false;
        /*-----------------------------------------------*/

        public Form_Config_PosicionMesas()
        {
            InitializeComponent();
        }

        private void Form_Config_PosicionMesas_Load(object sender, EventArgs e)
        {
            label_NombreMesa.Text = "";
            llenarCombo();

            showAreas();
            panel_Areas.Dock = DockStyle.Fill;
            panel_Mesas.Dock = DockStyle.Fill;
            panel_Mesas.Visible = false;
            panel1.Visible = false;

            posMouseActX = btn.Location.X;
            posMouseActY = btn.Location.Y;
        }
        public void llenarCombo()
        {
            DataTable dtTamanos = new DataTable();
            dtTamanos = fnAreas.getTamanossAll();

            comboBox_Tamano.DataSource = dtTamanos;
            comboBox_Tamano.DisplayMember = "nombre";
            comboBox_Tamano.ValueMember = "id";
        }
        private void showAreas()
        {
            CargaAreas();

        }
        private void CargaAreas()
        {
            DataTable dtListCargas = new DataTable();
            dtListCargas = fnAreas.getListaAreas(id);

            int XYPuntosLinea1 = 10;
            int XYPuntosLinea2 = 10;
            int XYPuntosLinea3 = 10;
            int x = 0;

            foreach (DataRow Row in dtListCargas.Rows)
            {
                x++;
                string Name = Row["vchNombre"].ToString();
                id = Row["iidArea"].ToString();

                if (x <= 4)
                {
                    ///Buttons
                    btn = new Button();
                    btn.Size = new Size(120, 80);
                    btn.Location = new Point(XYPuntosLinea1, 10);
                    btn.Name = id;
                    btn.Text = Name;

                    btn.Click += new EventHandler(check);
                    panel_Areas.Controls.Add(btn);

                    XYPuntosLinea1 = XYPuntosLinea1 + 130;
                }
                else if (x <= 8)
                {
                    ///Buttons
                    btn = new Button();
                    btn.Size = new Size(120, 80);
                    btn.Location = new Point(XYPuntosLinea2, 120);
                    btn.Name = id;
                    btn.Text = Name;

                    btn.Click += new EventHandler(check);
                    panel_Areas.Controls.Add(btn);


                    XYPuntosLinea2 = XYPuntosLinea2 + 130;
                }
                else if (x <= 12)
                {
                    ///Buttons
                    btn = new Button();
                    btn.Size = new Size(120, 80);
                    btn.Location = new Point(XYPuntosLinea3, 230);
                    btn.Name = id;
                    btn.Text = Name;

                    btn.Click += new EventHandler(check);
                    panel_Areas.Controls.Add(btn);


                    XYPuntosLinea3 = XYPuntosLinea3 + 130;
                }
                else
                {
                    showAreas();
                    break;
                }
            }
        }
        private void check(Object sender, EventArgs e)
        {
            Button btn_IdArea = (Button)sender;
            int idArea = Convert.ToInt32(btn_IdArea.Name);
            DataTable dt = new DataTable();
            string NombreArea = fnAreas.getNombreArea(idArea);

            showMesas("", NombreArea, idArea, "0");
        }

        /*--------------------------------------------------------------------------        
        ------------------------------- Mesas -------------------------------------*/

        private void showMesas(string accion, string NombreArea, int id, string idMesa)
        {
            panel1.Visible = true;
            if (fnAreas.tieneAreaImagen(id)) 
            {
                string pathServer = ConfigurationManager.AppSettings["RUTASERVER"];
                if (pathServer == "")
                {
                    MessageBox.Show("La carpeta del servidor esta inaccesible o mal configurada");
                    return;
                }
                string RUTASERVER = "";
                string USERSERVER = "";
                string CLAVESERVER = "";
                try
                {
                    //Veo si existen la infomracion correcta dpara el conection server
                    RUTASERVER = ConfigurationManager.AppSettings["RUTASERVER"];
                    USERSERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["USERSERVER"]);
                    CLAVESERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["CLAVESERVER"]);
                }
                catch
                {
                    MessageBox.Show("Información de configuracion con el server file, necesaria");
                    return;
                }
                if (RUTASERVER == "" || USERSERVER == "" || CLAVESERVER == "")
                {
                    MessageBox.Show("Es necesario configurar la conexión con el servidor para los archivos");
                    return;
                }

                NetworkDrive oNetDrive = new aejw.Network.NetworkDrive();
                try
                {
                    oNetDrive.LocalDrive = "Y:";
                    oNetDrive.ShareName = @RUTASERVER;
                    try
                    {
                        oNetDrive.UnMapDrive();
                    }
                    catch
                    {
                    }
                    try
                    {
                        oNetDrive.MapDrive(USERSERVER, CLAVESERVER);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("MAP - Problema encontrado con: " + exp.ToString());
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("II. No se pudo conectar con el servidor de archivos");
                    return;
                }

                string imagen = "";
                try
                {
                    imagen = fnAreas.getImagenArea(id);
                }
                catch
                { }

                if (imagen != "")
                {
                    try
                    {
                        panel_Mesas.BackgroundImage = Image.FromFile(@imagen);
                        panel_Mesas.BackgroundImageLayout = ImageLayout.Center;
                    }
                    catch
                    { panel_Mesas.BackgroundImage = null; }
                }
                oNetDrive.LocalDrive = "Y:";
                oNetDrive.ShareName = @RUTASERVER;
                try
                {
                    oNetDrive.UnMapDrive();
                }
                catch { }                
            } 
            
            if (accion == "Mas")
            {
                panel_Areas.Visible = false;
                panel_Mesas.Visible = true;

                ///Label Titulo
                Label lb = new Label();
                lb.Font = new Font("Arial", 15);
                lb.Location = new Point(290, 10);
                lb.Text = "Area: " + NombreArea;
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Red;

                buttonAdelante(id.ToString());

                panel_Controles.Controls.Clear();
                
                panel_Mesas.Controls.Clear();
                CargaMesasPorCategoria(id, idMesa);
                panel_Mesas.Controls.Add(lb);
                buttonAtras(id.ToString());

            }
            else if (accion == "Menos")
            {
                panel_Areas.Visible = false;
                panel_Mesas.Visible = true;

                ///Label Titulo
                Label lb = new Label();
                lb.Font = new Font("Arial", 15);
                lb.Location = new Point(290, 10);
                lb.Text = "Area: " + NombreArea;
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Red;
                idMesa = "0";

                buttonAtras(id.ToString());
                buttonAdelante(id.ToString());

                panel_Controles.Controls.Clear();
                
                panel_Mesas.Controls.Clear();
                CargaMesasPorCategoria(id, idMesa);
                panel_Mesas.Controls.Add(lb);
            }
            else
            {
                panel_Areas.Visible = false;
                panel_Mesas.Visible = true;

                ///Label Titulo
                Label lb = new Label();
                lb.Font = new Font("Arial", 15);
                lb.Location = new Point(290, 10);
                lb.Text = "Area: " + NombreArea;
                lb.BackColor = Color.Transparent;
                lb.AutoSize = true;
                lb.ForeColor = Color.Red;

                panel_Controles.Controls.Clear();

                panel_Mesas.Controls.Clear();
                CargaMesasPorCategoria(id, idMesa);
                panel_Mesas.Controls.Add(lb);
            }
        }

        public void buttonAtras(string id)
        {
            ///Button para volver
            btn1 = new Button();
            btn1.Size = new Size(80, 40);
            btn1.Location = new Point(25, 10);
            btn1.Name = id.ToString();
            btn1.Text = "Atras";

            btn1.Click += new EventHandler(atras);
            panel_Controles.Controls.Add(btn1);
        }
        public void buttonAdelante(string id)
        {
            //Button para mostrar mas mesas
            btn = new Button();
            btn.Size = new Size(80, 40);
            btn.Location = new Point(120, 10);
            btn.Name = id;
            btn.Text = "Ver mas";

            btn.Click += new EventHandler(adelante);
            panel_Controles.Controls.Add(btn);
        }

        private void CargaMesasPorCategoria(int idArea, string idMesa)
        {
            DataTable dtListCargas = new DataTable();
            dtListCargas = fnAreas.GetListaMesas(idArea, idMesa);

            int XYPuntosLinea1 = 10;
            int XYPuntosLinea2 = 10;
            int XYPuntosLinea3 = 10;
            int x = 0;

            foreach (DataRow Row in dtListCargas.Rows)
            {
                x++;
                string Name = Row["descripcion"].ToString();
                id = Row["iidMesa"].ToString();
                posx = Row["iPosicionX"].ToString();
                posy = Row["iPosicionY"].ToString();
                tamx = Row["iTamanoX"].ToString();
                tamy = Row["iTamanoY"].ToString();

                if (x <= 5)
                {
                    ///Buttons
                    btn = new Button();
                    if (tamx == "" || tamy == "" || tamx == "0" || tamy == "0") { btn.Size = new Size(120, 80); }
                    else { btn.Size = new Size(Convert.ToInt32(tamx), Convert.ToInt32(tamy)); }
                    if (posx == "" || posx == "0" && posy == "" || posy == "0") { btn.Location = new Point(XYPuntosLinea1, 60); }
                    else { btn.Location = new Point(Convert.ToInt32(posx), Convert.ToInt32(posy)); }
                    btn.Name = id;
                    btn.Text = Name;
                    btn.BackColor = Color.Empty;

                    btn.MouseDown += new MouseEventHandler(mouseDown);
                    btn.MouseUp += new MouseEventHandler(mouseUp);
                    btn.MouseMove += new MouseEventHandler(mover);
                    btn.MouseClick += new MouseEventHandler(tamano);

                    panel_Mesas.Controls.Add(btn);
                    XYPuntosLinea1 = XYPuntosLinea1 + 130;
                }
                else if (x <= 10)
                {
                    ///Buttons
                    btn = new Button();
                    if (tamx == "" || tamy == "" || tamx == "0" || tamy == "0") { btn.Size = new Size(120, 80); }
                    else { btn.Size = new Size(Convert.ToInt32(tamx), Convert.ToInt32(tamy)); }
                    if (posx == "" || posx == "0" && posy == "" || posy == "0") { btn.Location = new Point(XYPuntosLinea2, 170); }
                    else { btn.Location = new Point(Convert.ToInt32(posx), Convert.ToInt32(posy)); }
                    btn.Name = id;
                    btn.Text = Name;
                    btn.BackColor = Color.Empty;

                    btn.MouseDown += new MouseEventHandler(mouseDown);
                    btn.MouseUp += new MouseEventHandler(mouseUp);
                    btn.MouseMove += new MouseEventHandler(mover);
                    btn.MouseClick += new MouseEventHandler(tamano);

                    panel_Mesas.Controls.Add(btn);
                    XYPuntosLinea2 = XYPuntosLinea2 + 130;
                }
                else if (x <= 15)
                {
                    ///Buttons
                    btn = new Button();
                    if (tamx == "" || tamy == "" || tamx == "0" || tamy == "0") { btn.Size = new Size(120, 80); }
                    else { btn.Size = new Size(Convert.ToInt32(tamx), Convert.ToInt32(tamy)); }
                    if (posx == "" || posx == "0" && posy == "" || posy == "0") { btn.Location = new Point(XYPuntosLinea3, 280); }
                    else { btn.Location = new Point(Convert.ToInt32(posx), Convert.ToInt32(posy)); }
                    btn.Name = id;
                    btn.Text = Name;
                    btn.BackColor = Color.Empty;

                    btn.MouseDown += new MouseEventHandler(mouseDown);
                    btn.MouseUp += new MouseEventHandler(mouseUp);
                    btn.MouseMove += new MouseEventHandler(mover);
                    btn.MouseClick += new MouseEventHandler(tamano);

                    panel_Mesas.Controls.Add(btn);
                    XYPuntosLinea3 = XYPuntosLinea3 + 130;
                }
                else
                {
                    buttonAdelante(idArea.ToString());
                    break;
                }
            }
            ///Label Num.Pagina            
            Label lb = new Label();
            lb.Font = new Font("Arial", 15);
            lb.Location = new Point(10, 380);
            lb.Size = new Size(150, 30);
            lb.Text = "Página Nº: " + numPagina;
            lb.BackColor = Color.Transparent;
            lb.ForeColor = Color.Red;
            //panel_Mesas.Controls.Add(lb);

            ///Buttons
            Button btnRestaurar = new Button();
            btnRestaurar.Size = new Size(110, 40);
            btnRestaurar.Location = new Point(5, 10);
            btnRestaurar.Name = idArea.ToString();
            btnRestaurar.Text = "Restaurar Todo";
            btnRestaurar.BackColor = Color.WhiteSmoke;
            btnRestaurar.Click += new EventHandler(restaurar);
            panel_Controles.Controls.Add(btnRestaurar);

            ///Buttons
            btn = new Button();
            btn.Size = new Size(110, 40);
            btn.Location = new Point(130, 10);
            btn.BackColor = Color.WhiteSmoke;
            btn.Name = "0";
            btn.Text = "<< Regresar a Areas";

            btn.Click += new EventHandler(cargaAreas);
            panel_Controles.Controls.Add(btn);
            label1.Text = idArea.ToString();
        }

        private void tamano(Object sender, EventArgs e)
        {
            Button btn_IdMesa = (Button)sender;
            int idMesa = Convert.ToInt32(btn_IdMesa.Name);

            label_idMesa.Text = idMesa.ToString();
            label_NombreMesa.Text = fnMesas.getNameByID(idMesa.ToString());
            string tamanoX = fnMesas.getTamanoXMesa(idMesa);
            string tamanoY = fnMesas.getTamanoYMesa(idMesa);
            idTamano = fnMesas.getTamano(tamanoX, tamanoY);
            if (tamanoX != "" && tamanoY != "" && idTamano != "")
            {
                comboBox_Tamano.SelectedValue = idTamano;
            }
            label_NombreMesa.Update();
        }
        private void restaurar(Object sender, EventArgs e)
        {
            Button btn_IdMesa = (Button)sender;
            int idArea = Convert.ToInt32(btn_IdMesa.Name);            
            
            if (fnAreas.restaurarPosicionMesas(idArea))
            {
                panel_Controles.Controls.Clear();
                panel_Mesas.Visible = false;
                panel_Areas.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Problemas al restaurar la posición de las mesas.");
            }
        }
        private void adelante(Object sender, EventArgs e)
        {
            Button btn_IdMesa = (Button)sender;
            int idArea = Convert.ToInt32(btn_IdMesa.Name);

            numPagina++;
            string nombreArea = fnAreas.getNombreArea(idArea);
            showMesas("Mas", nombreArea, idArea, id);
        }
        private void atras(Object sender, EventArgs e)
        {
            Button btn_IdMesa = (Button)sender;
            int idArea = Convert.ToInt32(btn_IdMesa.Name);

            numPagina = 1;
            string nombreArea = fnAreas.getNombreArea(idArea);
            showMesas("Menos", nombreArea, idArea, id);
        }

        private void cargaAreas(Object sender, EventArgs e)
        {
            numPagina = 1;
            panel_Mesas.Controls.Clear();
            panel_Controles.Controls.Clear();
            panel_Mesas.Visible = false;
            panel_Areas.Visible = true;
            panel1.Visible = false;
        }

        private void mouseDown(Object sender, MouseEventArgs e)
        {
            posMouseBotonX = e.Location.X;
            posMouseBotonY = e.Location.Y;

            botonPresonado = true;
        }
        private void mover(Object sender, MouseEventArgs e)
        {
            Button btn_IdMesa = (Button)sender;
            int idMesa = Convert.ToInt32(btn_IdMesa.Name);

            posMouseFormX = posMouseActX + e.Location.X;
            posMouseFormY = posMouseActY + e.Location.Y;

            if (botonPresonado)
            {
                moverbtn(btn_IdMesa);
                fnMesas.insertNuevaCoordenada(idMesa, posMouseActX, posMouseActY);
            }
        }
        private void mouseUp(Object sender, MouseEventArgs e)
        {
            botonPresonado = false;
        }
        private void moverbtn(Object sender)
        {
            Button btn_IdArea = (Button)sender;


            btn_IdArea.Location = new Point(posMouseFormX - posMouseBotonX, posMouseFormY);
            posMouseActX = btn_IdArea.Location.X;
            posMouseActY = btn_IdArea.Location.Y;
        }

        private void button_Cambiar_Click(object sender, EventArgs e)
        {
            string iidMesa = label_idMesa.Text;
            string idMesa = label_NombreMesa.Text;
            string tamano = comboBox_Tamano.SelectedValue.ToString();
            string iTamanoX = fnAreas.getTamanoX(tamano);
            string iTamanoY = fnAreas.getTamanoY(tamano);
            string idArea = label1.Text;

            if (idMesa == "") { MessageBox.Show("Favor de seleccionar una mesa"); return; }
            if (tamano == "0") { MessageBox.Show("Favor de seleccionar un tamaño"); return; }
            if (fnAreas.nuevoTamano(iidMesa, iTamanoX, iTamanoY))
            {
                MessageBox.Show("guardado nuevo tamaño con exito.");
                panel_Mesas.Controls.Clear();
                string nombreArea = fnAreas.getNombreArea(Convert.ToInt32(idArea));
                showMesas("", nombreArea, Convert.ToInt32(idArea), "0");                
            }
            else { MessageBox.Show("Problemas al cambiar el tamaño."); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Formularios.Form_NuevoTamano frm = new Formularios.Form_NuevoTamano("","");
            frm.llenarCombo += new Form1.MessageHandler(llenarCombo);
            frm.ShowDialog();
        }

        private void comboBox_Tamano_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_Tamano.SelectedValue.ToString() == "0")
            {
                button_EditarTamano.Visible = false;
                button3.Visible = true;
            }
            else
            {
                button_EditarTamano.Visible = true;
                button3.Visible = false;
            }
        }

        private void button_EditarTamano_Click(object sender, EventArgs e)
        {
            string iidMesa = label_idMesa.Text;
            string idMesa = label_NombreMesa.Text;
            string tamano = comboBox_Tamano.SelectedValue.ToString();
            string iTamanoX = fnAreas.getTamanoX(tamano);
            string iTamanoY = fnAreas.getTamanoY(tamano);
            string idArea = label1.Text;

            if (idMesa == "") { MessageBox.Show("Favor de seleccionar una mesa"); return; }
            //if (tamano == "0") { MessageBox.Show("Favor de seleccionar un tamaño"); return; }
            else
            {
                Formularios.Form_NuevoTamano frm = new Formularios.Form_NuevoTamano(iidMesa, idTamano);
                frm.llenarCombo += new Form1.MessageHandler(llenarCombo);
                frm.ShowDialog();
                MessageBox.Show("guardado nuevo tamaño con exito.");
                panel_Mesas.Controls.Clear();
                string nombreArea = fnAreas.getNombreArea(Convert.ToInt32(idArea));
                showMesas("", nombreArea, Convert.ToInt32(idArea), "0");
            } 
            /*if (fnAreas.nuevoTamano(iidMesa, iTamanoX, iTamanoY))
            {
                MessageBox.Show("guardado nuevo tamaño con exito.");
                panel_Mesas.Controls.Clear();
                string nombreArea = fnAreas.getNombreArea(Convert.ToInt32(idArea));
                showMesas("", nombreArea, Convert.ToInt32(idArea), "0");
            }
            else { MessageBox.Show("Problemas al cambiar el tamaño."); }

           
            if (iidMesa == "") { }
            else
            {
                
            }*/
        }

    }
}