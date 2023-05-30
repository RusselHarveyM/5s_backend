CREATE TABLE Rooms [dbo].[Rooms](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BuildingId]    INT  ,
    [RoomNumber]    VARCHAR(255) ,
    [Picture]    VARBINARY(MAX) ,
    [Picture]    VARBINARY(MAX) ,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Room] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]) ON DELETE CASCADE,

);