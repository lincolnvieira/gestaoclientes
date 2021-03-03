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