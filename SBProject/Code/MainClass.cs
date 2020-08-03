using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBProject.Code
{
    class MainClass
    {
        static void Main(string[] args)
        {
            
            // пример 
            // получаем курсы валют на текущую дату, записываем их в локальную БД 
            // и вытаскиваем курс доллара на текущую дату

            // получаем текущую дату
            DateTime dt = DateTime.Now;
            var date = dt.ToString("dd.MM.yyyy");
            ExRateManagement exManagement = new ExRateManagement();

            // получаем список курсов валют
            List<ExchRate> exchRates = exManagement.GetEcxhRate(date);

            // попытка записи курсов валют в локальную БД (если уже есть курсы на текущую дату, то вставка не будет произведена)
            exManagement.WriteRateToDB(exchRates);

            // вытаскиваем из локальной базы курс доллара на текущую дату
            Console.WriteLine(exManagement.GetRateByValDate("usd", date));

            Console.ReadLine();


            // ту же самую процедуру можно сделать для любой другой даты, задав, например, date = 01.01.2019
            // в локальную бд добавятся курсы на эту дату
            

            //======================================================
            //// запись списка валют в БД в таблицу CurrencyTable
            /// (таблица CurrencyTable не используется для получения курса валют)
            /*
            CurrencyManagement curManagement = new CurrencyManagement();
            List<Currency> curList = new List<Currency>();

            curList = curManagement.GetCurrency();

            foreach (var v in curList)
            {
                Console.WriteLine("ID = " + v.Id + "; Name = " + v.ISO_Char_Code);
            }
            Console.ReadLine();
            curManagement.WriteCurrencyToDB(curList);
            */

        }
    }
}
