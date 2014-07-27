using iTextSharp.text;
using iTextSharp.text.pdf;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.PDF
{
    /// <summary>
    /// PDF Creator
    /// @Author Benjamin Böcherer
    /// </summary>
    public class PDFCreator
    {
        /// <summary>
        /// Creates the PDF.
        /// </summary>
        /// <param name="pdfdoc">The pdfdoc.</param>
        /// <param name="title">The title.</param>
        public void CreatePDF(Document pdfdoc, string title)
        {
            pdfdoc.SetMargins(50, 50, 50, 50);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"d:\{0}.pdf", title));
            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path, FileMode.Create));
            pdfdoc.Open();
            PdfContentByte pdfcontent = writer.DirectContent;
        }

        /// <summary>
        /// Creates the paragraph left.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Paragraph CreateParagraphLeft(string text, Font font)
        {
            return new iTextSharp.text.Paragraph(Element.ALIGN_LEFT, new iTextSharp.text.Chunk(text, font));
        }

        /// <summary>
        /// Creates the paragraph right.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Paragraph CreateParagraphRight(string text, Font font)
        {
            var para = new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk(text, font));
            para.Alignment = Element.ALIGN_RIGHT;
            return para;
        }

        /// <summary>
        /// Creates the paragraph right summary.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Paragraph CreateParagraphRightSummary(string text, Font font)
        {
            var para = new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk(text, font));
            para.Alignment = Element.ALIGN_RIGHT;
            para.IndentationRight = 55;
            return para;
        }

        /// <summary>
        /// Creates the paragraph left summary.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Paragraph CreateParagraphLeftSummary(string text, Font font)
        {
            var para = new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk(text, font));
            para.Alignment = Element.ALIGN_LEFT;
            para.IndentationRight = 155;
            return para;
        }

        /// <summary>
        /// Creates the paragraph.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Paragraph CreateParagraph(string text, Font font)
        {
            return new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk(text, font));
        }

        /// <summary>
        /// Adds the empty paragraph.
        /// </summary>
        /// <returns></returns>
        public Paragraph AddEmptyParagraph()
        {
            iTextSharp.text.Font standard = iTextSharp.text.FontFactory.GetFont("Tahoma", 10);
            return CreateParagraph(Environment.NewLine, standard);
        }

        /// <summary>
        /// Creates the standard phrase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="standard">The standard.</param>
        /// <returns></returns>
        public PdfPCell CreateStandardPhrase(string text, Font standard)
        {
            return new PdfPCell(new Phrase(text, standard)) { Border = Rectangle.NO_BORDER };
        }

        /// <summary>
        /// Creates the PDF table.
        /// </summary>
        /// <param name="courses">The courses.</param>
        /// <returns></returns>
        public PdfPTable CreatePDFTable(List<Course> courses)
        {
            PdfPTable overviewtable = new PdfPTable(4);
            overviewtable.WidthPercentage = 100;
            overviewtable.AddCell(new PdfPCell(new Phrase("Kursname", GetStandardFont())) { Border = Rectangle.BOTTOM_BORDER });
            overviewtable.AddCell(new PdfPCell(new Phrase("Startdatum", GetStandardFont())) { Border = Rectangle.BOTTOM_BORDER });
            overviewtable.AddCell(new PdfPCell(new Phrase("Beschreibung", GetStandardFont())) { Border = Rectangle.BOTTOM_BORDER });
            overviewtable.AddCell(new PdfPCell(new Phrase("Preis", GetStandardFont())) { Border = Rectangle.BOTTOM_BORDER });

            if (courses != null)
            {
                foreach (var itm in courses)
                {
                    overviewtable.AddCell(CreateStandardPhrase(itm.Label, GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.ModifiedOn.ToString(), GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.Description, GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.GrossPrice.ToString("c"), GetStandardFont()));
                }
            }

            return overviewtable;
        }

        /// <summary>
        /// Gets the standard font.
        /// </summary>
        /// <returns></returns>
        public Font GetStandardFont()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 10);
        }

        /// <summary>
        /// Gets the standard font bold.
        /// </summary>
        /// <returns></returns>
        public Font GetStandardFontBold()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 10, Font.BOLD);
        }

        /// <summary>
        /// Gets the standard font title.
        /// </summary>
        /// <returns></returns>
        public Font GetStandardFontTitle()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 18);
        }

    }
}
