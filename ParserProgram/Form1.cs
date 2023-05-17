using ParserProgram.Classes;
using ParserProgram.Classes.Textcomparing;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParserProgram
{
    public partial class Form : System.Windows.Forms.Form
    {
        const string pathFileSerialize = @"..\..\..\..\serializeINFO.bin";

        string parsePath = "";
        string name = "";
        string password = "";
        List<string> emailsReceiver = new();
        string emailSenDefault = "";
        string emailRecDefault = "";
        bool allEmails;
        string time = "";

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(pathFileSerialize, FileMode.OpenOrCreate))
                {
                    Settings settings = (Settings)formatter.Deserialize(stream);

                    parsePath = settings.parsePath;
                    name = settings.name;
                    password = settings.password;
                    emailsReceiver = settings.emailReciever;
                    emailSenDefault = settings.emailSenDefault;
                    emailRecDefault = settings.emailRecDefault;
                    allEmails = settings.allEmails;
                    time = settings.time;
                }
            }
            catch { }

            AutorunClass autorunClass = new AutorunClass();
            autorunClass.AutoRun(true);

            timer.Start();
        }

        private void StartProgram()
        {
            ArchiveClass archiveClass = new ArchiveClass(parsePath);
            CompareClass compareClass = new CompareClass(parsePath, emailSenDefault, emailRecDefault, emailsReceiver, name, password, allEmails);
            WebClass webClass = new WebClass(parsePath);

            //webClass.DoSearch();
            compareClass.DoCompare();
            archiveClass.doArchive();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string actTime = DateTime.Now.ToShortTimeString();
            if (time == actTime)
            {
                StartProgram();
                timer.Stop();
            }
        }
    }
}