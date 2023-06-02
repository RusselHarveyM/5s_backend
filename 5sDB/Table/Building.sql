CREATE TABLE [dbo].[Building] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BuildingName]    VARCHAR(255)  NOT NULL UNIQUE,
    [Buildingcode]      VARCHAR(255)  NOT NULL UNIQUE,
    [Image] VARBINARY(MAX)
);