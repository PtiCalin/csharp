# 12 — WinForms : exemples

> 📘 [Theory](../../01-theory/12-winforms/README.md) · 🏋️ [Exercises](../../03-exercices/12-winforms/README.md)

## Exemple 1 — Calculatrice d'épargne (inspiration TP1 Partie 2)

### `Program.cs`

```csharp
using System;
using System.Windows.Forms;

namespace EpargneApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormEpargne());
        }
    }
}
```

### `FormEpargne.cs`

```csharp
using System;
using System.Windows.Forms;

namespace EpargneApp
{
    public partial class FormEpargne : Form
    {
        public FormEpargne()
        {
            InitializeComponent();
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            // 1. Validation des saisies.
            if (!double.TryParse(txtMontant.Text, out double montant) || montant <= 0)
            {
                MessageBox.Show("Montant invalide.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontant.Focus();
                return;
            }

            if (!double.TryParse(txtTaux.Text, out double taux) || taux < 0)
            {
                MessageBox.Show("Taux invalide.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaux.Focus();
                return;
            }

            if (!int.TryParse(txtAnnees.Text, out int annees) || annees <= 0)
            {
                MessageBox.Show("Nombre d'années invalide.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnnees.Focus();
                return;
            }

            // 2. Calcul (intérêt composé).
            double valeurFinale = montant * Math.Pow(1 + taux / 100.0, annees);
            double interets     = valeurFinale - montant;

            // 3. Affichage.
            lblValeurFinale.Text = $"Valeur finale : {valeurFinale:C2}";
            lblInterets.Text     = $"Intérêts cumulés : {interets:C2}";
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            txtMontant.Clear();
            txtTaux.Clear();
            txtAnnees.Clear();
            lblValeurFinale.Text = "";
            lblInterets.Text     = "";
            txtMontant.Focus();
        }
    }
}
```

> 💡 Le fichier `FormEpargne.Designer.cs` est généré par le concepteur visuel.
> Voir la solution complète dans [`Epargne/`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/IFT1179-A-H26_TP1_Partie2/Epargne/).

## Exemple 2 — Validation en temps réel via `TextChanged`

```csharp
private void txtMontant_TextChanged(object sender, EventArgs e)
{
    bool valide = double.TryParse(txtMontant.Text, out double m) && m > 0;

    // Active/désactive le bouton selon la validité.
    btnCalculer.Enabled = valide;

    // Indication visuelle.
    txtMontant.BackColor = valide
        ? System.Drawing.Color.White
        : System.Drawing.Color.MistyRose;
}
```

## Exemple 3 — `ListBox` dynamique

```csharp
private void btnAjouter_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtArticle.Text)) return;
    lstArticles.Items.Add(txtArticle.Text);
    txtArticle.Clear();
    txtArticle.Focus();
}

private void btnSupprimer_Click(object sender, EventArgs e)
{
    if (lstArticles.SelectedIndex >= 0)
        lstArticles.Items.RemoveAt(lstArticles.SelectedIndex);
}
```

## 🔗 Voir aussi

- [Theory → 12-winforms](../../01-theory/12-winforms/README.md)
- [Exercises → 12-winforms](../../03-exercices/12-winforms/README.md)
- TP1 Partie 2 : [`IFT1179-A-H26_TP1_Partie2`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/IFT1179-A-H26_TP1_Partie2)
