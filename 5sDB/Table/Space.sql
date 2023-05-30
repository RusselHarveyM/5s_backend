CREATE TABLE [dbo].[Spaces](
    [Id] INT NOT NULL IDENTITY(1,1), 
    [Name]    VARCHAR(255),
    [Pictures]    VARBINARY(MAX),
    [RoomId] INT, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SpacesRoom] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE,
);