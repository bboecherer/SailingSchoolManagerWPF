using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.SealingSchool.ViewModelBase;
using De.SealingSchoolManager.Model;
using System.Collections.Specialized;
using System.Windows.Input;

namespace De.SealingSchool.ViewModel
{
    public class StudentListViewModel : De.SealingSchool.ViewModelBase.ViewModel
    {

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
            students = new ObservableCollection<StudentViewModel>(StudentList.Students.Select(p => new StudentViewModel(p)));
            Students.CollectionChanged += Students_CollectionChanged;
        }

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (StudentViewModel vm in e.NewItems)
                {
                    StudentList.Students.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (StudentViewModel vm in e.OldItems)
                {
                    StudentList.Students.Remove(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                StudentList.Students.Clear();
            }
        }

        private ICommand addStudentCommand;

        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand(p => ExecuteAddStudentCommand());
                }
                return addStudentCommand;
            }
        }

        private void ExecuteAddStudentCommand()
        {
            Students.Add(new StudentViewModel(new Student()));
        }
    }
}
