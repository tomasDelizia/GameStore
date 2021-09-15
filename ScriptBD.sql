USE [PAV-3K2-2021-9]

-- DBCC CHECKIDENT ('TABLA', RESEED, 0);	-- Resetear contador de id de una tabla

CREATE TABLE Generos (
	IdGenero INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT generos_id_genero_pk PRIMARY KEY(IdGenero));

CREATE TABLE Clasificaciones (
	IdClasificacion INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT clasificaciones_id_clasificacion_pk PRIMARY KEY(IdClasificacion));

CREATE TABLE Desarrolladores (
	IdDesarrollador INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT desarrolladores_id_desarrollador_pk PRIMARY KEY(IdDesarrollador));

--CREATE TABLE Publicantes (
--	IdPublicante INT IDENTITY,
--	Nombre VARCHAR(50) NOT NULL,
--	Descripcion VARCHAR(MAX),
--	CONSTRAINT publicantes_id_publicante_pk PRIMARY KEY(IdPublicante));

CREATE TABLE Marcas (
	IdMarca INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT marcas_id_marca_pk PRIMARY KEY(IdMarca));

CREATE TABLE Plataformas (
	IdPlataforma INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT plataformas_id_plataforma_pk PRIMARY KEY(IdPlataforma));

CREATE TABLE EstadosDeVideojuego (
	IdEstado INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT estados_videojuego_id_estado_pk PRIMARY KEY(IDEstado));

--CREATE TABLE VIDEOJUEGOS (
--	codigo INT IDENTITY,
--	nombre VARCHAR(50) NOT NULL,
--	precio_unitario DECIMAL(9,2) NOT NULL,
--	monto_alquiler_por_dia DECIMAL(10,2),
--	monto_devolucion_tardia_por_dia DECIMAL(10,2),
--	stock INT NOT NULL,
--	id_estado INT,
--	fecha_salida DATE,
--	id_clasificacion INT,
--	id_genero INT,
--	id_desarrollador INT,
--	id_publicante INT,
--	id_plataforma INT,
--	imagen VARCHAR(100),
--	descripcion VARCHAR(MAX),
--	CONSTRAINT videojuegos_codigo_pk PRIMARY KEY(codigo),
--	CONSTRAINT videojuegos_id_estado_fk FOREIGN KEY(id_estado) REFERENCES ESTADOS_DE_VIDEOJUEGO(id_estado)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	CONSTRAINT videojuegos_id_clasificacion_fk FOREIGN KEY(id_clasificacion) REFERENCES CLASIFICACIONES(id_clasificacion)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	CONSTRAINT videojuegos_id_genero_fk FOREIGN KEY(id_genero) REFERENCES GENEROS(id_genero)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	CONSTRAINT videojuegos_id_desarrollador_fk FOREIGN KEY(id_desarrollador) REFERENCES DESARROLLADORES(id_desarrollador)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	CONSTRAINT videojuegos_id_publicante_fk FOREIGN KEY(id_publicante) REFERENCES PUBLICANTES(id_publicante)
--    ON UPDATE CASCADE ON DELETE SET NULL,	
--	CONSTRAINT videojuegos_id_plataforma_fk FOREIGN KEY(id_plataforma) REFERENCES PLATAFORMAS(id_plataforma)
--    ON UPDATE CASCADE ON DELETE SET NULL,	
--	);

--CREATE TABLE CONSOLAS (
--	codigo INT IDENTITY,
--	nombre VARCHAR(50) NOT NULL,
--	precio_unitario DECIMAL(9,2) NOT NULL,
--	monto_alquiler_por_dia DECIMAL(10,2),
--	monto_devolucion_tardia_por_dia DECIMAL(10,2),
--	stock INT NOT NULL,
--	fecha_salida DATE,
--	id_clasificacion INT,
--	id_plataforma INT,
--	imagen VARCHAR(100),
--	descripcion VARCHAR(MAX),
--	CONSTRAINT consolas_codigo_pk PRIMARY KEY(codigo),
--	CONSTRAINT consolas_id_clasificacion_fk FOREIGN KEY(id_clasificacion) REFERENCES CLASIFICACIONES(id_clasificacion)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	CONSTRAINT consolas_id_plataforma_fk FOREIGN KEY(id_plataforma) REFERENCES PLATAFORMAS(id_plataforma)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	);

--CREATE TABLE PERIFERICOS (
--	codigo INT IDENTITY,
--	nombre VARCHAR(50) NOT NULL,
--	precio_unitario DECIMAL(9,2) NOT NULL,
--	monto_alquiler_por_dia DECIMAL(10,2),
--	monto_devolucion_tardia_por_dia DECIMAL(10,2),
--	stock INT NOT NULL,
--	fecha_salida DATE,
--	id_plataforma INT,
--	imagen VARCHAR(100),
--	descripcion VARCHAR(MAX),
--	CONSTRAINT perifericos_codigo_pk PRIMARY KEY(codigo),
--	CONSTRAINT perifericos_id_plataforma_fk FOREIGN KEY(id_plataforma) REFERENCES PLATAFORMAS(id_plataforma)
--    ON UPDATE CASCADE ON DELETE SET NULL,
--	);

CREATE TABLE TiposDeArticulo (
	IdTipoArticulo INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT tipo_de_articulo_id_tipo_articulo_pk PRIMARY KEY(IdTipoArticulo));

CREATE TABLE Articulos (
	Codigo INT IDENTITY,
	IdTipoArticulo INT,
	Nombre VARCHAR(50) NOT NULL,
	PrecioUnitario DECIMAL(9,2) NOT NULL,
	Stock INT NOT NULL,
	-- MontoAlquilerPorDia DECIMAL(10,2),
	-- MontoDevolucionTardiaPorDia DECIMAL(10,2),
	IdEstado INT,
	FechaSalida DATE,
	IdMarca INT,
	IdClasificacion INT,
	IdGenero INT,
	IdDesarrollador INT,
	-- IdPublicante INT,
	IdPlataforma INT,
	Imagen VARCHAR(100),
	Descripcion VARCHAR(MAX),
	CONSTRAINT articulos_codigo_pk PRIMARY KEY(Codigo),
	CONSTRAINT articulos_id_tipo_articulo_fk FOREIGN KEY(IdTipoArticulo) REFERENCES TiposDeArticulo (IdTipoArticulo)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT articulos_id_estado_fk FOREIGN KEY(IdEstado) REFERENCES EstadosDeVideojuego(IdEstado)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT articulos_id_clasificacion_fk FOREIGN KEY(IdClasificacion) REFERENCES Clasificaciones(IdClasificacion)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT articulos_id_genero_fk FOREIGN KEY(IdGenero) REFERENCES Generos(IdGenero)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT articulos_id_desarrollador_fk FOREIGN KEY(IdDesarrollador) REFERENCES Desarrolladores(IdDesarrollador)
    ON UPDATE CASCADE ON DELETE SET NULL,
	-- CONSTRAINT articulos_id_publicante_fk FOREIGN KEY(IdPublicante) REFERENCES Publicantes(IdPublicante)
    -- ON UPDATE CASCADE ON DELETE SET NULL,	
	CONSTRAINT articulos_id_plataforma_fk FOREIGN KEY(IdPlataforma) REFERENCES Plataformas(IdPlataforma)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT articulos_id_marca_fk FOREIGN KEY(IdMarca) REFERENCES Marcas(IdMarca)
    ON UPDATE CASCADE ON DELETE SET NULL
	);

CREATE TABLE TiposDeFactura (
	IdTipoFactura INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT tipos_de_factura_id_tipo_factura_pk PRIMARY KEY(IdTipoFactura));

CREATE TABLE FormasDePago (
	IdFormaPago INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT formas_de_pago_id_forma_pago_pk PRIMARY KEY(IdFormaPago));

CREATE TABLE Barrios (
	IdBarrio INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	CONSTRAINT barrios_id_barrio_pk PRIMARY KEY(IdBarrio));

CREATE TABLE Socios (
    IdSocio INT IDENTITY,
    Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	NroDocumento INT NOT NULL,
    Email VARCHAR(50),
	Telefono VARCHAR(30),
	FechaNacimiento DATE,
	FechaAlta DATE,
    CalleNombre VARCHAR(50),
    CalleNumero INT,
    IdBarrio INT,
    CONSTRAINT socios_id_socio_pk PRIMARY KEY(IdSocio),
	CONSTRAINT socios_id_barrio_fk FOREIGN KEY(IdBarrio) REFERENCES Barrios(IdBarrio)
    ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE Cargos (
	IdCargo INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT cargos_id_cargo_pk PRIMARY KEY(IdCargo));

CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY,
    NroDocumento INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(50),
	Telefono VARCHAR(30),
    FechaNacimiento DATE NOT NULL,
    FechaAlta DATE  NOT NULL,
    CalleNombre VARCHAR(50),
    CalleNumero INT,
    IdCargo INT,
	IdBarrio INT,
    CONSTRAINT empleados_id_empleado_pk PRIMARY KEY(IdEmpleado),
	CONSTRAINT empleados_id_barrio_fk FOREIGN KEY(IdBarrio) REFERENCES Barrios (IdBarrio)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT empleados_id_cargo_fk FOREIGN KEY(IdCargo) REFERENCES Cargos (IdCargo)
    ON UPDATE CASCADE ON DELETE SET NULL,
);

CREATE TABLE Permisos (
	idPermiso INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT permisos_id_permiso_pk PRIMARY KEY(IdPermiso));

CREATE TABLE Roles (
	IdRol INT IDENTITY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(MAX),
	CONSTRAINT roles_id_rol_pk PRIMARY KEY(IdRol));

CREATE TABLE Usuarios (
	IdUsuario INT IDENTITY,
	NombreUsuario VARCHAR(50) NOT NULL,
	Contrasenia VARCHAR(50) NOT NULL,
	FechaAlta DATE,
	IdEmpleado INT,
	CONSTRAINT usuarios_id_usuario_pk PRIMARY KEY(IdUsuario),
	CONSTRAINT usuarios_id_empleado_fk FOREIGN KEY(IdEmpleado) REFERENCES Empleados (IdEmpleado)
    ON UPDATE CASCADE ON DELETE SET NULL,
	);

CREATE TABLE RolesXUsuarios (
	IdUsuario INT NOT NULL,
	IdRol INT NOT NULL,
	CONSTRAINT roles_x_usuarios_id_usuario_id_rol_pk PRIMARY KEY(IdUsuario, IdRol),
	CONSTRAINT roles_x_usuarios_id_usuario_fk FOREIGN KEY(IdUsuario) REFERENCES Usuarios (IdUsuario)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT roles_x_usuarios_id_rol_fk FOREIGN KEY(IdRol) REFERENCES Roles (IdRol)
    ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE PermisosXRoles (
	IdRol INT NOT NULL,
	IdPermiso INT NOT NULL,
	CONSTRAINT permisos_x_roles_id_rol_id_permiso_pk PRIMARY KEY(IdRol, IdPermiso),
	CONSTRAINT permisos_x_roles_id_rol_fk FOREIGN KEY(IdRol) REFERENCES Roles (IdRol)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT permisos_x_roles_id_permiso_fk FOREIGN KEY(IdPermiso) REFERENCES Permisos (IdPermiso)
    ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE Sesiones (
    IdUsuario INT,
    FechaYHoraInicio DATETIME,
    FechaYHoraFin DATETIME,
    CONSTRAINT sesiones_id_usuario_fecha_hora_inicio_pk PRIMARY KEY(IdUsuario, FechaYHoraInicio),
    CONSTRAINT sesiones_id_usuario_fk FOREIGN KEY(IdUsuario) REFERENCES Usuarios(IdUsuario)
    ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Ventas (
    NroFactura INT IDENTITY,
	IdTipoFactura INT,
    FechaVenta DATE NOT NULL,
	IdFormaPago INT,
	IdSocio INT,
	IdVendedor INT,
    CONSTRAINT ventas_nro_factura_pk PRIMARY KEY(NroFactura),
	CONSTRAINT ventas_id_tipo_factura_fk FOREIGN KEY(IdTipoFactura) REFERENCES TiposDeFactura (IdTipoFactura)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT ventas_id_forma_pago_fk FOREIGN KEY(IdFormaPago) REFERENCES FormasDePago (IdFormaPago)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT ventas_id_socio_fk FOREIGN KEY(IdSocio) REFERENCES Socios (IdSocio)
    ON UPDATE NO ACTION ON DELETE CASCADE,
	CONSTRAINT ventas_id_vendedor_fk FOREIGN KEY(IdVendedor) REFERENCES Empleados (IdEmpleado)
    ON UPDATE NO ACTION ON DELETE CASCADE,
);

CREATE TABLE DetallesDeVenta (
	NroFactura INT NOT NULL,
	Codigo INT NOT NULL,
	Cantidad INT NOT NULL,
	PrecioUnitario DECIMAL(9,2) NOT NULL,
	CONSTRAINT detalles_de_venta_nro_factura_codigo_pk PRIMARY KEY(NroFactura, Codigo),
	CONSTRAINT detalles_de_venta_nro_factura_fk FOREIGN KEY(NroFactura) REFERENCES Ventas (NroFactura)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT detalles_de_venta_codigo_fk FOREIGN KEY(Codigo) REFERENCES Articulos (Codigo)
    ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE Alquileres (
    NroAlquiler INT IDENTITY,
	IdTipoFactura INT,
	IdFormaPago INT,
	MontoSenia DECIMAL(9,2) NOT NULL,
	FechaInicio INT NOT NULL,
	FechaFin DATE NOT NULL,
	FechaFinReal DATE,
	IdSocio INT,
	IdVendedor INT,
    CONSTRAINT alquileres_nro_factura_pk PRIMARY KEY(NroAlquiler),
	CONSTRAINT alquileres_id_tipo_factura_fk FOREIGN KEY(IdTipoFactura) REFERENCES TiposDeFactura (IdTipoFactura)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT alquileres_id_forma_pago_fk FOREIGN KEY(IdFormaPago) REFERENCES FormasDePago (IdFormaPago)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT alquileres_id_socio_fk FOREIGN KEY(IdSocio) REFERENCES Socios (IdSocio)
    ON UPDATE NO ACTION ON DELETE CASCADE,
	CONSTRAINT alquileres_id_vendedor_fk FOREIGN KEY(IdVendedor) REFERENCES Empleados (IdEmpleado)
    ON UPDATE NO ACTION ON DELETE CASCADE,
);

CREATE TABLE DetallesDeAlquiler (
	NroAlquiler INT NOT NULL,
	Codigo INT NOT NULL,
	Categoria INT,
	MontoAlquilerPorDia DECIMAL(9,2) NOT NULL,
	MontoDevolucionTardiaPorDia DECIMAL(9,2) NOT NULL,
	CONSTRAINT detalles_de_alquiler_nro_alquiler_codigo_pk PRIMARY KEY(NroAlquiler, Codigo),
	CONSTRAINT detalles_de_alquiler_nro_alquiler_fk FOREIGN KEY(NroAlquiler) REFERENCES Alquileres (NroAlquiler)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT detalles_de_alquiler_codigo_fk FOREIGN KEY(Codigo) REFERENCES Articulos (Codigo)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT detalles_de_alquiler_categoria_fk FOREIGN KEY(Categoria) REFERENCES CategoriasDeAlquiler (IdCategoriaAlquiler)
    ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE CategoriasDeAlquiler (
	IdCategoriaAlquiler INT NOT NULL,
	Nombre VARCHAR(30) NOT NULL,
	Descripcion VARCHAR(MAX),
	MontoAlquilerPorDia DECIMAL(9,2) NOT NULL,
	MontoDevolucionTardiaPorDia DECIMAL(9,2) NOT NULL,
	CONSTRAINT categorias_de_alquiler_id_categoria_ok PRIMARY KEY (IdCategoriaAlquiler)
);

CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY,
    RazonSocial VARCHAR(50) NOT NULL,
	Cuit INT,
    Email VARCHAR(50),
	Telefono VARCHAR(30),
	FechaAlta DATE,
    CalleNombre VARCHAR(50),
    CalleNumero INT,
    IdBarrio INT,
    CONSTRAINT proveedores_id_socio_pk PRIMARY KEY(IdProveedor),
	CONSTRAINT proveedores_id_barrio_fk FOREIGN KEY(IdBarrio) REFERENCES Barrios(IdBarrio)
    ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE Compras (
    NroFactura INT IDENTITY,
	IdTipoFactura INT,
    FechaCompra DATE NOT NULL,
	IdProveedor INT,
	IdEncargadoCompra INT,
    CONSTRAINT compras_nro_factura_pk PRIMARY KEY(NroFactura),
	CONSTRAINT compras_id_tipo_factura_fk FOREIGN KEY(IdTipoFactura) REFERENCES TiposDeFactura (IdTipoFactura)
    ON UPDATE CASCADE ON DELETE SET NULL,
	CONSTRAINT compras_id_proveedor_fk FOREIGN KEY(IdProveedor) REFERENCES Proveedores (IdProveedor)
    ON UPDATE NO ACTION ON DELETE CASCADE,
	CONSTRAINT compras_id_encargado_fk FOREIGN KEY(IdProveedor) REFERENCES Empleados (IdEmpleado)
    ON UPDATE NO ACTION ON DELETE CASCADE,
);

CREATE TABLE DetallesDeCompra (
	NroFactura INT NOT NULL,
	Codigo INT NOT NULL,
	Cantidad INT NOT NULL,
	PrecioUnitario DECIMAL(9,2) NOT NULL,
	CONSTRAINT detalles_de_compra_nro_factura_codigo_pk PRIMARY KEY(NroFactura, Codigo),
	CONSTRAINT detalles_de_compra_nro_factura_fk FOREIGN KEY(NroFactura) REFERENCES Compras (NroFactura)
    ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT detalles_de_compra_codigo_fk FOREIGN KEY(Codigo) REFERENCES Articulos (Codigo)
    ON UPDATE CASCADE ON DELETE CASCADE,
);