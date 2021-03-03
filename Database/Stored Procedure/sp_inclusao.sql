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