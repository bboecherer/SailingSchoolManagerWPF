using iTextSharp.text;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.PDF
{
    public class PDFTest
    {
        PDFCreator creator = new PDFCreator();
        public void test()
        {
            Document pdfdoc = new Document();
            creator.CreatePDF(pdfdoc, "Invoice");

            Paragraph headline = creator.CreateParagraph("Rechnung für Kurs XYZ", creator.GetStandardFontTitle());
            pdfdoc.Add(headline);
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.CreateParagraph("Rechnungsnummer: xxxxx", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("Rechnungsdatum: " + DateTime.Now.ToLongDateString(), creator.GetStandardFont()));
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Vielen Dank für Ihre Teilnahmen", creator.GetStandardFontBold()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.CreateParagraph("Platzhalter für Tabelle", creator.GetStandardFont()));
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            List<Course> dummy = new List<Course>();

            Course c1 = new Course();
            c1.Label = "Test";
            c1.Description = "Testbeschreibung";
            c1.ModifiedOn = DateTime.Now;
            c1.GrossPrice = new Decimal(12.5);
            dummy.Add(c1);

            Course c2 = new Course();
            c2.Label = "Test 2";
            c2.Description = "Testbeschreibung2";
            c2.ModifiedOn = DateTime.Now;
            c2.GrossPrice = new Decimal(22.5);
            dummy.Add(c2);

            pdfdoc.Add(creator.CreatePDFTable(dummy));

            pdfdoc.Close();
        }


    }
}
