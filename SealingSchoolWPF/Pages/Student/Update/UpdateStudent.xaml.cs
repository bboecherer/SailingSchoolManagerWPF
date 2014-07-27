using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Student.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateStudentViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudent"/> class.
        /// </summary>
        /// <param name="student">The student.</param>
        public UpdateStudent(SailingSchoolWPF.ViewModel.StudentViewModel.StudentViewModel student)
        {
            //      Model.Student stud = GetStudentDataFromModel(student);
            InitializeComponent();
            viewModel = new UpdateStudentViewModel(GetStudentDataFromModel(student));
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Gets the student data from model.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
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
            stud.Label = student.Firstname + " " + student.Lastname;
            stud.StudentId = Convert.ToInt32(student.Id);
            stud.LastName = student.Lastname;
            stud.FirstName = student.Firstname;
            stud.AdditionalInfo = student.Notes;
            stud.CreatedOn = student.CreatedOn;
            stud.Bank = studBank;
            stud.Adress = studAdress;
            stud.Qualifications = student.Qualifications;

            return stud;
        }

        /// <summary>
        /// Handles the Closing event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
