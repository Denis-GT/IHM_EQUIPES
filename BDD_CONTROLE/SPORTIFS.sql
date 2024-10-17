CREATE TABLE [dbo].[SPORTIFS]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	Nom varchar(32),
	NumAdherent varchar(20), 
	Equipe_Id int NULL,
    CONSTRAINT [R_SPORTIF_EQUIPE] FOREIGN KEY ([Equipe_Id]) REFERENCES EQUIPES(Id),		
)
