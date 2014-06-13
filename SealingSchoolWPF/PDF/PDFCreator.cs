using iTextSharp.text;
using iTextSharp.text.pdf;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.PDF
{
    public class PDFCreator
    {
        public void CreatePDF(Document pdfdoc, string title)
        {
            pdfdoc.SetMargins(50, 50, 50, 50);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"d:\{0}.pdf", title));
            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path, FileMode.Create));
            pdfdoc.Open();
            PdfContentByte pdfcontent = writer.DirectContent;
        }

        public Paragraph CreateParagraph(string text, Font font)
        {
            return new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk(text, font));
        }

        public Paragraph AddEmptyParagraph()
        {
            iTextSharp.text.Font standard = iTextSharp.text.FontFactory.GetFont("Tahoma", 10);
            return CreateParagraph(Environment.NewLine, standard);
        }

        public PdfPCell CreateStandardPhrase(string text, Font standard)
        {
            return new PdfPCell(new Phrase(text, standard)) { Border = Rectangle.NO_BORDER };
        }

        public PdfPTable CreatePDFTable(List<Course> courses)
        {
            PdfPTable overviewtable = new PdfPTable(4);
            overviewtable.WidthPercentage = 100;
            overviewtable.AddCell(CreateStandardPhrase("Name der Person", GetStandardFont()));
            overviewtable.AddCell(new PdfPCell(new Phrase("gültig am", GetStandardFont())) { Border = Rectangle.NO_BORDER });
            overviewtable.AddCell(new PdfPCell(new Phrase("Sitzplatz", GetStandardFont())) { Border = Rectangle.NO_BORDER });
            overviewtable.AddCell(new PdfPCell(new Phrase("Preis", GetStandardFont())) { Border = Rectangle.NO_BORDER });

            if (courses != null)
            {
                foreach (var itm in courses)
                {
                    overviewtable.AddCell(CreateStandardPhrase(itm.Label, GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.ModifiedOn.ToString(), GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.Description, GetStandardFont()));
                    overviewtable.AddCell(CreateStandardPhrase(itm.GrossPrice.ToString("c"), GetStandardFont()));

                }
                overviewtable.AddCell(CreateStandardPhrase(string.Empty, GetStandardFont()));
                overviewtable.AddCell(CreateStandardPhrase(string.Empty, GetStandardFont()));
            }

            return overviewtable;
        }

        public Font GetStandardFont()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 10);
        }

        public Font GetStandardFontBold()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 10, Font.BOLD);
        }

        public Font GetStandardFontTitle()
        {
            return iTextSharp.text.FontFactory.GetFont("Arial", 18);
        }
    }
}
