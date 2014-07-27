using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.ViewModel.Instructor;
using SailingSchoolWPF.ViewModel.InstructorViewModel;
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

namespace SailingSchoolWPF.Pages.Instructor.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateInstructor : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateInstructorViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInstructor"/> class.
        /// </summary>
        /// <param name="instructor">The instructor.</param>
        public UpdateInstructor(SailingSchoolWPF.ViewModel.Instructor.InstructorViewModel instructor)
        {
            InitializeComponent();
            viewModel = new UpdateInstructorViewModel(GetInstructorDataFromModel(instructor));
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Gets the instructor data from model.
        /// </summary>
        /// <param name="instructor">The instructor.</param>
        /// <returns></returns>
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

            instr.InstructorId = Convert.ToInt32(instructor.Id);
            instr.LastName = instructor.Lastname;
            instr.FirstName = instructor.Firstname;
            instr.AdditionalInfo = instructor.Notes;
            instr.CreatedOn = instructor.CreatedOn;
            instr.Bank = instrBank;
            instr.Adress = instrAdress;
            instr.Label = instructor.Firstname + " " + instructor.Lastname;
            instr.FeeValueDay = instructor.HonorarValueDay;
            instr.FeeValueStd = instructor.HonorarValueStd;

            instr.Qualifications = instructor.Qualifications;
            instr.RatingValue = instructor.RatingValue;



            return instr;
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
