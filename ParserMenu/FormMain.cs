using ParserProgram.Classes;
using System.Diagnostics;
using ParserProgram;
using System.Runtime.Serialization.Formatters.Binary;
using OpenQA.Selenium.DevTools.V110.DOM;

namespace ParserMenu
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        internal List<string> listSenders = new List<string>();
        internal List<string> listReciever = new List<string>();
        internal string defSender;
        internal string defReciever;

        private const string pathFileSerialize = @"..\..\..\..\serializeINFO.bin";

        internal FormMain()
        {
            InitializeComponent();
        }

        private void checkProcess()
        {
            Process[] pname = Process.GetProcessesByName("ParserProgram");
            if (pname.Length == 0)
            {
                button_LaunchStop.Text = "Запустить";
            }
            else
            {
                button_LaunchStop.Text = "Остановить";
            }
        }

        private void LaunchProgram()
        {
            GetexeClass getexeClass = new();
            string exePath = "";
            getexeClass.getExe(ref exePath);

            if (button_LaunchStop.Text == "Запустить")
            {
                Process.Start(exePath);
                button_LaunchStop.Text = "Остановить";
            }
            else
            {
                foreach (Process proc in Process.GetProcessesByName("ParserProgram"))
                {
                    proc.Kill();
                }
                button_LaunchStop.Text = "Запустить";
            }
        }

        private void SaveProperties() //Сохранить параметры
        {
            bool flagAllEmail = false;

            if (checkBox_Info.Checked)
                flagAllEmail = true;
            else
                flagAllEmail = false;

            Settings settings = new()
            {
                parsePath = textBox_ParsePath.Text,
                emailSender = listSenders,
                emailSenDefault = textBox_EmailSender.Text,
                emailReciever = listReciever,
                emailRecDefault = textBox_EmailReciever.Text,
                name = textBox_Name.Text,
                password = textBox_Password.Text,
                allEmails = flagAllEmail,
                time = dateTimePicker1.Text
            };

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(pathFileSerialize, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, settings);
            }
        }

        private void FormMain_Load(object sender, EventArgs e) //При загрузке формы
        {
            checkProcess();

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(pathFileSerialize, FileMode.OpenOrCreate))
                {
                    Settings settings = (Settings)formatter.Deserialize(stream);

                    textBox_ParsePath.Text = settings.parsePath;
                    textBox_Name.Text = settings.name;
                    textBox_Password.Text = settings.password;
                    listSenders = settings.emailSender;
                    listReciever = settings.emailReciever;
                    textBox_EmailSender.Text = settings.emailSenDefault;
                    defSender = settings.emailSenDefault;
                    textBox_EmailReciever.Text = settings.emailRecDefault;
                    defReciever = settings.emailRecDefault;
                    dateTimePicker1.Text = settings.time;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SearchPath_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.ShowDialog();
                textBox_ParsePath.Text = folderBrowserDialog.SelectedPath.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_showPass_CheckedChanged(object sender, EventArgs e) //Показать пароль
        {
            if (checkBox_showPass.Checked)
            {
                textBox_Password.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void chooseSender_Click(object sender, EventArgs e)
        {
            ChooseEmail chooseEmail = new(this, 0, pathFileSerialize);
            chooseEmail.ShowDialog();
        }

        private void chooseReciever_Click(object sender, EventArgs e)
        {
            ChooseEmail chooseEmail = new(this, 1, pathFileSerialize);
            chooseEmail.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveProperties();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (textBox_ParsePath.Text != "" && textBox_Name.Text != "" && textBox_Password.Text != "" && textBox_EmailSender.Text != "" && textBox_EmailReciever.Text != "")
            {
                SaveProperties();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
        }

        private void button1_Launch_Click(object sender, EventArgs e)
        {
            LaunchProgram();
        }
    }
}