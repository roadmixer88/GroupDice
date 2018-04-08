using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDice
{
    public class Stat
    {
        public Stat(String name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
        public String Name { get; set; }
        public int Value { get; set; }
    }
}
