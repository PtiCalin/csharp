namespace Epargne
{
    partial class FormTp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.montantTextBox = new System.Windows.Forms.TextBox();
            this.tauxTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FondRadioButton = new System.Windows.Forms.RadioButton();
            this.cpgRadioButton = new System.Windows.Forms.RadioButton();
            this.affichageLabel = new System.Windows.Forms.Label();
            this.calculerButton = new System.Windows.Forms.Button();
            this.sommaireButton = new System.Windows.Forms.Button();
            this.quitterButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Montant investissement";
            // 
            // montantTextBox
            // 
            this.montantTextBox.Location = new System.Drawing.Point(256, 23);
            this.montantTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.montantTextBox.Name = "montantTextBox";
            this.montantTextBox.Size = new System.Drawing.Size(148, 26);
            this.montantTextBox.TabIndex = 1;
            // 
            // tauxTextBox
            // 
            this.tauxTextBox.Location = new System.Drawing.Point(256, 85);
            this.tauxTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tauxTextBox.Name = "tauxTextBox";
            this.tauxTextBox.Size = new System.Drawing.Size(148, 26);
            this.tauxTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rendement annuel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FondRadioButton);
            this.groupBox1.Controls.Add(this.cpgRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(507, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(276, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type de placement";
            // 
            // FondRadioButton
            // 
            this.FondRadioButton.AutoSize = true;
            this.FondRadioButton.Location = new System.Drawing.Point(10, 66);
            this.FondRadioButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FondRadioButton.Name = "FondRadioButton";
            this.FondRadioButton.Size = new System.Drawing.Size(136, 24);
            this.FondRadioButton.TabIndex = 1;
            this.FondRadioButton.TabStop = true;
            this.FondRadioButton.Text = "Fond commun";
            this.FondRadioButton.UseVisualStyleBackColor = true;
            // 
            // cpgRadioButton
            // 
            this.cpgRadioButton.AutoSize = true;
            this.cpgRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cpgRadioButton.Location = new System.Drawing.Point(10, 31);
            this.cpgRadioButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpgRadioButton.Name = "cpgRadioButton";
            this.cpgRadioButton.Size = new System.Drawing.Size(259, 24);
            this.cpgRadioButton.TabIndex = 0;
            this.cpgRadioButton.TabStop = true;
            this.cpgRadioButton.Text = "Certificat de placement garantie";
            this.cpgRadioButton.UseVisualStyleBackColor = true;
            // 
            // affichageLabel
            // 
            this.affichageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.affichageLabel.Location = new System.Drawing.Point(21, 198);
            this.affichageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.affichageLabel.Name = "affichageLabel";
            this.affichageLabel.Size = new System.Drawing.Size(753, 175);
            this.affichageLabel.TabIndex = 5;
            // 
            // calculerButton
            // 
            this.calculerButton.Location = new System.Drawing.Point(21, 131);
            this.calculerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculerButton.Name = "calculerButton";
            this.calculerButton.Size = new System.Drawing.Size(294, 35);
            this.calculerButton.TabIndex = 6;
            this.calculerButton.Text = "Affichage pour le placement courant";
            this.calculerButton.UseVisualStyleBackColor = true;
            this.calculerButton.Click += new System.EventHandler(this.calculerButton_Click);
            // 
            // sommaireButton
            // 
            this.sommaireButton.Location = new System.Drawing.Point(21, 400);
            this.sommaireButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sommaireButton.Name = "sommaireButton";
            this.sommaireButton.Size = new System.Drawing.Size(423, 35);
            this.sommaireButton.TabIndex = 7;
            this.sommaireButton.Text = "Afficher le sommaire pour tous les placements traités";
            this.sommaireButton.UseVisualStyleBackColor = true;
            this.sommaireButton.Click += new System.EventHandler(this.sommaireButton_Click);
            // 
            // quitterButton
            // 
            this.quitterButton.Location = new System.Drawing.Point(507, 400);
            this.quitterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quitterButton.Name = "quitterButton";
            this.quitterButton.Size = new System.Drawing.Size(112, 35);
            this.quitterButton.TabIndex = 8;
            this.quitterButton.Text = "Quitter";
            this.quitterButton.UseVisualStyleBackColor = true;
            this.quitterButton.Click += new System.EventHandler(this.quitterButton_Click);
            // 
            // FormTp1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 503);
            this.Controls.Add(this.quitterButton);
            this.Controls.Add(this.sommaireButton);
            this.Controls.Add(this.calculerButton);
            this.Controls.Add(this.affichageLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tauxTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.montantTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTp1";
            this.Text = "Formulaire tp1 #2";
            this.Load += new System.EventHandler(this.FormTp1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox montantTextBox;
        private System.Windows.Forms.TextBox tauxTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FondRadioButton;
        private System.Windows.Forms.RadioButton cpgRadioButton;
        private System.Windows.Forms.Label affichageLabel;
        private System.Windows.Forms.Button calculerButton;
        private System.Windows.Forms.Button sommaireButton;
        private System.Windows.Forms.Button quitterButton;
    }
}

