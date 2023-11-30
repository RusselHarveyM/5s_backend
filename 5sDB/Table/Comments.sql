CREATE TABLE [dbo].[Comments]
(
	[Id]  INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sort]    VARCHAR(255)  ,
    [SetInOrder]    VARCHAR(255)  ,
    [Shine]    VARCHAR(255)  ,
    [Standarize]    VARCHAR(255)  ,
    [Sustain]    VARCHAR(255)  ,
    [Security]    VARCHAR(255)  ,
    [isActive] BIT,
    [DateModified] DATE,
    [RatingId] INT,
    CONSTRAINT [FK_CommentSpace] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Ratings] ([Id]) ON DELETE CASCADE,
)
