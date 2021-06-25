USE MASTER
CREATE DATABASE Mediturnos
GO

USE Mediturnos

GO

CREATE TABLE Usuarios(
	ID INT PRIMARY KEY NOT NULL identity(1,1),
	Email VARCHAR(250) UNIQUE NOT NULL,
	Contasena Varchar(50) NOT NULL,
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
	IDObraSocial INT Foreign key references ObrasSociales(ID) NOT NULL,
	Apellido VARCHAR(100) NOT NULL, 
	Nombre VARCHAR(100) NOT NULL,
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    NroAfiliado varchar (40) NULL,
	Estado bit not null,
	IDUsuario INT not null Foreign key references Usuarios(ID)
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
	Estado bit not null
)
GO

CREATE TABLE Turnos(
  ID INT Primary Key Not null identity(1,1),
  FechaHora DATETIME NOT NULL CHECK (FechaHora > GETDATE()),
  IDMedico INT NOT NULL FOREIGN KEY REFERENCES Medicos(ID),
  IDPaciente INT NOT NULL FOREIGN KEY REFERENCES Pacientes(ID),
  Estado BIT not null,
)

-- #############
-- ## DATOS ####
-- #############

Set dateformat 'DMY'

/* PACIENTES */
INSERT INTO Pacientes([ID], [Apellido], [Nombre], [FechaNacimiento],[Domicilio],[EMail], [Celular], [Genero], [NroAfiliado], [ObraSocial], [Estado]) VALUES(1,'Maldonado','Alejandro','24/03/1994', 'Av. Cordoba 2345', 'aleejo@lorenita.com', '118765555', 'M', '123444', 'Swiss Medical', 1),(2,'Guevara','Marcelo','24/05/1984', 'Av. Maipu 2355', 'marcelo@gachate.com', '118556677', 'M', '32444', 'OSDE', 1),(3,'Armandinho','Favelo','09/01/1974', 'Av. Brasil 4345', 'clarao@llalaa.com', '118737895', 'M', '54321', 'DOSUBA', 1),(4,'Marcowick', 'Maria Elena','14/09/1991', 'Av. Las Perlas 6345', 'marialespe@tequiero.com', '11845325', 'F', '87234', 'GALENO', 1),(5,'Perez','Carmela','29/05/1955', 'Av. Santa fe 5435', 'carmelita@alguna.com', '1156783322', 'F', '998742', 'Swiss Medical', 1),(6,'Maldonado','Alejandro','24/03/1994', 'Av. Cordoba 2345', 'aleejo@lamorenita.com', '118765555', 'M', '123444', 'Swiss Medical', 1),(7,'Marengo','Johny','12/03/1995', 'Av. Nidea 6645', '', '117886545', 'M', '5434441', 'Encubreti', 1),(8,'Rolando','Alberto Fasito','30/03/1964', 'Av. Siempreviva 2222', 'alegre@siempre.com', '112223334', 'M', '776655', 'Swiss Medical', 1),(9,'Gomez','Gabriela','11/03/1944', 'Av. Cordoba 1111', 'gaby_99@alexandria.com', '114433223', 'F', '322133', 'DOSUBA', 1),(10,'Ramirez','Gerarda Romula','22/02/1997', 'Rotarix 1111', 'Gerard@general.com', '112398675', 'O', '454343', 'OSDE', 1);
/* MEDICOS */
INSERT INTO Medicos([ID],[Nombre],[Apellido],[FechaNacimiento],[Domicilio],[EMail], [Celular], [Genero], [NroMatricula], [Especialidad], [Estado]) VALUES(1,'Quiroga','Horacio','14/03/1954', 'Av. Cordoba 1111', 'Hor_q@libros.com.ar', '1129098765', 'M', '12345', 'Clinico', 1),(2,'Funes','Alejandro','12/03/1964', 'Av. Coronel Diaz 2345', 'funes@elmemorioso.com', '112365478', 'M', '222222', 'Psiquiatria', 1),(3,'Maldonado','Alejandro','24/03/1994', 'Av. Radiografo 2345', 'tecuro@tetrato.com', '1144337898', 'M', '444444', 'Traumatologia', 1),(4,'De Arco','Juana','01/01/1966', 'Av. Las Batallas 6777', 'juanita@tecacha.com', '11345678', 'F', '55555', 'Cardiologia', 1),(5,'Mercolario','Marian','24/03/1955', 'Loquesea 1322', 'marinero@lala.com', '1123433322', 'M', '667767', 'Urologia', 1),(6,'Rucci','Paola','24/07/1978', 'Av. Sueños 2222', 'lamdeci@salvadora.com', '1122987456', 'F', '888776', 'Neurologia', 1);
/* TURNOS */
INSERT INTO Turnos([FechaHora],[IDMedico],[IDPaciente], [Estado]) VALUES('01/07/2020 07:40',1,1, 1),('01/07/2021 17:40',2,2, 1),('01/05/2020 18:30',3,3, 1),('04/04/2020 10:40',4,4, 1),('01/01/2021 11:20',1,1, 1),('01/11/2021 09:40',1,5, 1),('11/09/2021 16:30',2,7, 1),('01/08/2021 13:20',3,8, 1),('22/09/2022 13:40',4,10, 1),('19/11/2021 11:40',5,9, 1);


--update Medicos set Estado = 1 where ID = 1

--update Turno set estado = 1 where ID= 1

update Turno set IDMedico= 22, IDPaciente= 33, Estado = true where
