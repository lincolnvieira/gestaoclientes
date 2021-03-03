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