using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.DataAccess
{
    public class StudentAddedEventArgs: EventArgs
    {
        public StudentAddedEventArgs(Student newStudent)
        {
            this.NewStudent = newStudent;
        }

        public Student NewStudent { get; private set; }
    }
}