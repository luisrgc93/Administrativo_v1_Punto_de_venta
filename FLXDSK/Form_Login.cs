using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK
{
    public partial class Form_Login : Form
    {
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Class_ParametrosGenerales ClsParametros = new Classes.Class_ParametrosGenerales();


        Classes.Class_Login fnLogin = new Classes.Class_Login();
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            ValidaIngreso();
        }
        private void ValidaIngreso()
        {
            string usuario = textBox_Usuario.Text;
            string clave = textBox_Clave.Text;

            if (usuario == "")
            {
                MessageBox.Show("El usuario es necesario para iniciar sesión.");
                textBox_Usuario.Focus();
            }
            else
            {
                if (clave == "")
                {
                    MessageBox.Show("La contraseña es necesaria para iniciar sesión.");
                    textBox_Clave.Focus();
                }
                else
                {
                    
                    //puesto uno es administrador
                 //int idusuario = fnLogin.getIDLogin(usuario, clave, "1");
                    int idusuario = fnLogin.getIDLogin(usuario, clave);
                   
                    if (idusuario != 0)
                    {
                        Classes.Class_Session.Serial = ClsEmp.GetMeSerialNumer();

                        Classes.Class_Session.dtParamConf = ClsParametros.getListaconfiguraciones();

                        Classes.Class_Session.Idusuario = idusuario;
                        fnLogin.InsertaSession();

                        Form_EmpresaSelect FrmEmp = new Form_EmpresaSelect(idusuario);
                        FrmEmp.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña ó usuario incorrecto");
                        textBox_Clave.Text = "";
                        textBox_Usuario.Text = "";
                        textBox_Usuario.Focus();
                    }
                }
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            if (fnLogin.EsPrimerUsuario() != 0)
            {
                this.ControlBox = false;
                textBox_Usuario.Focus();
            }
            else {
                Classes.Class_Session.siPrimeroIngreso = "SI";
                MessageBox.Show("Bienvenido a SoftSolution POS, como es la primera vez que utilizas nuestro sistema, te guiaremos en la configuración del mismo");
                MessageBox.Show("Primero tienes que crear el usuario para ingresar al sistema");
                Formularios.Form_Usuarios form = new Formularios.Form_Usuarios("Primer Ingreso");
                form.ShowDialog();
            }
        }

        private void textBox_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///validamos
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ValidaIngreso();
            }
        }
    }
}
