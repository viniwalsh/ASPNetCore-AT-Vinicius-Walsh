CREATE TABLE Poder(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Poder NVARCHAR(100) NOT NULL,
	Descricao NVARCHAR(255) NOT NULL,
	HeroiId INT FOREIGN KEY REFERENCES Heroi(Id)
);

SELECT * FROM Heroi;
SELECT * FROM Poder;

INSERT INTO Heroi
	(NomeCompleto, Codinome, ImageURL, Lancamento)
	values ('Bruce Wayne', 'Batman', 'https://upload.wikimedia.org/wikipedia/pt/8/8d/Batman_por_Jim_Lee.jpg','1939-05-01');

INSERT INTO Poder
	(Poder, Descricao, HeroiId)
	values ('Artes Marciais', 'Perito em Artes marciais', 1);

DELETE FROM Poder WHERE Id = 2;
DELETE FROM Heroi WHERE Id = 1;

SELECT * FROM Poder WHERE HeroiId = 1;

SELECT l.Poder, a.Codinome FROM Poder as l
	INNER JOIN Heroi as a
	ON a.Id = l.HeroiId
WHERE a.NomeCompleto = 'Brune Wayne'
