using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_III_Parcial_2021
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btRegistroJuicios_Click(object sender, EventArgs e)
        {
            RegistroJuicio formulario = new RegistroJuicio();
            formulario.Show();
        }

        private void btFacturar_Click(object sender, EventArgs e)
        {
            Facturación formulario = new Facturación();
            formulario.Show();
        }

        private void btPersonal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
