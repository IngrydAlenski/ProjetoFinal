CREATE TRIGGER trg_audit_catnota
ON categorianotas
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @old NVARCHAR(MAX), @new NVARCHAR(MAX);

	IF EXISTS (SELECT * FROM deleted)
		SELECT @old = (SELECT * FROM deleted FOR JSON AUTO)

	IF EXISTS (SELECT * FROM inserted)
		SELECT @new = (SELECT * FROM inserted FOR JSON AUTO)

	INSERT INTO AuditoriaGeral (NomeTabela, TipoAcao, Usuario, DataAcao, DadosAntigos, DadosNovos)
	VALUES(
		'categorianotas',
		CASE
			WHEN EXISTS (SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
			WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
			WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
		END,
		SUSER_SNAME(),
		SYSDATETIMEOFFSET() AT  TIME ZONE 'E. SOUTH AMERICA STANDARD TIME',
		@old,
		@new

		);
end;

select * from sys.sql_logins

ALTER ROLE db_owner ADD MEMBER anjos;

SELECT 
    dp.name AS Usuario,
    dp.type_desc AS Tipo,
    o.name AS Objeto,
    p.permission_name AS Permissao,
    p.state_desc AS Estado
FROM sys.database_permissions p
JOIN sys.database_principals dp ON p.grantee_principal_id = dp.principal_id
LEFT JOIN sys.objects o ON p.major_id = o.object_id
ORDER BY dp.name, o.name;