using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace ParserProgram.Classes.Textcomparing
{
    internal class PdfClass
    {
        static string folderPath;
        static string dateNow = DateTime.Now.ToShortDateString();
        static string datePast = DateTime.Now.AddDays(-1).ToShortDateString();
        internal PdfClass(string folderP)
        {
            folderPath = folderP;
        }

        private string getPdfText(string date, string pdfName)
        {
            string exctractedText = "";
            try
            {
                string pdfPath = folderPath + "\\" + date + "\\files_PDF\\" + pdfName + ".pdf";
                using (PdfReader reader = new PdfReader(pdfPath))
                {
                    StringBuilder text = new StringBuilder();
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    exctractedText = text.ToString();
                }
            }
            catch
            {

            }
            return exctractedText;
        }

        internal void doTextAnalysis(List<string> pdfIds)
        {
            for(int i = 0; i < pdfIds.Count; i++)
            {
                string pdfId = pdfIds[i];
                string oldText = getPdfText(datePast, pdfId);
                string actText = getPdfText(dateNow, pdfId);
                TextComparator textComparator = new(oldText, actText, dateNow, pdfId, folderPath);
                textComparator.Compare();
            }
        }
    }
}
