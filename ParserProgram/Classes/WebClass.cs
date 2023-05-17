using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace ParserProgram.Classes
{
    internal class WebClass
    {
        static string folderPath;
        internal WebClass(string folderP)
        {
            folderPath = folderP;
        }
 
        static string dateNow = DateTime.Now.ToShortDateString();
        ChromeDriverService service;
        ChromeOptions options;

        private IWebDriver SetDriver()
        {
            service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            options = new();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(service, options);
            return driver;
        }

        private void SaveToTxt(List<string> filesInfo)
        {
            string fileInfoPath = folderPath + "\\" + dateNow + "\\idList.txt";
            File.Create(fileInfoPath).Close();
            File.WriteAllLines(fileInfoPath, filesInfo);
        }

        private void DownloadPdf(List<string> id)
        {
            string pdfPath = folderPath + "\\" + dateNow + "\\" + "files_PDF";

            if (!Directory.Exists(pdfPath))
                Directory.CreateDirectory(pdfPath);

            for (int i = 0; i < id.Count; i++)
            {
                string uri = "https://apicr.minzdrav.gov.ru/api.ashx?op=GetClinrecPdf&id=" + id[i].Trim('К', 'Р');
                string fileName = pdfPath + "\\" + id[i].Replace('_', '-') + ".pdf";
                using (WebClient wc = new())
                {
                    wc.DownloadFile(uri, fileName);
                }
            }
        }

        internal void DoSearch()
        {
            try
            {
                IWebDriver driver = SetDriver();
                driver.Navigate().GoToUrl("https://cr.minzdrav.gov.ru/clin_recomend");
                Thread.Sleep(500);
                List<IWebElement> idsWeb = driver.FindElements(By.XPath("//div[@class='tab-content-block__tab-pane-item-wrapper tab-content-block__tab-pane-item-wrapper_item']//div[1]/a")).ToList(); //Путь к столбцу id
                List<IWebElement> namesWeb = driver.FindElements(By.XPath("//div[@class='tab-content-block__tab-pane-item-wrapper tab-content-block__tab-pane-item-wrapper_item']//div[2]/a")).ToList(); //Путь к столбцу name
                List<IWebElement> datesWeb = driver.FindElements(By.XPath("//div[@class='tab-content-block__tab-pane-item-wrapper tab-content-block__tab-pane-item-wrapper_item']//div[5]")).ToList(); //Путь к столбцу date

                List<string> filesInfo = new();
                List<string> idOnly = new();

                for (int i = 1; i < idsWeb.Count; i++)
                {
                    string id = idsWeb[i].Text;
                    string name = namesWeb[i].Text;
                    string date = datesWeb[i].Text;
                    idOnly.Add(id);
                    filesInfo.Add(id.Replace('_', '-') + " " + name.Replace(' ', '_') + " " + date);
                }

                driver.Close();
                driver.Quit();

                Directory.CreateDirectory(folderPath + "\\" + dateNow);
                SaveToTxt(filesInfo);
                DownloadPdf(idOnly);
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка парсинга: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
