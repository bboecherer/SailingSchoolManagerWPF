using SailingSchoolWPF.Data;
using SailingSchoolWPF.Pages.Instructor.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Instructor
{
    /// <summary>
    /// ViewModel for instructor list
    /// @Author Benjamin Böcherer
    /// </summary>
    class InstructorListViewModel : ViewModel
    {
        #region ctor
        public InstructorListViewModel()
        {
            BindDataGrid();
        }

        static InstructorListViewModel instance = null;
        static readonly object padlock = new object();

        public static InstructorListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new InstructorListViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        private ObservableCollection<InstructorViewModel> instructors;
        public ObservableCollection<InstructorViewModel> Instructors
        {
            get
            {
                return instructors;
            }
            set
            {
                if (Instructors != value)
                {
                    instructors = value;
                    this.OnPropertyChanged("Instructors");
                }
            }
        }
        #endregion

        #region helpers
        private void BindDataGrid()
        {
            IList<SailingSchoolWPF.Model.Instructor> studs = instructorMgr.GetAll();
            instructors = new ObservableCollection<InstructorViewModel>(studs.Select(p => new InstructorViewModel(p)));
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
            CreateInstructor window = new CreateInstructor();
            window.ShowDialog();
        }
        #endregion

    }
}