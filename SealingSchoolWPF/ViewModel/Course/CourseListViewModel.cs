
using SealingSchoolWPF.Data;
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
            IList<SealingSchoolWPF.Model.Course> coursesList = courseMgr.GetAll();
            courses = new ObservableCollection<CourseViewModel>(coursesList.Select(p => new CourseViewModel(p)));
            courses.CollectionChanged += Students_CollectionChanged;
        }

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (CourseViewModel vm in e.NewItems)
                {
                    courseMgr.Create(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (CourseViewModel vm in e.OldItems)
                {
                    courseMgr.Delete(vm.Model);
                }
            }
        }

        private ICommand addCourseCommand;

        public ICommand AddCourseCommand
        {
            get
            {
                if (addCourseCommand == null)
                {
                    addCourseCommand = new RelayCommand(p => ExecuteAddCourseCommand());
                }
                return addCourseCommand;
            }
        }

        private void ExecuteAddCourseCommand()
        {
            Courses.Add(new CourseViewModel(new SealingSchoolWPF.Model.Course()));
        }

    }
}