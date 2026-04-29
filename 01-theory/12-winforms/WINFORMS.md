# 12 — WinForms (introduction)

> 📚 [Examples](../../02-examples/12-winforms/README.md) · 🏋️ [Exercises](../../03-exercices/12-winforms/README.md)

> ⚠️ **Cible** : .NET Framework 4.7+ ou .NET 6+ avec template `Windows Forms App`.
> Utilisé dans le TP1 Partie 2 du cours UdeM IFT1179.

## L1 — Intuition

Une application WinForms = un **formulaire** (`Form`) qui contient des **contrôles**
(`Button`, `TextBox`, `Label`, …) et **réagit aux événements** (clic, changement de
texte, fermeture). Toute la logique est branchée à des **gestionnaires d'événements**.

```text
Utilisateur ──[clic]──▶ Bouton ──[déclenche]──▶ Form1.btnCalculer_Click(...)
```

## L2 — Anatomie d'un projet

```text
MonApp/
├── Program.cs               # Point d'entrée : Application.Run(new Form1())
├── Form1.cs                 # Logique : gestionnaires d'événements
├── Form1.Designer.cs        # GÉNÉRÉ : disposition des contrôles (NE PAS éditer à la main)
├── Form1.resx               # Ressources (icônes, images...)
└── App.config               # Configuration (.NET Framework)
```

### Structure typique de `Form1.cs`

```csharp
using System;
using System.Windows.Forms;

namespace MonApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();              // Construit l'interface depuis Designer.cs.
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMontant.Text, out double montant))
            {
                MessageBox.Show("Montant invalide.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double interet = montant * 0.05;
            lblResultat.Text = $"Intérêt : {interet:C2}";
        }
    }
}
```

## L3 — Contrôles courants

| Contrôle       | Propriété clé            | Événement principal    |
| -------------- | ------------------------ | ---------------------- |
| `Label`        | `Text`                   | (rare)                 |
| `TextBox`      | `Text`                   | `TextChanged`          |
| `Button`       | `Text`                   | `Click`                |
| `CheckBox`     | `Checked`                | `CheckedChanged`       |
| `RadioButton`  | `Checked`                | `CheckedChanged`       |
| `ComboBox`     | `Items`, `SelectedItem`  | `SelectedIndexChanged` |
| `ListBox`      | `Items`, `SelectedIndex` | `SelectedIndexChanged` |
| `DataGridView` | `DataSource`             | `CellClick`            |

### Convention de nommage

| Préfixe | Contrôle     |
| ------- | ------------ |
| `lbl`   | Label        |
| `txt`   | TextBox      |
| `btn`   | Button       |
| `chk`   | CheckBox     |
| `rdo`   | RadioButton  |
| `cbo`   | ComboBox     |
| `lst`   | ListBox      |
| `grd`   | DataGridView |

## L4 — Pièges

- ⚠️ **Modifier `Form1.Designer.cs` à la main** : casse le synchronisme avec le
  designer visuel. Toujours passer par la fenêtre Properties.
- ⚠️ Tout `TextBox.Text` est une `string` — toujours `TryParse` avant calculs.
- ⚠️ Bloquer le thread UI avec une longue opération → fenêtre figée (« Not Responding »).
  Pour les gros traitements, utiliser `async/await` ou `BackgroundWorker`.
- ⚠️ Modifier un contrôle UI depuis un autre thread → `InvalidOperationException`.
  Marshaller via `Invoke(...)`.
- ⚠️ Oublier `MessageBox.Show` pour les erreurs utilisateur : laisser une exception
  remonter dans une app WinForms = crash visible.

## ✅ Vérifiez votre compréhension

1. Pourquoi ne **pas** éditer `Form1.Designer.cs` directement ?
2. Quelle propriété d'un `TextBox` contient le texte saisi par l'utilisateur ? De quel
   type est-elle ?
3. Quel événement choisirais-tu pour valider la saisie d'un montant **dès que l'utilisateur
   tape** ? Et pour calculer **uniquement quand il clique** ?

## 🔗 Pour aller plus loin

- Microsoft Learn — [Windows Forms Tutorial](https://learn.microsoft.com/dotnet/desktop/winforms/)
- TP1 Partie 2 du cours : [`IFT1179-A-H26_TP1_Partie2`](../../05-references/course-materials/UDEM_H26_IFT1179/assignements/TP1/IFT1179-A-H26_TP1_Partie2)
