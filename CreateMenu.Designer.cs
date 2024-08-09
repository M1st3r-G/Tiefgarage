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
            label1 = new Label();
            tbxName = new TextBox();
            LevelContainer = new Panel();
            SuspendLayout();
            // 
            // btnAcceptCreate
            // 
            btnAcceptCreate.Location = new Point(418, 599);
            btnAcceptCreate.Name = "btnAcceptCreate";
            btnAcceptCreate.Size = new Size(136, 44);
            btnAcceptCreate.TabIndex = 1;
            btnAcceptCreate.Text = "Erstelle Parkhaus";
            btnAcceptCreate.UseVisualStyleBackColor = true;
            btnAcceptCreate.Click += btnAcceptCreate_Click;
            // 
            // btnAddLevel
            // 
            btnAddLevel.Location = new Point(418, 65);
            btnAddLevel.Name = "btnAddLevel";
            btnAddLevel.Size = new Size(135, 45);
            btnAddLevel.TabIndex = 2;
            btnAddLevel.Text = "Erstelle Etage";
            btnAddLevel.UseVisualStyleBackColor = true;
            btnAddLevel.Click += btnAddLevel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(418, 9);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 3;
            label1.Text = "Parkhaus Name:";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(419, 27);
            tbxName.Name = "tbxName";
            tbxName.PlaceholderText = "Unbenanntes Parkhaus";
            tbxName.Size = new Size(135, 23);
            tbxName.TabIndex = 4;
            // 
            // LevelContainer
            // 
            LevelContainer.AutoScroll = true;
            LevelContainer.Location = new Point(12, 12);
            LevelContainer.Name = "LevelContainer";
            LevelContainer.Size = new Size(383, 631);
            LevelContainer.TabIndex = 5;
            // 
            // CreateMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 655);
            Controls.Add(LevelContainer);
            Controls.Add(tbxName);
            Controls.Add(label1);
            Controls.Add(btnAddLevel);
            Controls.Add(btnAcceptCreate);
            Name = "CreateMenu";
            Text = "Create Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAcceptCreate;
        private Button btnAddLevel;
        private Label label1;
        private TextBox tbxName;
        private Panel LevelContainer;
    }
}