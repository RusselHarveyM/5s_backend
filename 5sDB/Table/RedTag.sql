CREATE TABLE [dbo].[RedTags](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName]    VARCHAR(255)  ,
    [Quantity]    INT  ,
    [RoomId]    INT,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RedTags] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE,

);