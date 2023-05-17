using System.Net.Mail;
using System.Net;

namespace ParserProgram.Classes
{
    internal class EmailClass
    {
        static string dateNow = DateTime.Now.ToShortDateString();
        static string emailSendDef;
        static string emailRecDef;
        List<string> emailsRecievers;
        static string name;
        static string password;
        static bool allEmails;

        internal EmailClass(string emailS, string emailR, List<string> emailsRec, string n, string p, bool allE) 
        {
            emailSendDef = emailS;
            emailRecDef = emailR;
            emailsRecievers = emailsRec;
            name = n;
            password = p;
            allEmails = allE;
        }

        SmtpClient smtp;
        MailAddress reciever;
        MailAddress sender;
        MailMessage message;

        private void SendMessage(string rec, string added, string changed, string deleted)
        {
            string time = DateTime.Now.ToShortTimeString();
            reciever = new(rec); //Получатель
            message = new(sender, reciever); //Сообщение

            string mesTitle = "<h2>Результаты анализа</h2><p>Дата: " + dateNow + "<br>Время: " + time + "</p>";
            message.Subject = "ММЦ оповещение об изменениях клинических рекомендаций";

            if (added == "Без изменений" && changed == "Без изменений" && deleted == "Без изменений")
            {
                message.Body = mesTitle + "<h4>Изменений не найдено</h4>";
            }
            else
            {
                message.Body = mesTitle + "<h4>Добавлены:</h4><p>" + added + "</p><h4>Изменены:</h4><p>" + changed + "</p><h4>Удалены:</h4><p>" + deleted + "</p>";
            }
            message.IsBodyHtml = true;

            try
            {
                smtp.Send(message);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, проверьте соответствие пароля устройства от выбранного отправителя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void GetMessage(string added, string changed, string deleted)
        {
            string emailRec;
            smtp = new SmtpClient("smtp.mail.ru", 25); //smtp порт
            smtp.Credentials = new NetworkCredential(emailSendDef, password); //Логин и пароль отправителя
            smtp.EnableSsl = true;
            sender = new MailAddress(emailSendDef, name);

            if (allEmails == true)
            {
                for (int i = 0; i < emailsRecievers.Count; i++)
                {
                    emailRec = emailsRecievers[i];
                    SendMessage(emailRec, added, changed, deleted);
                }
            }
            else
            {
                emailRec = emailRecDef;
                SendMessage(emailRec, added, changed, deleted);
            }
        }
    }
}
