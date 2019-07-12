namespace AnyShortener
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serviceoption = new System.Windows.Forms.ComboBox();
            this.saveoptionsbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Default shortener:";
            // 
            // serviceoption
            // 
            this.serviceoption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceoption.FormattingEnabled = true;
            this.serviceoption.Items.AddRange(new object[] {
            "is.gd",
            "v.gd",
            "bit.ly",
            "rebrand.ly",
            "7th.it",
            "cutt.ly",
            "shorte.st",
            "dot.tk"});
            this.serviceoption.Location = new System.Drawing.Point(144, 41);
            this.serviceoption.Name = "serviceoption";
            this.serviceoption.Size = new System.Drawing.Size(146, 21);
            this.serviceoption.TabIndex = 9;
            // 
            // saveoptionsbtn
            // 
            this.saveoptionsbtn.Location = new System.Drawing.Point(181, 68);
            this.saveoptionsbtn.Name = "saveoptionsbtn";
            this.saveoptionsbtn.Size = new System.Drawing.Size(109, 23);
            this.saveoptionsbtn.TabIndex = 10;
            this.saveoptionsbtn.Text = "Apply";
            this.saveoptionsbtn.UseVisualStyleBackColor = true;
            this.saveoptionsbtn.Click += new System.EventHandler(this.Saveoptionsbtn_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 104);
            this.Controls.Add(this.saveoptionsbtn);
            this.Controls.Add(this.serviceoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Any Shortener - Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serviceoption;
        private System.Windows.Forms.Button saveoptionsbtn;
    }
}