-- пример запуска хранимой процедуры ProcedureGetExRate для получения курса доллара 
-- на дату 03.08.2020

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[ProcedureGetExRate]
		@curCode = N'usd',
		@date = N'03.08.2020'

