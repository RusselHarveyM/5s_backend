CREATE TABLE Spaces [dbo].[Spaces](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]    VARCHAR(255),
    [Picture]    VARBINARY(MAX),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Spaces] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id]) ON DELETE CASCADE,

);