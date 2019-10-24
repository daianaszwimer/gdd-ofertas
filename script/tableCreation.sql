/*IF OBJECT_ID (N'dbo.Usuario', N'U') IS NOT NULL  
DROP TABLE gd_esquema.Usuario;  
GO
*/
CREATE TABLE [gd_esquema].[Usuario](
	[usuario_id][varchar](20) NOT NULL,
	[usuario_username][varchar](64) NOT NULL,
	[usuario_password][varchar](64) NOT NULL,
	[usuario_intentos_fallidos_login][Int] NOT NULL,
	[usuario_eliminado][bit] NULL
)

CREATE TABLE [gd_esquema].[RolesxUsuario](
	[id_usuario][varchar](20) NOT NULL,
	[id_rol][varchar](20) NOT NULL,
)
-- faltan crear las de abajo
CREATE TABLE [gd_esquema].[Rol](
	[rol_id][varchar](20) NOT NULL,
	[rol_nombre][varchar](20) NOT NULL,
	[rol_habilitado][bit] NULL,
	[rol_eliminado][bit] NULL,
)

CREATE TABLE [gd_esquema].[FuncionalidadxRol](
	[id_rol][varchar](20) NOT NULL,
	[id_funcionalidad][varchar](20) NOT NULL,
)

CREATE TABLE [gd_esquema].[Funcionalidad](
	[funcionalidad_id][varchar](20) NOT NULL,
	[funcionalidad_descripcion][varchar](64) NOT NULL,
)

CREATE TABLE [gd_esquema].[Cliente](
	[cliente_id][varchar](20) NOT NULL,
	[cliente_id_usuario][varchar](20) NOT NULL,
	[cliente_nombre][varchar](64) NOT NULL,
	[cliente_apellido][varchar](64) NOT NULL,
	[cliente_dni][varchar](64) NOT NULL,
	[cliente_mail][varchar](64) NOT NULL,
	[cliente_telefono][varchar](64) NOT NULL,
	[cliente_habilitado][bit] NULL,
	[cliente_fecha_nacimiento][datetime] NULL,
	[cliente_id_domicilio][varchar](20) NOT NULL,
	[cliente_credito][int] NOT NULL,
)

CREATE TABLE [gd_esquema].[Domicilio](
	[domicilio_id][varchar](20) NOT NULL,
	[domicilio_id_localidad][varchar](20) NOT NULL,
	[domicilio_calle][varchar](64) NOT NULL,
	[domicilio_numero_piso][int] NOT NULL,
	[domicilio_departamento][char](20) NOT NULL,
	[domicilio_codigo_postal][int] NOT NULL,
)

CREATE TABLE [gd_esquema].[Localidad](
	[localidad_id][varchar](20) NOT NULL,
	[localidad_nombre][varchar](64) NOT NULL,
)

CREATE TABLE [gd_esquema].[Carga_Credito](
	[carga_credito_id][varchar](20) NOT NULL,
	[carga_credito_id_cliente][varchar](20) NOT NULL,
	[carga_credito_id_tipo_pago][varchar](20) NOT NULL,
	[carga_credito_id_tarjeta][varchar](20) NOT NULL,
	[carga_credito_fecha][datetime] NOT NULL,
	[carga_credito_monto][int] NOT NULL,
)

CREATE TABLE [gd_esquema].[Tipo_Pago](
	[tipo_pago_id][varchar](20) NOT NULL,
	[tipo_pago_nombre][varchar](64) NOT NULL,
)

CREATE TABLE [gd_esquema].[Tarjeta](
	[tarjeta_id][varchar](20) NOT NULL,
	[tarjeta_numero][varchar](64) NOT NULL,
	[tarjeta_fecha_venc][datetime] NOT NULL,
	[tarjeta_cod_seguridad][varchar](20) NOT NULL,
	-- tarjeta_tipo ?
)