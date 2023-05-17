using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace ParserProgram.Classes.Textcomparing
{
    public class TextComparator
    {
        string pathToSave;
        string oldText;
        string newText;
        string header = "KP?";
        XTextFormatter tf;
        PdfDocument pdf;
        PdfPage pdfPage;
        double y = 20;
        int lineCount = 0;
        XGraphics graph;
        XFont textFont;
        XFont dateFont;
        XFont headerFont;
        public TextComparator(string oldT, string newT)
        {
            oldText = oldT;
            newText = newT;
            InitPDF();
        }
        public TextComparator(string oldT, string newT, string date, string header, string path)
        {
            pathToSave = path + "\\" + date;
            oldText = oldT;
            newText = newT;
            this.header = header;
            InitPDF();
            AddToPDF(this.header, "Black", 16, "center", headerFont);
            AddToPDF("Дата : " + date, "Black", 14, "center", dateFont);
        }

        void InitPDF()
        {
            // Настройка документа
            pdf = new PdfDocument();
            pdfPage = pdf.AddPage();
            graph = XGraphics.FromPdfPage(pdfPage);
            tf = new XTextFormatter(graph);
            pdf.Info.Author = "MMC";
            pdf.Info.Keywords = "ММЦ, Минздрав, Клинические рекомендации";
            pdfPage.Size = PageSize.A4;
            // Создание шрифта для текста
            textFont = new XFont("Times New Roman", 12, XFontStyle.Regular);
            // Создание шрифта для даты
            dateFont = new XFont("Times New Roman", 14, XFontStyle.Bold);
            // Создание шрифта для заголовка
            headerFont = new XFont("Times New Roman", 16, XFontStyle.BoldItalic);
        }

        void AddToPDF(string text, string color, int height, string position, XFont font)
        {
            double x = 10;
            if (position == "left")
                x = 10;
            if (position == "center")
                x = pdfPage.Width / 2 - 30;
            // Создание прямоугольника для рисования текста и отрисовки в нем
            XRect rect = new XRect(x, y, pdfPage.Width, height);
            if (color == "Black")
                tf.DrawString(text, font, XBrushes.Black, rect);
            else if (color == "Red")
                tf.DrawString(text, font, XBrushes.DarkRed, rect);
            else if (color == "Green")
                tf.DrawString(text, font, XBrushes.Green, rect);
            else if (color == "Yellow")
                tf.DrawString(text, font, XBrushes.Orange, rect);
            lineCount++;
            y += height;
            if (y >= height * 55)
            {
                pdfPage = pdf.AddPage();
                graph = XGraphics.FromPdfPage(pdfPage);
                tf = new XTextFormatter(graph);
                y = 20;
            }
        }

        void AddToPDF(string text, string color)
        {
            // Создание прямоугольника для рисования текста и отрисовки в нем
            XRect rect = new XRect(10, y, pdfPage.Width, 12);
            if (color == "Black")
                tf.DrawString(text, textFont, XBrushes.Black, rect);
            else if (color == "Red")
                tf.DrawString(text, textFont, XBrushes.DarkRed, rect);
            else if (color == "Green")
                tf.DrawString(text, textFont, XBrushes.Green, rect);
            else if (color == "Yellow")
                tf.DrawString(text, textFont, XBrushes.Orange, rect);
            lineCount++;
            y += 14;
            if (y >= 14 * 55)
            {
                pdfPage = pdf.AddPage();
                graph = XGraphics.FromPdfPage(pdfPage);
                tf = new XTextFormatter(graph);
                y = 20;
            }
        }

        void CreatePDF()
        {
            pdf.Save(pathToSave + "\\changed\\report " + header + ".pdf");
        }

        public void Compare()
        {
            //Проверка первого уровня: тексты целиком
            if (oldText != newText)
            {
                //Списки параграфов текста 1 и всех предложений этих абзацев
                List<SentencesClass> sentences1 = new List<SentencesClass>();
                List<string> paragraphs1 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < oldText.Split('\n').Length; i++)
                    paragraphs1.Add(oldText.Split('\n')[i]);
                if (oldText.Split('\n').Length < newText.Split('\n').Length)
                    for (int i = 0; i < Math.Abs(oldText.Split('\n').Length - newText.Split('\n').Length); i++)
                        paragraphs1.Add("[Абзац отсутствует]");

                //Списки параграфов текста 2 и всех предложений этих абзацев
                List<SentencesClass> sentences2 = new List<SentencesClass>();
                List<string> paragraphs2 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < newText.Split('\n').Length; i++)
                    paragraphs2.Add(newText.Split('\n')[i]);
                if (oldText.Split('\n').Length > newText.Split('\n').Length)
                    for (int i = 0; i < Math.Abs(oldText.Split('\n').Length - newText.Split('\n').Length); i++)
                        paragraphs2.Add("[Абзац удален]");

                //Заполнение списка предложений
                for (int i = 0; i < paragraphs1.Count; i++)
                {
                    for (int j = 0; j < paragraphs1[i].Split('.').Length; j++)
                        if (paragraphs1[i].Split('.')[j].Length > 0 && paragraphs1[i].Split('.')[j] != "[Абзац отсутствует]")
                            sentences1.Add(new SentencesClass(i, paragraphs1[i].Split('.')[j] + "."));
                    try
                    {
                        if (paragraphs1[i].Split('.').Length < paragraphs2[i].Split('.').Length)
                            for (int j = 0; j < Math.Abs(paragraphs1[i].Split('.').Length - paragraphs2[i].Split('.').Length); j++)
                                sentences1.Add(new SentencesClass(i, " [Предложение отсутствует]. "));
                    }
                    catch { }
                    if (sentences1.Count > 0)
                        sentences1[sentences1.Count - 1].text += "\n";
                }
                //Заполнение списка предложений
                for (int i = 0; i < paragraphs2.Count; i++)
                {
                    for (int j = 0; j < paragraphs2[i].Split('.').Length; j++)
                        if (paragraphs2[i].Split('.')[j].Length > 0 && paragraphs2[i].Split('.')[j] != "[Абзац удален]")
                            sentences2.Add(new SentencesClass(i, paragraphs2[i].Split('.')[j] + "."));
                    try
                    {
                        if (paragraphs1[i].Split('.').Length > paragraphs2[i].Split('.').Length)
                            for (int j = 0; j < Math.Abs(paragraphs1[i].Split('.').Length - paragraphs2[i].Split('.').Length); j++)
                                sentences2.Add(new SentencesClass(i, " [Предложение удалено]. "));
                    }
                    catch { }
                    if (sentences2.Count > 0)
                        sentences2[sentences2.Count - 1].text += "\n";
                }

                //Проверка второго уровня: Абзацы целиком
                for (int i = 0; i < paragraphs1.Count; i++)
                {

                    if (paragraphs1[i] == paragraphs2[i])
                    {
                        //AddToPDF(oldText, paragraphs1[i] + "\n", Color.White);
                        AddToPDF(paragraphs2[i], "Black");

                    }
                    else if (paragraphs1[i] == "[Абзац отсутствует]")
                    {
                        //AddToPDF(oldText, paragraphs1[i] + "\n", Color.Red);
                        AddToPDF(paragraphs2[i], "Green");
                    }
                    else if (paragraphs2[i] == "[Абзац удален]")
                    {
                        AddToPDF(paragraphs2[i], "Red");
                        //AddToPDF(paragraphs1[i] + "\n", "Green");
                    }
                    else
                    {
                        //Проверка третьего уровня: Предложения целиком
                        for (int k = 0; k < sentences1.Count; k++)
                        {
                            if (sentences1[k].paragraphID == i && sentences2[k].paragraphID == i)
                            {
                                if (sentences1[k].text == sentences2[k].text)
                                {
                                    //AddToPDF(oldText, sentences1[k].text, Color.White);
                                    AddToPDF(sentences2[k].text, "Black");
                                }
                                else if (sentences1[k].text.Replace("\n", "") == " [Предложение отсутствует]. ")
                                {
                                    //AddToPDF(oldText, sentences1[k].text, Color.Red);
                                    AddToPDF(sentences2[k].text, "Green");
                                }
                                else if (sentences2[k].text.Replace("\n", "") == " [Предложение удалено]. ")
                                {
                                    AddToPDF(sentences2[k].text, "Red");
                                    //AddToPDF(oldText, sentences1[k].text, Color.LimeGreen);
                                }
                                else
                                {
                                    //AddToPDF(oldText, sentences1[k].text, Color.Yellow);
                                    AddToPDF(sentences2[k].text, "Yellow");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                AddToPDF("Текст не изменен", "Black");
            }
            CreatePDF();
        }
    }
}
