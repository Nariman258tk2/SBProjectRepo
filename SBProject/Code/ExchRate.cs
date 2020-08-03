using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SBProject.Code
{
    [Table(Name = "ExRateTable")]
    public class ExchRate
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "ValId")]
        public string ValId { get; set; }

        [Column(Name = "NumCode")]
        public string NumCode { get; set; }

        [Column(Name = "CharCode")]
        public string CharCode { get; set; }

        [Column(Name = "Nominal")]
        public int Nominal { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Value")]
        public double Value { get; set; }

        [Column(Name = "Date")]
        public string Date { get; set; }

    }
}
