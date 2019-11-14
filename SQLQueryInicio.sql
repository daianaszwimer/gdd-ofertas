use GD2C2019
--FK: idDomicilio

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

IF OBJECT_ID('proveedor', 'U') IS NOT NULL 
  DROP TABLE proveedor;

IF OBJECT_ID('rubro', 'U') IS NOT NULL 
  DROP TABLE rubro;  

create table usuario(
	usuario_username varchar(50) PRIMARY KEY NOT NULL,
	usuario_password varchar(500) NOT NULL,
	usuario_intentos_fallidos_login int DEFAULT 0,
	usuario_habilitado int default 1, 
	)

create table localidad(
	localidad_id int identity not null primary key,
	localidad_nombre varchar(50)
)

create table domicilio(
	domicilio_id int identity not null primary key,
	idLocalidad int REFERENCES localidad,
	domicilio_calle varchar(30),
	domicilio_piso int, --TODO: Ver default es 0
	domicilio_depto varchar(3),
	domicilio_codpostal int
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

create table rubro(
	rubro_id int identity not null primary key,
	rubro_descripcion varchar(64)
)
CREATE TABLE proveedor(
	proveedor_id INT NOT NULL identity(1, 1) PRIMARY KEY,
	--proveedor_id_usuario INT,
	proveedor_razon_social varchar(64) UNIQUE NOT NULL,
	proveedor_id_domicilio INT,
	proveedor_cuit nvarchar(64) UNIQUE NOT NULL,
	proveedor_telefono int,
	proveedor_mail varchar(64),
	proveedor_id_rubro INT foreign key references rubro,
	proveedor_nombre_contacto varchar(64),
	proveedor_habilitado bit default 1,
	proveedor_eliminado bit default 0
)

create table cliente(
	cliente_id int identity not null primary key,
	--username varchar(50) not null REFERENCES usuario,
	idDomicilio int not null REFERENCES domicilio,
	cliente_nombre varchar(50),
	cliente_apellido varchar(50),
	cliente_dni int UNIQUE, --UNIQUE
	cliente_mail varchar(50),
	cliente_telefono int,
	cliente_fechaNacimiento datetime,
	cliente_habilitado bit default 1,
	cliente_eliminado bit default 0
)

create table cargaDeCredito(
	carga_credito_id int identity not null primary key,
	idCliente int REFERENCES cliente,
	idTipoDePago int REFERENCES tipoDePago,
	idTarjeta int REFERENCES tarjeta,
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

insert into usuario (usuario_username, usuario_password)
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

insert into localidad
	values ('CABA'),('Loma Hermosa')

insert into domicilio(idLocalidad, domicilio_calle, domicilio_piso, domicilio_depto, domicilio_codpostal)
	values (1,'Llavallol 2730', 7, 'A', 1417), (2,'La pampa',0,'', 1657)

insert into cliente(idDomicilio, cliente_nombre, cliente_apellido, cliente_dni, cliente_mail, cliente_telefono , cliente_fechaNacimiento)
	values  (1,'Marina', 'Posru', 40677010, 'maru@gmail.com', 45037392, 12/09/1997),
			(2,'Diego', 'Peccia', 41698201, 'diego@gmail.com', 40367892, 23/03/1998)

insert into rubro (rubro_descripcion) values ('metalurgia'), ('sistemas'), ('farmaceutica')

INSERT INTO proveedor (proveedor_razon_social, proveedor_id_domicilio,proveedor_cuit, proveedor_telefono, proveedor_mail, proveedor_id_rubro, proveedor_nombre_contacto) 
	VALUES ('SIEMENS S.A.',2,'41063122','1241','diego@gmail.com',2,'Diegote'),
		   ('Farmaceutica',1,'2333','12431','mari@gmail.com',3,'Mari');

