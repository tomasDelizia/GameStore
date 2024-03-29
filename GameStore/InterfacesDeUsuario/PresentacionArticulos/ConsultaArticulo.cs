﻿using System;
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
using GameStore.InterfacesDeUsuario.PresentacionCompras;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
using GameStore.InterfacesDeUsuario.PresentacionAlquileres;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ConsultaArticulo : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioArticulo _servicioArticulo;
        private readonly IServicioTipoArticulo _servicioTipoArticulo;
        private readonly IServicioPlataforma _servicioPlataforma;
        private RegistrarCompra _registrarCompra;
        private RegistrarVenta _registrarVenta;
        private RegistrarAlquiler _registrarAlquiler;

        public ConsultaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
        }
        public ConsultaArticulo(IUnidadDeTrabajo unidadDeTrabajo, RegistrarVenta registrarVenta)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            SetBotonesParaVenta();
            _registrarVenta = registrarVenta;
        }

        public ConsultaArticulo(IUnidadDeTrabajo unidadDeTrabajo, RegistrarCompra frmRegistrarCompra)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            SetBotonesParaVenta();
            _registrarCompra = frmRegistrarCompra;
        }

        public ConsultaArticulo(IUnidadDeTrabajo unidadDeTrabajo, RegistrarAlquiler frmRegistrarAlquiler)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            SetBotonesParaVenta();
            _registrarAlquiler = frmRegistrarAlquiler;
        }

        private void ConsultaArticulo_Load(object sender, EventArgs e)
        {
            CargarTipoArticulos(cboTipoArticulo);
            CargarPlataformas(cboPlataforma);
            ConsultarArticulos();
        }

        private void CargarPlataformas(ComboBox combo)
        {
            var plataformas = _servicioPlataforma.ListarPlataformas();
            FormUtils.CargarCombo(ref cboPlataforma, new BindingSource() { DataSource = plataformas }, "Nombre", "IdPlataforma");
        }

        private void CargarTipoArticulos(ComboBox combo)
        {
            var tiposArticulos = _servicioTipoArticulo.ListarTiposDeArticulo();
            FormUtils.CargarCombo(ref cboTipoArticulo, new BindingSource() { DataSource = tiposArticulos }, "Nombre", "IdTipoArticulo");
        }

        private void ConsultarArticulos()
        {
            ckbIncluirTodos.Checked = false;
            var articulos = _servicioArticulo.ListarArticulosActivos();
            CargarDgvArticulos(articulos);
            MostrarImagenArticuloSeleccionado();
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> articulosFiltrados;
                if (!string.IsNullOrEmpty(txtUPC.Text))
                {
                    long codigo = Convert.ToInt64(txtUPC.Text);
                    articulosFiltrados = _servicioArticulo.Encontrar(a => a.Codigo == codigo).ToList();
                    CargarDgvArticulos(articulosFiltrados);
                    return;
                }
                
                var nombreArticulo = txtNombre.Text.Trim();
                if (nombreArticulo.Length > 50)
                    throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");

                var tipoArticulo = (TipoArticulo)cboTipoArticulo.SelectedItem;
                if (tipoArticulo == null)
                {
                    tipoArticulo = new TipoArticulo();
                    tipoArticulo.Nombre = "";
                }

                var plataforma = (Plataforma)cboPlataforma.SelectedItem;
                if (plataforma == null)
                {
                    plataforma = new Plataforma();
                    plataforma.Nombre = "";
                }

                var precioMin = numPrecioMin.Value;
                var precioMax = numPrecioMax.Value;
                if (precioMin > precioMax)
                    throw new ApplicationException("Ingrese un rango de precios válido.");

                articulosFiltrados = _servicioArticulo.Encontrar(a => a.Nombre.Contains(nombreArticulo) && a.PrecioUnitario >= precioMin
                && a.PrecioUnitario <= precioMax && a.TipoArticulo.Nombre == tipoArticulo.Nombre && a.Plataforma.Nombre == plataforma.Nombre).ToList();
                CargarDgvArticulos(articulosFiltrados);
            } catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Información", MessageBoxButtons.OK);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("El código de producto universal solo acepta caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDgvArticulos(List<Articulo> articulos)
        {
            dgvArticulos.Rows.Clear();

            foreach (var articulo in articulos)
            {
                var fila = new string[]
                {
                    articulo.Codigo.ToString(),
                    articulo.Nombre,
                    "$ " + articulo.PrecioUnitario.ToString(),
                    articulo.Stock.ToString(),
                    articulo.TipoArticulo.Nombre,
                    articulo.Plataforma.Nombre.ToString(),
                    articulo.EstadoVideojuego.Nombre,
                };
                dgvArticulos.Rows.Add(fila);
            }
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarImagenArticuloSeleccionado();
        }

        private void MostrarImagenArticuloSeleccionado()
        {
            var idArticulo = Convert.ToInt64(dgvArticulos.CurrentRow.Cells["Codigo"].Value);
            var articulo = _servicioArticulo.GetPorId(idArticulo);
            byte[] contenidoImagen = articulo.Archivo.Contenido;
            MemoryStream memorystream = new MemoryStream(contenidoImagen, 0, contenidoImagen.Length);
            Image imagen = Image.FromStream(memorystream);
            picArticulo.Image = imagen;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaArticulo(_unidadDeTrabajo).ShowDialog();
            ConsultarArticulos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // validar cantidad de filas seleccionadas.
            if (dgvArticulos.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                new ModificacionArticulo(_unidadDeTrabajo, id).ShowDialog();
                ConsultarArticulos();
                return;
            }

            else if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);

                new BajaArticulo(_unidadDeTrabajo, id).ShowDialog();
                ConsultarArticulos();
                return;
            }

            else if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarArticulos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SetBotonesParaVenta()
        {
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnSeleccionar.Visible = true;
            ckbIncluirTodos.Visible = false;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 1)
            {
                if (_registrarCompra != null)
                {
                    List<Articulo> articulos = _registrarCompra.GetArticulos();
                    var id = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                    var articulo = _servicioArticulo.GetPorId(id);
                    if (articulos.Contains(articulo))
                    {
                        MessageBox.Show("Ya seleccionó este artículo.", "Información", MessageBoxButtons.OK);
                        return;
                    }
                    IngresarCantidad frmCantidad = new IngresarCantidad();
                    frmCantidad.ShowDialog();
                    int cantidad = frmCantidad.GetCantidad();
                    frmCantidad.Dispose();
                    if (cantidad > 0)
                    {
                        _registrarCompra.AgregarArticulo(articulo, cantidad);
                        this.Dispose();
                    }
                    return;
                }

                else if (_registrarVenta != null)
                {
                    List<Articulo> articulos = _registrarVenta.GetArticulos();
                    var id = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                    var articulo = _servicioArticulo.GetPorId(id);
                    if (articulos.Contains(articulo))
                    {
                        MessageBox.Show("Ya seleccionó este artículo.", "Información", MessageBoxButtons.OK);
                        return;
                    }
                    if (articulo.Stock == 0)
                    {
                        MessageBox.Show("El artículo seleccionado no cuenta con stock en este momento.", "Información", MessageBoxButtons.OK);
                        return;
                    }
                    IngresarCantidad frmCantidad = new IngresarCantidad(articulo.Stock);
                    frmCantidad.ShowDialog();
                    int cantidad = frmCantidad.GetCantidad();
                    frmCantidad.Dispose();
                    if (cantidad > 0)
                    {
                        _registrarVenta.AgregarArticulo(articulo, cantidad);
                        this.Dispose();
                    }
                    return;
                }
				
				else if (_registrarAlquiler != null)
                {
                    List<Articulo> articulos = _registrarAlquiler.GetArticulos();
                    var id = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                    var articulo = _servicioArticulo.GetPorId(id);
                    if (articulos.Contains(articulo))
                    {
                        MessageBox.Show("Ya seleccionó este artículo.", "Información", MessageBoxButtons.OK);
                        return;
                    }

                    if (!articulo.EsVideojuego())
                    {
                        MessageBox.Show("Solo se pueden alquilar Videojuegos.", "Información", MessageBoxButtons.OK);
                        return;
                    }

                    if (!(articulo.Stock > 0))
                    {
                        MessageBox.Show("La cantidad en stock no es suficiente.", "Información", MessageBoxButtons.OK);
                        return;
                    }

                    _registrarAlquiler.AgregarArticulo(articulo);
                    this.Dispose();
				}
            }

            else if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void ckbIncluirTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIncluirTodos.Checked)
            {
                var articulos = _servicioArticulo.ListarArticulos();
                CargarDgvArticulos(articulos);
            }
            else
                ConsultarArticulos();
        }
    }
}
