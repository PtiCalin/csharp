using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalA24
{
    internal class Maison : Logis
    {
        private double hypotheque, taxes;

        public Maison(string emplacement, double h, double tx) : base(emplacement)
        {
            hypotheque = h; 
            taxes = tx;
        }

        public override double CoutMensuel()
        {
            return hypotheque + taxes/12;
        }
    }
}
