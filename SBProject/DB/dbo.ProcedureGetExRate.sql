-- процедура получение курса валюты по коду валюты и дате
-- на вход подаются параметры: код валюты, дата курса (в текстовом виде dd.mm.yyyy)
-- на выходе получаем курс валюты с типом Float

CREATE PROCEDURE [dbo].[ProcedureGetExRate]
	@curCode NVARCHAR(10),
	@date NVARCHAR(10)
AS
	declare @value Float
	SELECT @value = round(Value, 4) from [dbo].ExRateTable exRate
	where exRate.CharCode = @curCode and exRate.Date = @date
Select @value as ReturnValue