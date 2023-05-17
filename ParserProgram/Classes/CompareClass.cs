using Org.BouncyCastle.Crypto;
using ParserProgram.Classes.Textcomparing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ParserProgram.Classes
{
    internal class CompareClass
    {
        static string folderPath;
        static string emailSendDef;
        static string emailRecDef;
        List<string> emailsRecievers;
        static string name;
        static string password;
        static bool allEmails;

        internal CompareClass(string folderP, string emailS, string emailR, List<string> emailsRec, string n, string p, bool allE)
        {
            folderPath = folderP;
            emailSendDef = emailS;
            emailRecDef = emailR;
            emailsRecievers = emailsRec;
            name = n;
            password = p;
            allEmails = allE;
        }

        private void getFileInfo(string path, ref List<string[]> filesOnly, ref List<string> idOnly)
        {
            List<string> lines = File.ReadLines(path).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines.ElementAt(i).Split(' ');
                idOnly.Add(line[0]);
                filesOnly.Add(line);
            }
        }

        private List<string> findChanges(List<string> neededId, List<string[]> neededInfo)
        {
            List<string> result = new();
            for (int i = 0; i < neededId.Count(); i++)
            {
                for (int j = 0; j < neededInfo.Count(); j++)
                {
                    string[] line = neededInfo.ElementAt(j);
                    if (neededId.ElementAt(i) == line[0])
                    {
                        result.Add(line[0] + " " + line[1]);
                    }
                }
            }
            return result;
        }

        string formatText(List<string> idList) //Форматировать список файлов
        {
            string text = "";
            if (idList.Count > 0)
            {
                for (int i = 0; i < idList.Count; i++)
                {
                    text += idList[i].Replace('_', ' ') + "<br>";
                }
            }
            else
            {
                text = "Без изменений";
            }
            return text;
        }

        private void CreateFoldersForReport(List<string> ids, string pdfPath, string needPath)
        {
            foreach (string id in ids)
            {
                string fileName = id + ".pdf";
                File.Copy(pdfPath + "\\" + fileName, needPath + "\\" + fileName, true);
            }
        }

        internal void DoCompare() //Сделать формирование отчета
        {
            string lastFolder = folderPath + "\\" + DateTime.Now.AddDays(-1).ToShortDateString();

            if (Directory.Exists(lastFolder))
            {
                List<string[]> actFilesInfo = new(); //Актуальный список (полный)
                List<string[]> lastFilesInfo = new(); //Прошеднмй список (полный)
                List<string> actIdOnly = new(); //Актуальный список (только id)
                List<string> lastIdOnly = new(); //Прошеднмй список (только id)

                string actInfoPath = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\idList.txt";
                string lastInfoPath = folderPath + "\\" + DateTime.Now.AddDays(-1).ToShortDateString() + "\\idList.txt";

                getFileInfo(actInfoPath, ref actFilesInfo, ref actIdOnly); //Информация актуального списка
                getFileInfo(lastInfoPath, ref lastFilesInfo, ref lastIdOnly); //Информация прошедшего списка

                List<string> addedId = actIdOnly.Except(lastIdOnly).ToList();
                List<string> addedInfo = findChanges(addedId, actFilesInfo); //Получить добавленные
                List<string> deletedId = lastIdOnly.Except(actIdOnly).ToList();
                List<string> deletedInfo = findChanges(deletedId, lastFilesInfo); //Получить удаленные

                List<string> sameFilesInfoAct = new();
                List<string> sameFilesInfoOld = new();
                for (int i = 0; i < actFilesInfo.Count; i++) //Нахождение изменений дат в файле
                {
                    for (int j = 0; j < lastFilesInfo.Count; j++)
                    {
                        string[] actLine = actFilesInfo.ElementAt(i);
                        string[] oldLine = lastFilesInfo.ElementAt(j);
                        if (actLine[0] == oldLine[0])
                        {
                            sameFilesInfoAct.Add(actLine[0] + " " + actLine[1] + " " + actLine[2]);
                            sameFilesInfoOld.Add(oldLine[0] + " " + oldLine[1] + " " + oldLine[2]);
                        }
                    }
                }

                List<string> changedFiles = sameFilesInfoAct.Except(sameFilesInfoOld).ToList();
                List<string> changedInfo = new();
                List<string> changedId = new();
                for (int i = 0; i < changedFiles.Count; i++)
                {
                    string[] line = changedFiles.ElementAt(i).Split(' ');
                    changedInfo.Add(line[0] + " " + line[1]);
                    changedId.Add(line[0]);
                }

                string addedMessage = formatText(addedInfo);
                string deletedMessage = formatText(deletedInfo);
                string changedMessage = formatText(changedInfo);

                string pathToAdded = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\added";
                string pathToDeleted = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\deleted";
                string pathToChanged = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\changed";
                Directory.CreateDirectory(pathToAdded);
                Directory.CreateDirectory(pathToDeleted);
                Directory.CreateDirectory(pathToChanged);

                string actPath = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\files_PDF";
                string oldPath = folderPath + "\\" + DateTime.Now.ToShortDateString() + "\\files_PDF";
                
                CreateFoldersForReport(addedId, actPath, pathToAdded);
                CreateFoldersForReport(deletedId, oldPath, pathToDeleted);

                foreach (string id in changedId)
                {
                    string fileName = id + ".pdf";
                    File.Copy(actPath + "\\" + fileName, pathToChanged + "\\" + DateTime.Now.ToShortDateString() + " " + fileName, true);
                    File.Copy(oldPath + "\\" + fileName, pathToChanged + "\\" + DateTime.Now.AddDays(-1).ToShortDateString() + " " + fileName, true);
                }

                EmailClass email = new(emailSendDef, emailRecDef, emailsRecievers, name, password, allEmails);
                email.GetMessage(addedMessage, changedMessage, deletedMessage);

                PdfClass pdf = new(folderPath); //Сравнение текста и создание отчета
                pdf.doTextAnalysis(changedId);
            }            
        }
    }
}
