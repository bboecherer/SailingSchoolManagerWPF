using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Model
{

    public class Student : SealingSchoolObject
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Adress Adress { get; set; }

        public ContactData Contact { get; set; }

        public BankAccountData Bank { get; set; }


    }
}