namespace Tp2Form
{
    partial class Tp2FormPartie1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.affichageLabel = new System.Windows.Forms.Label();
            this.joueurButton = new System.Windows.Forms.Button();
            this.defenseButton = new System.Windows.Forms.Button();
            this.ailierButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // affichageLabel
            // 
            this.affichageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.affichageLabel.Location = new System.Drawing.Point(23, 9);
            this.affichageLabel.Name = "affichageLabel";
            this.affichageLabel.Size = new System.Drawing.Size(412, 189);
            this.affichageLabel.TabIndex = 0;
            // 
            // joueurButton
            // 
            this.joueurButton.Location = new System.Drawing.Point(494, 29);
            this.joueurButton.Name = "joueurButton";
            this.joueurButton.Size = new System.Drawing.Size(144, 23);
            this.joueurButton.TabIndex = 1;
            this.joueurButton.Text = "Afficher tous les joueurs";
            this.joueurButton.UseVisualStyleBackColor = true;
            // 
            // defenseButton
            // 
            this.defenseButton.Location = new System.Drawing.Point(494, 74);
            this.defenseButton.Name = "defenseButton";
            this.defenseButton.Size = new System.Drawing.Size(144, 23);
            this.defenseButton.TabIndex = 2;
            this.defenseButton.Text = "Afficher les défenseurs";
            this.defenseButton.UseVisualStyleBackColor = true;
            // 
            // ailierButton
            // 
            this.ailierButton.Location = new System.Drawing.Point(494, 121);
            this.ailierButton.Name = "ailierButton";
            this.ailierButton.Size = new System.Drawing.Size(144, 23);
            this.ailierButton.TabIndex = 3;
            this.ailierButton.Text = "Afficher les ailiers";
            this.ailierButton.UseVisualStyleBackColor = true;
            // 
            // Tp2FormPartie1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 233);
            this.Controls.Add(this.ailierButton);
            this.Controls.Add(this.defenseButton);
            this.Controls.Add(this.joueurButton);
            this.Controls.Add(this.affichageLabel);
            this.Name = "Tp2FormPartie1";
            this.Text = "Tp2 partie 1";
            this.Load += new System.EventHandler(this.Tp2FormPartie1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button affichageButton;
        private System.Windows.Forms.Label affichageLabel;
        private System.Windows.Forms.Button joueurButton;
        private System.Windows.Forms.Button defenseButton;
        private System.Windows.Forms.Button ailierButton;
    }
}

