using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalA24
{
    internal class Logement : Logis   
    {
        private double loyer;

        public  Logement(string emplacement, double loyer)
            :base(emplacement)
        {
           this.loyer = loyer;
        }
        public override double CoutMensuel()
        {
            return loyer;
        }
    }
}
