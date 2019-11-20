-- todo: ver cual select tira: Warning: Null value is eliminated by an aggregate or other SET operation.

-- borro las tablas si existen
USE  [GD2C2019]
go

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Tipo_Pago') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Tipo_Pago

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Cupon') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Cupon

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Item') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Item

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Factura') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Factura

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Oferta') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Oferta

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Rubro') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Rubro

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Cliente') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Cliente

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Localidad') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Localidad

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Rol') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Rol

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.Usuario') IS NOT NULL
DROP TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Usuario

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_porcentaje') IS NOT NULL
DROP FUNCTION [NO_LO_TESTEAMOS_NI_UN_POCO].[top_5_mayor_porcentaje]

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_facturacion') IS NOT NULL
DROP FUNCTION [NO_LO_TESTEAMOS_NI_UN_POCO].[top_5_mayor_facturacion]

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.cliente_comprar_oferta') IS NOT NULL
DROP PROCEDURE [NO_LO_TESTEAMOS_NI_UN_POCO].[cliente_comprar_oferta]

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.facturacion') IS NOT NULL
DROP PROCEDURE [NO_LO_TESTEAMOS_NI_UN_POCO].[facturacion]

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta') IS NOT NULL
DROP PROCEDURE [NO_LO_TESTEAMOS_NI_UN_POCO].[proveedor_entrega_oferta]

IF OBJECT_ID('NO_LO_TESTEAMOS_NI_UN_POCO.obtener_ofertas_factura') IS NOT NULL
DROP FUNCTION [NO_LO_TESTEAMOS_NI_UN_POCO].[obtener_ofertas_factura]

IF SCHEMA_ID('NO_LO_TESTEAMOS_NI_UN_POCO') IS NOT NULL
DROP SCHEMA NO_LO_TESTEAMOS_NI_UN_POCO
GO

CREATE SCHEMA NO_LO_TESTEAMOS_NI_UN_POCO AUTHORIZATION gdCupon2019
GO

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Usuario(
	usuario_username nvarchar(64) NOT NULL,
	usuario_password nvarchar(500) NOT NULL,
	usuario_habilitado BIT DEFAULT 1,
	usuario_intentos_fallidos_login INT DEFAULT 0,
	usuario_eliminado BIT DEFAULT 0
	CONSTRAINT [UN_Usuario_Username] UNIQUE (usuario_username),
	CONSTRAINT [PK_Usuario] PRIMARY KEY (
		usuario_username
	)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Rol(
	rol_id INT identity(1 ,1) NOT NULL PRIMARY KEY,
	rol_nombre varchar(64) NOT NULL,
	rol_habilitado BIT DEFAULT 1,
	rol_eliminado BIT DEFAULT 0,
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(
	funcionalidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	funcionalidad_descripcion varchar(64) NOT NULL,
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario(
	rolesxusuario_id_usuario nvarchar(64) NOT NULL,
	rolesxusuario_id_rol INT NOT NULL

	CONSTRAINT [PK_RolesxUsuario] PRIMARY KEY (
		[rolesxusuario_id_usuario] ASC,
		[rolesxusuario_id_rol] ASC
	)
	
	CONSTRAINT [FK_RolesxUsuario_rol_id] FOREIGN KEY(rolesxusuario_id_rol)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].Rol (rol_id),
	CONSTRAINT [FK_RolesxUsuario_usuario_id] FOREIGN KEY(rolesxusuario_id_usuario)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Usuario] (usuario_username),
	CONSTRAINT UN_RolesxUsuario_id UNIQUE(rolesxusuario_id_usuario,rolesxusuario_id_rol)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(
	funcionalidadxrol_id_rol INT NOT NULL,
	funcionalidadxrol_id_funcionalidad INT NOT NULL

	CONSTRAINT [PK_FuncionalidadxRol] PRIMARY KEY (
		[funcionalidadxrol_id_rol] ASC,
		[funcionalidadxrol_id_funcionalidad] ASC
	)
	
	CONSTRAINT [FK_FuncionalidadxRol_funcionalidad_id] FOREIGN KEY(funcionalidadxrol_id_funcionalidad)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Funcionalidad] (funcionalidad_id),
	CONSTRAINT [FK_FuncionalidadxRol_rol_id] FOREIGN KEY(funcionalidadxrol_id_rol)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Rol] (rol_id),
	CONSTRAINT UN_FuncionalidadxRol_id UNIQUE(funcionalidadxrol_id_rol,funcionalidadxrol_id_funcionalidad)

)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Localidad(
	localidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	localidad_nombre varchar(64) NOT NULL,
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio(
	domicilio_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	domicilio_id_localidad INT NOT NULL,
	domicilio_calle varchar(64) NOT NULL,
	domicilio_numero_piso INT NULL,
	domicilio_departamento char(20) NULL,
	domicilio_codigo_postal INT NOT NULL,
	
	CONSTRAINT [FK_Domicilio_localidad_id] FOREIGN KEY(domicilio_id_localidad)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Localidad] (localidad_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Cliente(
	cliente_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cliente_id_usuario nvarchar(64) NOT NULL,
	cliente_nombre varchar(64) NOT NULL,
	cliente_apellido varchar(64) NOT NULL,
	cliente_dni varchar(64) NOT NULL,
	cliente_mail varchar(64) NOT NULL,
	cliente_telefono varchar(64) NULL,
	cliente_habilitado BIT DEFAULT 1,
	cliente_eliminado BIT DEFAULT 0,
	cliente_fecha_nacimiento datetime NULL,
	cliente_id_domicilio INT NOT NULL,
	cliente_credito decimal(12, 2) DEFAULT 0
	
	CONSTRAINT [FK_Cliente_domicilio_id] FOREIGN KEY(cliente_id_domicilio)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Domicilio] (domicilio_id),
	CONSTRAINT [FK_Cliente_usuario_id] FOREIGN KEY(cliente_id_usuario)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Usuario] (usuario_username),
-- asumimos que si dos clientes tienen = nombre, apellido, dni, telefono, fecha nac y cliente_mail son "gemelos"
	CONSTRAINT UN_Cliente_unico UNIQUE (cliente_dni, cliente_mail, cliente_nombre, cliente_apellido, cliente_fecha_nacimiento, cliente_telefono)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Tarjeta(
	tarjeta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tarjeta_numero varchar(64) NOT NULL,
	tarjeta_fecha_venc datetime NOT NULL,
	tarjeta_cod_seguridad varchar(64) NOT NULL,
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Tipo_Pago(
	tipo_pago_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tipo_pago_nombre varchar(64) NOT NULL,
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito(
	carga_credito_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	carga_credito_id_cliente INT NOT NULL,
	carga_credito_id_tipo_pago INT NOT NULL,
	carga_credito_id_tarjeta INT,
	carga_credito_fecha datetime NOT NULL,
	carga_credito_monto decimal(12, 2) NOT NULL,
	
	CONSTRAINT [FK_Carga_Credito_tipo_pago_id] FOREIGN KEY(carga_credito_id_tipo_pago)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago] (tipo_pago_id),
	CONSTRAINT [FK_Carga_Credito_cliente_id] FOREIGN KEY(carga_credito_id_cliente)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Cliente] (cliente_id),
	CONSTRAINT [FK_Carga_Credito_tarjeta_id] FOREIGN KEY(carga_credito_id_tarjeta)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Tarjeta] (tarjeta_id),
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Rubro(
	rubro_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	rubro_descripcion varchar(64) NOT NULL
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor(
	proveedor_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	proveedor_id_usuario nvarchar(64) NOT NULL,
	proveedor_mail varchar(64) NULL,
	proveedor_telefono varchar(64) NULL,
	proveedor_cuit varchar(64) UNIQUE NOT NULL,
	proveedor_habilitado BIT DEFAULT 1,
	proveedor_eliminado BIT DEFAULT 0,
	proveedor_id_rubro INT NOT NULL,
	proveedor_id_domicilio INT NOT NULL,
	proveedor_nombre_contacto VARCHAR(64) NULL,
	proveedor_razon_social VARCHAR(64) UNIQUE NOT NULL
	
	CONSTRAINT [FK_proveedor_domicilio_id] FOREIGN KEY(proveedor_id_domicilio)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Domicilio] (domicilio_id),
	CONSTRAINT [FK_proveedor_usuario_id] FOREIGN KEY(proveedor_id_usuario)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Usuario] (usuario_username),
	CONSTRAINT [FK_proveedor_rubro_id] FOREIGN KEY(proveedor_id_rubro)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Rubro] (rubro_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Oferta(
	oferta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	oferta_descripcion nvarchar(255) NOT NULL,
	oferta_fecha_publicacion datetime NOT NULL,
	oferta_fecha_venc datetime NOT NULL,
	oferta_precio decimal(12, 2) NOT NULL,
	oferta_precio_lista decimal(12, 2) NOT NULL,
	oferta_cantidad int NOT NULL,
	oferta_restriccion_compra INT NOT NULL,
	oferta_id_proveedor INT NOT NULL,
	oferta_tiempo_validez_cupon INT NOT NULL, -- cambiar der
	
	CONSTRAINT [FK_proveedor_proveedor_id] FOREIGN KEY(oferta_id_proveedor)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Proveedor] (proveedor_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta(
	compra_oferta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	compra_oferta_id_cliente INT NOT NULL,
	compra_oferta_id_oferta INT NOT NULL,
	compra_oferta_cantidad INT NOT NULL,
	compra_oferta_fecha datetime NOT NULL,
	compra_oferta_codigo varchar(64) NOT NULL, -- todo: cambiar der
	
	CONSTRAINT [FK_compra_oferta_cliente_id] FOREIGN KEY(compra_oferta_id_cliente)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Cliente] (cliente_id),
	CONSTRAINT [FK_compra_oferta_oferta_id] FOREIGN KEY(compra_oferta_id_oferta)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Oferta] (oferta_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Cupon(
	cupon_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cupon_id_cliente INT NULL,
	cupon_id_compra_oferta INT NOT NULL,
	cupon_fecha_venc datetime NOT NULL,
	cupon_fecha_consumo datetime NULL,
	cupon_codigo varchar(64) NOT NULL, -- cambiar der
	
	CONSTRAINT [FK_cupon_cliente_id] FOREIGN KEY(cupon_id_cliente)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Cliente] (cliente_id),
	CONSTRAINT [FK_cupon_compra_oferta_id] FOREIGN KEY(cupon_id_compra_oferta)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Compra_Oferta] (compra_oferta_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Factura(
	factura_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	factura_importe decimal(12, 2) NOT NULL,
	factura_fecha_inicio datetime NOT NULL,
	factura_fecha_fin datetime NOT NULL,
	factura_id_proveedor INT NOT NULL,
	
	CONSTRAINT [FK_factura_proveedor_id] FOREIGN KEY(factura_id_proveedor)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Proveedor] (proveedor_id)
)

CREATE TABLE NO_LO_TESTEAMOS_NI_UN_POCO.Item(
	item_id_factura INT NOT NULL,
	item_id_compra_oferta INT NOT NULL

	CONSTRAINT [PK_FacturaxCompraOferta] PRIMARY KEY (
		[item_id_factura] ASC,
		[item_id_compra_oferta] ASC
	)
	
	CONSTRAINT [FK_FacturaxCompraOferta_factura_id] FOREIGN KEY(item_id_factura)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].Factura (factura_id),
	CONSTRAINT [FK_FacturaxCompraOferta_compra_oferta_id] FOREIGN KEY(item_id_compra_oferta)
		REFERENCES [NO_LO_TESTEAMOS_NI_UN_POCO].[Compra_Oferta] (compra_oferta_id),
	CONSTRAINT UN_FacturaxCompraOferta_id UNIQUE(item_id_compra_oferta, item_id_factura)
)


SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Funcionalidad] ON

-- funcionalidades
-- alta de usuario y login y cambio de pw todos tienen acceso
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(1, 'ABM Rol')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(2, 'ABM Cliente')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(3, 'ABM Proveedor')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(6, 'Baja y Modificacion Usuario')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(7, 'Carga de Credito')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(8, 'Confeccion y Publicacion de Ofertas')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(9, 'Compra de Ofertas')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(10, 'Entrega/Consumo de Ofertas')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(5, 'Facturacion a Proveedor')
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(4, 'Listado Estadistico')

SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Funcionalidad] OFF

SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Rol] ON

INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(1, 'administrativo', 1, 0)
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(2, 'proveedor', 1, 0)
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(3, 'cliente', 1, 0)
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(4, 'administrador general', 1, 0)

SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Rol] OFF

-- agrego tipos de pago
-- crear tipo de pago automatico y usarlo cuando se da de alta al cliente
SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago] ON

INSERT INTO [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (1, 'automatico')
INSERT INTO [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (2, 'efectivo')
INSERT INTO [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (3, 'credito')
INSERT INTO [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (4, 'debito')

SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].[Tipo_Pago] OFF

-- funcionalidades administrador
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 2);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 3);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 4);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 6);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 7);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 8);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 5);
-- funcionalidades proveedor
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (2, 8);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (2, 10);
-- funcionalidades cliente
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (3, 7);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (3, 9);
-- funcionalidades administrador general
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 1);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 2);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 3);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 4);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 5);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 6);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 7);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 8);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 9);
INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 10);

-- inserto las localidades
INSERT INTO [NO_LO_TESTEAMOS_NI_UN_POCO].[Localidad] (localidad_nombre) 
  SELECT distinct [gd_esquema].[Maestra].Cli_Ciudad from gd_esquema.[Maestra] where [gd_esquema].[Maestra].Cli_Ciudad  is not null
  UNION SELECT distinct [gd_esquema].[Maestra].Provee_Ciudad from gd_esquema.[Maestra] where [gd_esquema].[Maestra].Provee_Ciudad is not null 

-- inserto las direcciones
-- cod postal, departamento y numero piso no conozco, va 0
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Domicilio (domicilio_calle, domicilio_id_localidad, domicilio_codigo_postal, domicilio_departamento, domicilio_numero_piso)
select distinct d.Cli_Direccion, l.localidad_id, 0, 0, 0
from [gd_esquema].[Maestra] d
inner join [NO_LO_TESTEAMOS_NI_UN_POCO].Localidad l on l.localidad_nombre = d.Cli_Ciudad 
where d.Cli_Direccion is not null
union select distinct p.Provee_Dom, lo.localidad_id, 0, 0, 0
from [gd_esquema].[Maestra] p
inner join [NO_LO_TESTEAMOS_NI_UN_POCO].Localidad lo on lo.localidad_nombre = p.Provee_Ciudad
where p.Provee_Dom is not null

-- inserto los usuarios (solo clientes por ahora), por default el username es el dni
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario (usuario_username, usuario_password)
  select distinct m.Cli_Dni, LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), m.Cli_Dni)), 2)) from [gd_esquema].[Maestra] m where m.Cli_Dni is not null

-- inserto clientes
-- por default en el credito les pongo 0, despues en procedure lo calculo y pongo bien
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente (cliente_dni, cliente_id_usuario, cliente_nombre, cliente_apellido, cliente_mail, 
cliente_telefono, cliente_fecha_nacimiento, cliente_id_domicilio, cliente_credito)
select distinct m.Cli_Dni, u.usuario_username, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Mail, m.Cli_Telefono, m.Cli_Fecha_Nac, d.domicilio_id, 0
from [gd_esquema].[Maestra] m
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Localidad l on l.localidad_nombre = m.Cli_Ciudad
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Domicilio d on d.domicilio_calle = m.Cli_Direccion and l.localidad_id = d.domicilio_id_localidad
join [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u on u.usuario_username = m.Cli_Dni
 
-- inserto cargas
-- como no especifica tarjeta, pongo null
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Carga_Credito (
carga_credito_id_cliente,
carga_credito_id_tipo_pago,
carga_credito_id_tarjeta,
carga_credito_fecha,
carga_credito_monto)
select c.cliente_id, (case when m.Tipo_Pago_Desc = 'Crédito' then (select t.tipo_pago_id from [NO_LO_TESTEAMOS_NI_UN_POCO].Tipo_Pago t where t.tipo_pago_nombre = 'credito') 
when m.Tipo_Pago_Desc = 'Efectivo' then (select t.tipo_pago_id from [NO_LO_TESTEAMOS_NI_UN_POCO].Tipo_Pago t where t.tipo_pago_nombre = 'efectivo') 
else 0 end), NULL
, m.Carga_Fecha, m.Carga_Credito 
from [gd_esquema].Maestra m
join [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente c on c.cliente_dni = m.Cli_Dni
where m.Tipo_Pago_Desc is not null and m.Carga_Credito is not null and m.Carga_Fecha is not null

-- inserto a mis usuarios con el rol correspondiente
-- hasta aca solo cargue clientes, por lo tanto, todos tienen el rol de cliente
-- todo: mejorar esto e insertar clientes y provee juntos con union
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario)
select 3, u.usuario_username from [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u

-- inserto usuario de proveedores, por default el username es el cuit
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario (usuario_username, usuario_password)
  select distinct m.Provee_CUIT, LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), m.Provee_CUIT)), 2)) from [gd_esquema].[Maestra] m where m.Provee_CUIT is not null

-- inserto el usuario admin
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario (usuario_username, usuario_password) values ('admin', LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), 'w23e')), 2)))
-- le asigno el rol
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario) values (4, 'admin')

-- inserto rubros
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Rubro (rubro_descripcion)
select distinct m.Provee_Rubro
from [gd_esquema].[Maestra] m
where m.Provee_Rubro is not null

-- inserto proveedores
-- nombre de contacto y mail no tengo, va null
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor (proveedor_id_usuario, proveedor_razon_social, proveedor_telefono, proveedor_cuit, proveedor_id_rubro, proveedor_id_domicilio)
select distinct u.usuario_username, m.Provee_RS, m.Provee_Telefono, m.Provee_CUIT, r.rubro_id, d.domicilio_id
from [gd_esquema].[Maestra] m
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Localidad l on l.localidad_nombre = m.Provee_Ciudad
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Domicilio d on d.domicilio_calle = m.Provee_Dom and l.localidad_id = d.domicilio_id_localidad
join [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u on u.usuario_username = m.Provee_CUIT
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Rubro r on r.rubro_descripcion = Provee_Rubro
-- validar que no sea nulo

-- busco los proveedores y les asigno el rol
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario)
select 2, u.usuario_username from  [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u where u.usuario_username in (
	select distinct m.Provee_CUIT from [gd_esquema].[Maestra] m where m.Provee_CUIT is not null
)

-- inserto ofertas
-- cada oferta tiene mismo cuit, misma fechas y misma descripcion
-- el limite por cliente no lo sabemos -> ponemos = al stock, o sea no hay limite
-- la fecha de duracion del cupon no la sabemos -> ponemos 0
-- todo: averiguar si hay alguna compra que no se haya retirado
  insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Oferta(oferta_descripcion, oferta_fecha_publicacion, oferta_fecha_venc, oferta_precio, oferta_precio_lista, 
  oferta_restriccion_compra, oferta_cantidad, oferta_id_proveedor, oferta_tiempo_validez_cupon)
  select distinct m.Oferta_Descripcion, m.Oferta_Fecha, m.Oferta_Fecha_Venc, m.Oferta_Precio, m.Oferta_Precio_Ficticio, m.Oferta_Cantidad, m.Oferta_Cantidad, p.proveedor_id, 0
  FROM [gd_esquema].[Maestra] m
  join [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  where m.Oferta_Descripcion is not null

-- asumimos que usuario en la vieja db compro 1 oferta por columna
-- vimos que el codigo de oferta no era unico por cada compra
-- si hay duplicados le concatena -1, -2
-- tendriamos que usar el mismo codigo para el cupon y para la compra
 insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Compra_Oferta (compra_oferta_id_oferta, compra_oferta_fecha,
  compra_oferta_cantidad,
  compra_oferta_id_cliente, compra_oferta_codigo)
  select distinct 
  o.oferta_id,
  m.Oferta_Fecha_Compra, 1,
  c.cliente_id, m.Oferta_Codigo 
  from [gd_esquema].Maestra m 
  join [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  join [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente c on c.cliente_id_usuario = u.usuario_username
  join [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
  o.oferta_fecha_publicacion = m.Oferta_Fecha and o.oferta_fecha_venc = m.Oferta_Fecha_Venc and
  o.oferta_precio = m.Oferta_Precio and o.oferta_precio_lista = m.Oferta_Precio_Ficticio and
  o.oferta_cantidad = m.Oferta_Cantidad and o.oferta_id_proveedor = p.proveedor_id
  where m.Oferta_Fecha_Compra is not null;

-- aca tenemos que chequear el tema de duplicados
WITH CTE_Codigos (compra_oferta_codigo, compra_oferta_id, num_col)
AS
(
 SELECT compra_oferta_codigo, compra_oferta_id,
 ROW_NUMBER() OVER(PARTITION BY compra_oferta_codigo order by compra_oferta_codigo)
 FROM NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta
)
update CTE_Codigos set compra_oferta_codigo = concat(compra_oferta_codigo, '-1')
 where num_col > 1;
 
WITH CTE_Codigos (compra_oferta_codigo, compra_oferta_id, num_col)
AS
(
 SELECT compra_oferta_codigo, compra_oferta_id,
 ROW_NUMBER() OVER(PARTITION BY compra_oferta_codigo order by compra_oferta_codigo)
 FROM NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta
)
update CTE_Codigos set compra_oferta_codigo = concat(SUBSTRING(compra_oferta_codigo, 0, LEN(compra_oferta_codigo) - 1), '-2')
 where num_col > 1 


-- no tenemos fecha de vencimiento del cupon, ponemos la misma que la que fue consumido, total ya fue consumido 
-- procedure para canjear cupon que genera cupon cuando se hace compra_oferta
-- de esa manera nos garantizamos que sea unico.
-- si la fecha de consumo no es null, ya fue consumido
-- le ponemos el mismo codigo que a la compra
-- asumimos que el cliente que lo compro es el mismo que lo retiro
insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Cupon(cupon_fecha_venc, cupon_fecha_consumo, cupon_id_compra_oferta, cupon_id_cliente, cupon_codigo)
  select distinct  m.Oferta_Entregado_Fecha, m.Oferta_Entregado_Fecha,
  co.compra_oferta_id, 
  c.cliente_id, co.compra_oferta_codigo
  from [gd_esquema].Maestra m 
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente c on c.cliente_id_usuario = u.usuario_username
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  left join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
  o.oferta_fecha_publicacion = m.Oferta_Fecha and o.oferta_fecha_venc = m.Oferta_Fecha_Venc and
  o.oferta_precio = m.Oferta_Precio and o.oferta_precio_lista = m.Oferta_Precio_Ficticio and
  o.oferta_cantidad = m.Oferta_Cantidad and o.oferta_id_proveedor = p.proveedor_id
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Compra_Oferta co on 
	co.compra_oferta_id_oferta = o.oferta_id and co.compra_oferta_fecha = m.Oferta_Fecha_Compra
	and co.compra_oferta_id_cliente = c.cliente_id
  where m.Oferta_Entregado_Fecha is not null

-- migramos factura: numero es el id y el importe lo calculamos 
-- fecha de inicio es la fecha menor que aparece con el numero de factura
-- y la fecha final es la fecha de la factura
SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].Factura ON

-- validar que no se inserte la misma oferta mas de 1 vez
insert into  [NO_LO_TESTEAMOS_NI_UN_POCO].Factura(factura_id, factura_fecha_fin, factura_id_proveedor, factura_fecha_inicio, factura_importe)
select distinct m.Factura_Nro, m.Factura_Fecha, p.proveedor_id,
(select min(ma.Oferta_Fecha_Compra)
from  [gd_esquema].Maestra ma
where ma.Factura_Nro = m.Factura_Nro and ma.Factura_Fecha = m.Factura_Fecha
and ma.Oferta_Fecha_Compra is not null
) as 'fecha min', (select sum(mae.Oferta_Precio) from [gd_esquema].Maestra mae
where mae.Factura_Nro = m.Factura_Nro and mae.Factura_Fecha = m.Factura_Fecha
)
from  [gd_esquema].Maestra m
left join [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
where m.Factura_Fecha is not null and m.Factura_Nro is not null

SET IDENTITY_INSERT [NO_LO_TESTEAMOS_NI_UN_POCO].Factura OFF

-- inserto item-factura
  insert into [NO_LO_TESTEAMOS_NI_UN_POCO].Item(item_id_compra_oferta, item_id_factura)
  select distinct co.compra_oferta_id, f.factura_id
  from [gd_esquema].Maestra m 
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente c on c.cliente_id_usuario = u.usuario_username
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  left join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
  o.oferta_fecha_publicacion = m.Oferta_Fecha and o.oferta_fecha_venc = m.Oferta_Fecha_Venc and
  o.oferta_precio = m.Oferta_Precio and o.oferta_precio_lista = m.Oferta_Precio_Ficticio and
  o.oferta_cantidad = m.Oferta_Cantidad and o.oferta_id_proveedor = p.proveedor_id
  left join [NO_LO_TESTEAMOS_NI_UN_POCO].Compra_Oferta co on 
	co.compra_oferta_id_oferta = o.oferta_id and co.compra_oferta_fecha = m.Oferta_Fecha_Compra
	and co.compra_oferta_id_cliente = c.cliente_id
	left join [NO_LO_TESTEAMOS_NI_UN_POCO].Factura f on f.factura_id = m.Factura_Nro and f.factura_fecha_fin = m.Factura_Fecha
  where m.Factura_Nro is not null

-- calculo el saldo de cada cliente
declare @id_cliente INT
DECLARE cursor_cliente CURSOR FOR SELECT c.cliente_id FROM [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente c
OPEN cursor_cliente
FETCH cursor_cliente INTO @id_cliente
WHILE @@FETCH_STATUS = 0
    BEGIN
		UPDATE [NO_LO_TESTEAMOS_NI_UN_POCO].Cliente SET cliente_credito = isnull(
			(select sum(cc.carga_credito_monto) from [NO_LO_TESTEAMOS_NI_UN_POCO].Carga_Credito cc
			where cc.carga_credito_id_cliente = @id_cliente) -
			(select sum(co.compra_oferta_cantidad * o.oferta_precio) from [NO_LO_TESTEAMOS_NI_UN_POCO].Compra_Oferta co
			join [NO_LO_TESTEAMOS_NI_UN_POCO].Oferta o on o.oferta_id = co.compra_oferta_id_oferta
			where co.compra_oferta_id_cliente = @id_cliente
			)
		, 0)
		WHERE @id_cliente = cliente_id
    FETCH cursor_cliente INTO @id_cliente
END
CLOSE cursor_cliente
DEALLOCATE cursor_cliente

-- calculo stock de cada oferta

-- FIN DE MIGRACION
-- estadisticas

go
create function NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_porcentaje(@anio int, @semestre int)
returns table
as
	return (
		select top 5 p.proveedor_cuit, p.proveedor_razon_social,
		(
			select max( (o.oferta_precio_lista - o.oferta_precio)/o.oferta_precio_lista*100 ) from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta o
			where o.oferta_id_proveedor = p.proveedor_id 
			and year(o.oferta_fecha_publicacion) = @anio
			and 1 =
			(case when @semestre = 1 and month(o.oferta_fecha_publicacion) in (1,2,3,4,5,6) then 1 when @semestre = 2 and month(o.oferta_fecha_publicacion) in (7,8,9,10,11,12) then 1 else 0 end)
			group by o.oferta_id
		) as 'descuento'
		from [NO_LO_TESTEAMOS_NI_UN_POCO].Proveedor p 
		order by 'descuento' desc
	)
go

create function NO_LO_TESTEAMOS_NI_UN_POCO.top_5_mayor_facturacion(@anio int, @semestre int)
returns table
as
	return (
		select top 5 p.proveedor_cuit, p.proveedor_razon_social, isnull(p.proveedor_nombre_contacto, '') as 'nombre_contacto',
		isnull((
			select sum(f.factura_importe) from NO_LO_TESTEAMOS_NI_UN_POCO.Factura f
			where f.factura_id_proveedor = p.proveedor_id 
			and year(f.factura_fecha_inicio) = @anio
			and year(f.factura_fecha_fin) = @anio
			and 1 =
			(case when @semestre = 1 and month(f.factura_fecha_inicio) in (1,2,3,4,5,6) and month(f.factura_fecha_fin) in (1,2,3,4,5,6) then 1 when @semestre = 2 and month(f.factura_fecha_inicio) in (7,8,9,10,11,12) and month(f.factura_fecha_fin) in (7,8,9,10,11,12) then 1 else 0 end)
			group by f.factura_id_proveedor
		), 0) as 'facturacion'
		from NO_LO_TESTEAMOS_NI_UN_POCO.Proveedor p
		order by 'facturacion' desc
	)
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.cliente_comprar_oferta(@id_cliente int, @id_oferta int, @fecha datetime, @cantidad int, @codigo varchar(64) output)
as
begin transaction
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cliente where cliente_id = @id_cliente and cliente_habilitado = 0)
		begin
			rollback
				raiserror('El cliente está deshabilitado y no puede realizar compras.', 16, 1)
			return
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cliente where cliente_credito < (select oferta_precio from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta where oferta_id = @id_oferta) and cliente_id = @id_cliente)
		begin
			rollback
				raiserror('El cliente no posee crédito suficiente.', 16, 1)
			return
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta where oferta_id = @id_oferta and @cantidad > oferta_restriccion_compra)
		begin
			rollback
				raiserror('La cantidad supera la restricción por cliente.', 16, 1)
			return
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta where oferta_id = @id_oferta and oferta_cantidad < @cantidad)
		begin
			rollback
				raiserror('No hay suficiente cantidad en stock.', 16, 1)
			return
		end
	-- genero codigo compra
	DECLARE @id_nuevo VARCHAR(200)
	SELECT @id_nuevo = NEWID()

	set @codigo = (SELECT CAST((ABS(CHECKSUM(@id_nuevo))%10) AS VARCHAR(1)) + 
	CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
	CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
	LEFT(@id_nuevo,7))

	-- regenero codigo hasta que sea unico
	while @codigo in (select compra_oferta_codigo from NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta)
		begin
			SELECT @id_nuevo = NEWID()

			set @codigo = (SELECT CAST((ABS(CHECKSUM(@id_nuevo))%10) AS VARCHAR(1)) + 
			CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
			CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
			LEFT(@id_nuevo,7))
		end

	-- genero codigo cupon
	declare @codigo_cup varchar(64)
	SELECT @id_nuevo = NEWID()

	set @codigo_cup = (SELECT CAST((ABS(CHECKSUM(@id_nuevo))%10) AS VARCHAR(1)) + 
	CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
	CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
	LEFT(@id_nuevo,7))

	-- regenero codigo_cup hasta que sea unico
	while @codigo_cup in (select cupon_codigo from NO_LO_TESTEAMOS_NI_UN_POCO.Cupon)
		begin
			SELECT @id_nuevo = NEWID()

			set @codigo_cup = (SELECT CAST((ABS(CHECKSUM(@id_nuevo))%10) AS VARCHAR(1)) + 
			CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
			CHAR(ASCII('A')+(ABS(CHECKSUM(@id_nuevo))%25)) +
			LEFT(@id_nuevo,7))
		end
	
	insert into NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta(compra_oferta_codigo, compra_oferta_fecha, compra_oferta_cantidad, compra_oferta_id_cliente, compra_oferta_id_oferta) values (@codigo, @fecha, @cantidad, @id_cliente, @id_oferta)
	update NO_LO_TESTEAMOS_NI_UN_POCO.Cliente set cliente_credito = (cliente_credito - (select oferta_precio from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta where oferta_id = @id_oferta)) where cliente_id = @id_cliente
	update NO_LO_TESTEAMOS_NI_UN_POCO.Oferta set oferta_cantidad = oferta_cantidad - 1 where oferta_id = @id_oferta
	insert into NO_LO_TESTEAMOS_NI_UN_POCO.Cupon (cupon_codigo, cupon_fecha_venc, cupon_id_compra_oferta) 
	values (@codigo_cup, DATEADD(DAY, (select oferta_tiempo_validez_cupon from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta where oferta_id = @id_oferta), @fecha), (select compra_oferta_id from NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta where compra_oferta_codigo = @codigo and compra_oferta_id_cliente = @id_cliente and compra_oferta_id_oferta = @id_oferta))
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.proveedor_entrega_oferta(@fecha_consumo datetime, @id_proveedor int, @id_cliente int, @codigo_cup varchar(64))
-- me van a pasar el id del cupon?
as
begin transaction
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cupon
	join NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta on compra_oferta_id = cupon_id_compra_oferta
	join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on compra_oferta_id_oferta = oferta_id
	where cupon_codigo = @codigo_cup and oferta_id_proveedor <> @id_proveedor)
		begin
			-- proveedor no es dueño de la oferta
			rollback
				raiserror('No se puede canjear el cupón porque el proveedor no corresponde con el proveedor de la oferta.', 16, 1)
			return
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cupon
	join NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta on compra_oferta_id = cupon_id_compra_oferta
	join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on compra_oferta_id_oferta = oferta_id
	where cupon_codigo = @codigo_cup and oferta_id_proveedor = @id_proveedor and cupon_fecha_consumo is not null)
		begin
			-- cupón ya fue consumido
			rollback
				raiserror('No se puede canjear el cupón porque ya fue canjeado.', 16, 1)
			return
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cupon
	join NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta on compra_oferta_id = cupon_id_compra_oferta
	join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on compra_oferta_id_oferta = oferta_id
	where cupon_codigo = @codigo_cup and oferta_id_proveedor = @id_proveedor and cupon_fecha_venc < @fecha_consumo)
		begin
			-- cupón vencido
			rollback
				raiserror('No se puede canjear el cupón porque venció.', 16, 1)
			return
		end
	update NO_LO_TESTEAMOS_NI_UN_POCO.Cupon set cupon_fecha_consumo = @fecha_consumo, cupon_id_cliente = @id_cliente where cupon_codigo = @codigo_cup
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.facturacion(@fecha_inicio datetime, @fecha_fin datetime, @id_proveedor int, @id_factura int output)
as
begin transaction
	insert into NO_LO_TESTEAMOS_NI_UN_POCO.Factura(factura_id_proveedor, factura_importe, factura_fecha_inicio, factura_fecha_fin) values (@id_proveedor, 
		(select sum(compra_oferta_cantidad * oferta_precio) from NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta
		join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on oferta_id = compra_oferta_id_oferta
		where compra_oferta_fecha >= @fecha_inicio and compra_oferta_fecha <= @fecha_fin
		and oferta_id_proveedor = @id_proveedor),
		@fecha_inicio, @fecha_fin
	)
	set @id_factura = (select IDENT_CURRENT('NO_LO_TESTEAMOS_NI_UN_POCO.Factura'))
	insert into NO_LO_TESTEAMOS_NI_UN_POCO.Item(item_id_factura, item_id_compra_oferta)
	select @id_factura, compra_oferta_id from NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta
	join NO_LO_TESTEAMOS_NI_UN_POCO.Oferta on oferta_id = compra_oferta_id_oferta
	where compra_oferta_fecha >= @fecha_inicio and compra_oferta_fecha <= @fecha_fin
	and oferta_id_proveedor = @id_proveedor
commit
go

create function NO_LO_TESTEAMOS_NI_UN_POCO.obtener_ofertas_factura(@id_factura int)
returns table
as
	return (
		select oferta_descripcion, oferta_fecha_publicacion, oferta_fecha_venc, oferta_precio, oferta_precio_lista, oferta_cantidad
		from NO_LO_TESTEAMOS_NI_UN_POCO.Oferta
		join NO_LO_TESTEAMOS_NI_UN_POCO.Compra_Oferta on compra_oferta_id_oferta = oferta_id
		join NO_LO_TESTEAMOS_NI_UN_POCO.Item on compra_oferta_id = item_id_compra_oferta
		join NO_LO_TESTEAMOS_NI_UN_POCO.Factura on factura_id = item_id_factura
		where factura_id = @id_factura
	)
go

/* hecho en app
create procedure usuario_login(@username nvarchar(64), @password nvarchar(500))
as
begin transaction
	if not exists(select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Usuario where usuario_username = @username and usuario_password = LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), @password)), 2)))
		begin
			update NO_LO_TESTEAMOS_NI_UN_POCO.Usuario set usuario_intentos_fallidos_login = usuario_intentos_fallidos_login + 1
			where usuario_username = @username
				if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Usuario where usuario_username = @username and usuario_intentos_fallidos_login > 3)
					begin
						update NO_LO_TESTEAMOS_NI_UN_POCO.Usuario set usuario_habilitado = 0
						where usuario_username = @username
					end
			raiserror('Usuario o contraseña inválidos', 16, 1)
			return
		end
	else
		begin
		if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Usuario where usuario_username = @username and usuario_habilitado = 0)
			begin
				raiserror('Usuario inhabilitado, no puede iniciar sesión', 16, 1)
				return
			end
		else
			begin
				if exists (select 1 from d_esquema.Usuario where usuario_username = @username and usuario_eliminado = 1)
					begin
						raiserror('El usuario está eliminado', 16, 1)
						return
					end
				-- success
				update NO_LO_TESTEAMOS_NI_UN_POCO.Usuario set usuario_intentos_fallidos_login = 0
				where usuario_username = @username
			end
		end
commit
go


-- funcionalidades
create procedure NO_LO_TESTEAMOS_NI_UN_POCO.rol_cambiar_nombre (@id_rol int, @nombre varchar(64))
as
begin transaction
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Rol where @nombre = rol_nombre and @id_rol <> rol_id)
	begin
		rollback
			raiserror('No puede agregar un nombre de rol existente.', 16, 1)
		return
	end	
	
	update NO_LO_TESTEAMOS_NI_UN_POCO.Rol
	set rol_nombre = @nombre
	where rol_id = @id_rol
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.rol_agregar_funcionalidad (@id_rol int, @id_func int)
as
begin transaction
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol where @id_func = funcionalidadxrol_id_funcionalidad and @id_rol = funcionalidadxrol_id_rol)
	begin
		rollback
			raiserror('El rol ya tiene esa funcionalidad.', 16, 1)
		return
	end	
	
	insert into NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol(funcionalidadxrol_id_funcionalidad, funcionalidadxrol_id_rol)
	values(@id_func, @id_rol)
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.rol_quitar_funcionalidad (@id_rol int, @id_func int)
as
begin transaction
	if not exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol where @id_func = funcionalidadxrol_id_funcionalidad and @id_rol = funcionalidadxrol_id_rol)
	begin
		rollback
			raiserror('No puede sacar una funcionalidad que no tiene', 16, 1)
		return
	end	
	
	delete from NO_LO_TESTEAMOS_NI_UN_POCO.FuncionalidadxRol
	where funcionalidadxrol_id_rol = @id_rol and funcionalidadxrol_id_funcionalidad = @id_func
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.rol_inhabilitar(@id_rol int)
as
begin transaction
	update NO_LO_TESTEAMOS_NI_UN_POCO.Rol set rol_habilitado = 0 where @id_rol = rol_id
	delete from NO_LO_TESTEAMOS_NI_UN_POCO.RolesxUsuario where @id_rol = rolesxusuario_id_rol
commit
go

create procedure usuario_modificar_password(@username nvarchar(64), @password nvarchar(500))
as
begin transaction
	update NO_LO_TESTEAMOS_NI_UN_POCO.Usuario set usuario_password = LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), @password)), 2))
	where usuario_username = @username
commit
go

create procedure NO_LO_TESTEAMOS_NI_UN_POCO.cliente_agregar(@nombre varchar(64), @apellido nvarchar(64), @dni nvarchar(64), @mail nvarchar(64), @telefono nvarchar(64), @calle nvarchar(64), @piso int, @departamento char(20), @localidad nvarchar(64), @codigo_postal int, @fech_nac datetime, @id_usuario int)
as
begin transaction
	-- validaciones
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cliente where @dni = cliente_dni)
		begin
			raiserror('Ya existe un cliente con ese dni', 16, 1)
			return
		end
	else
		begin
			if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Cliente where @nombre = cliente_nombre and @apellido = cliente_apellido and @mail = cliente_mail and @telefono = cliente_telefono and @fech_nac = cliente_fecha_nacimiento)
				begin
					raiserror('Ya existe un cliente con mismo nombre, apellido, mail, telefono y fecha de nacimiento', 16, 1)
					return
				end
		end
	if exists (select 1 from NO_LO_TESTEAMOS_NI_UN_POCO.Domicilio 
	join NO_LO_TESTEAMOS_NI_UN_POCO.Localidad on localidad_id = domicilio_id_localidad
	where @calle = domicilio_calle and @piso = domicilio_numero_piso and @departamento = domicilio_departamento and @codigo_postal = domicilio_codigo_postal and localidad_nombre = @localidad)
		begin
			print('aaa')
		end
	-- ver si existe la direccion, usar el id si existe, si no crearla
	-- si no existe la localidad, crearla
	-- despues creo usuario y le agrego lo 200 de regalo
commit
go

create function buscar_clientes(@nombre varchar(64), @apellido varchar(64), @dni varchar(64), @email varchar(64))
return table
as
	return (
		select 
	)
end
go*/
/*
Nombre (texto libre)
 Apellido (texto libre)
 DNI (texto libre exacto)
 Email (texto libre)

*/

-- cambiar todos los nvarchar por varchar

-- como validamos lo del username? tenemos lo de unique, podemos usar directamente esa validacion en la app?

-- HACER TRIGGER CUANDO CLIENTE CARGA CREDITO O COMPRA ALGO, ACTUALIZAR EL CLIENTE_CREDITO o usar procedure

-- procedure para comprar que valide que el cliente no compre mas ofertas de las que puede

-- limite de compra es por cliente: https://groups.google.com/forum/#!topic/gestiondedatos/05dXYNKpbe0

-- crear procedures para cosas que requiran validacion ej: cambiar cupon

-- funcion para buscar clientes

--La eliminación del rol implica una baja lógica del mismo. El rol debe poder inhabilitarse. No permitido la asignación de un rol inhabilitado a un usuario, por ende, se le debe quitar el rol inhabilitado a todos aquellos usuarios que lo posean.

/*

todo: El alumno deberá determinar un procedimiento para evitar la generación de clientes “gemelos” (distinto nombre de usuario, pero igual datos identificatorios según se justifique en la estrategia de resolución). X
Toda creación de cliente nuevo, implica una carga de dinero de bienvenida de $200 X
validar que usuario que compra ofertas o carga credito este habiltiado X OFERTAS ES DE NICO
no pueden existir 2 proveedores con la misma razón social y cuit. NICO
Un proveedor inhabilitado no podrá armar ofertas NICO
ofertas: fecha debe ser mayor o igual a la fecha actual del sistema. NICO
se deberá validar que la adquisición no supere la cantidad máxima de ofertas permitida por usuario
un cupón no puede ser canjeado más de una vez, si el cupón se venció tampoco podrá ser canjeado TODO
crear usuario de cada tipo

-- cuando se crea un cliente se le debitan $200:
-- todo: usar un stored procedure que sea crear cliente y ahi debitar los 200 pe
USE GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [NO_LO_TESTEAMOS_NI_UN_POCO].[alta_cliente]
ON [NO_LO_TESTEAMOS_NI_UN_POCO].[Cliente]
AFTER INSERT
AS
BEGIN TRANSACTION
	declare @id_cliente_nuevo varchar(64)
	SELECT @id_cliente_nuevo = c.cliente_id FROM Cliente c INNER JOIN inserted i 
	ON i.cliente_apellido = c.cliente_apellido
	AND i.cliente_dni = c.cliente_dni
	AND i.cliente_fecha_nacimiento = c.cliente_fecha_nacimiento
	AND i.cliente_nombre = c.cliente_nombre
	AND i.cliente_mail = c.cliente_mail
	-- usar cursores?
	INSERT INTO NO_LO_TESTEAMOS_NI_UN_POCO.Carga_Credito(carga_credito_id_cliente, carga_credito_monto, carga_credito_id_tipo_pago, carga_credito_fecha) 
	VALUES (@id_cliente_nuevo, 200, 1, GETDATE()) -- todo: hay que usar la fecha del archivo de config
COMMIT TRANSACTION
GO
-- validar que cliente que carga credito esté habilitado
CREATE TRIGGER [NO_LO_TESTEAMOS_NI_UN_POCO].validez_cliente_credito
ON [NO_LO_TESTEAMOS_NI_UN_POCO].Carga_Credito
AFTER INSERT, UPDATE
AS
BEGIN TRANSACTION
	IF EXISTS(SELECT 1 FROM inserted i
		WHERE EXISTS(SELECT 1 FROM Cliente c WHERE c.cliente_id = i.carga_credito_id_cliente AND c.cliente_habilitado = 0))
		BEGIN
			RAISERROR ( 'Un Cliente inhabilitado no puede cargar credito', 1, 1)
			ROLLBACK
			RETURN
		END
COMMIT TRANSACTION
GO
*/