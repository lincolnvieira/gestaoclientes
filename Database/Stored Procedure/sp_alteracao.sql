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