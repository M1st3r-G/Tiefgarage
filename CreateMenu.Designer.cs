namespace Tiefgarage
{
    partial class CreateMenu
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
            btnAcceptCreate = new Button();
            btnAddLevel = new Button();
            SuspendLayout();
            // 
            // btnAcceptCreate
            // 
            btnAcceptCreate.Location = new Point(626, 369);
            btnAcceptCreate.Name = "btnAcceptCreate";
            btnAcceptCreate.Size = new Size(136, 44);
            btnAcceptCreate.TabIndex = 1;
            btnAcceptCreate.Text = "Erstelle Parkhaus";
            btnAcceptCreate.UseVisualStyleBackColor = true;
            btnAcceptCreate.Click += btnAcceptCreate_Click;
            // 
            // btnAddLevel
            // 
            btnAddLevel.Location = new Point(626, 309);
            btnAddLevel.Name = "btnAddLevel";
            btnAddLevel.Size = new Size(135, 45);
            btnAddLevel.TabIndex = 2;
            btnAddLevel.Text = "Erstelle Etage";
            btnAddLevel.UseVisualStyleBackColor = true;
            btnAddLevel.Click += btnAddLevel_Click;
            // 
            // CreateMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddLevel);
            Controls.Add(btnAcceptCreate);
            Name = "CreateMenu";
            Text = "Create Menu";
            ResumeLayout(false);
        }

        #endregion
        private Button btnAcceptCreate;
        private Button btnAddLevel;
    }
}