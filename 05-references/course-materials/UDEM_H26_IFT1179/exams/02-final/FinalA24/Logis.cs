using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalA24
{
        internal abstract class Logis : IComparable<Logis>
        {
            private string Emplacement;

            public Logis(string emplacement)
            {
                Emplacement = emplacement;
            }

            public string Adresse
            {
                get { 
                    return Emplacement;
                }
            }

           public abstract double CoutMensuel();
           public override string ToString()
            {
                return Adresse + " coutant " + CoutMensuel() + "$ par mois";
            }

            public int CompareTo(Logis autre)
            {
                return Adresse.CompareTo(autre.Adresse);
            }

            public override bool Equals(object obj)
            {
                return obj is Logis Logis &&
                       Adresse == Logis.Adresse;
            }

            public override int GetHashCode()
            {
                return -1527294274 + EqualityComparer<string>.Default.GetHashCode(Adresse);
            }
        }
}
