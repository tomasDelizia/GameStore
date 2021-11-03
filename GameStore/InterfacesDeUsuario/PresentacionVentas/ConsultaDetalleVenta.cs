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

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class ConsultaDetalleVenta : Form
    {
        private ICollection<DetalleVenta> _detallesDeVenta;

        public ConsultaDetalleVenta(ICollection<DetalleVenta> detallesDeVenta)
        {
            InitializeComponent();
            dgvDetallesDeVenta.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvDetallesDeVenta.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _detallesDeVenta = detallesDeVenta;
        }

        private void ConsultaDetalleVenta_Load(object sender, EventArgs e)
        {
            ConsultarDetallesDeVenta();
            CalcularTotal();
        }

        private void ConsultarDetallesDeVenta()
        {
            CargarDetallesDeVenta(_detallesDeVenta);
            MostrarImagenArticuloSeleccionado();
            dgvDetallesDeVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in _detallesDeVenta)
            {
                var subtotal = detalle.CalcularSubtotal();
                total += subtotal;
            }
            txtTotal.Text = total.ToString();
        }

        private void MostrarImagenArticuloSeleccionado()
        {
            var nroFactura = Convert.ToInt32(dgvDetallesDeVenta.CurrentRow.Cells["NroFactura"].Value);
            var idArticulo = Convert.ToInt64(dgvDetallesDeVenta.CurrentRow.Cells["Codigo"].Value);
            var articulo = GetArticulo(nroFactura, idArticulo);
            byte[] contenidoImagen = articulo.Archivo.Contenido;
            MemoryStream memorystream = new MemoryStream(contenidoImagen, 0, contenidoImagen.Length);
            Image imagen = Image.FromStream(memorystream);
            picArticulo.Image = imagen;
        }

        private Articulo GetArticulo(int nroFactura, long idArticulo)
        {
            foreach(var detalle in _detallesDeVenta)
            {
                if (detalle.NroFactura == nroFactura && detalle.Codigo == idArticulo)
                    return detalle.Articulo;
            }
            return null;
        }

        private void CargarDetallesDeVenta(ICollection<DetalleVenta> detallesDeVenta)
        {
            dgvDetallesDeVenta.Rows.Clear();
            foreach (var detalle in detallesDeVenta)
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
                dgvDetallesDeVenta.Rows.Add(fila);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvDetallesDeVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarImagenArticuloSeleccionado();
        }
    }
}
