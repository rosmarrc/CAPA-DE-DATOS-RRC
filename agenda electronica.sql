CREATE DATABASE agenda electronica

USE agendaelectronica




CREATE TABLE Agenda (
    id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    FechaNacimiento DATE,
    Direccion VARCHAR(100),
    Genero VARCHAR(10),
    EstadoCivil VARCHAR(20),
    Movil VARCHAR(20),
    Telefono VARCHAR(20),
    CorreoElectronico VARCHAR(100)
);

select * from Agenda