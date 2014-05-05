﻿using SealingSchoolWPF.Model;
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
            : base("SchoolContext")
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
        public DbSet<InfoBox> InfoBoxes { get; set; }
    }
}
