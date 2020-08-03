# SBProjectRepo
SB currency exchange rates

Код содержится в папке SBProject/Code
файл основного класса с функцией Main() - MainClass.cs
в функции Main() запускается пример считывания курса валют на текущую дату,
запись курсов валют в локальную БД и, затем, считывание из БД
курса доллара на текущую дату

В папке SBProject/DB находятся скрипты создания таблиц валют и курса валют (dbo.CreateCurrencyTable.sql, dbo.CreateExRateTable.sql), 
а так же процедура, которая вытаскивает значения курса валют из локальной БД по коду валюту и дате (dbo.ProcedureGetExRate.sql)
и пример запуска этой процедуры (RunProcedureGetExRate.sql)
