using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_III_Parcial_2021
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
                Menu formulario = new Menu();
                formulario.Show();
            if (TxtUsuario.Text == "")
            {
                errorProvider1.SetError(TxtUsuario, " Ingrese el Usuario");
                TxtUsuario.Focus();
                return;

            }
            errorProvider1.SetError(TxtUsuario, "");

            if (TxtContraseña.Text == "")
            {
                errorProvider1.SetError(TxtContraseña, " Ingrese la Contraseña");
                TxtContraseña.Focus();
                return;

            }
            errorProvider1.SetError(TxtContraseña, "");




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
    
}
