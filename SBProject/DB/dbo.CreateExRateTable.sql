-- скрипт создания таблицы курсов валют

CREATE TABLE [dbo].[ExRateTable] (
    [Id]       INT         IDENTITY (1, 1) NOT NULL,
    [ValId]    NCHAR (20)  NOT NULL,
    [NumCode]  NCHAR (20)  NULL,
    [CharCode] NCHAR (10)  NOT NULL,
    [Nominal]  INT         NOT NULL,
    [Name]     NCHAR (100) NULL,
    [Value]    FLOAT (53)  NOT NULL,
    [Date]     NCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

