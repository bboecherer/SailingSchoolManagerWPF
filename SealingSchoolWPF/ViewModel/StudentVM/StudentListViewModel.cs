using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.StudentViewModel
{
    class StudentListViewModel : ViewModel
    {

        static StudentListViewModel instance = null;
        static readonly object padlock = new object();

        public static StudentListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StudentListViewModel();
                    }
                    return instance;
                }
            }
        }


        private StudentMgr studMgr = new StudentMgr();

        private ObservableCollection<StudentViewModel> students;

        public ObservableCollection<StudentViewModel> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (Students != value)
                {
                    students = value;
                    this.OnPropertyChanged("Students");
                }
            }
        }

        public StudentListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Student> studs = studMgr.GetAll();
            students = new ObservableCollection<StudentViewModel>(studs.Select(p => new StudentViewModel(p)));
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(p => ExecuteAddCommand());
                }
                return addCommand;
            }
        }

        private void ExecuteAddCommand()
        {
            CreateStudent window = new CreateStudent();
            window.ShowDialog();
        }


    }
}