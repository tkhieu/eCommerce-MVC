using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.SimpleJSON
{
    public class AccountJSON
    {
        public String id { get; set; }
        public String label { get; set; }
        public String value { get; set; }

        public AccountJSON(String id,String label,String value)
        {
            this.id = id;
            this.label = label;
            this.value = value;
        }
    }
}
