using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalA24
{
    internal class parCout : IComparer<Logis>
    {
        public int Compare(Logis x, Logis y)
        {
            double dif = x.CoutMensuel() -y.CoutMensuel();
            if (dif > 0)
                return 1;
            else if (dif < 0) return -1;
            else return 0;  
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Logis> logis = new List<Logis>();

            StreamReader aLire = File.OpenText("immeubles.txt");
            string ligneLue = null;
            while ((ligneLue = aLire.ReadLine()) != null)
            {
                string[] valeurs = ligneLue.Split(';');
                string adresse = valeurs[0];
               double h = double.Parse(valeurs[1].Trim());
                double t = double.Parse(valeurs[2].Trim());
                double rev = double.Parse(valeurs[3].Trim());

                logis.Add(new Immeuble(adresse, h, t, rev));
            }

            aLire.Close();

           logis.Sort();
            int indice = logis.BinarySearch(new Logement("24 Sussex Drive, K1M 1M4", 0));
            if (indice < 0)
                Console.WriteLine("Ce logis n'est pas trouvé");
            else
                Console.WriteLine(logis[indice]);
            
            parCout pourTrie = new parCout();
            logis.Sort(pourTrie);
            indice = logis.BinarySearch(new Logement("", 0), pourTrie);
            if (indice >= 0)
                Console.WriteLine(logis[indice]);
            else
                Console.WriteLine("aucun logis gratuit");


            Console.ReadLine();
        }
    }
}
