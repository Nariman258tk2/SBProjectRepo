using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SBProject.Code
{
    public class ExRateManagement
    {

        public List<ExchRate> GetEcxhRate(string dateTxt)
        {
            //string dateTxt = 
            string url = @"http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + dateTxt;
            XDocument xdoc = XDocument.Load(url);

            ExchRate exRate = null;
            List<ExchRate> exRateList = new List<ExchRate>();

            foreach (var elms in xdoc.Descendants("ValCurs").Elements())
            {

                if (elms.Name == "Valute")
                {
                    exRate = new ExchRate();
                    exRate.ValId = elms.Attribute("ID").Value;
                    exRate.Date = dateTxt;

                    if (elms.HasElements)
                    {

                        foreach (var element in elms.Elements())
                        {
                            switch (element.Name.ToString())
                            {
                                case "NumCode":
                                    exRate.NumCode = element.Value;
                                    break;

                                case "CharCode":
                                    exRate.CharCode = element.Value;
                                    break;

                                case "Nominal":
                                    exRate.Nominal = Int32.Parse(element.Value);
                                    break;

                                case "Name":
                                    exRate.Name = element.Value;
                                    break;

                                case "Value":
                                    exRate.Value = Convert.ToDouble(element.Value);
                                    break;
                            }
                        }
                        exRateList.Add(exRate);
                        exRate = null;
                    }
                }
            }
            return (exRateList);
        }

        public bool WriteRateToDB(List<ExchRate> exchRateList)
        {
            // получаем первый элемент в списке курсов, берем из него дату
            String date = exchRateList.FirstOrDefault(k => k.Date == k.Date).Date;

            string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#\\SBProject\\SBProject\\ExRateSB.mdf;Integrated Security=True";
            DataContext db = new DataContext(conString);

            Table<ExchRate> rates = db.GetTable<ExchRate>();

            // проверяем, если в базе уже есть элементы с такой датой, тогда выходим из функции (вставку в базу не производим)
            if (db.GetTable<ExchRate>().Any(t => t.Date == date))
                return false;

            // выполняем вставку курсов в таблицу ExRateTable
            foreach (var v in exchRateList)
            {
                db.GetTable<ExchRate>().InsertOnSubmit(v);
                db.SubmitChanges();
            }

            return true;
        }


        // возвращает курс валюты по коду валюты и дате
        public double GetRateByValDate(string curCode, string date)
        {
            string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#\\SBProject\\SBProject\\ExRateSB.mdf;Integrated Security=True";
            DataContext db = new DataContext(conString);
            Table<ExchRate> rates = db.GetTable<ExchRate>();

            var q = db.GetTable<ExchRate>().Where(t => t.Date == date && t.CharCode == curCode).FirstOrDefault();

            if (q != null)
                return q.Value;

            return 0;
        }


        // TEST
        public void GetRatesFromDB()        // for testing
        {
            string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#\\SBProject\\SBProject\\ExRateSB.mdf;Integrated Security=True";
            DataContext db = new DataContext(conString);
            Table<ExchRate> rates = db.GetTable<ExchRate>();

            foreach (var v in rates)
            {
                Console.WriteLine(v.Name + "; " + v.Value + "; " + v.Date);
            }

        }

    }
    
}
