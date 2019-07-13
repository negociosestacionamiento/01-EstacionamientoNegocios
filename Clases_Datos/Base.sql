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
	HoraEntrada TIME(0) NOT NULL DEFAULT GETDATE()
)
GO

CREATE TABLE Estacionamiento.Detalle(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idVehiculo INT NOT NULL REFERENCES Estacionamiento.Vehiculo,
	HoraSalida TIME(0),
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

EXEC REGISTRO_TIPO_VEHICULO 'Individual'
GO
EXEC REGISTRO_TIPO_VEHICULO 'Ligero'
GO
EXEC REGISTRO_TIPO_VEHICULO 'Pesado'
GO
SELECT * FROM Estacionamiento.TipoVehiculo
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

EXEC ACTUALIZAR_TIPO_VEHICULO 1,'Individual'
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
	INSERT Estacionamiento.Vehiculo VALUES (@Placa,@idTipo,getDate())
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION	
END CATCH
GO

EXEC REGISTRO_VEHICULO 'BAA0001',1
GO
EXEC REGISTRO_VEHICULO 'HAB2649',2
GO
EXEC REGISTRO_VEHICULO 'BAB2005',3
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


CREATE PROC SP_DeplegarTipoVehiculo
AS BEGIN
	SELECT idTipo AS ID, Nombre FROM [Estacionamiento].[TipoVehiculo] 
END
GO

EXEC SP_DeplegarTipoVehiculo
GO

CREATE PROC SP_DesplegarEstacionamientoVehiculo
AS BEGIN
	SELECT idVehiculo AS ID, Placa, HoraEntrada AS Hora_de_entrada, Nombre AS Tipo_de_vehiculo FROM [Estacionamiento].[Vehiculo] INNER JOIN [Estacionamiento].[TipoVehiculo] 
	ON [Estacionamiento].[Vehiculo].[idTipo]=[Estacionamiento].[TipoVehiculo].[idTipo]
END
GO

EXEC SP_DesplegarEstacionamientoVehiculo
GO

CREATE PROC SP_DesplegarEstacionamientoDetalle
AS BEGIN
	SELECT        Estacionamiento.Vehiculo.Placa, Estacionamiento.Vehiculo.HoraEntrada AS Hora_de_entrada, Estacionamiento.TipoVehiculo.Nombre AS Tipo_de_vehiculo, Estacionamiento.Detalle.HoraSalida AS Hora_de_salida, 
                         Estacionamiento.Detalle.Cobro
FROM            Estacionamiento.Detalle INNER JOIN
                         Estacionamiento.Vehiculo ON Estacionamiento.Detalle.idVehiculo = Estacionamiento.Vehiculo.idVehiculo INNER JOIN
                         Estacionamiento.TipoVehiculo ON Estacionamiento.Vehiculo.idTipo = Estacionamiento.TipoVehiculo.idTipo
						 END

EXEC SP_DesplegarEstacionamientoDetalle
GO

