
CREATE DATABASE BD_ESTACIONAMIENTO_CM
GO

USE BD_ESTACIONAMIENTO_CM
GO

CREATE SCHEMA Estacionamiento
GO

CREATE TABLE Estacionamiento.TipoVehiculo(
	idTipo INT IDENTITY PRIMARY KEY NOT NULL,
	Nombre VARCHAR (50)
)
GO

CREATE TABLE Estacionamiento.Vehiculo(
	idVehiculo INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Placa VARCHAR(10) NOT NULL,
	idTipo INT NOT NULL REFERENCES Estacionamiento.TipoVehiculo,
	HoraEntrada TIME NOT NULL DEFAULT GETDATE()
)
GO

CREATE TABLE Estacionamiento.Detalle(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idVeiculo INT NOT NULL REFERENCES Estacionamiento.Vehiculo,
	HoraSalida TIME,
	Cobro MONEY
)
GO

CREATE PROC REGISTRO_TIPO_VEHICULO
(
	@nombre VARCHAR(50) OUT
)
AS BEGIN TRANSACTION
BEGIN TRY
	INSERT Estacionamiento.TipoVehiculo VALUES (@nombre)
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION	
END CATCH
GO

CREATE PROC ACTUALIZAR_TIPO_VEHICULO
(
	@id INT,
	@nombre VARCHAR(50) OUT
)
AS BEGIN TRANSACTION
BEGIN TRY
	UPDATE Estacionamiento.TipoVehiculo SET Nombre = @nombre
	WHERE idTipo = @id
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION	
END CATCH
GO

EXEC ACTUALIZAR_TIPO_VEHICULO 1,'PICK UP'
GO
SELECT * FROM Estacionamiento.TipoVehiculo
GO

CREATE PROC REGISTRO_VEHICULO
(
	@Placa VARCHAR(10),
	@idTipo INT OUT
)
AS BEGIN TRANSACTION
BEGIN TRY
	INSERT Estacionamiento.Vehiculo VALUES (@Placa,@idTipo)
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION	
END CATCH
GO

CREATE PROC ACTUALIZAR_VEHICULO
(
	@Id INT,
	@Placa VARCHAR(10),
	@idTipo INT OUT
)
AS BEGIN TRANSACTION
BEGIN TRY
	UPDATE Estacionamiento.Vehiculo SET Placa = @Placa, idTipo = @idTipo
	WHERE idVehiculo = @Id
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION	
END CATCH
GO

EXEC ACTUALIZAR_VEHICULO 1,'HDN0001',3
GO
SELECT * FROM Estacionamiento.Vehiculo
GO

