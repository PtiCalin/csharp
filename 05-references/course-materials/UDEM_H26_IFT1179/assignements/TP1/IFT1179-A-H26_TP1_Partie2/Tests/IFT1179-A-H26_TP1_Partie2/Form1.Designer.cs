namespace IFT1179_A_H26_TP1_Partie2
{
    partial class FormTp1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_montant = new System.Windows.Forms.Label();
            this.label_rendement = new System.Windows.Forms.Label();
            this.textBox_montant = new System.Windows.Forms.TextBox();
            this.textBox_rendement = new System.Windows.Forms.TextBox();
            this.radioButton_certificat = new System.Windows.Forms.RadioButton();
            this.radioButton_fondCommun = new System.Windows.Forms.RadioButton();
            this.groupBox_typePlacement = new System.Windows.Forms.GroupBox();
            this.button_affichageCourrant = new System.Windows.Forms.Button();
            this.textBox_calcul = new System.Windows.Forms.TextBox();
            this.button_affichageSommaire = new System.Windows.Forms.Button();
            this.button_quitter = new System.Windows.Forms.Button();
            this.groupBox_typePlacement.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_montant
            // 
            this.label_montant.AutoSize = true;
            this.label_montant.Location = new System.Drawing.Point(22, 49);
            this.label_montant.Name = "label_montant";
            this.label_montant.Size = new System.Drawing.Size(177, 20);
            this.label_montant.TabIndex = 0;
            this.label_montant.Text = "Montant investissement";
            this.label_montant.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_rendement
            // 
            this.label_rendement.AutoSize = true;
            this.label_rendement.Location = new System.Drawing.Point(22, 104);
            this.label_rendement.Name = "label_rendement";
            this.label_rendement.Size = new System.Drawing.Size(145, 20);
            this.label_rendement.TabIndex = 1;
            this.label_rendement.Text = "Randement annuel";
            this.label_rendement.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textBox_montant
            // 
            this.textBox_montant.Location = new System.Drawing.Point(223, 44);
            this.textBox_montant.Name = "textBox_montant";
            this.textBox_montant.Size = new System.Drawing.Size(170, 26);
            this.textBox_montant.TabIndex = 2;
            this.textBox_montant.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_rendement
            // 
            this.textBox_rendement.Location = new System.Drawing.Point(223, 99);
            this.textBox_rendement.Name = "textBox_rendement";
            this.textBox_rendement.Size = new System.Drawing.Size(170, 26);
            this.textBox_rendement.TabIndex = 3;
            // 
            // radioButton_certificat
            // 
            this.radioButton_certificat.AutoSize = true;
            this.radioButton_certificat.Location = new System.Drawing.Point(20, 30);
            this.radioButton_certificat.Name = "radioButton_certificat";
            this.radioButton_certificat.Size = new System.Drawing.Size(259, 24);
            this.radioButton_certificat.TabIndex = 4;
            this.radioButton_certificat.TabStop = true;
            this.radioButton_certificat.Text = "Certificat de placement garantie";
            this.radioButton_certificat.UseVisualStyleBackColor = true;
            this.radioButton_certificat.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_fondCommun
            // 
            this.radioButton_fondCommun.AutoSize = true;
            this.radioButton_fondCommun.Location = new System.Drawing.Point(20, 65);
            this.radioButton_fondCommun.Name = "radioButton_fondCommun";
            this.radioButton_fondCommun.Size = new System.Drawing.Size(139, 24);
            this.radioButton_fondCommun.TabIndex = 5;
            this.radioButton_fondCommun.TabStop = true;
            this.radioButton_fondCommun.Text = "Fond Commun";
            this.radioButton_fondCommun.UseVisualStyleBackColor = true;
            this.radioButton_fondCommun.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // groupBox_typePlacement
            // 
            this.groupBox_typePlacement.Controls.Add(this.radioButton_certificat);
            this.groupBox_typePlacement.Controls.Add(this.radioButton_fondCommun);
            this.groupBox_typePlacement.Location = new System.Drawing.Point(451, 25);
            this.groupBox_typePlacement.Name = "groupBox_typePlacement";
            this.groupBox_typePlacement.Size = new System.Drawing.Size(322, 100);
            this.groupBox_typePlacement.TabIndex = 6;
            this.groupBox_typePlacement.TabStop = false;
            this.groupBox_typePlacement.Text = "Type de placement";
            this.groupBox_typePlacement.Enter += new System.EventHandler(this.groupBox_typePlacement_Enter);
            // 
            // button_affichageCourrant
            // 
            this.button_affichageCourrant.Location = new System.Drawing.Point(28, 155);
            this.button_affichageCourrant.Name = "button_affichageCourrant";
            this.button_affichageCourrant.Size = new System.Drawing.Size(303, 30);
            this.button_affichageCourrant.TabIndex = 7;
            this.button_affichageCourrant.Text = "Affichage pour le placement courrant";
            this.button_affichageCourrant.UseVisualStyleBackColor = true;
            // 
            // textBox_calcul
            // 
            this.textBox_calcul.Location = new System.Drawing.Point(28, 213);
            this.textBox_calcul.Multiline = true;
            this.textBox_calcul.Name = "textBox_calcul";
            this.textBox_calcul.ReadOnly = true;
            this.textBox_calcul.Size = new System.Drawing.Size(745, 157);
            this.textBox_calcul.TabIndex = 8;
            // 
            // button_affichageSommaire
            // 
            this.button_affichageSommaire.Location = new System.Drawing.Point(28, 393);
            this.button_affichageSommaire.Name = "button_affichageSommaire";
            this.button_affichageSommaire.Size = new System.Drawing.Size(499, 30);
            this.button_affichageSommaire.TabIndex = 9;
            this.button_affichageSommaire.Text = "Afficher le sommaire pour tous les placements traités";
            this.button_affichageSommaire.UseVisualStyleBackColor = true;
            // 
            // button_quitter
            // 
            this.button_quitter.Location = new System.Drawing.Point(647, 393);
            this.button_quitter.Name = "button_quitter";
            this.button_quitter.Size = new System.Drawing.Size(126, 30);
            this.button_quitter.TabIndex = 10;
            this.button_quitter.Text = "Quitter";
            this.button_quitter.UseVisualStyleBackColor = true;
            // 
            // FormTp1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_quitter);
            this.Controls.Add(this.button_affichageSommaire);
            this.Controls.Add(this.textBox_calcul);
            this.Controls.Add(this.button_affichageCourrant);
            this.Controls.Add(this.groupBox_typePlacement);
            this.Controls.Add(this.textBox_rendement);
            this.Controls.Add(this.textBox_montant);
            this.Controls.Add(this.label_rendement);
            this.Controls.Add(this.label_montant);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormTp1";
            this.Text = "FormTp1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_typePlacement.ResumeLayout(false);
            this.groupBox_typePlacement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_montant;
        private System.Windows.Forms.Label label_rendement;
        private System.Windows.Forms.TextBox textBox_montant;
        private System.Windows.Forms.TextBox textBox_rendement;
        private System.Windows.Forms.RadioButton radioButton_certificat;
        private System.Windows.Forms.RadioButton radioButton_fondCommun;
        private System.Windows.Forms.GroupBox groupBox_typePlacement;
        private System.Windows.Forms.Button button_affichageCourrant;
        private System.Windows.Forms.TextBox textBox_calcul;
        private System.Windows.Forms.Button button_affichageSommaire;
        private System.Windows.Forms.Button button_quitter;
    }
}

