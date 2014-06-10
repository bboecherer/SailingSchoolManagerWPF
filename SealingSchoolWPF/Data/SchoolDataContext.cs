using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
    class SchoolDataContext : DbContext
    {
        public SchoolDataContext()
      : base( "SchoolContext" )
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CreditNote> CreditNotes { get; set; }
        public DbSet<CreditNoteItem> CreditNoteItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<BankAccountData> Banks { get; set; }
        public DbSet<ContactData> Contacts { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<InfoBox> InfoBoxes { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<PdfTemplate> PdfTemplates { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<GeneralFee> GeneralFees { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<MaterialTyp> MaterialTyps { get; set; }
        public DbSet<IncomingInvoice> IncomingInvoices { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<CoursePlaning> CoursePlanings { get; set; }
        public DbSet<BlockedTimeSpan> BlockedTimeSpans { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatTyp> BoatTyps { get; set; }
    public DbSet<MaterialGroup> MaterialGroups { get; set; }
    public DbSet<TrainingActivity> TrainingActivities { get; set; }
    }
}
