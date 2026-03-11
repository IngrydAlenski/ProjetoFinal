--auditoria
--limitar somente para acesso ao administrador sysadmin
--tabela geral de auditoria


--PASSO 01
CREATE TABLE AuditoriaGeral (
	IdAuditoria INT PRIMARY KEY IDENTITY,
	NomeTabela VARCHAR(100),
	TipoAcao VARCHAR(100),
	Usuario VARCHAR(100),
	DataAcao DATETIME,
		DadosAntigos NVARCHAR(MAX),
	DadosNovos NVARCHAR(MAX)
);
select * from sys.sql_logins
--2 PASSO CRIACAO DAS TRIGGERS
CREATE TRIGGER trg_audit_usuario
ON usuario
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
		'Usuario',
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








