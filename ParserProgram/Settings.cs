using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserProgram
{
    [Serializable]
    public class Settings
    {
        public string parsePath { get; set; }
        public List<string> emailSender { get; set; }
        public string emailSenDefault { get; set; }
        public List<string> emailReciever { get; set; }
        public string emailRecDefault { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool allEmails { get; set; }

        public string time { get; set; }
    }
}
