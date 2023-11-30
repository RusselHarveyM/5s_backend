CREATE TABLE [dbo].[SpaceImage]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [SpaceId] INT NOT NULL,
    [Image] VARBINARY(MAX) NOT NULL,
    [UploadedDate] DATE NOT NULL,
    
    CONSTRAINT FK_SpaceImage_Space FOREIGN KEY ([SpaceId]) REFERENCES [dbo].[Spaces]([Id])
)
