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

            instrBank.BankName = instructor.BankName;
            instrBank.BankNo = instructor.BankNo;
            instrBank.Bic = instructor.Bic;
            instrBank.Iban = instructor.Iban;
            instrBank.AccountNo = instructor.AccountNo;

            instr.Id = Convert.ToInt32(instructor.Id);
            instr.LastName = instructor.Lastname;
            instr.FirstName = instructor.Firstname;
            instr.AdditionalInfo = instructor.Notes;
            instr.CreatedOn = instructor.CreatedOn;
            instr.Bank = instrBank;
            instr.Adress = instrAdress;

            return instr;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
