
use master
CREATE database Mediturnos
go

CREATE DATABASE Mediturnos
GO

USE Mediturnos
GO

CREATE TABLE Usuarios(
	ID INT PRIMARY KEY NOT NULL identity(1,1),
	Email VARCHAR(250) UNIQUE NOT NULL,
	Contrasena Varchar(50) NOT NULL,
	Estado bit not null,
)
GO
CREATE TABLE Especialidades(
	ID INT Primary Key NOT NULL identity(1,1),
	Especialidad varchar(150) NOT NULL
)
GO
CREATE TABLE ObrasSociales(
	ID INT Primary key not null identity(1,1),
	ObraSocial varchar(100) not null
)
GO
CREATE TABLE Pacientes(
	ID INT PRIMARY KEY NOT NULL identity(1,1), 
	IDUsuario INT not null Foreign key references Usuarios(ID),
	IDObraSocial INT Foreign key references ObrasSociales(ID) NOT NULL,
	Apellido VARCHAR(100) NOT NULL, 
	Nombre VARCHAR(100) NOT NULL,
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    NroAfiliado varchar (40) NULL
)
GO
CREATE TABLE Medicos(
	ID INT PRIMARY KEY NOT NULL identity(1,1), 
	IDUsuario INT not null Foreign key references Usuarios(ID),
	IDEspecialidad INT not null Foreign key references Especialidades(ID),
	Apellido VARCHAR(100) NOT NULL, 
	Nombre VARCHAR(100) NOT NULL,
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    Matricula varchar (40) NULL,

)
GO

CREATE TABLE EstadoTurno(
	ID INT Primary Key NOT NULL identity(1,1),
	EstadoTurno varchar(15) NOT NULL 
)
GO

CREATE TABLE Turnos(
  ID INT Primary Key Not null identity(1,1),
  FechaHora DateTime NOT NULL CHECK (FechaHora > GETDATE()),
  IDMedico INT NOT NULL FOREIGN KEY REFERENCES Medicos(ID),
  IDPaciente INT NOT NULL FOREIGN KEY REFERENCES Pacientes(ID),
  Estado int not null FOREIGN KEY REFERENCES EstadoTurno(ID)
)

Set dateformat 'DMY'

--20 Usuarios
insert into Usuarios (Email, Contrasena, Estado) VALUES
('Pepe@gmail.com', '1234', 1), 
('Pato@hotmail.com', '1234', 1),
('Paisa@gmail.ar', '1234', 1),
('Doro@hotmail.com', '1234', 1), 
('Pablo@gmail.com', '1234', 1), 
('Pablo22@gmail.com', '1234', 1), 
('Toto@gmail.com', '1234', 1), 
('Elepa_roro@gmail.com', '1234', 1), 
('Medic_bom@gmail.com', '1234', 1),
('gonzagomez@yahoo.com', '1234', 1),
('pipi99@yahoo.com', '1234', 1),
('marispert@gmail.com', '1234', 1),
('ejemplo@gmail.com', '1234', 1),
('pedro_escov@gmail.com', '1234', 1),
('delfi_per@yahoo.com.ar', '1234', 1),
('magali1996@gmail.com', '1234', 1),
('caroperez12@gmail.com', '1234', 1),
('DanteClick@gmail.com', '1234', 1),
('ElChanta@gmail.com', '1234', 1),
('pablobonf@yahoo.com.ar', '1234', 1)

--8 Especialidades
insert into Especialidades (Especialidad) values ('Dermatología'), ('Oftalmología'), ('Traumatología'), ('Urología'), ('Oftalmología'), ('Otorrinolaringología'), ('Ginecología'), ('CARDIOLOGIA')

--10 medicos
insert into Medicos(Nombre, Apellido, Domicilio, Celular, FechaNacimiento, Genero, Matricula, IDUsuario, IDEspecialidad) values
('Pepe','Luis','Falsa 123','1234560','19980223','M','1234', 1, 1), 
('Pato','Goye','Brown 321','2234542','19900203','M','2234', 2, 2),
('Matias','Paisa','Blegrano 456','8954624','19940205','M','7894', 3, 1),
('Isidoro','Arostegui','Medina 1775','7363214','19980729','M','4321', 4, 6),
('Pablo','Olsavsky','estomba 2594','7793278','19970502','M','2345', 5, 8),
('Pablo','Sorrivas','gorriti 53','9893295','19940815','M','7894', 6, 3),
('Tota','Garcia','San Martin 4562','4594514','19801226','F','9874', 7, 5),
('Elsa','mazzochi','Saavedra 894','7594214','19880317','F','4561', 8, 7),
('Daina','Alfano','Castelli 1539','4563321','19900101','F','6541', 9, 7),
('Gonzalo','gomez','Roca 32312','2312555','19961118','M','3691', 10, 7)


--6 Obras sociales
insert into ObrasSociales(ObraSocial) values ('DIVA'), ('OSDE'), ('MEDAFI'), ('GALENO'), ('MEDICUS'), ('IOMA')

--9 pacientes
insert into Pacientes(Nombre, Apellido, Domicilio, Celular, FechaNacimiento, Genero, NroAfiliado, IDUsuario, IDObraSocial) values
('Maria','Gonzales','Rivadavia 1233','1234560','19961118','F','1234', 11, 1), 
('Mariel','Espert','Güemes 1223','2312555','19980223','F','7412', 12, 2), 
('Muestra','Ejemplo','Brown 1123','4563321','19940205','F','8523', 13, 5), 
('Delfina','Rapani','Alberdi 453','4594514','19801225','F','1234', 14, 4), 
('Magali','Ginzo','Rosas 1208','9893295','19990703','F','9632', 15, 1), 
('Carolina','Perez','Artigas 1024','1130060','19910402','F','8945', 16, 6), 
('Dante','Abecia','Bolivar 3015','1439630','19981117','M','6541', 17, 1), 
('Chanta','Pirola','San Martin 645','7414560','19980729','M','9874', 18, 3), 
('Pablo','Bonfilio','Belgrano 456','1334852','19940520','M','9512', 19, 1)

-- Estados de turnos
insert into EstadoTurno(EstadoTurno) values
('Agendado'),
('Cancelado'),
('Asistido'),
('Reagendado'),
('Ausente')


--0=turno no-vigente-cancelado,1=turno vigente-agendado,2=Asistió al turno,3=Turno-Re-Agendado, 4=Faltó al turno
--turnos 7
insert into Turnos (FechaHora, IDMedico, IDPaciente, Estado) values
('23-10-2021 11:44', 1, 1, 1),
('12-11-2021 10:24', 4, 3, 2),
('17-12-2021 17:10', 2, 5, 3),
('24-09-2021 16:35', 1, 2, 4),
('12-08-2021 12:55', 7, 3, 5),
('13-09-2021 10:36', 3, 7, 1),
('08-07-2022 09:21', 2, 4, 1)




/*
/////ESTA OPCION PUEDE IR /// INTERVALO DE UNA HORA POR SESION 
-- Revisar con Pablito y Dorito  --> y en medico agregar el intervalos en minutos 40, 20, 160
CREATE TABLE DisponibilidadHoraria(
	ID int Primary key identity(1,1),
	IDMedico int foreign key references Medicos(id),
	Dia date not null,
	HorarioInicio time not null,
	HorarioFin time not null,
	Repite bit not null,
	Estado bit not null
)

go
--- estos son los horarios cortados 
create table Horarios
(
	ID tinyint primary key identity(1,1) not null,
	IDDisponibilidadHoraria tinyint foreign key references DisponibilidadHoraria(ID) not null,
	HorarioInicio time not null,
	HorarioFin time not null
)


*/