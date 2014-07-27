using SailingSchoolWPF.Data;
using SailingSchoolWPF.Pages.Student.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.StudentViewModel
{
    /// <summary>
    /// ViewModel for StudentList
    /// @Author Benjamin Böcherer
    /// </summary>
    class StudentListViewModel : ViewModel
    {
        #region ctor
        public StudentListViewModel()
        {
            BindDataGrid();
        }
        #endregion

        #region singleton
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
        #endregion

        #region properties
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
        #endregion

        #region helpers
        private void BindDataGrid()
        {
            IList<SailingSchoolWPF.Model.Student> studs = studentMgr.GetAll();
            students = new ObservableCollection<StudentViewModel>(studs.Select(p => new StudentViewModel(p)));
        }
        #endregion

        #region commands
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
        #endregion

    }
}