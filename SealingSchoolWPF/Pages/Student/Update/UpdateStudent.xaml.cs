using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.Model;
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

namespace SealingSchoolWPF.Pages.Student.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : ModernWindow
    {
        UpdateStudentViewModel viewModel;

        public UpdateStudent(SealingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel student)
        {
            //      Model.Student stud = GetStudentDataFromModel(student);
            InitializeComponent();
            viewModel = new UpdateStudentViewModel(GetStudentDataFromModel(student));
            this.DataContext = viewModel;
        }

        private Model.Student GetStudentDataFromModel(StudentViewModel student)
        {
            Model.Student stud = new Model.Student();
            Adress studAdress = new Adress();
            BankAccountData studBank = new BankAccountData();

            studAdress.AddressLine1 = student.AddressLine1;
            studAdress.City = student.City;
            studAdress.ZipCode = student.ZipCode;
            studAdress.Street = student.Street;

            studBank.BankName = student.BankName;
            studBank.BankNo = student.BankNo;
            studBank.Bic = student.Bic;
            studBank.Iban = student.Iban;
            studBank.AccountNo = student.AccountNo;
            studBank.Sepa = student.Sepa;

            stud.Id = Convert.ToInt32(student.Id);
            stud.LastName = student.Lastname;
            stud.FirstName = student.Firstname;
            stud.AdditionalInfo = student.Notes;
            stud.CreatedOn = student.CreatedOn;
            stud.Bank = studBank;
            stud.Adress = studAdress;

            return stud;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
