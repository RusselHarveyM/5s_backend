CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sort]    FLOAT  ,
    [SetInOrder]    FLOAT  ,
    [Shine]    FLOAT  ,
    [Standarize]    FLOAT  ,
    [Sustain]    FLOAT  ,
    [Security]    FLOAT  ,
    [isActive] BIT,
    [DateModified] DATE,
    [RatingId] INT,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comment] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Ratings] ([Id]) ON DELETE CASCADE,
)
