using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FLXDSK
{
    public partial class Form1 : Form
    {
        #region Private properties
        private readonly Classes.Class_Empresa _clsEmp = new Classes.Class_Empresa();
        private readonly Classes.Catalogos.Administracion.Class_Usuarios _clsUsu = new Classes.Catalogos.Administracion.Class_Usuarios();
        private readonly Classes.Catalogos.Administracion.Class_Accesos _clsAcc = new Classes.Catalogos.Administracion.Class_Accesos();
        private readonly Classes.Catalogos.Administracion.Class_AccesosUsuarios _clsAccUsu = new Classes.Catalogos.Administracion.Class_AccesosUsuarios();
        #endregion

        //declaro un delegado 
        public delegate void MessageHandler();

        public Form1()
        {
          InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            tabControl.Dock = DockStyle.Fill;

            var frmLogin = new Form_Login();

            //Intentamos Conectarnos a la base de datos
            var conexionCorrecta = _clsEmp.IsCorrectoConexion();
            if (conexionCorrecta)
            {
                //valida si existe un key clase empresa
                var existe = _clsEmp.GetMeSerialNumer();
                if (existe != "")
                {
                    //existe 
                    frmLogin.ShowDialog();
                }
                else
                {// el form del key
                    var frmkey = new Form_Serial();
                    frmkey.ShowDialog();
                    frmLogin.ShowDialog();
                }

                //Disabling the user option menu if im not administrator
                if (_clsAcc.SoyAdministrador())
                {
                    usuariosToolStripMenuItem1.Enabled = true;
                    administracionToolStripMenuItem.Enabled = true;
                }
                else
                {
                    usuariosToolStripMenuItem1.Enabled = false;
                }

                //Put the name to the window
                Text = ":: " + Classes.Class_Session.SessAlias + " ::";

                try
                {
                    ValidaVersionesSoftware();
                }
                catch
                {
                    // ignored
                }

                //Show user name:
                var nombreUsuario = _clsUsu.getNameUsuarioId(Classes.Class_Session.Idusuario.ToString());
                label_Bienvenido.Text = "Bienvenido: "+nombreUsuario;
                label_Bienvenido.Location = new Point(this.Width - 200, 34);

                AgregarMenuToDb();
                AddPermissionsToUserLogged();
            }
            else {
                var frmIsntal = new herramientas.Form_conexion();
                frmIsntal.ShowDialog();
            }

            //Validate user and enterprise are logged correctly, if not, close application
            var usuarioString = "";
            var empresaString = "";
            try
            {
                usuarioString = Convert.ToString(Classes.Class_Session.Idusuario);
                empresaString = Convert.ToString(Classes.Class_Session.IDEMPRESA);
            }
            catch
            {
                // ignored
            }

            if (usuarioString == "" || usuarioString == "0" || empresaString == "" || empresaString == "0") this.Close();
            
            //ventana de publicidad quitar para los que la compren.
            /*var timer = new Timer {Interval = 1000};
            timer.Tick += delegate(object s, EventArgs ee)
            {
                ((Timer)s).Stop();
               muestraPublicidad();
            };
            timer.Start();*/
        }

        /*private void stock_minimo()
        {
            DataTable stock = new DataTable();
            stock = ClsStk.stock_minimo();

            if (stock.Rows.Count != 0)
            {
                Formularios.Existencias.Form_Stock_Minimo frm = new Formularios.Existencias.Form_Stock_Minimo();
                frm.abrir_compras += new Form1.MessageHandler(abrir_compras);
                frm.ShowDialog();
            }
        }*/

        //--------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------ADMINISTRACION----------------------------------------------
        private void empresasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string title = "Empresa";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Administracion.Form_List_Empresas frm = new Listas.Administracion.Form_List_Empresas();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Usuarios";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Administracion.Form_List_Usuarios frm = new Listas.Administracion.Form_List_Usuarios();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Grupo de Accesos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Administracion.Form_List_Roles frm = new Listas.Administracion.Form_List_Roles();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void parametrosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Administracion.Form_ParametrosGenerales frm = new Formularios.Administracion.Form_ParametrosGenerales();
            frm.ShowDialog();
        }
        private void cuponesDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Cupones";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Administracion.Form_List_Cupones frm = new Listas.Administracion.Form_List_Cupones();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void ventasToolStripMenuItem_TipoMovES_Click(object sender, EventArgs e)
        {
            string title = "Tipos Movimientos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Administracion.Form_List_TipoMovimiento frm = new Listas.Administracion.Form_List_TipoMovimiento();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------CATALOGOS----------------------------------------------
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Clientes";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Form_aperturass frm = new Listas.Catalogos.Form_aperturass();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Catalogo de Eventos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Form_List_Eventos frm = new Listas.Catalogos.Form_List_Eventos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void materiaPrimaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Materia Prima";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Form_List_MateriaPrima frm = new Listas.Form_List_MateriaPrima();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void productosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Listado de Productos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Mercancia.Form_List_Productos frm = new Listas.Catalogos.Mercancia.Form_List_Productos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Insumos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Form_List_Insumos frm = new Listas.Catalogos.Form_List_Insumos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cetegoriasDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Categorias";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Form_List_Categorias frm = new Listas.Form_List_Categorias();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void categoriaDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Categorias Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Mercancia.Form_List_CategoriaMateriaPrima frm = new Listas.Catalogos.Mercancia.Form_List_CategoriaMateriaPrima();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void categoriasTiposDeInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Tipos de Insumos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Mercancia.Form_List_TipoInsumos frm = new Listas.Catalogos.Mercancia.Form_List_TipoInsumos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void areasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Areas";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Local.Form_List_Areas frm = new Listas.Catalogos.Local.Form_List_Areas();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void mesasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Mesas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Local.Form_List_Mesas frm = new Listas.Catalogos.Local.Form_List_Mesas();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void puestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Puesto";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Personal.Form_List_Puesto frm = new Listas.Catalogos.Personal.Form_List_Puesto();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void personalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string title = "Personal";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Personal.Form_List_Personal frm = new Listas.Catalogos.Personal.Form_List_Personal();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void tipoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Tipos de Proveedores";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Proveedores.Form_List_Tipo_Proveedores frm = new Listas.Catalogos.Proveedores.Form_List_Tipo_Proveedores();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void proveedoresToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Proveedores";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Proveedores.Form_List_Proveedor frm = new Listas.Catalogos.Proveedores.Form_List_Proveedor();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void ValidaVersionesSoftware()
        {
            pictureBox_Loading.Show();
            
            DataTable dt = new DataTable();
            dt = _clsAcc.getKeyEmpresa();
            if (dt.Rows.Count == 0)
                return;

            /*
            DataRow row = dt.Rows[0];
            string key = row["vchKey"].ToString();

            DataTable ids = new DataTable();
            ids = ClsAcc.isPcRequiereActualizaciones();

            if (ids.Rows.Count == 0)
            {
                MessageBox.Show("Esta aplicacion necesita autorización, favor de Visitar \nwww.flexor.mx/soporte.php ó llámenos al tel (33) 18.13.11.12.");
                Application.Exit();
            }

            DataRow OroW = ids.Rows[0];
            string idVersion = OroW["iidVersionNube"].ToString();
            string idPrograma = OroW["iidProgramaNube"].ToString();
            
            wUpdate.Service1 wUpdate = new FLXDSK.wUpdate.Service1();
            string respuesta = "";
            try
            {
                string SHA1checksum = GetFileChecksum(new SHA1CryptoServiceProvider());

                respuesta = wUpdate.VerificaActualizacionDSKWhitChekSum(key, idVersion, idPrograma, SHA1checksum);
            }
            catch {
                MessageBox.Show("Verifica los permisos para consumo de webservice.\n\rNo se actualizo el sistema");
            }

            string JsClientes = "{\"Archivos\":" + respuesta + "}";
            try
            {
                JObject o = JObject.Parse(respuesta);

                string error = (string)o.SelectToken("error");
                string mensaje = (string)o.SelectToken("mensaje");
                string existe = (string)o.SelectToken("existenewversion");

                if (Convert.ToInt32(error) == 1)
                {
                    MessageBox.Show(mensaje);
                }

                if (Convert.ToInt32(existe) == 1)
                {
                    DialogResult resultado = MessageBox.Show(mensaje, "Actualizar Sistema", MessageBoxButtons.OKCancel);

                    if (DialogResult.OK == resultado)
                    {
                        Application.Exit();
                        string ruta = ConfigurationManager.AppSettings["Update"];
                        System.Diagnostics.Process.Start(ruta);
                    }
                }

            }
            catch { }*/
            pictureBox_Loading.Hide();
            //--------------------------------------------------------------------------------------------------------------------------------------
        }
        //TODO: REFACTOR THIS
        public void AgregarMenuToDb()
        {
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {
                var nombreId = toolItem.Text;
                if (!toolItem.HasDropDownItems) continue;
                foreach (ToolStripMenuItem subItem in toolItem.DropDownItems)
                {
                    var nombreIdSub = subItem.Text;
                    var nombreIdTool = subItem.Name;
                    if (subItem.HasDropDownItems)
                    {
                        foreach (ToolStripItem ultimoMenu in subItem.DropDownItems)
                        {
                            var nombreIdEnd = ultimoMenu.Name;
                            var nombreIdEndText = ultimoMenu.Text;

                            if (!_clsAccUsu.ExisteMenuEnLaDb(nombreIdEndText, nombreIdSub))
                            {
                                _clsAccUsu.InsertarMenutoDb(nombreIdEndText, nombreIdSub, nombreIdEnd);
                            }
                        }
                    }
                    else
                    {
                        //Ver Opcion Menu
                        if (!_clsAccUsu.ExisteMenuEnLaDb(nombreIdSub, nombreId))
                        {
                            _clsAccUsu.InsertarMenutoDb(nombreIdSub, nombreId, nombreIdTool);
                        }
                    }
                }

            }
        }

        private void AddPermissionsToUserLogged()
        {
            var idEmpresa = Convert.ToString(Classes.Class_Session.IDEMPRESA);
            var idUsuario = Classes.Class_Session.Idusuario.ToString();

            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {
                if (!toolItem.HasDropDownItems) continue;
                foreach (ToolStripMenuItem subItem in toolItem.DropDownItems)
                {
                    var nombreIdSub = subItem.Name;
                    if (subItem.HasDropDownItems)
                    {
                        foreach (ToolStripItem ultimoMenu in subItem.DropDownItems)
                        {
                            string nombreIdEnd = ultimoMenu.Name;

                            ultimoMenu.Enabled = _clsAccUsu.ExisteOpcionMenu(nombreIdEnd, idUsuario, idEmpresa);
                        }
                    }
                    else
                    {
                        //Ver Opcion Menu
                        subItem.Enabled = _clsAccUsu.ExisteOpcionMenu(nombreIdSub, idUsuario, idEmpresa);
                    }
                }
            }
        }

        private void CrearPestana(string name)
        {
            string title = name;//"TabPage " + (tabControl.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(myTabPage);
            tabControl.SelectedTab = myTabPage;

            int numeroTab = tabControl.TabCount - 1;
        }

        /// <summary>
        /// //////////////Catalogos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

      

        private void toolStripButton_ChangeEmpresa_Click(object sender, EventArgs e)
        {
            //Bloquear el menu
            InhabilitarMenu();
            int idUsuario = Classes.Class_Session.Idusuario;
            Form_EmpresaSelect frmEmp = new Form_EmpresaSelect(idUsuario);
            frmEmp.cerrarTabsDis += new Form1.MessageHandler(cerrarTabsDis);
            frmEmp.inhabilitarMenu += new MessageHandler(InhabilitarMenu);        
            frmEmp.ShowDialog();            
        }

        private void InhabilitarMenu()
        {
            
        }
        
        public void cerrarTabsDis()
        {
            for (int i = tabControl.TabPages.Count - 1; i >= 0; i--)
            {
                TabPage current_tab = tabControl.TabPages[i];
                if (current_tab.Name != "tabPage_Home")
                {
                    tabControl.TabPages.Remove(current_tab);
                }
            }
            //colocamos el nombre a la ventana
            this.Text = ":: " + Classes.Class_Session.SessAlias + " ::";
        }      

        private void acercaDeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*Formularios.Form_Acerca frmAcerca = new Formularios.Form_Acerca();
            frmAcerca.Show();  */
        }


        private void requisitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Formularios.Form_Requisitos frmAccesosModulos = new Formularios.Form_Requisitos();
            frmAccesosModulos.Show();*/
        }

        private void configurarConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            herramientas.Form_conexion frmfac = new herramientas.Form_conexion();
            frmfac.Show(); 
        }

        private void configurarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            herramientas.Form_ConfigMail frmfac = new herramientas.Form_ConfigMail();
            frmfac.Show(); 
        }

        private void enviarInformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Classes.Class_Informes ClsInf = new Classes.Class_Informes();
            if (ClsInf.ExistenInformes())
            {
                herramientas.Form_Informes FrmInf = new herramientas.Form_Informes();
                FrmInf.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen Informes pendientes de Envio");
            }*/
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*Formularios.Form_Acerca frmAcerca = new Formularios.Form_Acerca();
            frmAcerca.Show();*/
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buscarActualizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaVersionesSoftware();
            }catch{}
        }

        private void cambiarDeEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bloquear el menu
            InhabilitarMenu();
            int idUsuario = Classes.Class_Session.Idusuario;
            Form_EmpresaSelect frmEmp = new Form_EmpresaSelect(idUsuario);
            frmEmp.cerrarTabsDis += new Form1.MessageHandler(cerrarTabsDis);
            frmEmp.inhabilitarMenu += new MessageHandler(InhabilitarMenu);
            frmEmp.ShowDialog();
        }

        private void asignarAccesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Formularios.Catalogo.Form_Asignacion_Roles frm = new Formularios.Catalogo.Form_Asignacion_Roles();
            frm.Show();*/
        }


        /********************************Catalogos*********************************/
       

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Productos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Catalogos.Reporte_Productos frm = new Reportes.Catalogos.Reporte_Productos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }  
        /***************************************************************************/

        /********************************Administracion****************************/
      

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Empresas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Administracion.Form_List_Empresas frm = new Listas.Administracion.Form_List_Empresas();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }        

       

        private void ventaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Ventas";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Ventas.Form_List_Pedidos frm = new Listas.Ventas.Form_List_Pedidos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    
        private void materiaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Materia Prima";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Form_List_MateriaPrima frm = new Listas.Form_List_MateriaPrima();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

   

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Proveedores";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Catalogos.Reporte_Proveedores frm = new Reportes.Catalogos.Reporte_Proveedores();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void tiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Tiempos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Tiempos frm = new Reportes.Reporte_Tiempos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void configuradorDeImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        
        private void eventosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Eventos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Eventos frm = new Reportes.Reporte_Eventos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void costeoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Costeo";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Costeo frm = new Reportes.Reporte_Costeo();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void listaFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Facturas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Ventas.Form_List_Facturas frm = new Listas.Ventas.Form_List_Facturas();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

     

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        
        
        private void movimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //adsaabrir_compras///sad
            string title = "Movimiento de Productos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Form_List_Movimientos frm = new Listas.Catalogos.Form_List_Movimientos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }


        private void teToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }


        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void impresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Impresoras";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Configuracion.Form_List_Impresoras frm = new Listas.Configuracion.Form_List_Impresoras();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        
        private void facturasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte Facturas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Facturas frm = new Reportes.Reporte_Facturas();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        
        

        private void cuponesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Cupones";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Cupones frm = new Reportes.Reporte_Cupones();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void productividadMeserosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Productividad Meseros";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Productividad frm = new Reportes.Reporte_Productividad();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void cerrarCorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Cortes de Turno";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Ventas.Form_List_Cortes frm = new Listas.Ventas.Form_List_Cortes();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

       


        private void categoriasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string title = "Categorias Activos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Form_CategoriasActivos frm = new Listas.Catalogos.Form_CategoriasActivos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Activos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Form_ActivosFijos frm = new Listas.Catalogos.Form_ActivosFijos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gastosFijosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Gastos Fijos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Form_List_GastosFijos frm = new Listas.Form_List_GastosFijos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        
        private void qrDeConexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.Form_QrConexion Formulario = new Formularios.Configuracion.Form_QrConexion();
            Formulario.Show();
        }

        
        
        private void movimientoDineroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Movimiento Dinero";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Ventas.Form_List_MovimientoDin frm = new Listas.Ventas.Form_List_MovimientoDin();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        /// <summary>
        /// /////Inventarios
        /// </summary>
        /// 

        //Inicial
        private void inicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string title = "Inventario Inicial Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Ajustes frm = new Listas.Inventarios.Form_List_Ajustes("Inicial");
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        //Ajuste
        private void ajusteToolStripMenuItem_Click(object sender, EventArgs e) /////////////////
        {
            string title = "Ajuste Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Ajustes frm = new Listas.Inventarios.Form_List_Ajustes("Ajuste");
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        //Compra
        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Compras";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Compras frm = new Listas.Inventarios.Form_List_Compras();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void almacenesToolStripMenuItem_Inventario_Almacenes_Click(object sender, EventArgs e)
        {
            string title = "Almacenes";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Almacenes frm = new Listas.Inventarios.Form_List_Almacenes();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void existenciasToolStripMenuItem_Inv_ExistenciasMP_Click(object sender, EventArgs e)
        {
            string title = "Existencias Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_ExistenciasMPrima frm = new Listas.Inventarios.Form_ExistenciasMPrima();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        private void traspasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Traspasos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_TraspasosMp frm = new Listas.Inventarios.Form_TraspasosMp();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void cortesDeTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Cortes de Turno";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Ventas.Form_List_Cortes frm = new Listas.Ventas.Form_List_Cortes();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        
        private void seriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Series Facturas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Facturacion.Form_List_Series frm = new Listas.Facturacion.Form_List_Series();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void requisiciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Requisiciones";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Form_Requisiciones frm = new Reportes.Form_Requisiciones();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void pagosComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Pagos a Compras";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Form_ListaPagos frm = new Reportes.Form_ListaPagos();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void pedidosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string title = "Pedidos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Ventas.Form_List_Pedidos frm = new Listas.Ventas.Form_List_Pedidos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void productosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
             try
            {
                string title = "Productos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Mercancia.Form_List_Productos frm = new Listas.Catalogos.Mercancia.Form_List_Productos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cortesMeseroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string title = "Cortes Meseros";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Ventas.Form_List_CortesMeseros frm = new Listas.Ventas.Form_List_CortesMeseros();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

       

        private void pedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Pedidos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Pedidoscs frm = new Reportes.Reporte_Pedidoscs();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void cortesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string title = "Reporte de Cortes";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Reportes.Reporte_Cortes frm = new Reportes.Reporte_Cortes();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void almacenesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string title = "Almacenes";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Almacenes frm = new Listas.Inventarios.Form_List_Almacenes();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void inicialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string title = "Inventario Inicial Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Ajustes frm = new Listas.Inventarios.Form_List_Ajustes("Inicial");
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }
        //Ajuste
        //private void ajusteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string title = "Ajuste Materia Prima";
        //    bool isPresent = false;

        //    for (int i = 0; i < tabControl.TabPages.Count; i++)
        //    {
        //        if (tabControl.TabPages[i].Name == title)
        //        {
        //            isPresent = true;
        //            tabControl.SelectedTab = tabControl.TabPages[i];
        //            break;
        //        }
        //    }
        //    if (!isPresent)
        //    {
        //        TabPage myTabPage = new TabPage(title);
        //        myTabPage.Name = title;
        //        tabControl.Dock = DockStyle.Fill;

        //        tabControl.TabPages.Add(myTabPage);
        //        int numeroTab = tabControl.TabCount - 1;
        //        Listas.Inventarios.Form_List_Ajustes frm = new Listas.Inventarios.Form_List_Ajustes("Ajuste");
        //        frm.TopLevel = false;
        //        frm.Visible = true;
        //        frm.FormBorderStyle = FormBorderStyle.None;
        //        frm.Dock = DockStyle.Fill;
        //        tabControl.TabPages[numeroTab].Controls.Add(frm);

        //        tabControl.SelectedTab = myTabPage;
        //        myTabPage.Focus();
        //    }
        //    else
        //    {
        //        tabControl.SelectedTab.Name = title;
        //    }
        //}

        private void compraToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string title = "Compras";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Compras frm = new Listas.Inventarios.Form_List_Compras();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

       

        private void existenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Existencias Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_ExistenciasMPrima frm = new Listas.Inventarios.Form_ExistenciasMPrima();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void traspasosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string title = "Traspasos";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_TraspasosMp frm = new Listas.Inventarios.Form_TraspasosMp();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }



        private void materiaPrimaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string title = "Materia prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                FLXDSK.Listas.Form_List_MateriaPrima frm = new FLXDSK.Listas.Form_List_MateriaPrima();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void ajesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Ajuste Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Inventarios.Form_List_Ajustes frm = new Listas.Inventarios.Form_List_Ajustes("Ajuste");
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void aperturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Aperturas";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Form_apertura frm = new Listas.Catalogos.Form_apertura();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void catalgosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void insumosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string title = "Insumos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Form_List_Insumos frm = new Listas.Catalogos.Form_List_Insumos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void materiaPrimaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string title = "Categorias Materia Prima";
            bool isPresent = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Name == title)
                {
                    isPresent = true;
                    tabControl.SelectedTab = tabControl.TabPages[i];
                    break;
                }
            }
            if (!isPresent)
            {
                TabPage myTabPage = new TabPage(title);
                myTabPage.Name = title;
                tabControl.Dock = DockStyle.Fill;

                tabControl.TabPages.Add(myTabPage);
                int numeroTab = tabControl.TabCount - 1;
                Listas.Catalogos.Mercancia.Form_List_CategoriaMateriaPrima frm = new Listas.Catalogos.Mercancia.Form_List_CategoriaMateriaPrima();
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl.TabPages[numeroTab].Controls.Add(frm);

                tabControl.SelectedTab = myTabPage;
                myTabPage.Focus();
            }
            else
            {
                tabControl.SelectedTab.Name = title;
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Categorias";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Form_List_Categorias frm = new Listas.Form_List_Categorias();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void insumosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Tipos de Insumos";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Catalogos.Mercancia.Form_List_TipoInsumos frm = new Listas.Catalogos.Mercancia.Form_List_TipoInsumos();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);
                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void empresasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string title = "Empresa";
                bool isPresent = false;

                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Name == title)
                    {
                        isPresent = true;
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
                if (!isPresent)
                {
                    TabPage myTabPage = new TabPage(title);
                    myTabPage.Name = title;
                    tabControl.Dock = DockStyle.Fill;

                    tabControl.TabPages.Add(myTabPage);
                    int numeroTab = tabControl.TabCount - 1;
                    Listas.Administracion.Form_List_Empresas frm = new Listas.Administracion.Form_List_Empresas();
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    tabControl.TabPages[numeroTab].Controls.Add(frm);

                    tabControl.SelectedTab = myTabPage;
                    myTabPage.Focus();
                }
                else
                {
                    tabControl.SelectedTab.Name = title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        }

        

    }

 