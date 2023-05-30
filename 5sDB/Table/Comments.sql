﻿CREATE TABLE [dbo].[Comments]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
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
    CONSTRAINT [FK_CommentSpace] FOREIGN KEY ([SpaceId]) REFERENCES [dbo].[Ratings] ([Id]) ON DELETE CASCADE,
)
