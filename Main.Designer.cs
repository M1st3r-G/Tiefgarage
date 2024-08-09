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
            label2 = new Label();
            fileContainer = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(214, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 50);
            label1.TabIndex = 0;
            label1.Text = "Parkhaus";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 243);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(89, 60);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Ein Neues Parkhaus erstellen";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 124);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 0;
            label2.Text = "Parkhaus öffnen";
            // 
            // fileContainer
            // 
            fileContainer.AutoScroll = true;
            fileContainer.BorderStyle = BorderStyle.FixedSingle;
            fileContainer.Location = new Point(450, 150);
            fileContainer.Name = "fileContainer";
            fileContainer.Size = new Size(150, 150);
            fileContainer.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 315);
            Controls.Add(label2);
            Controls.Add(fileContainer);
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
        private Label label2;
        private FlowLayoutPanel fileContainer;
    }
}