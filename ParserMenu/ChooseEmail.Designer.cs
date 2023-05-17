namespace ParserMenu
{
    partial class ChooseEmail
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
            comboBoxEmails = new ComboBox();
            label = new Label();
            buttonDone = new Button();
            buttonAdd = new Button();
            buttonDel = new Button();
            textBox_NewEmail = new TextBox();
            labelLines = new Label();
            SuspendLayout();
            // 
            // comboBoxEmails
            // 
            comboBoxEmails.Cursor = Cursors.Hand;
            comboBoxEmails.FormattingEnabled = true;
            comboBoxEmails.Location = new Point(12, 42);
            comboBoxEmails.Name = "comboBoxEmails";
            comboBoxEmails.Size = new Size(283, 29);
            comboBoxEmails.TabIndex = 0;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 18);
            label.Name = "label";
            label.Size = new Size(0, 21);
            label.TabIndex = 1;
            // 
            // buttonDone
            // 
            buttonDone.BackColor = Color.White;
            buttonDone.FlatStyle = FlatStyle.Popup;
            buttonDone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDone.Location = new Point(301, 42);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(93, 29);
            buttonDone.TabIndex = 2;
            buttonDone.Text = "Готово";
            buttonDone.UseVisualStyleBackColor = false;
            buttonDone.Click += buttonDone_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.White;
            buttonAdd.FlatStyle = FlatStyle.Popup;
            buttonAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAdd.Location = new Point(301, 108);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(93, 29);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDel
            // 
            buttonDel.BackColor = Color.White;
            buttonDel.FlatStyle = FlatStyle.Popup;
            buttonDel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDel.Location = new Point(301, 143);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(93, 29);
            buttonDel.TabIndex = 4;
            buttonDel.Text = "Удалить";
            buttonDel.UseVisualStyleBackColor = false;
            buttonDel.Click += buttonDel_Click;
            // 
            // textBox_NewEmail
            // 
            textBox_NewEmail.BorderStyle = BorderStyle.FixedSingle;
            textBox_NewEmail.Location = new Point(12, 108);
            textBox_NewEmail.MaxLength = 50;
            textBox_NewEmail.Name = "textBox_NewEmail";
            textBox_NewEmail.Size = new Size(283, 29);
            textBox_NewEmail.TabIndex = 5;
            // 
            // labelLines
            // 
            labelLines.AutoSize = true;
            labelLines.ForeColor = Color.Gray;
            labelLines.Location = new Point(12, 78);
            labelLines.Name = "labelLines";
            labelLines.Size = new Size(382, 21);
            labelLines.TabIndex = 6;
            labelLines.Text = "--------------------------------------------------------------";
            // 
            // ChooseEmail
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 184);
            Controls.Add(labelLines);
            Controls.Add(textBox_NewEmail);
            Controls.Add(buttonDel);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDone);
            Controls.Add(label);
            Controls.Add(comboBoxEmails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(422, 223);
            MinimumSize = new Size(422, 223);
            Name = "ChooseEmail";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройка почты";
            Load += ChooseEmail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxEmails;
        private Label label;
        private Button buttonDone;
        private Button buttonAdd;
        private Button buttonDel;
        private TextBox textBox_NewEmail;
        private Label labelLines;
    }
}