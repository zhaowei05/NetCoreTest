using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [SqlSugar.SugarTable("M_OPT")]
    public class M_OPT
    {
        public string OPT_ID { get; set; }

        public string PWD { get; set; }

        public string NAME { get; set; }
    }
}
