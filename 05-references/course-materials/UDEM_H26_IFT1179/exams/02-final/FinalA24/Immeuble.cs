using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalA24
{
    internal class Immeuble: Maison
    {
        private double revenus;

        public Immeuble(string emplacement, double h, double tx, double rev) : base(emplacement, h, tx)
        {
            revenus = rev;
        }

        public override double CoutMensuel()
        {
            return base.CoutMensuel() - revenus;
        }
    }
}
