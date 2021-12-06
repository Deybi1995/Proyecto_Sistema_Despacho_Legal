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
    public partial class Facturación : Form
    {
        public Facturación()
        {
            InitializeComponent();
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo;
            int Nombre;
            float costo;

            codigo = CmbTipoServicio.SelectedIndex;
            Nombre = CmbTipoServicio.SelectedIndex;
            costo = CmbTipoServicio.SelectedIndex;

            switch (codigo)
            {
                case 0: lbCodigo.Text = "0001";break;
                case 1: lbCodigo.Text = "0002";break;
                case 2: lbCodigo.Text = "0003"; break;
                case 3: lbCodigo.Text = "0004"; break;
                case 4: lbCodigo.Text = "0005"; break;
                case 5: lbCodigo.Text = "0006"; break;
                case 6: lbCodigo.Text = "0007"; break;
                case 7: lbCodigo.Text = "0008"; break;
                default: lbCodigo.Text ="0009"; break;
            }
            switch (Nombre)
            {
                case 0: lbNombre.Text = "Cobranza";break;
                case 1:lbNombre.Text = "Asesoría y consulta jurídica";break;
                case 2:lbNombre.Text = "Investigación jurídica";break;
                case 3:lbNombre.Text = "Elaboración de contratos";break;
                case 4:lbNombre.Text = "Auditorias jurídicas";break;
                case 5:lbNombre.Text = "Derechos Civiles";break;
                case 6:lbNombre.Text = "Derecho Penal";break;
                case 7:lbNombre.Text = "Derecho Laboral";break;
                default:lbNombre.Text = "Derecho Administrativo";break;
                                 
            }
            switch (costo)
            {
                case 0: lbCosto.Text = "1500"; break;
                case 1: lbCosto.Text= "1000"; break;
                case 2: lbCosto.Text = "3000"; break;
                case 3: lbCosto.Text = "1000"; break;
                case 4: lbCosto.Text = "5000"; break;
                case 5: lbCosto.Text = "2000"; break;
                case 6: lbCosto.Text = "3500"; break;
                case 7: lbCosto.Text = "2500"; break;
                default: lbCosto.Text = "2300"; break;
            }
        }

        private void BtVender_Click(object sender, EventArgs e)
        {
            clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

            Ticket1.TextoCentro("DEFENSORIA LEGAL DEYBI "); //imprime una linea de descripcion
            Ticket1.TextoCentro("**********************************");

            Ticket1.TextoIzquierda("Dirc: Colonia 3 de Mayo");
            Ticket1.TextoIzquierda("Tel: 31784272 ");
            Ticket1.TextoIzquierda("Rtn: 07151995006264");
            Ticket1.TextoIzquierda("");
            Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
            Ticket1.TextoIzquierda("No Fac: 0000-001-01-0001");
            Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
            Ticket1.TextoIzquierda("Le Atendio: Deybi Roiqueni Martines");
            Ticket1.TextoIzquierda("");
            clsFactura.CreaTicket.LineasGuion();

            clsFactura.CreaTicket.EncabezadoVenta();
            clsFactura.CreaTicket.LineasGuion();
            foreach (DataGridViewRow r in DgvResultado.Rows)
            {
                // PROD                     //CANT                                    PREC                         TOTAL
                Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
            }


            clsFactura.CreaTicket.LineasGuion();
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Total", double.Parse(LbTotalAPagar.Text)); // imprime linea con total
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(TxtEfectivo2.Text));
            Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(LbDevolucion1.Text));


            // Ticket1.LineasTotales(); // imprime linea 

            Ticket1.TextoIzquierda(" ");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoCentro("*     Gracias por preferirnos    *");

            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoIzquierda(" ");
            string impresora = "Microsoft XPS Document Writer";
            Ticket1.ImprimirTiket(impresora);
            MessageBox.Show("Gracias por preferirnos");
            this.Close();
        }

        private void BtAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(DgvResultado);

            file.Cells[0].Value = lbCodigo.Text;
            file.Cells[1].Value = lbNombre.Text;
            file.Cells[2].Value = TxtCantidad.Text;
            file.Cells[3].Value = lbCosto.Text;
            file.Cells[4].Value = (float.Parse(lbCosto.Text) * float.Parse(TxtCantidad.Text)).ToString();

            DgvResultado.Rows.Add(file);

            lbCodigo.Text = lbNombre.Text = LbCantidad.Text = "";

            ObtenerTotal();
        }
        
        public void ObtenerTotal()
        {
            float Costo = 0;
            int Contador = 0;

            Contador = DgvResultado.RowCount;

            for (int i = 0; i < Contador; i++)
            {
                Costo += float.Parse(DgvResultado.Rows[i].Cells[4].Value.ToString());
            }

            LbTotalAPagar.Text = Costo.ToString();
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea Eliminar el servicio?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    DgvResultado.Rows.Remove(DgvResultado.CurrentRow);
                }
            }
            catch  {}
            ObtenerTotal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LbDevolucion1.Text = (float.Parse(TxtEfectivo2.Text)-float.Parse(LbTotalAPagar.Text)).ToString();
            }
            catch { }
        }
    }
    
}
