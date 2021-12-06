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
    public partial class RegistroJuicio : Form
    {
        List<ClsLista> MiLista = new List<ClsLista>();
        public RegistroJuicio()
        {
            InitializeComponent();
            tslConsultar.Enabled = false;
            tslEliminar.Enabled = false;
        }
        private void tslRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarNombre() == false)
            {
                return;
            }
            if (ValidarTipoJuicio() == false)
            {
                return;
            }
            if (ValidarEdad() == false)
            {
                return;
            }

              if (Existe(txtNombre.Text))
            {
                erpError.SetError(txtNombre, "La persona Con este nombre ya esta registrada");
                txtNombre.Focus();
                return;
            }
            erpError.SetError(txtNombre, "");
           
            //Crear el Objeto de la Clase lista 
            ClsLista MiRegistro = new ClsLista();
            MiRegistro.Nombre = txtNombre.Text;
            MiRegistro.TipoJuicio = cmbTipoJuicio.SelectedItem.ToString();
            MiRegistro.Edad = int.Parse(txtEdad.Text);
            MiLista.Add(MiRegistro);
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = MiLista;
            LimpiarControles();
            txtNombre.Focus();
            tslConsultar.Enabled = true;
        }

        //Valida que no Ingrese mas Nombres con el mismo ya ingresado
        private bool Existe(string Nombre)
        {
            foreach (ClsLista MiRegistro in MiLista)
            {
               if (MiRegistro.Nombre == Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        //Validar Edad
        private bool ValidarEdad()
        {
            int edad;
            if (!int.TryParse(txtEdad.Text, out edad) || txtEdad.Text == "")
            {
                erpError.SetError(txtEdad, "Debe Ingresar unn Valor Numerico para la edad");
                return false;
            }
            else
            {
                erpError.SetError(txtEdad, "");
                return true;
            }
        }

    //Validar Tipo Juicio
    private bool ValidarTipoJuicio()
        {
            if (string.IsNullOrEmpty(cmbTipoJuicio.Text))
            {
                erpError.SetError(cmbTipoJuicio, "Debe seleccionar Un Tipo de Juicio");
              return false;
            }
            else
            {
                erpError.SetError(cmbTipoJuicio, "");
                return true;
            }

        }

        //Validar Nombre
        private bool ValidarNombre()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpError.SetError(txtNombre, "Debe Ingresar Un  Nombre");
                return false;
            }
            else
            {
                erpError.SetError(txtNombre, "");
                return true;
            }

        }

        //Metodo para Limpiar Los Controles
        private void LimpiarControles()
        {
          txtNombre.Clear();
            txtEdad.Clear();
            cmbTipoJuicio.SelectedIndex = 0;
        }

        private void tslSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Evento Consultar
        private void tslConsultar_Click(object sender, EventArgs e)
        {
          if (ValidarNombre() == false)
            {
                return;
            }
          ClsLista MiRegistro = GetRegistro(txtNombre.Text);
            if (MiRegistro == null)
            {
                erpError.SetError(txtNombre, "El Nombre no se Encuentra Registrado");
               LimpiarControles();
               txtNombre.Focus();
                return;

            }
            else
            {
                erpError.SetError(txtNombre, "");
                txtNombre.Text = MiRegistro.Nombre;
                cmbTipoJuicio.SelectedItem = MiRegistro.TipoJuicio;
                txtEdad.Text = MiRegistro.Edad.ToString();
                tslEliminar.Enabled = true;
            }
        }

        // Metodo Consultar Registro
        private ClsLista GetRegistro(string nombre)
        {
            return MiLista.Find(Registro => Registro.Nombre.Contains(nombre));

        }

        //Elemento Opción Eliminar
        private void tslEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombre == null)
            {
                erpError.SetError(txtNombre, "Debe consultar el registro que desea Eliminar");
                LimpiarControles();
                txtNombre.Focus();
                tslEliminar.Enabled=false;
                return;

            }
            else
            {
                erpError.SetError(txtNombre, "");
                DialogResult Respuesta = MessageBox.Show("Esta Suguro de  Eliniar el Registro", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Respuesta == DialogResult.Yes);

                {
                    foreach (ClsLista MiRegistro in MiLista)
                    {
                        if (MiRegistro.Nombre == txtNombre.Text)
                        {
                            MiLista.Remove(MiRegistro);
                            break;
                        }
                    }
                    LimpiarControles();
                    dgvDatos.DataSource = null;
                    dgvDatos.DataSource = MiLista;
                }
            }
        }

        private void tslRetornar_Click(object sender, EventArgs e)
        {
            Menu formulario = new Menu();
            formulario.Show();
        }
    }
}
