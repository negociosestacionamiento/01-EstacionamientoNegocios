
CREATE DATABASE BD_ESTACIONAMIENTO_CM
GO

USE BD_ESTACIONAMIENTO_CM
GO

CREATE SCHEMA Estacionamiento
GO

CREATE TABLE Estacionamiento.Vehiculo(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	Placa VARCHAR(10) NOT NULL,
	TipoVehiculo VARCHAR(50) NOT NULL,
	HoraEntrada DATETIME
)
GO

CREATE TABLE Estacionamiento.Aparcado(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Nivel INT
)
GO

CREATE TABLE Estacionamiento.Registro(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idVehiculo INT NOT NULL REFERENCES Estacionamiento.Vehiculo,
	idParqueo INT NOT NULL REFERENCES Estacionamiento.Aparcado
)
GO

CREATE TABLE Estacionamiento.Detalle(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idRegistro INT NOT NULL REFERENCES Estacionamiento.Registro,
	HoraSalida DATETIME,
	Cobro MONEY
)
GO

