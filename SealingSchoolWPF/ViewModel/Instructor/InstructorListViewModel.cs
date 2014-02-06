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
            instructors = new ObservableCollection<InstructorViewModel>(InstructorList.Instructors.Select(p => new InstructorViewModel(p)));
            instructors.CollectionChanged += Students_CollectionChanged;
        }

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (InstructorViewModel vm in e.NewItems)
                {
                    InstructorList.Instructors.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (InstructorViewModel vm in e.OldItems)
                {
                    InstructorList.Instructors.Remove(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                InstructorList.Instructors.Clear();
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