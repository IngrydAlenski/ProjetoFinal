USE MASTER 
--loginbackend ingrid
CREATE LOGIN back_ingrid WITH PASSWORD = 'senha@123';
--userbackend
CREATE USER user_ingrid FOR LOGIN back_ingrid;

--loginbackend marcos
CREATE LOGIN back_marcos WITH PASSWORD = 'senha@123';
--userbackend
CREATE USER user_marcos FOR LOGIN back_marcos;

--front gabriel
CREATE LOGIN front_gabriel WITH PASSWORD = 'senha@123';
--userfrontend
CREATE USER user_gabriel FOR LOGIN front_gabriel;

--front augusto
CREATE LOGIN front_augusto WITH PASSWORD = 'senha@123';
--userfrontend
CREATE USER user_augusto FOR LOGIN front_augusto;

EXEC sp_addrolemember 'db_owner', 'anjos';

select * from sys.sql_logins
--
--criando role backend
CREATE ROLE rolebackend;
--garantindo permissoes
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO rolebackend;
GRANT EXECUTE TO rolebackend;
--adiciona user as roles 
ALTER ROLE rolebackend ADD MEMBER user_ingrid;
ALTER ROLE rolebackend ADD MEMBER user_marcos;

--criando role frontend
CREATE ROLE rolefrontend;
--garantindo permissoes 
GRANT SELECT ON SCHEMA::dbo TO rolefrontend;
GRANT EXECUTE ON SCHEMA::dbo TO rolefrontend;
--adiciona user as roles
ALTER ROLE rolefrontend ADD MEMBER front_gabriel;
ALTER ROLE rolefrontend ADD MEMBER front_augusto;