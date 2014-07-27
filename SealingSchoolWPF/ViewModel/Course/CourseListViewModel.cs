
using SailingSchoolWPF.Data;
using SailingSchoolWPF.Pages.Courses.Create;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for course list
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CourseListViewModel : ViewModel
    {
        #region ctor
        public CourseListViewModel()
        {
            BindDataGrid();
        }

        static CourseListViewModel instance = null;
        static readonly object padlock = new object();

        public static CourseListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CourseListViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        private ObservableCollection<CourseViewModel> courses;
        public ObservableCollection<CourseViewModel> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                if (Courses != value)
                {
                    courses = value;
                    this.OnPropertyChanged("Courses");
                }
            }
        }
        #endregion

        #region helpers
        private void BindDataGrid()
        {
            IList<SailingSchoolWPF.Model.Course> courseList = courseMgr.GetAll();
            courses = new ObservableCollection<CourseViewModel>(courseList.Select(p => new CourseViewModel(p)));
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
            CreateCourse window = new CreateCourse();
            window.ShowDialog();
        }
        #endregion
    }
}