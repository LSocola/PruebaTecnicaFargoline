CREATE DATABASE SOCOLA_BD
GO

USE SOCOLA_BD
GO

CREATE TABLE Tipo_Documento (

IdDocumento INT IDENTITY NOT NULL PRIMARY KEY,
Descripcion VARCHAR(20) NOT NULL,
)
GO

CREATE TABLE Cliente (

Codigo INT IDENTITY PRIMARY KEY,
Nombre VARCHAR(100) NOT NULL,
Pais VARCHAR(50) NOT NULL,
IdDocumento INT NOT NULL,
NroDocumento VARCHAR(20) NOT NULL UNIQUE
FOREIGN KEY (IdDocumento) REFERENCES Tipo_Documento(IdDocumento)
)
GO

insert into Tipo_Documento values ('DNI')
insert into Tipo_Documento values ('RUC')
insert into Tipo_Documento values ('CARNET EXTRANJERIA')
insert into Cliente (Nombre,Pais,IdDocumento,NroDocumento) values ('Luis Alfredo Sócola Wisa','Uruaguay',1,'48025994')
insert into Cliente (Nombre,Pais,IdDocumento,NroDocumento) values ('FARGOLINE S.A.','Perú',2,'24531682122')
GO

CREATE PROCEDURE SP_Obtener_Cliente
@PI_CODIGO INT
AS
	SELECT c.Codigo,c.Nombre,c.Pais,c.IdDocumento,c.NroDocumento,t.Descripcion
	FROM Cliente c,Tipo_Documento t
	WHERE c.IdDocumento = t.IdDocumento
	AND c.Codigo = @PI_CODIGO
GO

CREATE PROCEDURE SP_Listar_Clientes
AS
	SELECT c.Codigo,c.Nombre,c.Pais,c.IdDocumento,c.NroDocumento,t.Descripcion
	FROM Cliente c,Tipo_Documento t
	WHERE c.IdDocumento = t.IdDocumento
GO

CREATE PROCEDURE SP_Listar_TipoDoc
AS
	SELECT t.IdDocumento, t.Descripcion
	FROM Tipo_Documento t
GO

CREATE PROCEDURE SP_Registrar_Cliente
@PV_NOMBRE VARCHAR(100),
@PV_PAIS VARCHAR(50),
@PI_TIPODOC INT,
@PV_NRODOC VARCHAR(20)
AS
	INSERT INTO Cliente (Nombre,Pais,IdDocumento,NroDocumento) VALUES (@PV_NOMBRE,@PV_PAIS,@PI_TIPODOC,@PV_NRODOC)
GO

CREATE PROCEDURE SP_Eliminar_Cliente
@PI_CODIGO INT
AS
	DELETE FROM CLIENTE  WHERE CODIGO = @PI_CODIGO;
GO


CREATE PROCEDURE SP_Actualizar_Cliente
@PI_CODIGO INT,
@PV_NOMBRE VARCHAR(100),
@PV_PAIS VARCHAR(50),
@PI_TIPODOC INT,
@PV_NRODOC VARCHAR(20)
AS
	UPDATE CLIENTE SET NOMBRE=@PV_NOMBRE,PAIS=@PV_PAIS,IdDocumento=@PI_TIPODOC,NRODOCUMENTO=@PV_NRODOC WHERE CODIGO = @PI_CODIGO
GO

exec SP_Listar_Clientes