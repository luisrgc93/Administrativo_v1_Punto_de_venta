using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Classes
{
    class Class_Limpiar
    {
         //Activa los Objetos de tipo TextBox -------- >
        public void Activar(Control parent)
         {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    string nom = ctrl.Name;
                    ctrl.Enabled = true;
                    ctrl.Text = "";
                }
                if (ctrl is ComboBox)
                {
                    ((ComboBox)parent.Controls[ctrl.Name]).SelectedValue = 0;
                    ctrl.Enabled = true;
                }
                if (ctrl is RichTextBox)
                {
                    string nom = ctrl.Name;
                    ctrl.Enabled = true;
                    ctrl.Text = "";
                }
                if (ctrl is DateTimePicker)
                {
                    string nom = ctrl.Name;
                    ctrl.Enabled = true;
                    ctrl.Text = "";
                }
            }
        }// Activa TextBox -------------------------- >
        //Activa los Objetos de tipo TextBox -------- >
        public void Editar(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if ((ctrl is TextBox) || (ctrl is ComboBox) || ctrl is RichTextBox)
                {
                    ctrl.Enabled = true;
                }
            }
        }// Activa TextBox -------------------------- >

        //Desactivar los Objetos de tipo TextBox ---- >
        public void Desactivar(Control parent)
        {
            
            foreach (Control ctrl in parent.Controls)
            {
                if ((ctrl is TextBox) || (ctrl is ComboBox) || ctrl is RichTextBox || ctrl is DateTimePicker)
                {
                    ctrl.Enabled = false;
                    ctrl.Text = "";

                }
            }
           
        }// Desactivar TextBox ------------------------ >
        
        public void Limpiar(Control parent)
        {//Limpiar los Objetos de tipo Textbox -------- >
            foreach (Control ctrl in parent.Controls)
            {
                if ((ctrl is TextBox))
                {
                    ctrl.Text = "";

                }               
            }
        }
    }
}
