/*IF OBJECT_ID (N'dbo.Usuario', N'U') IS NOT NULL  
DROP TABLE gd_esquema.Usuario;  
GO

CREATE TABLE gd_esquema.Usuario(
	usuario_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	usuario_username nvarchar(64) NOT NULL,
	usuario_password nvarchar(64) NOT NULL,
	usuario_intentos_fallidos_login INT NOT NULL,
	usuario_eliminado BIT NULL
	CONTRAINT [UN_Usuario_Username] UNIQUE (usuario_username)
)

CREATE TABLE gd_esquema.Rol(
	rol_id INT identity(1 ,1) NOT NULL PRIMARY KEY,
	rol_nombre varchar(20) NOT NULL,
	rol_habilitado BIT DEFAULT 1,
	rol_eliminado BIT DEFAULT 0,
)

CREATE TABLE gd_esquema.Funcionalidad(
	funcionalidad_id INT identity(1, 1) NOT NULL PRIMARY KEY,
	funcionalidad_descripcion varchar(64) NOT NULL,
)

CREATE TABLE gd_esquema.RolesxUsuario(
	rolesxusuario_id_usuario INT NOT NULL,
	rolesxusuario_id_rol INT NOT NULL

	CONSTRAINT [PK_RolesxUsuario] PRIMARY KEY (
		[rolesxusuario_id_usuario] ASC,
		[rolesxusuario_id_rol] ASC
	)
	
	CONSTRAINT [FK_RolesxUsuario_rol_id] FOREIGN KEY(rolesxusuario_id_rol)
		REFERENCES [gd_esquema].Rol (rol_id),
	CONSTRAINT [FK_RolesxUsuario_usuario_id] FOREIGN KEY(rolesxusuario_id_usuario)
		REFERENCES [gd_esquema].[Usuario] (usuario_id),
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
	cliente_credito INT NOT NULL
-- asumimos que si dos clientes tienen = nombre, apellido y dni son "gemelos"
	CONSTRAINT UN_Cliente_unico UNIQUE (cliente_nombre, cliente_apellido, cliente_dni)
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

-- funcionalidades
-- alta de usuario y login todos tienen acceso
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

INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(1, 'Administrativo', 1, 0)
INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(2, 'Proveedor', 1, 0)
INSERT INTO gd_esquema.Rol(rol_id, rol_nombre, rol_habilitado, rol_eliminado)
Values(3, 'Cliente', 1, 0)


*/

-- cuando se crea un cliente se le debitan $200:
CREATE TRIGGER [gd_esquema].alta_cliente
ON Cliente
AFTER INSERT
AS
BEGIN
	declare @id_cliente_nuevo INT
	-- hay una manera mejor? que sea el de id mayor me garantiza que sea el ultimo creado?
	SELECT TOP 1 @id_cliente_nuevo = cliente_id FROM Cliente ORDER BY cliente_id ASC
	-- todo: me fijo si existe o no en tabla de cargas?
	INSERT INTO gd_esquema.Carga_Credito(carga_credito_id, carga_credito_monto) VALUES (@id_cliente_nuevo, 200)
END
GO
-- validar que cliente que carga credito esté habilitado
CREATE TRIGGER [gd_esquema].validez_cliente_credito
ON Carga_Credito
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT * FROM Clientes 
		INNER JOIN Carga_Credito ON carga_credito_id_cliente = cliente_id
		WHERE habilitado = 0)
		RAISERROR ( 'Un Cliente inhabilitado no puede cargar credito', 1, 1)
		ROLLBACK TRANSACTION
END
GO

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

/*
todo: El alumno deberá determinar un procedimiento para evitar la generación de clientes “gemelos” (distinto nombre de usuario, pero igual datos identificatorios según se justifique en la estrategia de resolución). X
Toda creación de cliente nuevo, implica una carga de dinero de bienvenida de $200 X
validar que usuario que compra ofertas o carga credito este habiltiado X OFERTAS ES DE NICO
no pueden existir 2 proveedores con la misma razón social y cuit. NICO
Un proveedor inhabilitado no podrá armar ofertas NICO
ofertas: fecha debe ser mayor o igual a la fecha actual del sistema. NICO
crédito que posee el usuario sea suficiente para poder concretar dicha compra lo hago yo ??
un cupón no puede ser canjeado más de una vez, si el cupón se venció tampoco podrá ser canjeado y validarse que dicho cupón entrega corresponda al proveedor ?? yo?
crear usuario de cada tipo
*/