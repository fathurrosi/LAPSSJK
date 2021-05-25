using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LAPS.SJK.Logic.Helper
{
   public class PDFHelper
    {
        //http://asptipsandtricks.blogspot.com/2017/01/watermark-pdf-in-csharp.html
        public Paragraph AddParagragh(string ParagraphText)
        {
            Paragraph p = new Paragraph();
            p.SpacingBefore = 10f;
            p.FirstLineIndent = 10f;
            p.SpacingAfter = 15f;

            iTextSharp.text.Font f = new iTextSharp.text.Font();
            p.Font.SetFamily("Courier");
            p.Alignment = Element.ALIGN_JUSTIFIED;
            p.Font.Size = 13f;
            p.Font.SetColor(0, 0, 0);
            p.Add(ParagraphText);
            return p;
        }
        public Chunk AddParagraphHeader(string headingText)
        {
            Chunk ch = new Chunk(headingText);
            ch.Font.Size = 16f;
            ch.Font.SetStyle("bold");
            ch.Font.SetColor(0, 0, 0);
            return ch;
        }
        private void WriteWaterMark(string textWaterMark)
        {
            Document doc = new Document(PageSize.A4);

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/WaterMark.pdf", FileMode.Create));
                doc.Open();
                doc.Add(this.AddParagraphHeader("Getting ready"));
                doc.Add(this.AddParagragh(@"At the top level, there is a Figure instance containing all that we see and some more (that we don't see). The figure contains, among other things, instances of the Axes class as a Figure.axes field. The Axes instances contain almost everything we care about: all the lines, points, ticks, and labels. So, when we call plot(), we are adding a line (matplotlib.lines.Line2D) to the Axes.lines list. If we plot a histogram (hist()), we are adding rectangles to the list of Axes.patches ('patches' is the term inherited from MATLAB®, and it represents the 'patch of color' concept)."));
                doc.Add(this.AddParagragh(@"An instance of Axes also holds references to the XAxis and YAxis instances, which in turn refer to the x axis and y axis, respectively. The XAxis and YAxis instances manage the drawing of the axis, labels, ticks, tick labels, locators, and formatters. We can reference these through Axes.xaxis and Axes.yaxis, respectively. We don't have to go all the way down to XAxis or YAxis instances to get to the labels as matplotlib gives us a helper method (practically a shortcut) that enables iterations via these labels: matplotlib.pyplot.xlabel() and matplotlib.pyplot.ylabel()."));

                //water mark
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                BaseColor bc = new BaseColor(0, 0, 0, 65);
                iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 145.5F, iTextSharp.text.Font.ITALIC, bc);

                // Dim wfont = New Font(BaseFont.TIMES_ROMAN, 1.0F, BaseFont.COURIER, BaseColor.LIGHT_GRAY)
                ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase(textWaterMark, times), 245.5F, 480.0F, -55);

                //End water mark

                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/WaterMark.pdf");
            }
            catch (Exception ex)
            {
                doc.Close();
            }
        }
    }
    public class PdfWriterEvents : IPdfPageEvent
    {
        //https://stackoverflow.com/questions/2372041/c-sharp-itextsharp-pdf-creation-with-watermark-on-each-page
        string watermarkText = string.Empty;

        public PdfWriterEvents(string watermark)
        {
            watermarkText = watermark;
        }

        public void OnOpenDocument(PdfWriter writer, Document document) { }
        public void OnCloseDocument(PdfWriter writer, Document document) { }
        public void OnStartPage(PdfWriter writer, Document document)
        {
            float fontSize = 80;
            float xPosition = 300;
            float yPosition = 400;
            float angle = 45;
            try
            {
                PdfContentByte under = writer.DirectContentUnder;
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                under.BeginText();
                under.SetColorFill(BaseColor.LIGHT_GRAY);
                under.SetFontAndSize(baseFont, fontSize);
                under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, xPosition, yPosition, angle);
                under.EndText();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
        public void OnEndPage(PdfWriter writer, Document document) { }
        public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title) { }
        public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title) { }
        public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition) { }
        public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, String text) { }

    }
}

