namespace ParserMenu
{
    partial class FormMain
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
            textBox_ParsePath = new TextBox();
            label_ParsePath = new Label();
            button_SearchPath = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            label2 = new Label();
            checkBox_Info = new CheckBox();
            label3 = new Label();
            textBox_Name = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox_Password = new TextBox();
            checkBox_showPass = new CheckBox();
            chooseSender = new Button();
            textBox_EmailSender = new TextBox();
            chooseReciever = new Button();
            textBox_EmailReciever = new TextBox();
            button_Save = new Button();
            button_LaunchStop = new Button();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // textBox_ParsePath
            // 
            textBox_ParsePath.BackColor = Color.White;
            textBox_ParsePath.Enabled = false;
            textBox_ParsePath.ForeColor = Color.Gray;
            textBox_ParsePath.Location = new Point(35, 55);
            textBox_ParsePath.Name = "textBox_ParsePath";
            textBox_ParsePath.ReadOnly = true;
            textBox_ParsePath.Size = new Size(335, 29);
            textBox_ParsePath.TabIndex = 1;
            textBox_ParsePath.TabStop = false;
            // 
            // label_ParsePath
            // 
            label_ParsePath.AutoSize = true;
            label_ParsePath.Location = new Point(35, 31);
            label_ParsePath.Name = "label_ParsePath";
            label_ParsePath.Size = new Size(102, 21);
            label_ParsePath.TabIndex = 1;
            label_ParsePath.Text = "Путь к папке";
            // 
            // button_SearchPath
            // 
            button_SearchPath.BackColor = Color.White;
            button_SearchPath.FlatStyle = FlatStyle.Popup;
            button_SearchPath.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_SearchPath.ForeColor = Color.Black;
            button_SearchPath.Location = new Point(376, 55);
            button_SearchPath.Name = "button_SearchPath";
            button_SearchPath.Size = new Size(81, 29);
            button_SearchPath.TabIndex = 2;
            button_SearchPath.Text = "Поиск";
            button_SearchPath.UseVisualStyleBackColor = false;
            button_SearchPath.Click += button_SearchPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 241);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 10;
            label2.Text = "Получатель";
            // 
            // checkBox_Info
            // 
            checkBox_Info.AutoSize = true;
            checkBox_Info.Location = new Point(35, 300);
            checkBox_Info.Name = "checkBox_Info";
            checkBox_Info.Size = new Size(182, 25);
            checkBox_Info.TabIndex = 11;
            checkBox_Info.TabStop = false;
            checkBox_Info.Text = "Информировать всех";
            checkBox_Info.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 185);
            label3.Name = "label3";
            label3.Size = new Size(103, 21);
            label3.TabIndex = 15;
            label3.Text = "Отправитель";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(35, 130);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(167, 29);
            textBox_Name.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 106);
            label4.Name = "label4";
            label4.Size = new Size(135, 21);
            label4.TabIndex = 19;
            label4.Text = "Имя отправителя";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(208, 106);
            label5.Name = "label5";
            label5.Size = new Size(167, 21);
            label5.TabIndex = 21;
            label5.Text = "Пароль для устройств";
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(208, 130);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(249, 29);
            textBox_Password.TabIndex = 4;
            textBox_Password.UseSystemPasswordChar = true;
            // 
            // checkBox_showPass
            // 
            checkBox_showPass.AutoSize = true;
            checkBox_showPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox_showPass.Location = new Point(362, 165);
            checkBox_showPass.Name = "checkBox_showPass";
            checkBox_showPass.Size = new Size(95, 25);
            checkBox_showPass.TabIndex = 22;
            checkBox_showPass.TabStop = false;
            checkBox_showPass.Text = "Показать";
            checkBox_showPass.UseVisualStyleBackColor = true;
            checkBox_showPass.CheckedChanged += checkBox_showPass_CheckedChanged;
            // 
            // chooseSender
            // 
            chooseSender.BackColor = Color.White;
            chooseSender.FlatStyle = FlatStyle.Popup;
            chooseSender.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            chooseSender.ForeColor = Color.Black;
            chooseSender.Location = new Point(376, 209);
            chooseSender.Name = "chooseSender";
            chooseSender.Size = new Size(81, 29);
            chooseSender.TabIndex = 6;
            chooseSender.Text = "Выбрать";
            chooseSender.UseVisualStyleBackColor = false;
            chooseSender.Click += chooseSender_Click;
            // 
            // textBox_EmailSender
            // 
            textBox_EmailSender.BackColor = Color.White;
            textBox_EmailSender.Enabled = false;
            textBox_EmailSender.ForeColor = Color.Gray;
            textBox_EmailSender.Location = new Point(35, 209);
            textBox_EmailSender.Name = "textBox_EmailSender";
            textBox_EmailSender.ReadOnly = true;
            textBox_EmailSender.Size = new Size(335, 29);
            textBox_EmailSender.TabIndex = 5;
            // 
            // chooseReciever
            // 
            chooseReciever.BackColor = Color.White;
            chooseReciever.FlatStyle = FlatStyle.Popup;
            chooseReciever.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            chooseReciever.ForeColor = Color.Black;
            chooseReciever.Location = new Point(376, 265);
            chooseReciever.Name = "chooseReciever";
            chooseReciever.Size = new Size(81, 29);
            chooseReciever.TabIndex = 8;
            chooseReciever.Text = "Выбрать";
            chooseReciever.UseVisualStyleBackColor = false;
            chooseReciever.Click += chooseReciever_Click;
            // 
            // textBox_EmailReciever
            // 
            textBox_EmailReciever.BackColor = Color.White;
            textBox_EmailReciever.Enabled = false;
            textBox_EmailReciever.ForeColor = Color.Gray;
            textBox_EmailReciever.Location = new Point(35, 265);
            textBox_EmailReciever.Name = "textBox_EmailReciever";
            textBox_EmailReciever.ReadOnly = true;
            textBox_EmailReciever.Size = new Size(335, 29);
            textBox_EmailReciever.TabIndex = 7;
            // 
            // button_Save
            // 
            button_Save.BackColor = Color.White;
            button_Save.FlatStyle = FlatStyle.Popup;
            button_Save.Location = new Point(324, 412);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(133, 29);
            button_Save.TabIndex = 10;
            button_Save.Text = "Сохранить";
            button_Save.UseVisualStyleBackColor = false;
            button_Save.Click += button_Save_Click;
            // 
            // button_LaunchStop
            // 
            button_LaunchStop.BackColor = Color.White;
            button_LaunchStop.FlatStyle = FlatStyle.Popup;
            button_LaunchStop.Location = new Point(324, 447);
            button_LaunchStop.Name = "button_LaunchStop";
            button_LaunchStop.Size = new Size(133, 29);
            button_LaunchStop.TabIndex = 11;
            button_LaunchStop.Text = "Запустить";
            button_LaunchStop.UseVisualStyleBackColor = false;
            button_LaunchStop.Click += button1_Launch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 349);
            label1.Name = "label1";
            label1.Size = new Size(146, 21);
            label1.TabIndex = 26;
            label1.Text = "Время автозапуска";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(35, 373);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(75, 29);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.Value = new DateTime(2023, 4, 27, 0, 0, 0, 0);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(491, 506);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(button_LaunchStop);
            Controls.Add(button_Save);
            Controls.Add(textBox_EmailReciever);
            Controls.Add(chooseReciever);
            Controls.Add(textBox_EmailSender);
            Controls.Add(chooseSender);
            Controls.Add(checkBox_showPass);
            Controls.Add(label5);
            Controls.Add(textBox_Password);
            Controls.Add(label4);
            Controls.Add(textBox_Name);
            Controls.Add(label3);
            Controls.Add(checkBox_Info);
            Controls.Add(label2);
            Controls.Add(button_SearchPath);
            Controls.Add(label_ParsePath);
            Controls.Add(textBox_ParsePath);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(507, 545);
            MinimumSize = new Size(507, 545);
            Name = "FormMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню";
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ParsePath;
        private Label label_ParsePath;
        private Button button_SearchPath;
        private FolderBrowserDialog folderBrowserDialog;
        private Label label2;
        private CheckBox checkBox_Info;
        private Label label3;
        private TextBox textBox_Name;
        private Label label4;
        private Label label5;
        private TextBox textBox_Password;
        private CheckBox checkBox_showPass;
        private Button chooseSender;
        internal TextBox textBox_EmailSender;
        private Button chooseReciever;
        internal TextBox textBox_EmailReciever;
        private Button button_Save;
        private Button button_LaunchStop;
        private Label label1;
        private DateTimePicker dateTimePicker1;
    }
}