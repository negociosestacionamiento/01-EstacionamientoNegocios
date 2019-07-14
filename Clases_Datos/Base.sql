CREATE DATABASE BD_ESTACIONAMIENTO_CM
GO

USE BD_ESTACIONAMIENTO_CM
GO

CREATE SCHEMA Estacionamiento
GO

--Crear tablas
CREATE TABLE Estacionamiento.TipoVehiculo(
	idTipo INT IDENTITY PRIMARY KEY NOT NULL,
	Nombre VARCHAR (50)
)
GO

CREATE TABLE Estacionamiento.Vehiculo(
	idVehiculo INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Placa VARCHAR(7) NOT NULL,
	idTipo INT NOT NULL REFERENCES Estacionamiento.TipoVehiculo
)
GO

CREATE TABLE Estacionamiento.Detalle(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idVehiculo INT NOT NULL REFERENCES Estacionamiento.Vehiculo,
	HoraEntrada TIME(0) NOT NULL DEFAULT GETDATE(),
	HoraSalida TIME(0) NOT NULL DEFAULT GETDATE()
	
)
GO

--Stores procedures de ingreso

CREATE PROC SP_Registro_Tipo_Vehiculo
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

EXEC SP_Registro_Tipo_Vehiculo 'Individual'
GO
EXEC SP_Registro_Tipo_Vehiculo 'Ligero'
GO
EXEC SP_Registro_Tipo_Vehiculo 'Pesado'
GO
SELECT * FROM Estacionamiento.TipoVehiculo
GO



CREATE PROC SP_Ingreso_Vehiculo
@Placa VARCHAR(8),
@idTipo INT 
AS
DECLARE @idVehiculo INT
BEGIN TRANSACTION
	--Si no exite el vehiculo entonces lo ingresa e inserta la fecha en hora entrada dentro de estacionamiento detalle
	IF NOT EXISTS(SELECT * FROM Estacionamiento.Vehiculo WHERE Placa=@Placa)
		BEGIN
			INSERT INTO Estacionamiento.Vehiculo(idTipo,Placa) VALUES(@idTipo,@Placa)
			SELECT @idVehiculo = idVehiculo FROM Estacionamiento.Vehiculo WHERE Placa = @Placa
			INSERT INTO Estacionamiento.Detalle (idVehiculo,HoraEntrada) VALUES (@idVehiculo,GETDATE())
		END
	ELSE
		BEGIN
			--Si existe entonces despliega el vehiculo que ya a sido ingresado con anterioridad 
			SELECT @idVehiculo = idVehiculo FROM Estacionamiento.Vehiculo WHERE Placa = @Placa AND idTipo=@idTipo
			
			--Si no se encuentra dentro del estacionamiento entonces se ingresa al estaciomaniento el vehiculo ya existente
			IF NOT EXISTS(SELECT * FROM Estacionamiento.Detalle INNER JOIN Estacionamiento.Vehiculo
			ON [Estacionamiento].[Detalle].[idVehiculo]=[Estacionamiento].[Vehiculo].[idVehiculo] WHERE [Estacionamiento].[Detalle].[idVehiculo] = @idVehiculo AND [Estacionamiento].[Vehiculo].[idTipo] = @idTipo
			AND [Estacionamiento].[Detalle].[HoraEntrada] IS NULL)
				BEGIN
					INSERT INTO Estacionamiento.Detalle (idVehiculo,HoraEntrada) VALUES (@idVehiculo,GETDATE())
				END
		END
COMMIT TRANSACTION
GO

EXEC SP_Ingreso_Vehiculo 'DTP1234',1
GO
EXEC SP_Ingreso_Vehiculo 'TPE1634',2
GO
EXEC SP_Ingreso_Vehiculo 'HTR3521',3
GO



CREATE PROC SP_Ingresar_Vehiculo_Detalle
	@idVehiculo INT 

	AS 	DECLARE	@Dnulo CHAR(10)
	BEGIN TRANSACTION

	--Verificamos que su hora de salida sea nula
	SELECT @Dnulo = [HoraSalida] FROM [Estacionamiento].[Detalle] WHERE idVehiculo = @idVehiculo
	--Actualizamos la hora de salida
	UPDATE [Estacionamiento].[Detalle] SET [HoraSalida] = GETDATE() WHERE idVehiculo = @idvehiculo
		BEGIN
			ROLLBACK
		END
GO


EXEC SP_Ingresar_Vehiculo_Detalle 1
GO
EXEC SP_Ingresar_Vehiculo_Detalle 2
GO
EXEC SP_Ingresar_Vehiculo_Detalle 3
GO

--Stored procedures de visualizacion


CREATE PROC SP_DeplegarTipoVehiculo
AS BEGIN
	SELECT idTipo, Nombre FROM Estacionamiento.TipoVehiculo
END
GO

EXEC SP_DeplegarTipoVehiculo
GO

CREATE PROC SP_DesplegarEstacionamientoVehiculo
AS BEGIN
	SELECT        Estacionamiento.Vehiculo.idVehiculo, Estacionamiento.Vehiculo.Placa, Estacionamiento.TipoVehiculo.Nombre AS Nombre_Tipo
FROM            Estacionamiento.Vehiculo INNER JOIN
                         Estacionamiento.TipoVehiculo ON Estacionamiento.Vehiculo.idTipo = Estacionamiento.TipoVehiculo.idTipo
END
GO

EXEC SP_DesplegarEstacionamientoVehiculo
GO

CREATE PROC SP_DesplegarEstacionamientoDetalle_Cobro
@idVehiculo INT 
AS	
DECLARE	@total DECIMAL(10,2),
				@Horas INT = 0,
				@Minutos INT = 0,
				@Tipo NVARCHAR(20),
				@Dnulo CHAR(10)
	BEGIN TRANSACTION 

SELECT @Horas = DATEDIFF(MINUTE,[HoraEntrada],[HoraSalida])/60 
	FROM [Estacionamiento].[Detalle] WHERE idVehiculo=@IdVehiculo
	--Obtenemos los minutos
	SELECT @Minutos = DATEDIFF(MINUTE,[HoraEntrada],[HoraSalida])%60 
	FROM [Estacionamiento].[Detalle] WHERE idVehiculo=@IdVehiculo

	--Obtenemos el tipo de vehiculo
	SELECT @Tipo = Nombre FROM [Estacionamiento].[TipoVehiculo] INNER JOIN [Estacionamiento].[Vehiculo]
	ON [Estacionamiento].[TipoVehiculo].[idTipo] = [Estacionamiento].[Vehiculo].[idTipo]
	INNER JOIN [Estacionamiento].[Detalle]
	ON [Estacionamiento].[Vehiculo].[idVehiculo] = [Estacionamiento].[Detalle].[idVehiculo] WHERE [Estacionamiento].[Detalle].[idVehiculo] = @IdVehiculo
	--Condiciones para realizar el cobro de acuerdo a la cantidad de horas
	IF((@Horas=0 AND @Minutos<=59) OR (@Horas=1 AND @Minutos=0) OR (@Horas=0 AND @Minutos = 0 ))
	BEGIN
		SET @total=20
	END
	ELSE IF((@Horas=1 AND @Minutos<=59) OR (@Horas=2 AND @Minutos=0))
	BEGIN
		SET @total=20+10
	END
	ELSE IF((@Horas=2 AND @Minutos<=59) OR (@Horas=3 AND @Minutos=0))
	BEGIN
		SET @total=20*3
	END
	ELSE IF((@Horas=3 AND @Minutos<=59) OR (@Horas=4 AND @Minutos=0))
	BEGIN
		SET @total=(20*3)+10
	END
	ELSE IF(@Horas>=4)
	BEGIN
		SET @total=15*@Horas
	END


	--Cobro segun tipo de vehiculo

	IF(@Tipo='Pesado')
		BEGIN
			SET @total=@total*2
		END

	IF(@Tipo='Individual')
		BEGIN
			SET @total=@total*0.5
		END

SELECT        Estacionamiento.Vehiculo.Placa, Estacionamiento.Detalle.HoraEntrada AS Hora_de_entrada, Estacionamiento.Detalle.HoraSalida AS Hora_de_salida, 
                         CAST(@Horas as CHAR(1)) +':'+ CAST(@Minutos as CHAR(2)) AS TIEMPO,  +'$.'+CAST (@total AS char)  AS TOTAL, CAST (@Tipo AS NVARCHAR) AS TIPO
FROM            Estacionamiento.Detalle INNER JOIN
                         Estacionamiento.Vehiculo ON Estacionamiento.Detalle.idVehiculo = Estacionamiento.Vehiculo.idVehiculo INNER JOIN
                         Estacionamiento.TipoVehiculo ON Estacionamiento.Vehiculo.idTipo = Estacionamiento.TipoVehiculo.idTipo WHERE Estacionamiento.Detalle.idVehiculo = @idVehiculo 

	IF(@Dnulo IS NULL)
		BEGIN
			COMMIT 
		END
	ELSE
		BEGIN
			ROLLBACK
		END
GO

EXEC SP_DesplegarEstacionamientoDetalle_Cobro 1
GO
EXEC SP_DesplegarEstacionamientoDetalle_Cobro 2
GO
EXEC SP_DesplegarEstacionamientoDetalle_Cobro 3
GO

