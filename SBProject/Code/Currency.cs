using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SBProject.Code
{
    [Table(Name = "CurrencyTable")]
    public class Currency
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public string Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "EngName")]
        public string EngName { get; set; }

        [Column(Name = "Nominal")]
        public int Nominal { get; set; }

        [Column(Name = "ParentCode")]
        public string ParentCode { get; set; }

        [Column(Name = "ISO_Num_Code")]
        public string ISO_Num_Code { get; set; }

        [Column(Name = "ISO_Char_Code")]
        public string ISO_Char_Code { get; set; }
    }
}
