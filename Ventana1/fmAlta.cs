using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventana1
{
    public partial class fmAlta : Form
    {
        public fmAlta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ///agregar validaciones chequeado, pero masomenos. hay que ponerle un poquito mas de polenta
            bool banderita = true;
            if (txtCodArt.TextLength ==0 )
            {   
                banderita = false;
                txtCodArt.BackColor = Color.Red;
            }    
            if (txtDescripcion.TextLength == 0)
            {
                banderita = false;
                txtDescripcion.BackColor = Color.Red;
            }
            if (txtNombre.TextLength == 0)
            {
                banderita = false;
                txtNombre.BackColor = Color.Red;
            }
            if(banderita)
            {   ///puede quedar pendiente igual pero me pone nervioso xd
                nuevo.Codigo = txtCodArt.Text; 
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.categoria = (Categoria)cbCategoria.SelectedItem;
                nuevo.Marca = (Marca)cbMarca.SelectedItem;
                nuevo.Imagen = txtImagen.Text;
                negocio.agregar(nuevo);
                MessageBox.Show("Agregado con exito REY/REYNA", "Exito");
            }
            else { MessageBox.Show("Campos Incompletos o Invalidos", "Error Campos"); }
            Close();
        }

        private void fmAlta_Load(object sender, EventArgs e)
        {
            CategoriaNegocio Catnegocio = new CategoriaNegocio();
            cbCategoria.DataSource = Catnegocio.Listar();
            MarcaNegocio marcNegocio = new MarcaNegocio();
            cbMarca.DataSource = marcNegocio.Listar();
        }
    }
}
