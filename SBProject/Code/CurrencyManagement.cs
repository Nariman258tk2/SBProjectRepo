using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SBProject.Code
{
    public class CurrencyManagement
    {
        public List<Currency> GetCurrency()
        {
            string url = @"http://www.cbr.ru/scripts/XML_valFull.asp";
            XDocument xdoc = XDocument.Load(url);

            Currency currency = null;
            List<Currency> currencyList = new List<Currency>();

            foreach (var elms in xdoc.Descendants("Valuta").Elements())
            {
                if (elms.Name == "Item")
                {
                    currency = new Currency();
                    currency.Id = elms.Attribute("ID").Value;

                    if (elms.HasElements)
                    {

                        foreach (var element in elms.Elements())
                        {
                            switch (element.Name.ToString())
                            {
                                case "Name":
                                    currency.Name = element.Value;
                                    break;

                                case "EngName":
                                    currency.EngName = element.Value;
                                    break;

                                case "Nominal":
                                    currency.Nominal = Int32.Parse(element.Value);
                                    break;

                                case "ParentCode":
                                    currency.Name = element.Value;
                                    break;

                                case "ISO_Num_Code":
                                    currency.ISO_Num_Code = element.Value;
                                    break;

                                case "ISO_Char_Code":
                                    currency.ISO_Char_Code = element.Value;
                                    break;
                            }
                        }
                        currencyList.Add(currency);
                        currency = null;
                    }
                }
            }
            
            return currencyList;
        }   
        

        // вставка списка валют в бд
        public bool WriteCurrencyToDB(List<Currency> currencyList)
        {
            string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\c#\\SBProject\\SBProject\\ExRateSB.mdf;Integrated Security=True";
            DataContext db = new DataContext(conString);

            Table<Currency> currencies = db.GetTable<Currency>();
            foreach(var v in currencyList)
            {
                if (db.GetTable<Currency>().Any(t => t.Id == v.Id))
                    continue;   // пропускаем итерацию, если такая запись уже существует
                db.GetTable<Currency>().InsertOnSubmit(v);
                db.SubmitChanges();
            }


            return true;
        }
    }
}
