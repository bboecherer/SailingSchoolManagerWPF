using iTextSharp.text;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailingSchoolWPF.Data;

namespace SailingSchoolWPF.PDF
{
    /// <summary>
    /// Class for PDF prints
    /// @Author Benjamin Böcherer
    /// </summary>
    public class PDFPrinter
    {
        /// <summary>
        /// The creator
        /// </summary>
        PDFCreator creator = new PDFCreator();
        /// <summary>
        /// The ta MGR
        /// </summary>
        private TrainingActivityMgr taMgr = new TrainingActivityMgr();
        /// <summary>
        /// The inv MGR
        /// </summary>
        private InvoiceMgr invMgr = new InvoiceMgr();
        /// <summary>
        /// The credit MGR
        /// </summary>
        private CreditNoteMgr creditMgr = new CreditNoteMgr();

        /// <summary>
        /// Creates the invoice PDF.
        /// </summary>
        /// <param name="invoiceName">Name of the invoice.</param>
        /// <param name="ta">The ta.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        public void createInvoicePDF(String invoiceName, TrainingActivity ta, int invoiceId)
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

        /// <summary>
        /// Creates the ta PDF.
        /// </summary>
        /// <param name="invoiceName">Name of the invoice.</param>
        /// <param name="ta">The ta.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
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

        /// <summary>
        /// Creates the credit note PDF.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cn">The cn.</param>
        public void createCreditNotePDF(string name, CreditNote cn)
        {
            Document pdfdoc = new Document();
            creator.CreatePDF(pdfdoc, "GS_" + name);

            var invDummy = creditMgr.GetById(cn.Id);

            Paragraph headline = creator.CreateParagraph(string.Format("Gutschrift"), creator.GetStandardFontTitle());

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraph("Empfänger:", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("Vor- und Nachname", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("Adresse", creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraph("PLZ und Ort", creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());

            pdfdoc.Add(creator.CreateParagraphRight("Gutschriftsnummer:               NAUGS-100000" + cn.Id, creator.GetStandardFont()));
            pdfdoc.Add(creator.CreateParagraphRight("Gutschriftsdatum: " + DateTime.Now.ToLongDateString(), creator.GetStandardFont()));

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(headline);

            pdfdoc.Add(creator.AddEmptyParagraph());
            pdfdoc.Add(creator.AddEmptyParagraph());

            List<Course> dummy = new List<Course>();

            //Course c1 = new Course();
            //c1.Label = taDummy.Course.Label;
            //c1.Description = taDummy.Course.Description;
            //c1.ModifiedOn = DateTime.Now;
            //c1.GrossPrice = taDummy.Course.GrossPrice;
            //dummy.Add(c1);

            pdfdoc.Add(creator.CreatePDFTable(dummy));

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
