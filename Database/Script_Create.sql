CREATE DATABASE GestaoClientes;
GO
USE GestaoClientes;
GO

CREATE TABLE TipoCliente (
	TipoClienteId INT IDENTITY(1,1),
	Descricao VARCHAR(30) NOT NULL,

	CONSTRAINT PK_TipoCliente_TipoClienteId PRIMARY KEY CLUSTERED (TipoClienteId)
);

CREATE TABLE Situacao (
	SituacaoId INT IDENTITY(1,1),
	Descricao VARCHAR(30) NOT NULL,

	CONSTRAINT PK_Situacao_SituacaoId PRIMARY KEY CLUSTERED (SituacaoId)
);

CREATE TABLE Cliente (
	ClienteId INT IDENTITY(1,1),
	Nome VARCHAR(100) NOT NULL,
	CPF VARCHAR(11),
    mTipoCliente INT NOT NULL,
	Sexo CHAR(1) NOT NULL,
	mSituacao INT NOT NULL,
	
	CONSTRAINT PK_Cliente_ClienteId_CPF            PRIMARY KEY CLUSTERED (ClienteId,CPF),
	CONSTRAINT FK_Cliente_TipoCliente_mTipoCliente FOREIGN KEY (mTipoCliente) REFERENCES TipoCliente(TipoClienteId),
	CONSTRAINT FK_Cliente_Situacao_mSituacao       FOREIGN KEY (mSituacao)    REFERENCES Situacao(SituacaoId)
);

INSERT INTO TipoCliente VALUES('BASICO');
INSERT INTO TipoCliente VALUES('INTERMEDIARIO');
INSERT INTO TipoCliente VALUES('PREMIUM');

INSERT INTO Situacao VALUES('ATIVO');
INSERT INTO Situacao VALUES('INATIVO');

GO
CREATE PROCEDURE sp_inclusao 
(
	@nome VARCHAR(100),
	@cpf  VARCHAR(11),
    @tipoCliente INT,
	@sexo CHAR,
	@situacao INT,
	@status INT OUTPUT
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Cliente WHERE CPF = @cpf)
	BEGIN
		INSERT INTO	Cliente (Nome, CPF, mTipoCliente, Sexo,mSituacao)
		VALUES (@nome, @cpf, @tipoCliente, @sexo, @situacao)

		SELECT @status = 1
	END 
	ELSE
	BEGIN
		SELECT @status = 2
	END
END;

GO
CREATE PROCEDURE sp_alteracao 
(
	@ID INT,
	@nome VARCHAR(100),
	@cpf  VARCHAR(11),
    @tipoCliente INT,
	@sexo CHAR,
	@situacao INT, 
	@status INT OUTPUT
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Cliente WHERE CPF = @cpf AND ClienteId <> @ID)
	BEGIN
		UPDATE Cliente 
		SET 
			Nome = @nome, 
			CPF = @cpf, 
			mTipoCliente = @tipoCliente, 
			Sexo = @sexo,
			mSituacao = @situacao
		WHERE 
			ClienteId = @ID

		SELECT @status = 1
	END 
	ELSE
	BEGIN
		SELECT @status = 2
	END 
END;

GO
CREATE PROCEDURE sp_exclusao 
(
	@ID INT, 
	@status INT OUTPUT
)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Cliente WHERE ClienteId = @ID)
	BEGIN
		DELETE FROM  Cliente WHERE ClienteId = @ID
		SELECT @status = 4
	END
	ELSE
	BEGIN
		SELECT @status = 2
	END
END;

GO
CREATE PROCEDURE sp_buscar
(
	@ID INT 
)
AS
BEGIN
	SELECT * FROM Cliente WHERE ClienteId = @ID
END;

GO
CREATE PROCEDURE sp_listagem 
AS
BEGIN
	SELECT 
		C.ClienteId,
		c.Nome,
		c.CPF,
		tp.Descricao AS TipoCliente,
		CASE 
			WHEN c.Sexo = 'F' 
			THEN
				'Feminino'
			ELSE
				'Masculino'
		END AS Sexo,
		s.Descricao AS Situacao
	FROM
		Cliente c
	INNER JOIN TipoCliente tp ON c.mTipoCliente = tp.TipoClienteId
	INNER JOIN Situacao s ON c.mSituacao = s.SituacaoId
END;

GO
CREATE PROCEDURE sp_listarTipoCliente 
AS
BEGIN
	BEGIN
		SELECT * FROM TipoCliente
	END 
END;

GO
CREATE PROCEDURE sp_listarSituacao 
AS
BEGIN
	BEGIN
		SELECT * FROM Situacao
	END 
END;