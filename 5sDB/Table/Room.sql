CREATE TABLE [dbo].[Rooms](
    [Id] INT NOT NULL IDENTITY(1,1), 
    [BuildingId]    INT  ,
    [RoomNumber]    VARCHAR(255) UNIQUE,
    [Image] VARBINARY(MAX),
    [Status] NVARCHAR(255),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoomBuilding] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]) ON DELETE CASCADE,
);