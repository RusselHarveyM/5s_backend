﻿/*
Deployment script for 5sDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "5sDB"
:setvar DefaultFilePrefix "5sDB"
:setvar DefaultDataPath "/var/opt/mssql/data/"
:setvar DefaultLogPath "/var/opt/mssql/data/"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Table [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [Id]         INT           NOT NULL,
    [FirstName]  VARCHAR (255) NULL,
    [LastName]   VARCHAR (255) NULL,
    [EmployeeId] INT           NULL,
    [Username]   VARCHAR (255) NULL,
    [Password]   VARCHAR (255) NULL,
    [IsAdmin]    BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Update complete.';


GO
