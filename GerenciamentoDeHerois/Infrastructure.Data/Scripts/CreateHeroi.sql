-- CREATE
-- DROP
-- ALTER TABLE COLUMN

-- DELETE
-- SELECT
-- UPDATE
-- INSERT

-- https://docs.microsoft.com/en-us/sql/t-sql/statements/create-table-transact-sql?view=sql-server-ver15
CREATE TABLE Heroi(
	Id	INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NomeCompleto NVARCHAR(200),
	Codinome NVARCHAR(200),
	ImageURL NVARCHAR(250),
	Lancamento DATETIME2
);

-- https://www.w3schools.com/sql/sql_insert.asp
INSERT INTO Heroi
	(NomeCompleto, Codinome, ImageURL, Lancamento)
	VALUES ('Walsh', 'Master of Bugs', 'https://www.catarseparaevolucao.com/wp-content/uploads/2020/03/WhatsApp-Image-2020-03-21-at-20.17.14-4.jpeg','1994-05-01');

-- https://www.w3schools.com/sql/sql_select.asp
SELECT * FROM Heroi;
SELECT * FROM Heroi WHERE Id = 2;

-- https://www.w3schools.com/sql/sql_delete.asp
DELETE FROM Heroi WHERE Id > 2;
DELETE FROM Heroi WHERE NomeCompleto = 'WalshHero';

-- https://www.w3schools.com/sql/sql_update.asp
UPDATE Heroi
	SET NomeCompleto = 'Walsh', Codinome = 'Mestre dos Bugs'
	WHERE Id = 7;
UPDATE Hero
	Set NomeCompleto = 'MageWalsh', Codinome = 'Mage Of Bugs'
	WHERE Id = 2;

-- https://www.w3schools.com/sql/sql_drop_table.asp
DROP TABLE Heroi;

-- https://www.w3schools.com/sql/sql_alter.asp
ALTER TABLE Heroi
	ALTER COLUMN NomeCompleto NVARCHAR(255);