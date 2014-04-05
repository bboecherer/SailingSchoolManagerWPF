using FirstFloor.ModernUI.Windows.Controls;
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
            stud.Id = Convert.ToInt32(student.Id);
            stud.LastName = student.Lastname;
            stud.FirstName = student.Firstname;
            stud.AddressLine1 = student.AddressLine1;
            stud.City = student.City;
            stud.ZipCode = student.ZipCode;
            stud.BankName = student.BankName;
            stud.BankNo = student.BankNo;
            stud.Bic = student.Bic;
            stud.Iban = student.Iban;
            stud.AdditionalInfo = student.Notes;
            stud.AccountNo = student.AccountNo;
            stud.CreatedOn = student.CreatedOn;

            return stud;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
