using GameStore.Entidades;
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

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class ConsultaDetalleCompra : Form
    {
        private ICollection<DetalleCompra> _detallesDeCompra;
        public ConsultaDetalleCompra(ICollection<DetalleCompra> detallesDeCompra)
        {
            InitializeComponent();
            dgvDetallesDeCompra.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvDetallesDeCompra.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _detallesDeCompra = detallesDeCompra;
        }

        private void ConsultaDetalleCompra_Load(object sender, EventArgs e)
        {
            ConsultarDetallesDeCompra();
            CalcularTotal();
        }

        private void ConsultarDetallesDeCompra()
        {
            CargarDetallesDeCompra(_detallesDeCompra);
            MostrarImagenArticuloSeleccionado();
            dgvDetallesDeCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MostrarImagenArticuloSeleccionado()
        {
            var nroFactura = Convert.ToInt32(dgvDetallesDeCompra.CurrentRow.Cells["NroFactura"].Value);
            var idArticulo = Convert.ToInt64(dgvDetallesDeCompra.CurrentRow.Cells["Codigo"].Value);
            var articulo = GetArticulo(nroFactura, idArticulo);
            byte[] contenidoImagen = articulo.Archivo.Contenido;
            MemoryStream memorystream = new MemoryStream(contenidoImagen, 0, contenidoImagen.Length);
            Image imagen = Image.FromStream(memorystream);
            picArticulo.Image = imagen;
        }

        private Articulo GetArticulo(int nroFactura, long idArticulo)
        {
            foreach (var detalle in _detallesDeCompra)
            {
                if (detalle.NroFactura == nroFactura && detalle.Codigo == idArticulo)
                    return detalle.Articulo;
            }
            return null;
        }

        private void CargarDetallesDeCompra(ICollection<DetalleCompra> detallesDeCompra)
        {
            dgvDetallesDeCompra.Rows.Clear();
            foreach (var detalle in detallesDeCompra)
            {
                var fila = new string[]
                {
                    detalle.NroFactura.ToString(),
                    detalle.Codigo.ToString(),
                    detalle.Articulo.Nombre,
                    "$ " + detalle.PrecioUnitario.ToString(),
                    detalle.Cantidad.ToString(),
                    "$ " + detalle.CalcularSubtotal(),
                    detalle.Articulo.TipoArticulo.Nombre,
                    detalle.Articulo.Plataforma.Nombre

                };
                dgvDetallesDeCompra.Rows.Add(fila);
            }
        }
        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in _detallesDeCompra)
            {
                var subtotal = detalle.CalcularSubtotal();
                total += subtotal;
            }
            txtTotal.Text = total.ToString();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvDetallesDeCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarImagenArticuloSeleccionado();
        }
    }
}
