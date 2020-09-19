using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using System.Runtime.InteropServices;

namespace Ventana1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();

        }
        protected void Cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvGrilla.DataSource = negocio.Listar();
            dgvGrilla.Columns[3].Visible = false;
          //  dgvGrilla.Columns[0].Visible = false;
        }

        private void dgvGrilla_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulos art = (Articulos)dgvGrilla.CurrentRow.DataBoundItem;
                pbImagen.Load(art.Imagen);
            }
            catch (Exception)
            {

            }
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            fmAlta alta = new fmAlta(); // creo la ventana
            alta.ShowDialog(); // abro la ventana
            Cargar();
        }

        /// ZONA DE LOS EVENTOS GENERADOS SIN QUERER :)
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }        
        private void pbImagen_Click(object sender, EventArgs e)
        {

        }
         private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos art;
            art = (Articulos)dgvGrilla.CurrentRow.DataBoundItem;
            fmAlta modificar = new fmAlta(art);
            Cargar();

        }
    }
}
