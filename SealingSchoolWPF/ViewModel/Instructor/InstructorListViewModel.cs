using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Instructor
{
    class InstructorListViewModel : ViewModel
    {
        private InstructorMgr instructorMgr = new InstructorMgr();
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

        public InstructorListViewModel()
        {
            IList<SealingSchoolWPF.Model.Instructor> instructorsList = instructorMgr.GetAll();
            instructors = new ObservableCollection<InstructorViewModel>(instructorsList.Select(p => new InstructorViewModel(p)));
            instructors.CollectionChanged += Students_CollectionChanged;
        }

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (InstructorViewModel vm in e.NewItems)
                {
                    instructorMgr.Create(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (InstructorViewModel vm in e.OldItems)
                {
                    instructorMgr.Delete(vm.Model);
                }
            }
        }


        private ICommand addInstructorCommand;

        public ICommand AddInstructorCommand
        {
            get
            {
                if (addInstructorCommand == null)
                {
                    addInstructorCommand = new RelayCommand(p => ExecuteAddInstructorCommand());
                }
                return addInstructorCommand;
            }
        }

        private void ExecuteAddInstructorCommand()
        {
            Instructors.Add(new InstructorViewModel(new SealingSchoolWPF.Model.Instructor()));
        }

    }
}