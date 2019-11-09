use GD2C2019

IF OBJECT_ID('cargaDeCredito', 'U') IS NOT NULL 
  DROP TABLE cargaDeCredito;

IF OBJECT_ID('tarjeta', 'U') IS NOT NULL 
  DROP TABLE tarjeta;

IF OBJECT_ID('tipoDePago', 'U') IS NOT NULL 
  DROP TABLE tipoDePago;

IF OBJECT_ID('cliente', 'U') IS NOT NULL 
  DROP TABLE cliente;

IF OBJECT_ID('domicilio', 'U') IS NOT NULL 
  DROP TABLE domicilio;

IF OBJECT_ID('localidad', 'U') IS NOT NULL 
  DROP TABLE localidad;

IF OBJECT_ID('rolxusuario', 'U') IS NOT NULL 
  DROP TABLE rolxusuario;

IF OBJECT_ID('funcionalidadxrol', 'U') IS NOT NULL 
  DROP TABLE funcionalidadxrol;
		
IF OBJECT_ID('rol', 'U') IS NOT NULL 
  DROP TABLE rol;

IF OBJECT_ID('funcionalidad', 'U') IS NOT NULL 
  DROP TABLE funcionalidad;			

IF OBJECT_ID('dbo.usuario', 'U') IS NOT NULL 
  DROP TABLE dbo.usuario; 



create table usuario(
	username varchar(50) PRIMARY KEY NOT NULL,
	pass varchar(500) NOT NULL,
	intentos_fallidos_login int DEFAULT 0,
	habilitado int default 1, 
	)

create table localidad(
	id int identity not null primary key,
	nombre varchar(50)
)

create table domicilio(
	id int identity not null primary key,
	idLocalidad int REFERENCES localidad,
	calle varchar(30),
	piso int, --TODO: Ver default es 0
	depto varchar(3),
	codpostal int
)

create table tarjeta(
	id int identity not null primary key,
	tarjeta_numero int,
	--tarjeta_tipo int,
	tarjeta_fecha_vec datetime,
	tarjeta_cod_seguridad int
)

create table tipoDePago(
	id int identity not null primary key,
	tipo_pago_nombre varchar(20)
)

create table cliente(
	id int identity not null primary key,
	--username varchar(50) not null REFERENCES usuario,
	idDomicilio int not null REFERENCES domicilio,
	nombre varchar(50),
	apellido varchar(50),
	dni int,
	mail varchar(50),
	telefono int,
	fechaNacimiento datetime
	--TODO: credito
	--		habilitado
)

create table cargaDeCredito(
	id int identity not null primary key,
	carga_credito_id_cliente int REFERENCES cliente,
	carga_credito_id_tipo_de_pago int REFERENCES tipoDePago,
	carga_credito_id_tarjeta int REFERENCES tarjeta,
	carga_credito_fecha datetime,
	carga_credito_monto int
)


create table funcionalidad(
	id int identity not null primary key,
	descripcion varchar(50))

create table rol(
	rol_id int identity not null primary key,
	rol_nombre varchar(100),
	rol_habilitado bit default 1,
	rol_eliminado bit default 0)

create table funcionalidadxrol(
	rol_id int not null REFERENCES rol,
	funcionalidad_id int not null REFERENCES funcionalidad)

create table rolxusuario(
	username varchar(50) not null REFERENCES usuario,
	rol_id int not null REFERENCES rol)

insert into usuario (username, pass)
	values ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
	('maru','aaa')

insert into funcionalidad (descripcion)
	values ('ABM Rol'),('ABM Cliente'),('ABM Proveedor'),('Carga de credito'),
			('Confeccion y publicacion de Ofertas'),('Compra de oferta'),('Entrega/Consumo de oferta'),
			('Facturacion a Proveedor'),('Listado Estadistico')

insert into rol (rol_nombre)
	values ('Administrador General'),('Cliente')

insert into funcionalidadxrol (rol_id, funcionalidad_id)
	values (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),
		(2,3),(2,5),(2,7)

insert into rolxusuario (username, rol_id)
	VALUES ('admin', 1), ('maru',2)

insert into tipoDePago (tipo_pago_nombre)
	values ('cargaInicial')

insert into tarjeta (tarjeta_numero,tarjeta_fecha_vec,tarjeta_cod_seguridad)
	values (00,00,00)