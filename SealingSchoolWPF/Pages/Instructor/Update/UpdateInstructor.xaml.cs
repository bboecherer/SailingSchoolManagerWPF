using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.ViewModel.Instructor;
using SealingSchoolWPF.ViewModel.InstructorViewModel;
using SealingSchoolWPF.ViewModel.StudentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SealingSchoolWPF.Pages.Instructor.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateInstructor : ModernWindow
    {
        UpdateInstructorViewModel viewModel;

        public UpdateInstructor(SealingSchoolWPF.ViewModel.Instructor.InstructorViewModel instructor)
        {
            //      Model.Student stud = GetStudentDataFromModel(student);
            InitializeComponent();
            viewModel = new UpdateInstructorViewModel(GetInstructorDataFromModel(instructor));
            this.DataContext = viewModel;
        }

        private Model.Instructor GetInstructorDataFromModel(InstructorViewModel instructor)
        {
            Model.Instructor instr = new Model.Instructor();
            Adress instrAdress = new Adress();
            BankAccountData instrBank = new BankAccountData();

            instrAdress.AddressLine1 = instructor.AddressLine1;
            instrAdress.City = instructor.City;
            instrAdress.ZipCode = instructor.ZipCode;
            instrAdress.Street = instructor.Street;

            instrBank.BankName = instructor.BankName;
            instrBank.BankNo = instructor.BankNo;
            instrBank.Bic = instructor.Bic;
            instrBank.Iban = instructor.Iban;
            instrBank.AccountNo = instructor.AccountNo;
            instrBank.Sepa = instructor.Sepa;

            instr.Id = Convert.ToInt32(instructor.Id);
            instr.LastName = instructor.Lastname;
            instr.FirstName = instructor.Firstname;
            instr.AdditionalInfo = instructor.Notes;
            instr.CreatedOn = instructor.CreatedOn;
            instr.Bank = instrBank;
            instr.Adress = instrAdress;

            instr.SSS = instructor.SSS;
            instr.SKS = instructor.SKS;
            instr.SBFBINNEN = instructor.SBFBINNEN;
            instr.SBFSEA = instructor.SBFSEA;
            instr.SRC = instructor.SRC;
            instr.UBI = instructor.UBI;
            instr.DSV = instructor.DSV;
            instr.SHS = instructor.SHS;
            instr.LifeGuard = instructor.LifeGuard;

            instr.SSSDate = instructor.SSSDate;
            instr.SKSDate = instructor.SKSDate;
            instr.SBFBINNENDate = instructor.SBFBINNENDate;
            instr.SBFSEADate = instructor.SBFSEADate;
            instr.SRCDate = instructor.SRCDate;
            instr.UBIDate = instructor.UBIDate;
            instr.DSVDate = instructor.DSVDate;
            instr.SHSDate = instructor.SHSDate;
            instr.LifeGuardDate = instructor.LifeGuardDate;

            return instr;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
