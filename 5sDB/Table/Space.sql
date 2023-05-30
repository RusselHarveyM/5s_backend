CREATE TABLE [dbo].[Spaces](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name]    VARCHAR(255),
    [Pictures]    VARBINARY(MAX),
    [RoomId] INT, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Spaces] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE,
);