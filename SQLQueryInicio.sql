use GD2C2019

drop table	dbo.rolxusuario,
			dbo.funcionalidadxrol,
			dbo.usuario,
			dbo.funcionalidad,
			dbo.rol,

create table usuario(
	username varchar(50) PRIMARY KEY NOT NULL,
	pass varchar(500) NOT NULL,
	intentos_fallidos_login int DEFAULT 0,
	habilitado int default 1, 
	CHECK(intentos_fallidos_login<=3))

create table funcionalidad(
	id int identity not null primary key,
	descripcion varchar(50))

create table rol(
	rol_id int identity not null primary key,
	rol_nombre varchar(100))

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
	values ('ABM Cliente'),('ABM Proveedor'),('Carga de credito'),
			('Alta de oferta'),('Compra de oferta'),('Baja de oferta'),
			('Facturacion'),('Estadisticas')

insert into rol (rol_nombre)
	values ('Administrador General'),('Cliente')

insert into funcionalidadxrol (rol_id, funcionalidad_id)
	values (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),
		(2,3),(2,5),(2,7)

insert into rolxusuario (username, rol_id)
	VALUES ('admin', 1), ('maru',2)