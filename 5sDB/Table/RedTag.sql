CREATE TABLE RedTags [dbo].[RedTags](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName]    VARCHAR(255)  ,
    [ItemNumber]    INT  ,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RedTags] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id]) ON DELETE CASCADE,

);