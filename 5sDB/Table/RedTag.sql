CREATE TABLE [dbo].[RedTags](
    [Id] INT NOT NULL IDENTITY(1,1), 
    [ItemName]    VARCHAR(255)  ,
    [Quantity]    INT  ,
    [RoomId]    INT,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RedTagsRoom] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE,

);