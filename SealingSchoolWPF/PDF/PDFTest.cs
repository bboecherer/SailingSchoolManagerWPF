using iTextSharp.text;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SealingSchoolWPF.Data;

namespace SealingSchoolWPF.PDF
{
    public class PDFTest
    {
        PDFCreator creator = new PDFCreator();
        private TrainingActivityMgr taMgr = new TrainingActivityMgr();
        private InvoiceMgr invMgr = new InvoiceMgr();

        public void test()
        {
            Document pdfdoc = new Document();
            creator.CreatePDF(pdfdoc, "Invoice");

            Paragraph headline = creator.CreateParagraphLeft("Rechnung für Kurs XYZ", creator.GetStandardFontTitle());
            pdfdoc.Add(headline);
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.CreateParagraphLeft("Rechnungsnummer: xxxxx", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphLeft("Rechnungsdatum: " + DateTime.Now.ToLongDateString(), creator.GetStandardFont()));
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraphLeft("Vielen Dank für Ihre Teilnahmen", creator.GetStandardFontBold()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.CreateParagraphLeft("Platzhalter für Tabelle", creator.GetStandardFont()));
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

        public void createPDF(String invoiceName, TrainingActivity ta, int invoiceId)
        {
            Document pdfdoc = new Document();
            creator.CreatePDF(pdfdoc, "RE_" + invoiceName);

            var taDummy = taMgr.GetById(ta.TrainingActivityId);

            Paragraph headline = creator.CreateParagraph(string.Format("Rechnung für Kurs {0}", taDummy.Course.Label), creator.GetStandardFontTitle());

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Empfänger:", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.FirstName + " " + taDummy.Student.LastName, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.Adress.Street, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.Adress.ZipCode + " " + taDummy.Student.Adress.City, creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraphRight("Rechnungsnummer:               NAU-100000" + invoiceId, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphRight("Rechnungsdatum: " + DateTime.Now.ToLongDateString(), creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(headline);

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            List<Course> dummy = new List<Course>();

            Course c1 = new Course();
            c1.Label = taDummy.Course.Label;
            c1.Description = taDummy.Course.Description;
            c1.ModifiedOn = DateTime.Now;
            c1.GrossPrice = taDummy.Course.GrossPrice;
            dummy.Add(c1);

            pdfdoc.Add(creator.CreatePDFTable(dummy));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            var line1 = new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            pdfdoc.Add(new Chunk(line1));

            pdfdoc.Add(creator.CreateParagraphRightSummary("Netto:  " + ta.Course.NetPrice.ToString("c"), creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphRightSummary("MwSt:   " + ta.Course.NetAmount.ToString("c"), creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphRightSummary("Brutto: " + ta.Course.GrossPrice.ToString("c"), creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Vielen Dank für Ihre Teilnahme!", creator.GetStandardFontBold()));

            pdfdoc.Close();
        }

        public void createTaPDF(String invoiceName, TrainingActivity ta, int invoiceId)
        {
            Document pdfdoc = new Document();
            Random random = new Random();
            creator.CreatePDF(pdfdoc, "Buchung_" + invoiceName + random.Next());

            var taDummy = taMgr.GetById(ta.TrainingActivityId);

            Paragraph headline = creator.CreateParagraph(string.Format("Buchungsbestätigung für Kurs {0}", taDummy.Course.Label), creator.GetStandardFontTitle());

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Empfänger:", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.FirstName + " " + taDummy.Student.LastName, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.Adress.Street, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph(taDummy.Student.Adress.ZipCode + " " + taDummy.Student.Adress.City, creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(headline);

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            List<Course> dummy = new List<Course>();

            Course c1 = new Course();
            c1.Label = taDummy.Course.Label;
            c1.Description = taDummy.Course.Description;
            c1.ModifiedOn = DateTime.Now;
            c1.GrossPrice = taDummy.Course.GrossPrice;
            dummy.Add(c1);

            pdfdoc.Add(creator.CreatePDFTable(dummy));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            var line1 = new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            pdfdoc.Add(new Chunk(line1));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Vielen Dank für Ihre Buchung!", creator.GetStandardFontBold()));

            pdfdoc.Close();
        }



        internal void createCreditNotePDF(string name, CreditNote cn)
        {
            Document pdfdoc = new Document();
            creator.CreatePDF(pdfdoc, "GS_" + name);

            var invDummy = invMgr.GetById(cn.Id);

            Paragraph headline = creator.CreateParagraph(string.Format("Gutschrift-Nr.: {0}", cn.Label), creator.GetStandardFontTitle());

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Empfänger:", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("Vorname + Nachname", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("Adresse", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("PLZ und Ort", creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraphRight("Gutschriftsnummer:               NAUGS-100000" + cn.Id, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphRight("Gutschriftsdatum: " + DateTime.Now.ToLongDateString(), creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(headline);

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            //List<Course> dummy = new List<Course>();

            //Course c1 = new Course();
            //c1.Label = taDummy.Course.Label;
            //c1.Description = taDummy.Course.Description;
            //c1.ModifiedOn = DateTime.Now;
            //c1.GrossPrice = taDummy.Course.GrossPrice;
            //dummy.Add(c1);

            //pdfdoc.Add(creator.CreatePDFTable(dummy));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            var line1 = new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            pdfdoc.Add(new Chunk(line1));

            //pdfdoc.Add(creator.CreateParagraphRightSummary("Netto:  " + ta.Course.NetPrice.ToString("c"), creator.GetStandardFont()));
            //pdfdoc.Add(creator.CreateParagraphRightSummary("MwSt:   " + ta.Course.NetAmount.ToString("c"), creator.GetStandardFont()));
            //pdfdoc.Add(creator.CreateParagraphRightSummary("Brutto: " + ta.Course.GrossPrice.ToString("c"), creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Vielen Dank für Ihre Teilnahme!", creator.GetStandardFontBold()));

            pdfdoc.Close();
        }
    }
}
