
CREATE DATABASE Sanchez_Arostegui_Olsavsky_DB
GO
use Sanchez_Arostegui_Olsavsky_DB
go


CREATE TABLE Pacientes(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL, 
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	EMail VARCHAR(250) UNIQUE NULL,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    NroAfiliado varchar (40) NULL,
    ObraSocial VARCHAR(100) NOT NULL,
	CONSTRAINT CHK_EMailCelular CHECK(EMail IS NOT NULL OR Celular IS NOT NULL),
)
GO
