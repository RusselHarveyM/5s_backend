CREATE TABLE [dbo].[Ratings](
    [Id] INT NOT NULL IDENTITY(1,1), 
    [Sort]    FLOAT  ,
    [SetInOrder]    FLOAT  ,
    [Shine]    FLOAT  ,
    [Standarize]    FLOAT  ,
    [Sustain]    FLOAT  ,
    [Security]    FLOAT  ,
    [isActive] BIT,
    [DateModified] DATE,
    [SpaceId] INT,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RatingSpace] FOREIGN KEY ([SpaceId]) REFERENCES [dbo].[Spaces] ([Id]) ON DELETE CASCADE,
);