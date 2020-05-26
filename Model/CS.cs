using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [SqlSugar.SugarTable("CS")]
    public class CS
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
