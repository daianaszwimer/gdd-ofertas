/*IF OBJECT_ID (N'dbo.Usuario', N'U') IS NOT NULL  
DROP TABLE gd_esquema.Usuario;  
GO
*/
USE GD2C2019

-- PARTE DAIANA
CREATE TABLE gd_esquema.Usuario(
	usuario_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	usuario_username nvarchar(64) NOT NULL,
	usuario_password nvarchar(64) NOT NULL,
	usuario_intentos_fallidos_login INT NOT NULL,
	usuario_eliminado BIT NULL,
)

CREATE TABLE gd_esquema.RolesxUsuario(
	rolesxusuario_id_usuario INT NOT NULL,
	rolesxusuario_id_rol INT NOT NULL,
)

CREATE TABLE gd_esquema.Rol(
	rol_id INT identity(1 ,1) NOT NULL PRIMARY KEY,
	rol_nombre varchar(20) NOT NULL,
	rol_habilitado BIT DEFAULT 1,
	rol_eliminado BIT DEFAULT 0,
)

CREATE TABLE gd_esquema.FuncionalidadxRol(
	funcionalidadxrol_id_rol INT NOT NULL,
	funcionalidadxrol_id_funcionalidad INT NOT NULL,
)

CREATE TABLE gd_esquema.Funcionalidad(
	funcionalidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	funcionalidad_descripcion varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Cliente(
	cliente_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cliente_id_usuario INT NOT NULL,
	cliente_nombre varchar(64) NOT NULL,
	cliente_apellido varchar(64) NOT NULL,
	cliente_dni varchar(64) UNIQUE NOT NULL,
	cliente_mail varchar(64) UNIQUE NOT NULL,
	cliente_telefono varchar(64) UNIQUE NULL,
	cliente_habilitado BIT NOT NULL,
	cliente_fecha_nacimiento datetime NULL,
	cliente_id_domicilio INT NOT NULL,
	cliente_credito INT NOT NULL,
)

CREATE TABLE gd_esquema.Domicilio(
	domicilio_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	domicilio_id_localidad INT NOT NULL,
	domicilio_calle varchar(64) NOT NULL,
	domicilio_numero_piso INT NULL,
	domicilio_departamento char(20) NULL,
	domicilio_codigo_postal INT NOT NULL,
)

CREATE TABLE gd_esquema.Localidad(
	localidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	localidad_nombre varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Carga_Credito(
	carga_credito_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	carga_credito_id_cliente INT NOT NULL,
	carga_credito_id_tipo_pago INT NOT NULL,
	carga_credito_id_tarjeta INT NOT NULL,
	carga_credito_fecha datetime NOT NULL,
	carga_credito_monto INT NOT NULL,
)

CREATE TABLE gd_esquema.Tipo_Pago(
	tipo_pago_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tipo_pago_nombre varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Tarjeta(
	tarjeta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tarjeta_numero varchar(64) NOT NULL,
	tarjeta_fecha_venc datetime NOT NULL,
	tarjeta_cod_seguridad varchar(64) NOT NULL,
)

-- PARTE POR NICO
CREATE TABLE gd_esquema.Provedor(
	proveedor_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	proveedor_id_usuario INT,
	proveedor_razon_social varchar(64) UNIQUE NOT NULL,
	proveedor_id_domicilio INT,
	proveedor_cuit nvarchar(64) UNIQUE NOT NULL,
	proveedor_telefono varchar(64),
	proveedor_mail varchar(64),
	proveedor_id_rubro INT,
	proveedor_nombre_contacto varchar(64),
	proveedor_habilitado BIT NOT NULL
)

CREATE TABLE gd_esquema.Rubro(
	rubro_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	rubro_descripcion varchar(64),
)

CREATE TABLE gd_esquema.Oferta(
	oferta_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	oferta_id_proveedor INT NOT NULL,
	oferta_descripcion varchar(64),
	oferta_precio numeric NOT NULL,
	oferta_precio_lista numeric,
	oferta_fecha_pubicacion datetime,
	oferta_fecha_venc datetime,
	oferta_cantidad numeric,
	oferta_restriccion_compra numeric NULL,
)

CREATE TABLE gd_esquema.Factura(
	factura_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	factura_importe numeric,
	factura_fecha_inicio datetime,
	factura_fecha_fin datetime,
	factura_id_proveedor INT NOT NULL,
)

CREATE TABLE gd_esquema.Item(
	item_id_factura INT NOT NULL,
	item_id_compra_oferta INT NOT NULL,
)

CREATE TABLE gd_esquema.Compra_Oferta(
	compra_oferta_id INT identity(1 ,1) NOT NULL PRIMARY KEY,
	compra_oferta_id_cliente INT NOT NULL,
	compra_oferta_id_oferta INT NOT NULL,
	compra_oferta_cantidad numeric,
	compra_oferta_fecha datetime,
)

CREATE TABLE gd_esquema.Cupon(
	cupon_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cupon_fecha_venc datetime,
	cupon_fecha_consumo datetime,
	cupon_id_compra_oferta INT NOT NULL,
	cupon_id_cliente INT NOT NULL,
)

-- CREO LAS FOREIGN KEYS --

ALTER TABLE gd_esquema.RolesxUsuario ADD FOREIGN KEY(rolesxusuario_id_usuario) REFERENCES gd_esquema.Usuario(usuario_id)

ALTER TABLE gd_esquema.RolesxUsuario ADD FOREIGN KEY(rolesxusuario_id_rol) REFERENCES gd_esquema.Rol(rol_id)

ALTER TABLE gd_esquema.FuncionalidadxRol ADD FOREIGN KEY(funcionalidadxrol_id_rol) REFERENCES gd_esquema.Rol(rol_id)

ALTER TABLE gd_esquema.FuncionalidadxRol ADD FOREIGN KEY(funcionalidadxrol_id_funcionalidad) REFERENCES gd_esquema.Funcionalidad(funcionalidad_id)

ALTER TABLE gd_esquema.Cliente ADD FOREIGN KEY(cliente_id_usuario) REFERENCES gd_esquema.Usuario(usuario_id)

ALTER TABLE gd_esquema.Cliente ADD FOREIGN KEY(cliente_id_domicilio) REFERENCES gd_esquema.Domicilio(domicilio_id)

ALTER TABLE gd_esquema.Domicilio ADD FOREIGN KEY(domicilio_id_localidad) REFERENCES gd_esquema.Localidad(localidad_id)

ALTER TABLE gd_esquema.Carga_Credito ADD FOREIGN KEY(carga_credito_id_cliente) REFERENCES gd_esquema.Cliente(cliente_id)

ALTER TABLE gd_esquema.Carga_Credito ADD FOREIGN KEY(carga_credito_id_tarjeta) REFERENCES gd_esquema.Tarjeta(tarjeta_id)


ALTER TABLE gd_esquema.Proveedor ADD FOREIGN KEY(proveedor_id_usuario) REFERENCES gd_esquema.Usuario(usuario_id)

ALTER TABLE gd_esquema.Proveedor ADD FOREIGN KEY(proveedor_id_rubro) REFERENCES gd_esquema.Rubro(rubro_id)

ALTER TABLE gd_esquema.Proveedor ADD FOREIGN KEY(proveedor_id_domicilio) REFERENCES gd_esquema.Domicilio(domicilio_id)

ALTER TABLE gd_esquema.Factura ADD FOREIGN KEY(factura_id_proveedor) REFERENCES gd_esquema.Proveedor(proveedor_id)

ALTER TABLE gd_esquema.Item ADD FOREIGN KEY(item_id_factura) REFERENCES gd_esquema.Factura(factura_id)

ALTER TABLE gd_esquema.Item ADD FOREIGN KEY(item_id_compra_oferta) REFERENCES gd_esquema.Compra_Oferta(compra_oferta_id)

ALTER TABLE gd_esquema.Compra_Oferta ADD FOREIGN KEY(compra_oferta_id_cliente) REFERENCES gd_esquema.Cliente(cliente_id)

ALTER TABLE gd_esquema.Compra_Oferta ADD FOREIGN KEY(compra_oferta_id_oferta) REFERENCES gd_esquema.Oferta(oferta_id)

ALTER TABLE gd_esquema.Oferta ADD FOREIGN KEY(oferta_id_proveedor) REFERENCES gd_esquema.Proveedor(proveedor_id)

ALTER TABLE gd_esquema.Cupon ADD FOREIGN KEY(cupon_id_compra_oferta) REFERENCES gd_esquema.Compra_Oferta(compra_oferta_id)

ALTER TABLE gd_esquema.Cupon ADD FOREIGN KEY(cupon_id_cliente) REFERENCES gd_esquema.Cliente(cliente_id)


-- FUNCIONES
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('ABM Rol')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('ABM Cliente')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('ABM Proveedor')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Registro')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Carga de Credito')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Confeccion y Publicacion de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Compra de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Entrga/Consumo de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Facturacion a Proveedor')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_descripcion)
Values('Listado Estadistico')

INSERT INTO gd_esquema.Rol(rol_nombre)
Values('Administrativo')
INSERT INTO gd_esquema.Rol(rol_nombre)
Values('Proveedor')
INSERT INTO gd_esquema.Rol(rol_nombre)
Values('Cliente')