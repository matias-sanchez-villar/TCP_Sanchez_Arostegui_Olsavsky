USE MASTER
go
create database Mediturnos
GO
USE Mediturnos
GO
SET LANGUAGE English
go


CREATE TABLE Usuarios(
	ID INT PRIMARY KEY NOT NULL identity(1,1),
	Email VARCHAR(250) UNIQUE NOT NULL,
	Contrasena Varchar(50) NOT NULL,
	TipoUsuario int NOT NULL,
	Estado bit not null
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
    Matricula varchar (40) NULL
)
GO

CREATE TABLE Turnos(
  ID INT Primary Key Not null identity(1,1),
  ---- > CAST(DATEPART(m, GETDATE()) AS VARCHAR) if VARCHAR==Dia,  muestro al paciente los turnos dados, y los turnos disponibles
  Fecha Date NOT NULL CHECK (Fecha > GETDATE()),
  Hora Time NOT NULL,
  IDMedico INT NOT NULL FOREIGN KEY REFERENCES Medicos(ID),
  IDPaciente INT NOT NULL FOREIGN KEY REFERENCES Pacientes(ID),
  Estado varchar(20) not null,
  Descripcion varchar(550) null
)
go

CREATE TABLE DisponibilidadHoraria(
	ID int Primary key identity(1,1),
	IDMedico int foreign key references Medicos(id),
	Dia varchar(10) not null,  
	HorarioInicio time not null,
	HorarioFin time not null,
	Estado bit not null      
)
go


--20 Usuarios
insert into Usuarios (Email, Contrasena, Estado, tipoUsuario) VALUES
('Pepe@gmail.com', '1234', 1, 1), 
('Pato@hotmail.com', '1234', 1, 1),
('Paisa@gmail.ar', '1234', 1, 1),
('Doro@hotmail.com', '1234', 1, 1), 
('Pablo@gmail.com', '1234', 1, 1), 
('Pablo22@gmail.com', '1234', 1, 1), 
('Toto@gmail.com', '1234', 1, 1), 
('Elepa_roro@gmail.com', '1234', 1, 1), 
('Medic_bom@gmail.com', '1234', 1, 1),
('gonzagomez@yahoo.com', '1234', 1, 1),

('pipi99@yahoo.com', '1234', 1, 2),
('marispert@gmail.com', '1234', 1, 2),
('ejemplo@gmail.com', '1234', 1, 2),
('pedro_escov@gmail.com', '1234', 1, 2),
('delfi_per@yahoo.com.ar', '1234', 1, 2),
('magali1996@gmail.com', '1234', 1, 2),
('caroperez12@gmail.com', '1234', 1, 2),
('DanteClick@gmail.com', '1234', 1, 2),
('ElChanta@gmail.com', '1234', 1, 2),
('pablobonf@yahoo.com.ar', '1234', 1, 2),

('root@root', 'admin', 1, 3)

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
('Daiana','Alfano','Castelli 1539','4563321','19900101','F','6541', 9, 7),
('Gonzalo','gomez','Roca 32312','2312555','19961118','M','3691', 10, 7)

--25 fechas -- a completar
insert into DisponibilidadHoraria (IDMedico, Dia, HorarioInicio, HorarioFin, Estado) values
(1, 'Friday', '12:00:00', '17:00:00', 1),
(1, 'Monday', '12:00:00', '17:00:00', 1),
(2, 'Friday', '16:00:00', '18:00:00', 1),
(2, 'Friday', '09:00:00', '12:00:00', 1),
(3, 'Monday', '09:00:00', '18:00:00', 1),
(3, 'Tuesday', '17:00:00', '22:00:00', 1),
(4, 'Friday', '13:00:00', '20:00:00', 1),
(4, 'Monday', '09:00:00', '12:00:00', 1),
(5, 'Friday', '10:00:00', '13:00:00', 1),
(5, 'Tuesday', '22:00:00', '00:00:00', 1),
(6, 'Friday', '12:00:00', '16:00:00', 1),
(6, 'Monday', '11:00:00', '13:00:00', 1),
(7, 'Tuesday', '12:00:00', '19:00:00', 1),
(7, 'Friday', '08:00:00', '12:00:00', 1),
(7, 'Friday', '17:00:00', '22:00:00', 1),
(8, 'Tuesday', '09:00:00', '12:00:00', 1),
(8, 'Friday', '18:00:00', '22:00:00', 1),
(8, 'Monday', '13:00:00', '18:00:00', 1),
(9, 'Friday', '08:00:00', '12:00:00', 1),
(9, 'Friday', '16:00:00', '20:00:00', 1),
(9, 'Monday', '09:00:00', '13:00:00', 1),
(10, 'Friday', '16:00:00', '22:00:00', 1),
(10, 'Tuesday', '12:00:00', '16:00:00', 1),
(10, 'Monday', '14:00:00', '18:00:00', 1)

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

--turnos 7
insert into Turnos (Fecha, Hora, IDMedico, IDPaciente, Estado) values
('23-10-2021', '13:00:00', 1, 1, 'Agendado'),
('12-11-2021', '12:00:00', 4, 3, 'Agendado'),
('17-12-2021', '12:00:00', 2, 5, 'Agendado'),
('24-09-2021', '12:00:00', 1, 2,'Agendado'),
('12-08-2021', '12:00:00', 7, 3, 'Agendado'),
('13-09-2021', '12:00:00', 3, 7, 'Agendado'),
('08-07-2022', '12:00:00', 2, 4, 'Agendado')

-- TRIGGER PARA QUE CUANDO SE ELIMINA UN PACIENTE SE ELIMINEN SUS TURNOS Y ELIMINA SU USUARIO
GO
CREATE TRIGGER TR_ELIMINAR_MEDICO_TURNO ON MEDICOS
INSTEAD OF DELETE
AS BEGIN
	DECLARE @IDMEDICO INT
	DECLARE @IDUSUARIO INT

	SELECT @IDMEDICO = ID, @IDUSUARIO = IDUsuario FROM DELETED

	DELETE FROM TURNOS WHERE IDMedico IN (SELECT ID FROM DELETED)
	DELETE FROM MEDICOS WHERE ID = @IDMEDICO
	DELETE FROM USUARIOS WHERE ID = @IDUSUARIO

END
GO

-- TRIGGER PARA QUE CUANDO SE ELIMINA UN PACIENTE SE ELIMINEN SUS TURNOS Y ELIMINA SU USUARIO

GO
CREATE TRIGGER TR_ELIMINAR_PACIENTES_TURNO ON PACIENTES
INSTEAD OF DELETE
AS BEGIN
	DECLARE @IDPACIENTE INT
	DECLARE @IDUSUARIO INT

	SELECT @IDPACIENTE = ID, @IDUSUARIO = IDUsuario FROM DELETED

	DELETE FROM TURNOS WHERE IDPaciente IN (SELECT ID FROM DELETED)
	DELETE FROM PACIENTES WHERE ID = @IDPACIENTE
	DELETE FROM USUARIOS WHERE ID = @IDUSUARIO

END

/*

-- Estados de turnos  -->> drop dawn list

insert into EstadoTurno(EstadoTurno) values
('Agendado'),
('Cancelado'),
('Asistido'),
('Reagendado'),
('Ausente')



-- devuelve el nombre en ingles (Lunes, Martes, etc pero en ingles)
select datename(dw,getdate()) 

-- devuelve el nombre en ingles (Lunes, Martes, etc pero en ingles)
select datename(weekday,getdate()) 

-- Creo que obtengo el numero del dia de la semana Domingo = 1 Lunes = 2
select datepart(dw,getdate()) 


*/
