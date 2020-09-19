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
        private Articulos art = null;
        public fmAlta()
        {
            InitializeComponent();
        }
        public fmAlta(Articulos Art)
        {
            InitializeComponent();
            art = Art;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
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

                if (art == null)
                    art = new Articulos();
                
                               
                art.Codigo = txtCodArt.Text;
                art.Descripcion = txtDescripcion.Text;
                art.Nombre = txtNombre.Text;
                art.categoria = (Categoria)cbCategoria.SelectedItem;
                art.Marca = (Marca)cbMarca.SelectedItem;
                art.Imagen = txtImagen.Text;
                //negocio.agregar(art);

                if (art.Id == 0)
                {
                    negocio.agregar(art);
                }
                else
                {
                    negocio.eliminar(art);
                }

                MessageBox.Show("Operación realizada con exito REY/REYNA", "Exito");
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
            cbCategoria.ValueMember = "Id";
            cbCategoria.DisplayMember = "Descripcion";
            //if(cbCategoria.SelectedIndex >0)
                cbCategoria.SelectedIndex = -1;
            //parte s de marca iguales a esto
            if (art != null)
            {
                txtCodArt.Text = art.Codigo;
                txtNombre.Text = art.Nombre;
                txtDescripcion.Text = art.Descripcion;
                txtImagen.Text = art.Imagen;
                ///txtPrecio.Text = (Sqlmoney)art.Precio;    ///RESOLVER!!!!
                cbCategoria.SelectedValue = art.categoria.Id;
                Text = "Modificacion De Registro";

            }
        

        }
    }
}
