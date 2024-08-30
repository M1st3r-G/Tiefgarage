namespace Tiefgarage
{
    partial class SimulationWindow
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
            btnBack = new Button();
            tbxTitle = new TextBox();
            cbbxCars = new ComboBox();
            btnAddCar = new Button();
            btnRemoveCar = new Button();
            btnClear = new Button();
            grpInteract = new GroupBox();
            btnRandom = new Button();
            label2 = new Label();
            btnFind = new Button();
            btnRemove = new Button();
            btnEnter = new Button();
            label1 = new Label();
            displayContainer = new FlowLayoutPanel();
            btnNavRight = new Button();
            btnNavLeft = new Button();
            lblIndex = new Label();
            tbxOutput = new TextBox();
            label3 = new Label();
            tbxFree = new TextBox();
            grpInteract.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(702, 9);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(90, 22);
            btnBack.TabIndex = 0;
            btnBack.Text = "Zurück";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // tbxTitle
            // 
            tbxTitle.BorderStyle = BorderStyle.None;
            tbxTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            tbxTitle.Location = new Point(344, 9);
            tbxTitle.Multiline = true;
            tbxTitle.Name = "tbxTitle";
            tbxTitle.ReadOnly = true;
            tbxTitle.Size = new Size(352, 53);
            tbxTitle.TabIndex = 2;
            tbxTitle.Text = "Loem Ipsum dies ist ein Titel";
            tbxTitle.TextAlign = HorizontalAlignment.Center;
            tbxTitle.TextChanged += textBox1_TextChanged;
            // 
            // cbbxCars
            // 
            cbbxCars.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbxCars.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbxCars.DropDownStyle = ComboBoxStyle.Simple;
            cbbxCars.FormattingEnabled = true;
            cbbxCars.Location = new Point(312, 68);
            cbbxCars.MaxDropDownItems = 15;
            cbbxCars.Name = "cbbxCars";
            cbbxCars.Size = new Size(108, 255);
            cbbxCars.TabIndex = 3;
            // 
            // btnAddCar
            // 
            btnAddCar.Location = new Point(321, 335);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(35, 25);
            btnAddCar.TabIndex = 4;
            btnAddCar.Text = "+";
            btnAddCar.UseVisualStyleBackColor = true;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // btnRemoveCar
            // 
            btnRemoveCar.Location = new Point(375, 335);
            btnRemoveCar.Name = "btnRemoveCar";
            btnRemoveCar.Size = new Size(35, 25);
            btnRemoveCar.TabIndex = 5;
            btnRemoveCar.Text = "-";
            btnRemoveCar.UseVisualStyleBackColor = true;
            btnRemoveCar.Click += btnRemoveCar_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(312, 366);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 27);
            btnClear.TabIndex = 6;
            btnClear.Text = "Parkhaus Leeren";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // grpInteract
            // 
            grpInteract.Controls.Add(btnRandom);
            grpInteract.Controls.Add(label2);
            grpInteract.Controls.Add(btnFind);
            grpInteract.Controls.Add(btnRemove);
            grpInteract.Controls.Add(btnEnter);
            grpInteract.Controls.Add(label1);
            grpInteract.Location = new Point(455, 68);
            grpInteract.Name = "grpInteract";
            grpInteract.Size = new Size(142, 271);
            grpInteract.TabIndex = 7;
            grpInteract.TabStop = false;
            grpInteract.Text = "Interaktionen";
            // 
            // btnRandom
            // 
            btnRandom.Location = new Point(22, 164);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(114, 23);
            btnRandom.TabIndex = 5;
            btnRandom.Text = "Zufällig befahren";
            btnRandom.UseVisualStyleBackColor = true;
            btnRandom.Click += btnRandom_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 146);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Allgemein";
            // 
            // btnFind
            // 
            btnFind.Location = new Point(22, 95);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(114, 23);
            btnFind.TabIndex = 3;
            btnFind.Text = "Finden";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(22, 66);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(114, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Ausparken";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(22, 37);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(114, 23);
            btnEnter.TabIndex = 1;
            btnEnter.Text = "Einfahren";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "Ausgewähltes Auto";
            // 
            // displayContainer
            // 
            displayContainer.AutoScroll = true;
            displayContainer.Location = new Point(12, 12);
            displayContainer.Name = "displayContainer";
            displayContainer.Size = new Size(294, 348);
            displayContainer.TabIndex = 9;
            // 
            // btnNavRight
            // 
            btnNavRight.Location = new Point(258, 366);
            btnNavRight.Name = "btnNavRight";
            btnNavRight.Size = new Size(30, 30);
            btnNavRight.TabIndex = 11;
            btnNavRight.Text = ">";
            btnNavRight.UseVisualStyleBackColor = true;
            btnNavRight.Click += btnNavRight_Click;
            // 
            // btnNavLeft
            // 
            btnNavLeft.Location = new Point(23, 366);
            btnNavLeft.Name = "btnNavLeft";
            btnNavLeft.Size = new Size(30, 30);
            btnNavLeft.TabIndex = 12;
            btnNavLeft.Text = "<";
            btnNavLeft.UseVisualStyleBackColor = true;
            btnNavLeft.Click += btnNavLeft_Click;
            // 
            // lblIndex
            // 
            lblIndex.AutoSize = true;
            lblIndex.Location = new Point(127, 378);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(36, 15);
            lblIndex.TabIndex = 13;
            lblIndex.Text = "12/12";
            // 
            // tbxOutput
            // 
            tbxOutput.Location = new Point(624, 251);
            tbxOutput.Multiline = true;
            tbxOutput.Name = "tbxOutput";
            tbxOutput.Size = new Size(164, 136);
            tbxOutput.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(456, 345);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 16;
            label3.Text = "Freie Plätze";
            // 
            // tbxFree
            // 
            tbxFree.Location = new Point(477, 363);
            tbxFree.Name = "tbxFree";
            tbxFree.ReadOnly = true;
            tbxFree.Size = new Size(120, 23);
            tbxFree.TabIndex = 17;
            // 
            // SimulationWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 401);
            Controls.Add(tbxFree);
            Controls.Add(label3);
            Controls.Add(tbxOutput);
            Controls.Add(lblIndex);
            Controls.Add(btnNavLeft);
            Controls.Add(btnNavRight);
            Controls.Add(displayContainer);
            Controls.Add(grpInteract);
            Controls.Add(btnClear);
            Controls.Add(btnRemoveCar);
            Controls.Add(btnAddCar);
            Controls.Add(cbbxCars);
            Controls.Add(tbxTitle);
            Controls.Add(btnBack);
            Name = "SimulationWindow";
            Text = "SimulationWindow";
            grpInteract.ResumeLayout(false);
            grpInteract.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private TextBox tbxTitle;
        private ComboBox cbbxCars;
        private Button btnAddCar;
        private Button btnRemoveCar;
        private Button btnClear;
        private GroupBox grpInteract;
        private Button btnFind;
        private Button btnRemove;
        private Button btnEnter;
        private Label label1;
        private Button btnRandom;
        private Label label2;
        private FlowLayoutPanel displayContainer;
        private Button btnNavRight;
        private Button btnNavLeft;
        private Label lblIndex;
        private TextBox tbxOutput;
        private Label label3;
        private TextBox tbxFree;
    }
}