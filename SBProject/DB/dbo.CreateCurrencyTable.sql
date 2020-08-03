-- скрипт создания таблицы валют

CREATE TABLE [dbo].[CurrencyTable]
(
	[ID] NCHAR(20) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(100) NULL, 
    [EngName] NCHAR(100) NULL, 
    [Nominal] INT NULL, 
    [ParentCode] NCHAR(20) NULL, 
    [ISO_Num_Code] NCHAR(20) NOT NULL, 
    [ISO_Char_Code] NCHAR(20) NOT NULL
)
