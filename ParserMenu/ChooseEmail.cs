using System.Collections.Specialized;
using System.Runtime.Serialization.Formatters.Binary;
using ParserProgram;

namespace ParserMenu
{
    public partial class ChooseEmail : System.Windows.Forms.Form
    {
        FormMain formMain;
        StringCollection emailCollection;
        int type;
        string pathFIleSerialize;
        List<string> strList = new List<string>();

        internal ChooseEmail(FormMain main, int type, string pathFIleSerialize)
        {
            InitializeComponent();
            formMain = main;
            this.type = type;
            this.pathFIleSerialize = pathFIleSerialize;
        }

        private void ChooseEmail_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxEmails.DropDownStyle = ComboBoxStyle.DropDownList;

                string typeName = "";
                label.Text = "Выберите почту " + typeName;

                BinaryFormatter formatter = new();
                using (FileStream stream = new(pathFIleSerialize, FileMode.OpenOrCreate))
                {
                    Settings settings = (Settings)formatter.Deserialize(stream);
                    if (type == 0)
                    {
                        typeName = "отправителя";

                        for (int i = 0; i < formMain.listSenders.Count; i++)
                        {
                            comboBoxEmails.Items.Add(formMain.listSenders[i]);
                        }
                        comboBoxEmails.SelectedItem = formMain.defSender;
                    }
                    else
                    {
                        typeName = "получателя";

                        for (int i = 0; i < formMain.listReciever.Count; i++)
                        {
                            comboBoxEmails.Items.Add(formMain.listReciever[i]);
                        }
                        comboBoxEmails.SelectedItem = formMain.defReciever;
                    }
                }
            }
            catch { }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                for (int i = 0; i < comboBoxEmails.Items.Count; i++) // Сохранить список почт
                {
                    strList.Add(comboBoxEmails.Items[i].ToString());
                }
                formMain.textBox_EmailSender.Text = comboBoxEmails.Text;
                formMain.listSenders = strList;
                formMain.defSender = comboBoxEmails.Text;
            }
            else
            {
                for (int i = 0; i < comboBoxEmails.Items.Count; i++) // Сохранить список почт
                {
                    strList.Add(comboBoxEmails.Items[i].ToString());
                }
                formMain.textBox_EmailReciever.Text = comboBoxEmails.Text;
                formMain.listReciever = strList;
                formMain.defReciever = comboBoxEmails.Text;
            }
            this.Close();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            comboBoxEmails.Items.Remove(comboBoxEmails.Text);
            comboBoxEmails.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox_NewEmail.Text != "")
            {
                comboBoxEmails.Items.Add(textBox_NewEmail.Text);
                comboBoxEmails.SelectedItem = textBox_NewEmail.Text;
            }
        }
    }
}
