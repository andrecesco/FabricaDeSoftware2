CREATE DATABASE BaseFabricaDeSoftware;

DECLARE @IdConfiguracao uniqueidentifier = NEWID();
DECLARE @IdUsuario uniqueidentifier = NEWID();

CREATE TABLE Usuario
(
	Id uniqueidentifier,
	NomeCompleto varchar(200),
	Email varchar(200),
	Telefone varchar(200),
	DataCadastro datetime,
	DataAlteracao datetime null,
	PRIMARY KEY (Id)
)

INSERT INTO Usuario VALUES(@IdUsuario, 'André Cesconetto', 'abcesconetto@gmail.com', '41 98856-6645', GETDATE(), NULL)

CREATE TABLE Configuracao
(
	Id uniqueidentifier,
	IdUsuario uniqueidentifier,
	DistanciaMaximaDaReta decimal(10,2),
	DistanciaMaximaEntrePilares decimal(10,2),
	DataAlteracao datetime,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
)

INSERT INTO Configuracao VALUES(@IdConfiguracao, @IdUsuario, 10, 3, GETDATE())

CREATE TABLE Calculo
(
	Id uniqueidentifier,
	IdConfiguracao uniqueidentifier,
	IdUsuario uniqueidentifier,
	DistanciaDaReta decimal(10,2),
	QuantidadeDePilares int,
	QuantidadeDePilaresReforcados int,
	PilaresComBaseReforcada varchar(50),
	DistanciaEntreVaos decimal(10,2),
	DataCadastro datetime,
	DataDelecao datetime null,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdConfiguracao) REFERENCES Configuracao(Id),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
)

CREATE TABLE FilaCalculo
(
	Id uniqueidentifier,
	IdConfiguracao uniqueidentifier,
	IdUsuario uniqueidentifier,
	DistanciaDaReta decimal(10,2),
	QuantidadeDePilares int,
	QuantidadeDePilaresReforcados int,
	PilaresComBaseReforcada varchar(50),
	DistanciaEntreVaos decimal(10,2),
	DataCadastro datetime
	PRIMARY KEY (Id),
	FOREIGN KEY (IdConfiguracao) REFERENCES Configuracao(Id),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
)

INSERT INTO Calculo VALUES(NEWID(), @IdConfiguracao, @IdUsuario, 11, 5, 3, '1, 4, 5', 2.75, GETDATE(), NULL)
INSERT INTO Calculo VALUES(NEWID(), @IdConfiguracao, @IdUsuario, 17, 7, 3, '1, 4, 7', 2.83, GETDATE(), NULL)