-- TODO: cambiar nombre de esquema

-- todo: ver cual select tira: Warning: Null value is eliminated by an aggregate or other SET operation.

-- borro las tablas si existen
USE  [GD2C2019]
go

IF OBJECT_ID('gd_esquema.Carga_Credito') IS NOT NULL
DROP TABLE gd_esquema.Carga_Credito

IF OBJECT_ID('gd_esquema.Tipo_Pago') IS NOT NULL
DROP TABLE gd_esquema.Tipo_Pago

IF OBJECT_ID('gd_esquema.Tarjeta') IS NOT NULL
DROP TABLE gd_esquema.Tarjeta

IF OBJECT_ID('gd_esquema.Cupon') IS NOT NULL
DROP TABLE gd_esquema.Cupon

IF OBJECT_ID('gd_esquema.Item') IS NOT NULL
DROP TABLE gd_esquema.Item

IF OBJECT_ID('gd_esquema.Factura') IS NOT NULL
DROP TABLE gd_esquema.Factura

IF OBJECT_ID('gd_esquema.Compra_Oferta') IS NOT NULL
DROP TABLE gd_esquema.Compra_Oferta

IF OBJECT_ID('gd_esquema.Oferta') IS NOT NULL
DROP TABLE gd_esquema.Oferta

IF OBJECT_ID('gd_esquema.Proveedor') IS NOT NULL
DROP TABLE gd_esquema.Proveedor

IF OBJECT_ID('gd_esquema.Rubro') IS NOT NULL
DROP TABLE gd_esquema.Rubro

IF OBJECT_ID('gd_esquema.Cliente') IS NOT NULL
DROP TABLE gd_esquema.Cliente

IF OBJECT_ID('gd_esquema.Domicilio') IS NOT NULL
DROP TABLE gd_esquema.Domicilio

IF OBJECT_ID('gd_esquema.Localidad') IS NOT NULL
DROP TABLE gd_esquema.Localidad

IF OBJECT_ID('gd_esquema.FuncionalidadxRol') IS NOT NULL
DROP TABLE gd_esquema.FuncionalidadxRol

IF OBJECT_ID('gd_esquema.RolesxUsuario') IS NOT NULL
DROP TABLE gd_esquema.RolesxUsuario

IF OBJECT_ID('gd_esquema.Rol') IS NOT NULL
DROP TABLE gd_esquema.Rol

IF OBJECT_ID('gd_esquema.Funcionalidad') IS NOT NULL
DROP TABLE gd_esquema.Funcionalidad

IF OBJECT_ID('gd_esquema.Usuario') IS NOT NULL
DROP TABLE gd_esquema.Usuario

IF OBJECT_ID('gd_esquema.top_5_mayor_porcentaje') IS NOT NULL
DROP FUNCTION [gd_esquema].[top_5_mayor_porcentaje]

CREATE TABLE gd_esquema.Usuario(
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

CREATE TABLE gd_esquema.Rol(
	rol_id INT identity(1 ,1) NOT NULL PRIMARY KEY,
	rol_nombre varchar(64) NOT NULL,
	rol_habilitado BIT DEFAULT 1,
	rol_eliminado BIT DEFAULT 0,
)

CREATE TABLE gd_esquema.Funcionalidad(
	funcionalidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	funcionalidad_descripcion varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.RolesxUsuario(
	rolesxusuario_id_usuario nvarchar(64) NOT NULL,
	rolesxusuario_id_rol INT NOT NULL

	CONSTRAINT [PK_RolesxUsuario] PRIMARY KEY (
		[rolesxusuario_id_usuario] ASC,
		[rolesxusuario_id_rol] ASC
	)
	
	CONSTRAINT [FK_RolesxUsuario_rol_id] FOREIGN KEY(rolesxusuario_id_rol)
		REFERENCES [gd_esquema].Rol (rol_id),
	CONSTRAINT [FK_RolesxUsuario_usuario_id] FOREIGN KEY(rolesxusuario_id_usuario)
		REFERENCES [gd_esquema].[Usuario] (usuario_username),
	CONSTRAINT UN_RolesxUsuario_id UNIQUE(rolesxusuario_id_usuario,rolesxusuario_id_rol)
)

CREATE TABLE gd_esquema.FuncionalidadxRol(
	funcionalidadxrol_id_rol INT NOT NULL,
	funcionalidadxrol_id_funcionalidad INT NOT NULL

	CONSTRAINT [PK_FuncionalidadxRol] PRIMARY KEY (
		[funcionalidadxrol_id_rol] ASC,
		[funcionalidadxrol_id_funcionalidad] ASC
	)
	
	CONSTRAINT [FK_FuncionalidadxRol_funcionalidad_id] FOREIGN KEY(funcionalidadxrol_id_funcionalidad)
		REFERENCES [gd_esquema].[Funcionalidad] (funcionalidad_id),
	CONSTRAINT [FK_FuncionalidadxRol_rol_id] FOREIGN KEY(funcionalidadxrol_id_rol)
		REFERENCES [gd_esquema].[Rol] (rol_id),
	CONSTRAINT UN_FuncionalidadxRol_id UNIQUE(funcionalidadxrol_id_rol,funcionalidadxrol_id_funcionalidad)

)

CREATE TABLE gd_esquema.Localidad(
	localidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	localidad_nombre varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Domicilio(
	domicilio_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	domicilio_id_localidad INT NOT NULL,
	domicilio_calle varchar(64) NOT NULL,
	domicilio_numero_piso INT NULL,
	domicilio_departamento char(20) NULL,
	domicilio_codigo_postal INT NOT NULL,
	
	CONSTRAINT [FK_Domicilio_localidad_id] FOREIGN KEY(domicilio_id_localidad)
		REFERENCES [gd_esquema].[Localidad] (localidad_id)
)

CREATE TABLE gd_esquema.Cliente(
	cliente_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cliente_id_usuario nvarchar(64) NOT NULL,
	cliente_nombre varchar(64) NOT NULL,
	cliente_apellido varchar(64) NOT NULL,
	cliente_dni varchar(64) NOT NULL,
	cliente_mail varchar(64) NOT NULL,
	cliente_telefono varchar(64) NULL,
	cliente_habilitado BIT DEFAULT 1,
	cliente_fecha_nacimiento datetime NULL,
	cliente_id_domicilio INT NOT NULL,
	cliente_credito decimal(12, 2) DEFAULT 0
	
	CONSTRAINT [FK_Cliente_domicilio_id] FOREIGN KEY(cliente_id_domicilio)
		REFERENCES [gd_esquema].[Domicilio] (domicilio_id),
	CONSTRAINT [FK_Cliente_usuario_id] FOREIGN KEY(cliente_id_usuario)
		REFERENCES [gd_esquema].[Usuario] (usuario_username),
-- asumimos que si dos clientes tienen = nombre, apellido, dni, fecha nac y cliente_mail son "gemelos"
	CONSTRAINT UN_Cliente_unico UNIQUE (cliente_dni, cliente_mail, cliente_nombre, cliente_apellido, cliente_fecha_nacimiento)
)

CREATE TABLE gd_esquema.Tarjeta(
	tarjeta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tarjeta_numero varchar(64) NOT NULL,
	tarjeta_fecha_venc datetime NOT NULL,
	tarjeta_cod_seguridad varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Tipo_Pago(
	tipo_pago_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	tipo_pago_nombre varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.Carga_Credito(
	carga_credito_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	carga_credito_id_cliente INT NOT NULL,
	carga_credito_id_tipo_pago INT NOT NULL,
	carga_credito_id_tarjeta INT,
	carga_credito_fecha datetime NOT NULL,
	carga_credito_monto decimal(12, 2) NOT NULL,
	
	CONSTRAINT [FK_Carga_Credito_tipo_pago_id] FOREIGN KEY(carga_credito_id_tipo_pago)
		REFERENCES [gd_esquema].[Tipo_Pago] (tipo_pago_id),
	CONSTRAINT [FK_Carga_Credito_cliente_id] FOREIGN KEY(carga_credito_id_cliente)
		REFERENCES [gd_esquema].[Cliente] (cliente_id),
	CONSTRAINT [FK_Carga_Credito_tarjeta_id] FOREIGN KEY(carga_credito_id_tarjeta)
		REFERENCES [gd_esquema].[Tarjeta] (tarjeta_id),
)

CREATE TABLE gd_esquema.Rubro(
	rubro_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	rubro_descripcion varchar(64) NOT NULL
)

CREATE TABLE gd_esquema.Proveedor(
	proveedor_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	proveedor_id_usuario nvarchar(64) NOT NULL,
	proveedor_mail varchar(64) NULL,
	proveedor_telefono varchar(64) NULL,
	proveedor_cuit varchar(64) UNIQUE NOT NULL,
	proveedor_habilitado BIT DEFAULT 1,
	proveedor_id_rubro INT NOT NULL,
	proveedor_id_domicilio INT NOT NULL,
	proveedor_nombre_contacto VARCHAR(64) NULL,
	proveedor_razon_social VARCHAR(64) UNIQUE NOT NULL
	
	CONSTRAINT [FK_proveedor_domicilio_id] FOREIGN KEY(proveedor_id_domicilio)
		REFERENCES [gd_esquema].[Domicilio] (domicilio_id),
	CONSTRAINT [FK_proveedor_usuario_id] FOREIGN KEY(proveedor_id_usuario)
		REFERENCES [gd_esquema].[Usuario] (usuario_username),
	CONSTRAINT [FK_proveedor_rubro_id] FOREIGN KEY(proveedor_id_rubro)
		REFERENCES [gd_esquema].[Rubro] (rubro_id)
)

CREATE TABLE gd_esquema.Oferta(
	oferta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	oferta_descripcion nvarchar(255) NOT NULL,
	oferta_fecha_publicacion datetime NOT NULL,
	oferta_fecha_venc datetime NOT NULL,
	oferta_precio decimal(12, 2) NOT NULL,
	oferta_precio_lista decimal(12, 2) NOT NULL,
	oferta_cantidad int NOT NULL,
	oferta_restriccion_compra INT NOT NULL,
	oferta_id_proveedor INT NOT NULL,
	
	CONSTRAINT [FK_proveedor_proveedor_id] FOREIGN KEY(oferta_id_proveedor)
		REFERENCES [gd_esquema].[Proveedor] (proveedor_id)
)

CREATE TABLE gd_esquema.Compra_Oferta(
	compra_oferta_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	compra_oferta_id_cliente INT NOT NULL,
	compra_oferta_id_oferta INT NOT NULL,
	compra_oferta_cantidad INT NOT NULL,
	compra_oferta_fecha datetime NOT NULL,
	compra_oferta_codigo varchar(64) NOT NULL, -- todo: cambiar der
	
	CONSTRAINT [FK_compra_oferta_cliente_id] FOREIGN KEY(compra_oferta_id_cliente)
		REFERENCES [gd_esquema].[Cliente] (cliente_id),
	CONSTRAINT [FK_compra_oferta_oferta_id] FOREIGN KEY(compra_oferta_id_oferta)
		REFERENCES [gd_esquema].[Oferta] (oferta_id)
)

CREATE TABLE gd_esquema.Cupon(
	cupon_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	cupon_id_cliente INT NOT NULL,
	cupon_id_compra_oferta INT NOT NULL,
	cupon_fecha_venc datetime NOT NULL,
	cupon_fecha_consumo datetime NOT NULL,
	cupon_codigo varchar(64) NOT NULL, -- cambiar der
	
	CONSTRAINT [FK_cupon_cliente_id] FOREIGN KEY(cupon_id_cliente)
		REFERENCES [gd_esquema].[Cliente] (cliente_id),
	CONSTRAINT [FK_cupon_compra_oferta_id] FOREIGN KEY(cupon_id_compra_oferta)
		REFERENCES [gd_esquema].[Compra_Oferta] (compra_oferta_id)
)

CREATE TABLE gd_esquema.Factura(
	factura_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	factura_importe decimal(12, 2) NOT NULL,
	factura_fecha_inicio datetime NOT NULL,
	factura_fecha_fin datetime NOT NULL,
	factura_id_proveedor INT NOT NULL,
	
	CONSTRAINT [FK_factura_proveedor_id] FOREIGN KEY(factura_id_proveedor)
		REFERENCES [gd_esquema].[Proveedor] (proveedor_id)
)

CREATE TABLE gd_esquema.Item(
	item_id_factura INT NOT NULL,
	item_id_compra_oferta INT NOT NULL

	CONSTRAINT [PK_FacturaxCompraOferta] PRIMARY KEY (
		[item_id_factura] ASC,
		[item_id_compra_oferta] ASC
	)
	
	CONSTRAINT [FK_FacturaxCompraOferta_factura_id] FOREIGN KEY(item_id_factura)
		REFERENCES [gd_esquema].Factura (factura_id),
	CONSTRAINT [FK_FacturaxCompraOferta_compra_oferta_id] FOREIGN KEY(item_id_compra_oferta)
		REFERENCES [gd_esquema].[Compra_Oferta] (compra_oferta_id),
	CONSTRAINT UN_FacturaxCompraOferta_id UNIQUE(item_id_compra_oferta, item_id_factura)
)


SET IDENTITY_INSERT [gd_esquema].[Funcionalidad] ON

-- funcionalidades
-- alta de usuario y login y cambio de pw todos tienen acceso
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(1, 'ABM Rol')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(2, 'ABM Cliente')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(3, 'ABM Proveedor')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(5, 'Modificacion Usuario')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(6, 'Baja Usuario')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(7, 'Carga de Credito')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(8, 'Confeccion y Publicacion de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(9, 'Compra de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(10, 'Entrega/Consumo de Ofertas')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(11, 'Facturacion a Proveedor')
INSERT INTO gd_esquema.Funcionalidad(funcionalidad_id, funcionalidad_descripcion)
Values(4, 'Listado Estadistico')

SET IDENTITY_INSERT [gd_esquema].[Funcionalidad] OFF

SET IDENTITY_INSERT [gd_esquema].[Rol] ON

INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(1, 'administrativo', 1, 0)
INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(2, 'proveedor', 1, 0)
INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(3, 'cliente', 1, 0)
INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(4, 'administrador general', 1, 0)

SET IDENTITY_INSERT [gd_esquema].[Rol] OFF

-- agrego tipos de pago
-- crear tipo de pago automatico y usarlo cuando se da de alta al cliente
SET IDENTITY_INSERT [gd_esquema].[Tipo_Pago] ON

INSERT INTO [gd_esquema].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (1, 'automatico')
INSERT INTO [gd_esquema].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (2, 'efectivo')
INSERT INTO [gd_esquema].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (3, 'credito')
INSERT INTO [gd_esquema].[Tipo_Pago](tipo_pago_id, tipo_pago_nombre) VALUES (4, 'debito')

SET IDENTITY_INSERT [gd_esquema].[Tipo_Pago] OFF

-- funcionalidades administrador
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 1);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 2);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 3);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 5);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 6);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 7); -- esta bien?
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 8);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (1, 11);
-- funcionalidades proveedor
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (2, 5);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (2, 8);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (2, 10);
-- funcionalidades cliente
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (3, 5);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (3, 7);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (3, 9);
-- funcionalidades administrador general
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 1);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 2);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 3);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 4);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 5);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 6);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 7);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 8);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 9);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 10);
INSERT INTO gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_rol, funcionalidadxrol_id_funcionalidad) VALUES (4, 11);

-- inserto las localidades
INSERT INTO [gd_esquema].[Localidad] (localidad_nombre) 
  SELECT distinct [gd_esquema].[Maestra].Cli_Ciudad from [gd_esquema].[Maestra] where [gd_esquema].[Maestra].Cli_Ciudad  is not null
  UNION SELECT distinct [gd_esquema].[Maestra].Provee_Ciudad from [gd_esquema].[Maestra] where [gd_esquema].[Maestra].Provee_Ciudad is not null 

-- inserto las direcciones
-- cod postal, departamento y numero piso no conozco, va 0
insert into [gd_esquema].Domicilio (domicilio_calle, domicilio_id_localidad, domicilio_codigo_postal, domicilio_departamento, domicilio_numero_piso)
select distinct d.Cli_Direccion, l.localidad_id, 0, 0, 0
from [gd_esquema].[Maestra] d
inner join [gd_esquema].Localidad l on l.localidad_nombre = d.Cli_Ciudad 
where d.Cli_Direccion is not null
union select distinct p.Provee_Dom, lo.localidad_id, 0, 0, 0
from [gd_esquema].[Maestra] p
inner join [gd_esquema].Localidad lo on lo.localidad_nombre = p.Provee_Ciudad
where p.Provee_Dom is not null

-- inserto los usuarios (solo clientes por ahora), por default el username es el dni
insert into [gd_esquema].Usuario (usuario_username, usuario_password)
  select distinct m.Cli_Dni, LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), m.Cli_Dni)), 2)) from [gd_esquema].[Maestra] m where m.Cli_Dni is not null

-- inserto clientes
-- por default en el credito les pongo 0, despues en procedure lo calculo y pongo bien
insert into [gd_esquema].Cliente (cliente_dni, cliente_id_usuario, cliente_nombre, cliente_apellido, cliente_mail, 
cliente_telefono, cliente_fecha_nacimiento, cliente_id_domicilio, cliente_credito)
select distinct m.Cli_Dni, u.usuario_username, m.Cli_Nombre, m.Cli_Apellido, m.Cli_Mail, m.Cli_Telefono, m.Cli_Fecha_Nac, d.domicilio_id, 0
from [gd_esquema].[Maestra] m
left join [gd_esquema].Localidad l on l.localidad_nombre = m.Cli_Ciudad
left join [gd_esquema].Domicilio d on d.domicilio_calle = m.Cli_Direccion and l.localidad_id = d.domicilio_id_localidad
join [gd_esquema].Usuario u on u.usuario_username = m.Cli_Dni
 
-- inserto cargas
-- como no especifica tarjeta, pongo null
insert into [gd_esquema].Carga_Credito (
carga_credito_id_cliente,
carga_credito_id_tipo_pago,
carga_credito_id_tarjeta,
carga_credito_fecha,
carga_credito_monto)
select c.cliente_id, (case when m.Tipo_Pago_Desc = 'Crédito' then (select t.tipo_pago_id from [gd_esquema].Tipo_Pago t where t.tipo_pago_nombre = 'credito') 
when m.Tipo_Pago_Desc = 'Efectivo' then (select t.tipo_pago_id from [gd_esquema].Tipo_Pago t where t.tipo_pago_nombre = 'efectivo') 
else 0 end), NULL
, m.Carga_Fecha, m.Carga_Credito 
from [gd_esquema].Maestra m
join [gd_esquema].Cliente c on c.cliente_dni = m.Cli_Dni
where m.Tipo_Pago_Desc is not null and m.Carga_Credito is not null and m.Carga_Fecha is not null

-- inserto a mis usuarios con el rol correspondiente
-- hasta aca solo cargue clientes, por lo tanto, todos tienen el rol de cliente
-- todo: mejorar esto e insertar clientes y provee juntos con union
insert into [gd_esquema].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario)
select 3, u.usuario_username from [gd_esquema].Usuario u

-- inserto usuario de proveedores, por default el username es el cuit
insert into [gd_esquema].Usuario (usuario_username, usuario_password)
  select distinct m.Provee_CUIT, LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), m.Provee_CUIT)), 2)) from [gd_esquema].[Maestra] m where m.Provee_CUIT is not null

-- inserto el usuario admin
insert into [gd_esquema].Usuario (usuario_username, usuario_password) values ('admin', LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), 'w23e')), 2)))
-- le asigno el rol
insert into [gd_esquema].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario) values (4, 'admin')

-- inserto rubros
insert into [gd_esquema].Rubro (rubro_descripcion)
select distinct m.Provee_Rubro
from [gd_esquema].[Maestra] m
where m.Provee_Rubro is not null

-- inserto proveedores
-- nombre de contacto y mail no tengo, va null
insert into [gd_esquema].Proveedor (proveedor_id_usuario, proveedor_razon_social, proveedor_telefono, proveedor_cuit, proveedor_id_rubro, proveedor_id_domicilio)
select distinct u.usuario_username, m.Provee_RS, m.Provee_Telefono, m.Provee_CUIT, r.rubro_id, d.domicilio_id
from [gd_esquema].[Maestra] m
left join [gd_esquema].Localidad l on l.localidad_nombre = m.Provee_Ciudad
left join [gd_esquema].Domicilio d on d.domicilio_calle = m.Provee_Dom and l.localidad_id = d.domicilio_id_localidad
join [gd_esquema].Usuario u on u.usuario_username = m.Provee_CUIT
left join [gd_esquema].Rubro r on r.rubro_descripcion = Provee_Rubro
-- validar que no sea nulo

-- busco los proveedores y les asigno el rol
insert into [gd_esquema].RolesxUsuario (rolesxusuario_id_rol, rolesxusuario_id_usuario)
select 2, u.usuario_username from  [gd_esquema].Usuario u where u.usuario_username in (
	select distinct m.Provee_CUIT from [gd_esquema].[Maestra] m where m.Provee_CUIT is not null
)

-- inserto ofertas
-- cada oferta tiene mismo cuit, misma fechas y misma descripcion
-- el limite por cliente no lo sabemos -> ponemos 0?? todo: revisar decision
  insert into [gd_esquema].Oferta(oferta_descripcion, oferta_fecha_publicacion, oferta_fecha_venc, oferta_precio, oferta_precio_lista, 
  oferta_restriccion_compra, oferta_cantidad, oferta_id_proveedor)
  select distinct m.Oferta_Descripcion, m.Oferta_Fecha, m.Oferta_Fecha_Venc, m.Oferta_Precio, m.Oferta_Precio_Ficticio, 0, m.Oferta_Cantidad, p.proveedor_id
  FROM [gd_esquema].[Maestra] m
  join [gd_esquema].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  where m.Oferta_Descripcion is not null

-- asumimos que usuario en la vieja db compro 1 oferta por columna
-- vimos que el codigo de oferta no era unico por cada compra
-- si hay duplicados le concatena -1, -2
-- tendriamos que usar el mismo codigo para el cupon y para la compra
 insert into [gd_esquema].Compra_Oferta (compra_oferta_id_oferta, compra_oferta_fecha,
  compra_oferta_cantidad,
  compra_oferta_id_cliente, compra_oferta_codigo)
  select distinct 
  o.oferta_id,
  m.Oferta_Fecha_Compra, 1,
  c.cliente_id, m.Oferta_Codigo 
  from [gd_esquema].Maestra m 
  join [gd_esquema].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  join [gd_esquema].Cliente c on c.cliente_id_usuario = u.usuario_username
  join [gd_esquema].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  join gd_esquema.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
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
 FROM gd_esquema.Compra_Oferta
)
update CTE_Codigos set compra_oferta_codigo = concat(compra_oferta_codigo, '-1')
 where num_col > 1;
 
WITH CTE_Codigos (compra_oferta_codigo, compra_oferta_id, num_col)
AS
(
 SELECT compra_oferta_codigo, compra_oferta_id,
 ROW_NUMBER() OVER(PARTITION BY compra_oferta_codigo order by compra_oferta_codigo)
 FROM gd_esquema.Compra_Oferta
)
update CTE_Codigos set compra_oferta_codigo = concat(SUBSTRING(compra_oferta_codigo, 0, LEN(compra_oferta_codigo) - 1), '-2')
 where num_col > 1 


-- no tenemos fecha de vencimiento del cupon, ponemos la misma que la que fue consumido, total ya fue consumido 
-- procedure para canjear cupon que genera cupon cuando se hace compra_oferta
-- de esa manera nos garantizamos que sea unico.
-- si la fecha de consumo no es null, ya fue consumido
-- le ponemos el mismo codigo que a la compra
-- asumimos que el cliente que lo compro es el mismo que lo retiro
insert into [gd_esquema].Cupon(cupon_fecha_venc, cupon_fecha_consumo, cupon_id_compra_oferta, cupon_id_cliente, cupon_codigo)
  select distinct  m.Oferta_Entregado_Fecha, m.Oferta_Entregado_Fecha,
  co.compra_oferta_id, 
  c.cliente_id, co.compra_oferta_codigo
  from [gd_esquema].Maestra m 
  left join [gd_esquema].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  left join [gd_esquema].Cliente c on c.cliente_id_usuario = u.usuario_username
  left join [gd_esquema].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  left join gd_esquema.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
  o.oferta_fecha_publicacion = m.Oferta_Fecha and o.oferta_fecha_venc = m.Oferta_Fecha_Venc and
  o.oferta_precio = m.Oferta_Precio and o.oferta_precio_lista = m.Oferta_Precio_Ficticio and
  o.oferta_cantidad = m.Oferta_Cantidad and o.oferta_id_proveedor = p.proveedor_id
  left join [gd_esquema].Compra_Oferta co on 
	co.compra_oferta_id_oferta = o.oferta_id and co.compra_oferta_fecha = m.Oferta_Fecha_Compra
	and co.compra_oferta_id_cliente = c.cliente_id
  where m.Oferta_Entregado_Fecha is not null

-- migramos factura: numero es el id y el importe lo calculamos 
-- fecha de inicio es la fecha menor que aparece con el numero de factura
-- y la fecha final es la fecha de la factura
SET IDENTITY_INSERT [gd_esquema].Factura ON

insert into  [gd_esquema].Factura(factura_id, factura_fecha_fin, factura_id_proveedor, factura_fecha_inicio, factura_importe)
select distinct m.Factura_Nro, m.Factura_Fecha, p.proveedor_id,
(select min(ma.Oferta_Fecha_Compra)
from  [gd_esquema].Maestra ma
where ma.Factura_Nro = m.Factura_Nro and ma.Factura_Fecha = m.Factura_Fecha
and ma.Oferta_Fecha_Compra is not null
) as 'fecha min', (select sum(mae.Oferta_Precio) from [gd_esquema].Maestra mae
where mae.Factura_Nro = m.Factura_Nro and mae.Factura_Fecha = m.Factura_Fecha
)
from  [gd_esquema].Maestra m
left join [gd_esquema].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
where m.Factura_Fecha is not null and m.Factura_Nro is not null

SET IDENTITY_INSERT [gd_esquema].Factura OFF

-- inserto item-factura
  insert into [gd_esquema].Item(item_id_compra_oferta, item_id_factura)
  select distinct co.compra_oferta_id, f.factura_id
  from [gd_esquema].Maestra m 
  left join [gd_esquema].Usuario u on u.usuario_username = CONVERT(varchar(64), m.Cli_Dni)
  left join [gd_esquema].Cliente c on c.cliente_id_usuario = u.usuario_username
  left join [gd_esquema].Proveedor p on p.proveedor_cuit = m.Provee_CUIT
  left join gd_esquema.Oferta o on o.oferta_descripcion = m.Oferta_Descripcion and
  o.oferta_fecha_publicacion = m.Oferta_Fecha and o.oferta_fecha_venc = m.Oferta_Fecha_Venc and
  o.oferta_precio = m.Oferta_Precio and o.oferta_precio_lista = m.Oferta_Precio_Ficticio and
  o.oferta_cantidad = m.Oferta_Cantidad and o.oferta_id_proveedor = p.proveedor_id
  left join [gd_esquema].Compra_Oferta co on 
	co.compra_oferta_id_oferta = o.oferta_id and co.compra_oferta_fecha = m.Oferta_Fecha_Compra
	and co.compra_oferta_id_cliente = c.cliente_id
	left join [gd_esquema].Factura f on f.factura_id = m.Factura_Nro and f.factura_fecha_fin = m.Factura_Fecha
  where m.Factura_Nro is not null

-- calculo el saldo de cada cliente
declare @id_cliente INT
DECLARE cursor_cliente CURSOR FOR SELECT c.cliente_id FROM [gd_esquema].Cliente c
OPEN cursor_cliente
FETCH cursor_cliente INTO @id_cliente
WHILE @@FETCH_STATUS = 0
    BEGIN
		UPDATE [gd_esquema].Cliente SET cliente_credito = isnull(
			(select sum(cc.carga_credito_monto) from [gd_esquema].Carga_Credito cc
			where cc.carga_credito_id_cliente = @id_cliente) -
			(select sum(co.compra_oferta_cantidad * o.oferta_precio) from [gd_esquema].Compra_Oferta co
			join [gd_esquema].Oferta o on o.oferta_id = co.compra_oferta_id_oferta
			where co.compra_oferta_id_cliente = @id_cliente
			)
		, 0)
		WHERE @id_cliente = cliente_id
    FETCH cursor_cliente INTO @id_cliente
END
CLOSE cursor_cliente
DEALLOCATE cursor_cliente

-- FIN DE MIGRACION
go
create function gd_esquema.top_5_mayor_porcentaje(@anio int, @semestre int)
returns table
as
	return (
		select top 5 p.proveedor_cuit, p.proveedor_razon_social,
		(
			select  max( (o.oferta_precio_lista - o.oferta_precio)/o.oferta_precio_lista*100 ) from gd_esquema.Oferta o
			where o.oferta_id_proveedor = p.proveedor_id
		) as 'descuento'
		from gd_esquema.Proveedor p order by 'descuento' desc
	)
go

-- estadisticas


-- funcionalidades
create procedure gd_esquema.rol_cambiar_nombre (@id_rol int, @nombre varchar(64))
as
begin transaction
	if exists (select rol_nombre from gd_esquema.Rol where @nombre = rol_nombre and @id_rol <> rol_id)
	begin
		rollback
			raiserror('No puede agregar un nombre de rol existente.', 16, 1)
		return
	end	
	
	update gd_esquema.Rol
	set rol_nombre = @nombre
	where rol_id = @id_rol
commit
go

create procedure gd_esquema.rol_agregar_funcionalidad (@id_rol int, @id_func int)
as
begin transaction
	if exists (select funcionalidadxrol_id_funcionalidad from gd_esquema.FuncionalidadxRol where @id_func = funcionalidadxrol_id_funcionalidad and @id_rol = funcionalidadxrol_id_rol)
	begin
		rollback
			raiserror('El rol ya tiene esa funcionalidad.', 16, 1)
		return
	end	
	
	insert into gd_esquema.FuncionalidadxRol(funcionalidadxrol_id_funcionalidad, funcionalidadxrol_id_rol)
	values(@id_func, @id_rol)
commit
go

create procedure gd_esquema.rol_quitar_funcionalidad (@id_rol int, @id_func int)
as
begin transaction
	if not exists (select funcionalidadxrol_id_funcionalidad from gd_esquema.FuncionalidadxRol where @id_func = funcionalidadxrol_id_funcionalidad and @id_rol = funcionalidadxrol_id_rol)
	begin
		rollback
			raiserror('No puede sacar una funcionalidad que no tiene', 16, 1)
		return
	end	
	
	delete from gd_esquema.FuncionalidadxRol
	where funcionalidadxrol_id_rol = @id_rol and funcionalidadxrol_id_funcionalidad = @id_func
commit
go

-- eliminacion del rol se hace directamente con query seteando el eliminado a 1

create procedure rol_inhabilitar(@id_rol int)
as
begin transaction
	update gd_esquema.Rol set rol_habilitado = 0 where @id_rol = rol_id
	delete from gd_esquema.RolesxUsuario where @id_rol = rolesxusuario_id_rol
commit
go

create procedure usuario_login(@username nvarchar(64), @password nvarchar(500))
as
begin transaction
	if not exists(select 1 from gd_esquema.Usuario where usuario_username = @username and usuario_password = LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), @password)), 2)))
		begin
			update gd_esquema.Usuario set usuario_intentos_fallidos_login = usuario_intentos_fallidos_login + 1
			where usuario_username = @username
				if exists (select 1 from gd_esquema.Usuario where usuario_username = @username and usuario_intentos_fallidos_login > 3)
					begin
						update gd_esquema.Usuario set usuario_habilitado = 0
						where usuario_username = @username
					end
			raiserror('Usuario o contraseña inválidos', 16, 1)
			return
		end
	else
		begin
		if exists (select 1 from gd_esquema.Usuario where usuario_username = @username and usuario_habilitado = 0)
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
				update gd_esquema.Usuario set usuario_intentos_fallidos_login = 0
				where usuario_username = @username
			end
		end
commit
go

create procedure usuario_modificar_password(@username nvarchar(64), @password nvarchar(500))
as
begin transaction
	update gd_esquema.Usuario set usuario_password = LOWER(CONVERT([varchar](500), HASHBYTES('SHA2_256', CONVERT(varchar(64), @password)), 2))
	where usuario_username = @username
commit
go

create procedure cliente_agregar(@nombre varchar(64), @apellido nvarchar(64), @dni nvarchar(64), @mail nvarchar(64), @telefono nvarchar(64), @direccion nvarchar(64), @piso int, @departamento char(20), @localidad nvarchar(64), @codigo_postal int, @fech_nac datetime, @id_usuario int)
as
begin transaction
	-- validaciones
	if exists (select 1 from gd_esquema.Cliente where @dni = cliente_dni)
		begin
			raiserror('Ya existe un cliente con ese dni', 16, 1)
			return
		end
	else
		begin
			if exists (select 1 from gd_esquema.Cliente where @nombre = cliente_nombre and @apellido = cliente_apellido and @mail = cliente_mail and @telefono = cliente_telefono and @fech_nac = cliente_fecha_nacimiento)
				begin
					raiserror('Ya existe un cliente con mismo nombre, apellido, mail, telefono y fecha de nacimiento', 16, 1)
					return
				end
		end
	-- ver si existe la direccion, usar el id si existe, si no crearla
	-- si no existe la localidad, crearla
	-- despues creo usuario y le agrego lo 200 de regalo
commit
go
/*
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
/*


	domicilio_id_localidad INT NOT NULL,
	domicilio_calle varchar(64) NOT NULL,
	domicilio_numero_piso INT NULL,
	domicilio_departamento char(20) NULL,
	domicilio_codigo_postal INT NOT NULL,
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
CREATE TRIGGER [gd_esquema].[alta_cliente]
ON [gd_esquema].[Cliente]
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
	INSERT INTO gd_esquema.Carga_Credito(carga_credito_id_cliente, carga_credito_monto, carga_credito_id_tipo_pago, carga_credito_fecha) 
	VALUES (@id_cliente_nuevo, 200, 1, GETDATE()) -- todo: hay que usar la fecha del archivo de config
COMMIT TRANSACTION
GO
-- validar que cliente que carga credito esté habilitado
CREATE TRIGGER [gd_esquema].validez_cliente_credito
ON [gd_esquema].Carga_Credito
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