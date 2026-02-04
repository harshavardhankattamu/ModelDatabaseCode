
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/22/2026 12:35:59
-- Generated from EDMX file: C:\Users\kattamudi.h\source\repos\adodemo\ModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Filmdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DepartmentEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_DepartmentEmployee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Films]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Films];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Films'
CREATE TABLE [dbo].[Films] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Actor] nvarchar(max)  NOT NULL,
    [Actress] nvarchar(max)  NOT NULL,
    [Director] nvarchar(max)  NOT NULL,
    [YOR] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [depid] int  NOT NULL,
    [deptname] varchar(50)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [empid] int IDENTITY(1,1) NOT NULL,
    [EmpName] varchar(20)  NOT NULL,
    [salary] int  NOT NULL,
    [depid] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Custid] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Customer1'
CREATE TABLE [dbo].[Customer1] (
    [Custid] int IDENTITY(1,1) NOT NULL,
    [Custname] nvarchar(max)  NOT NULL,
    [address] int  NOT NULL,
    [location] geography  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Films'
ALTER TABLE [dbo].[Films]
ADD CONSTRAINT [PK_Films]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [depid] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([depid] ASC);
GO

-- Creating primary key on [empid] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([empid] ASC);
GO

-- Creating primary key on [Custid] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Custid] ASC);
GO

-- Creating primary key on [Custid] in table 'Customer1'
ALTER TABLE [dbo].[Customer1]
ADD CONSTRAINT [PK_Customer1]
    PRIMARY KEY CLUSTERED ([Custid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [depid] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([depid])
    REFERENCES [dbo].[Departments]
        ([depid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[Employees]
    ([depid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------