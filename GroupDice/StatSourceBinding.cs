using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GroupDice
{
    public class StatSourceBinding
    {
        public Stat stat { get; set; }
        public Button Source { get; set; }
        public TextBox Destination { get; set; }
        
    }
}
