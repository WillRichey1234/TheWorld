using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld
{
    public class Money
    {
        public uint Platinum { get; set; }
        public uint Gold { get; set; }
        public uint Silver { get; set; }
        public uint Copper { get; set; }

        public override string ToString()
        {
            String output = "";
            bool addSpace = false;

            if (Platinum > 0)
            {
                output += String.Format("{0}P", Platinum);
                addSpace = true;
            }
            if (Gold > 0)
            {
                output += String.Format("{0}{1}G", addSpace ? " " : "", Gold);
                addSpace = true;
            }
            if (Silver > 0)
            { 
                output += String.Format("{0}{1}S", addSpace ? " " : "", Silver);
                addSpace = true;
            }
            if (Copper > 0 || !addSpace)
                output += String.Format("{0}{1}C", addSpace ? " " : "", Copper);

            return output;
        }
    }
}
