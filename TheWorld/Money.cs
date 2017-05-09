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

        public void NormalizeCoinage()
        {
            while(this.Copper > 100)
            {
                this.Silver++;
                this.Copper -= 100;
            }

            while (this.Silver > 100)
            {
                this.Gold++;
                this.Silver -= 100;
            }

            while(this.Gold > 100)
            {
                this.Platinum++;
                this.Gold -= 100;
            }
        }

        /// <summary>
        /// Add together two money pouches.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Money operator +(Money a, Money b)
        {
            Money sum = a;

            sum.Silver   += (sum.Copper + b.Copper) / 100;
            sum.Copper   += (sum.Copper + b.Copper) % 100;

            sum.Gold     += (sum.Silver + b.Silver) / 100;
            sum.Silver   += (sum.Silver + b.Silver) % 100;

            sum.Platinum += (sum.Gold + b.Gold) / 100;
            sum.Gold     += (sum.Gold + b.Gold) % 100;

            sum.Platinum += b.Platinum;

            return sum;
        }


        /// <summary>
        /// Subtract b from a.
        /// Throw an exception if the b is larger than a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Money operator -(Money a, Money b)
        {
            // You write this method!!
            return new Money();
        }
    }
}
