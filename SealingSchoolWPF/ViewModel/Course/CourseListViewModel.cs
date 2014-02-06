
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
            courses = new ObservableCollection<CourseViewModel>(CourseList.Courses.Select(p => new CourseViewModel(p)));
            courses.CollectionChanged += Students_CollectionChanged;
        }

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (CourseViewModel vm in e.NewItems)
                {
                    CourseList.Courses.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (CourseViewModel vm in e.OldItems)
                {
                    CourseList.Courses.Remove(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                CourseList.Courses.Clear();
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