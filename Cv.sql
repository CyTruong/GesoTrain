/*
 * =========================================================
 *
 *                       _oo0oo_
 *                      o8888888o
 *                      88" . "88
 *                      (| -_- |)
 *                      0\  =  /0
 *                    ___/`---'\___
 *                  .' \|     |// '.
 *                 / \|||  :  |||// \
 *                / _||||| -:- |||||- \
 *               |   | \\  -  /// |   |
 *               | \_|  ''\---/''  |_/ |
 *               \  .-\__  '-'  ___/-. /
 *             ___'. .'  /--.--\  `. .'___
 *          ."" '<  `.___\_<|>_/___.' >' "".
 *         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *         \  \ `_.   \_ __\ /__ _/   .-` /  /
 *     =====`-.____`.___ \_____/___.-`___.-'=====
 *                       `=---='
 *
 *     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *
 *               Buddha Bless:  "No Bugs Pls"
 *
 * ========================================================= */

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2019 16:38:05
-- Generated from EDMX file: C:\Users\Admin\OneDrive - gm.uit.edu.vn\Workspace .netMvc\GESO_Baitap\web\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CV];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CV_STUDENT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CV_STUDENT];
GO
IF OBJECT_ID(N'[dbo].[FACULTIES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FACULTIES];
GO
IF OBJECT_ID(N'[dbo].[SCHOOL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SCHOOL];
GO
IF OBJECT_ID(N'[dbo].[SKILL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SKILL];
GO
IF OBJECT_ID(N'[dbo].[STATUS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STATUS];
GO
IF OBJECT_ID(N'[dbo].[STUDENT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STUDENT];
GO
IF OBJECT_ID(N'[dbo].[STUDENT_EXPERIENCE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STUDENT_EXPERIENCE];
GO
IF OBJECT_ID(N'[dbo].[STUDENT_SKILL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STUDENT_SKILL];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CV_STUDENT'
CREATE TABLE [dbo].[CV_STUDENT] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [STUDENT_FK] int  NULL,
    [HOBBY] nvarchar(250)  NULL,
    [SPECIAL_SKILLS_TALENTS] nvarchar(250)  NULL
);
GO

-- Creating table 'FACULTIES'
CREATE TABLE [dbo].[FACULTIES] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NAME] nvarchar(50)  NULL,
    [SCHOOL_FK] int  NULL
);
GO

-- Creating table 'SCHOOL'
CREATE TABLE [dbo].[SCHOOL] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NAME] nvarchar(100)  NULL,
    [ADDRESS] nvarchar(200)  NULL,
    [STATUS_FK] int  NOT NULL,
    [CREATE_USER] int  NULL,
    [CREATE_DATE] datetime  NOT NULL,
    [ALTER_USER] int  NULL,
    [ALTER_DATE] datetime  NOT NULL,
    [CODE] nvarchar(20)  NULL,
    [HOUR_ABSENT] nvarchar(20)  NULL,
    [DAY_ABSENT] int  NULL,
    [TYPEOFTRAINING_FK] int  NULL
);
GO

-- Creating table 'SKILL'
CREATE TABLE [dbo].[SKILL] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NAME] nvarchar(50)  NULL
);
GO

-- Creating table 'STATUS'
CREATE TABLE [dbo].[STATUS] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NAME] nvarchar(25)  NULL
);
GO

-- Creating table 'STUDENT'
CREATE TABLE [dbo].[STUDENT] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NAME] nvarchar(100)  NULL,
    [EMAIL] nvarchar(100)  NULL,
    [PHONE] nvarchar(20)  NULL,
    [CLASS_CODE] nvarchar(20)  NULL,
    [SCHOOL_FK] int  NULL,
    [STATUS_FK] int  NULL,
    [CREATE_USER] int  NULL,
    [CREATE_DATE] datetime  NULL,
    [ALTER_USER] int  NULL,
    [ALTER_DATE] datetime  NULL,
    [CODE] nvarchar(50)  NULL,
    [FACULTIES_FK] int  NULL,
    [AVATAR] nvarchar(250)  NULL,
    [GENDER] int  NULL,
    [TRAINING_YEAR_FROM] int  NOT NULL,
    [TRAINING_YEAR_TO] int  NOT NULL,
    [LEVEL] int  NOT NULL
);
GO

-- Creating table 'STUDENT_EXPERIENCE'
CREATE TABLE [dbo].[STUDENT_EXPERIENCE] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [STUDENT_FK] int  NULL,
    [COMPANY_NAME] nvarchar(250)  NULL,
    [TITLE] nvarchar(250)  NULL,
    [FROM_MONTH] int  NULL,
    [TO_MONTH] int  NULL,
    [FROM_YEAR] int  NULL,
    [TO_YEAR] int  NULL,
    [DESCRIPTION_JOB] nvarchar(250)  NULL,
    [SALARY] float  NULL
);
GO

-- Creating table 'STUDENT_SKILL'
CREATE TABLE [dbo].[STUDENT_SKILL] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [STUDENT_FK] int  NOT NULL,
    [SKILL_FK] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'CV_STUDENT'
ALTER TABLE [dbo].[CV_STUDENT]
ADD CONSTRAINT [PK_CV_STUDENT]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FACULTIES'
ALTER TABLE [dbo].[FACULTIES]
ADD CONSTRAINT [PK_FACULTIES]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SCHOOL'
ALTER TABLE [dbo].[SCHOOL]
ADD CONSTRAINT [PK_SCHOOL]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SKILL'
ALTER TABLE [dbo].[SKILL]
ADD CONSTRAINT [PK_SKILL]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'STATUS'
ALTER TABLE [dbo].[STATUS]
ADD CONSTRAINT [PK_STATUS]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'STUDENT'
ALTER TABLE [dbo].[STUDENT]
ADD CONSTRAINT [PK_STUDENT]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'STUDENT_EXPERIENCE'
ALTER TABLE [dbo].[STUDENT_EXPERIENCE]
ADD CONSTRAINT [PK_STUDENT_EXPERIENCE]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'STUDENT_SKILL'
ALTER TABLE [dbo].[STUDENT_SKILL]
ADD CONSTRAINT [PK_STUDENT_SKILL]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Add Data
-- --------------------------------------------------
INSERT dbo.SCHOOL
(
    NAME,
    ADDRESS,
    STATUS_FK,
    CREATE_USER,
    CREATE_DATE,
    ALTER_USER,
    ALTER_DATE,
    CODE,
    HOUR_ABSENT,
    DAY_ABSENT,
    TYPEOFTRAINING_FK
)
VALUES
(   N'UIT',       -- NAME - nvarchar(100)
    N'Thủ Đức',       -- ADDRESS - nvarchar(200)
    0,         -- STATUS_FK - int
    1,         -- CREATE_USER - int
    GETDATE(), -- CREATE_DATE - datetime
    1,         -- ALTER_USER - int
    GETDATE(), -- ALTER_DATE - datetime
    N'KTPM2016',       -- CODE - nvarchar(20)
    N'',       -- HOUR_ABSENT - nvarchar(20)
    0,         -- DAY_ABSENT - int
    1          -- TYPEOFTRAINING_FK - int
    )

INSERT dbo.FACULTIES
(
    NAME,
    SCHOOL_FK
)
VALUES
(   N'Kĩ thuật Phần mềm', -- NAME - nvarchar(50)
    1    -- SCHOOL_FK - int
    )


INSERT dbo.FACULTIES
(
    NAME,
    SCHOOL_FK
)
VALUES
(   N'Khoa học máy tính', -- NAME - nvarchar(50)
    1    -- SCHOOL_FK - int
    )

INSERT dbo.FACULTIES
(
    NAME,
    SCHOOL_FK
)
VALUES
(   N'An ninh mạng', -- NAME - nvarchar(50)
    1    -- SCHOOL_FK - int
    )

INSERT dbo.FACULTIES
(
    NAME,
    SCHOOL_FK
)
VALUES
(   N'Khoa học máy tính', -- NAME - nvarchar(50)
    1    -- SCHOOL_FK - int
    )

INSERT dbo.FACULTIES
(
    NAME,
    SCHOOL_FK
)
VALUES
(   N'Kĩ thuật máy tính', -- NAME - nvarchar(50)
    1    -- SCHOOL_FK - int
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Lãnh đạo' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Thuyết trình' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Quản lý thời gian' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Quản lý công việc' -- NAME - nvarchar(50)
    )
INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Quản lý nhân sự' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Quản lý dự án' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Ra quyết định' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Làm việc nhóm' -- NAME - nvarchar(50)
    )

INSERT dbo.SKILL
(
    NAME
)
VALUES
(N'Quản lý stress' -- NAME - nvarchar(50)
    )


INSERT dbo.STUDENT
(
    NAME,
    EMAIL,
    PHONE,
    CLASS_CODE,
    SCHOOL_FK,
    STATUS_FK,
    CREATE_USER,
    CREATE_DATE,
    ALTER_USER,
    ALTER_DATE,
    CODE,
    FACULTIES_FK,
    AVATAR,
    GENDER,
    TRAINING_YEAR_FROM,
    TRAINING_YEAR_TO,
    LEVEL
)
VALUES
(   N'Phạm Nhật Trường',       -- NAME - nvarchar(100)
    N'1234@gmail.com',       -- EMAIL - nvarchar(100)
    N'0563683819',       -- PHONE - nvarchar(20)
    N'ktpm2016',       -- CLASS_CODE - nvarchar(20)
    1,         -- SCHOOL_FK - int
    0,         -- STATUS_FK - int
    1,         -- CREATE_USER - int
    GETDATE(), -- CREATE_DATE - datetime
    1,         -- ALTER_USER - int
    GETDATE(), -- ALTER_DATE - datetime
    N'',       -- CODE - nvarchar(50)
    1,         -- FACULTIES_FK - int
    N'https://i.imgur.com/TFxmGVu.jpg',       -- AVATAR - nvarchar(250)
    1,         -- GENDER - int
    2016,         -- TRAINING_YEAR_FROM - int
    2020,         -- TRAINING_YEAR_TO - int
    1          -- LEVEL - int
    )
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
