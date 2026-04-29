using System;
using System.IO;


class Colis
{
    private String code; //Son code de repérage
    private String adresse; //adresse de livraison
    private double poids; //poids du colis
    private String statut; //Le statut de la commande
    private double valeur; //La valeur totale de la commande

    public Colis(string code, string adresse, double poids, string statut, double valeur)
    {
        this.code = code;
        this.adresse = adresse;
        this.poids = poids;
        this.statut = statut;
        this.valeur = valeur;
    }

    public Colis(String code, String adresse, double poids, double valeur)
        : this(code, adresse, poids, "Étiquette créée", valeur)
    {
    }
    public Colis(String code)
    {
        this.code = code;
    }


    //à compléter

    public String Statut
    {
        get { return statut; }
        set { statut = value; }
    }

    public double Poids
    {
        get
        {
            return poids;
        }
    }

    public double Cout
    {
        get
        {
            double temp;
            if (valeur >= 50)
                temp = 0;
            else if (poids <= 50)
                temp = 15;
            else
                temp = 0.05 * poids;

            return temp;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is Colis colis &&
               code == colis.code;
        // ou code.equals(colis.code)
    }
}

class Livraison
{
    static void Main(string[] args)
    {
        Colis[] tabColis = new Colis[50];
        int nbColis = 0;

        nbColis = lireFichier(tabColis);

        livre(tabColis, nbColis, "E85684");

        Colis volumineux;
        Lourd(tabColis, nbColis, out volumineux);
        Console.WriteLine(volumineux.Statut);

        Console.WriteLine("Il y a {0} colis dans le fichier", nbColis);
    }


    public static int lireFichier(Colis[] t)
    {
        int n = 0;

        StreamReader lire = File.OpenText("aLivrer.txt");
        String code = null;

        while ((code = lire.ReadLine()) != null)
        {
            String adresse = lire.ReadLine();
            String poids = lire.ReadLine();
            String statut = lire.ReadLine();
            String prix = lire.ReadLine();

            t[n++] = new Colis(code, adresse, double.Parse(poids.Trim().Replace(".", ",")), statut, double.Parse(prix.Trim()));

        }
        return n;
    }

    public static void livre(Colis[] t, int n, String track)
    {
        Colis arrive = new Colis(track);
        int i = 0;

        while (i < n && arrive.Equals(t[i]) == false)
        {
            i++;
        }

        if (i < n)
            t[i].Statut = "Le colis a été livré à destination";
    }

    public static void Lourd(Colis[] t, int n, out Colis plusLourd)
    {
        int i;
        plusLourd = null;
        double pLourd = 0;
        for (i = 0; i < n; i++)
            if (t[i].Poids > pLourd)
            {
                plusLourd = t[i];
                pLourd = plusLourd.Poids;
            }
    }
}
}
