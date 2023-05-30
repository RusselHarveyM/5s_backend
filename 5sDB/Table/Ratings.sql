CREATE TABLE Ratings [dbo].[Ratings](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sort]    FLOAT  ,
    [SetInOrder]    FLOAT  ,
    [Shine]    FLOAT  ,
    [Standarize]    FLOAT  ,
    [Sustain]    FLOAT  ,
    [Security]    FLOAT  ,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rating] FOREIGN KEY ([SpaceId]) REFERENCES [dbo].[Space] ([Id]) ON DELETE CASCADE,
);