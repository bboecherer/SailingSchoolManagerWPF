
using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Courses.Create;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Course
{
    public class CourseListViewModel : ViewModel
    {

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


        private CourseMgr courseMgr = new CourseMgr();

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

        public CourseListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Course> courseList = courseMgr.GetAll();
            courses = new ObservableCollection<CourseViewModel>(courseList.Select(p => new CourseViewModel(p)));
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
            CreateCourse window = new CreateCourse();
            window.ShowDialog();
        }
    }
}