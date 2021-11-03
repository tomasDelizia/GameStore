using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class ConsultarDetalleAlquiler : Form
    {
        private ICollection<DetalleAlquiler> _detallesDeAlquiler;
        private int dias; 

        public ConsultarDetalleAlquiler(ICollection<DetalleAlquiler> detallesDeAlquiler, int cantidadDias)
        {
            InitializeComponent();
            dgvDetallesDeAlquileres.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvDetallesDeAlquileres.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _detallesDeAlquiler = detallesDeAlquiler;
            dias = cantidadDias;
        }

        private void ConsultarDetalleAlquiler_Load(object sender, EventArgs e)
        {
            ConsultarDetallesDeVenta();
            CalcularTotal();
        }

        private void ConsultarDetallesDeVenta()
        {
            CargarDetallesDeAlquiler(_detallesDeAlquiler);
            MostrarImagenArticuloSeleccionado();
            dgvDetallesDeAlquileres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in _detallesDeAlquiler)
            {
                var subtotal = detalle.CalcularSubtotal(dias);
                total += subtotal;
            }
            txtTotal.Text = total.ToString();
        }

        private void MostrarImagenArticuloSeleccionado()
        {
            var nroAlquiler = Convert.ToInt32(dgvDetallesDeAlquileres.CurrentRow.Cells["NroAlquiler"].Value);
            var idArticulo = Convert.ToInt64(dgvDetallesDeAlquileres.CurrentRow.Cells["Codigo"].Value);
            var articulo = GetArticulo(nroAlquiler, idArticulo);
            byte[] contenidoImagen = articulo.Archivo.Contenido;
            MemoryStream memorystream = new MemoryStream(contenidoImagen, 0, contenidoImagen.Length);
            Image imagen = Image.FromStream(memorystream);
            picArticulo.Image = imagen;
        }

        private Articulo GetArticulo(int nroAlquiler, long idArticulo)
        {
            foreach (var detalle in _detallesDeAlquiler)
            {
                if (detalle.NroAlquiler == nroAlquiler && detalle.Codigo == idArticulo)
                    return detalle.Articulo;
            }
            return null;
        }

        private void CargarDetallesDeAlquiler(ICollection<DetalleAlquiler> detallesDeAlquiler)
        {
            dgvDetallesDeAlquileres.Rows.Clear();
            foreach (var detalle in detallesDeAlquiler)
            {
                var fila = new string[]
                {
                    detalle.NroAlquiler.ToString(),
                    detalle.Codigo.ToString(),
                    detalle.Articulo.Nombre,
                    "$ " + detalle.MontoAlquilerPorDia.ToString(),
                    "$ " + detalle.CalcularSubtotal(dias),
                    detalle.Articulo.TipoArticulo.Nombre,
                    detalle.Articulo.Plataforma.Nombre

                };
                dgvDetallesDeAlquileres.Rows.Add(fila);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvDetallesDeAlquileres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarImagenArticuloSeleccionado();
        }
    }
}
