namespace Tiefgarage
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnCreate = new Button();
            btnOpen = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            cbbxSaved = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 50);
            label1.TabIndex = 0;
            label1.Text = "Parkhaus";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 227);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(169, 29);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Ein Neues Parkhaus erstellen";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(201, 62);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(126, 23);
            btnOpen.TabIndex = 3;
            btnOpen.Text = "Parkhaus öffnen";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(201, 127);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Parkhaus löschen";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(201, 189);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(126, 23);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Parkhaus bearbeiten";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // cbbxSaved
            // 
            cbbxSaved.DropDownStyle = ComboBoxStyle.Simple;
            cbbxSaved.FormattingEnabled = true;
            cbbxSaved.Location = new Point(12, 62);
            cbbxSaved.Name = "cbbxSaved";
            cbbxSaved.Size = new Size(169, 150);
            cbbxSaved.TabIndex = 6;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 270);
            Controls.Add(cbbxSaved);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnOpen);
            Controls.Add(btnCreate);
            Controls.Add(label1);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCreate;
        private Button btnOpen;
        private Button btnDelete;
        private Button btnEdit;
        private ComboBox cbbxSaved;
    }
}