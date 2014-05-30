using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class CoursePlaningViewModel : ViewModel<SealingSchoolWPF.Model.CoursePlaning>
    {

        public CoursePlaningViewModel(SealingSchoolWPF.Model.CoursePlaning model)
            : base(model)
        {
        }

        static CoursePlaningViewModel instance = null;
        static readonly object padlock = new object();

        public static CoursePlaningViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CoursePlaningViewModel(new SealingSchoolWPF.Model.CoursePlaning());
                    }
                    return instance;
                }
            }
        }

        public int Id
        {
            get
            {
                return Model.CoursePlaningId;
            }
            set
            {
                if (Id != value)
                {
                    Model.CoursePlaningId = value;
                    this.OnPropertyChanged("CoursePlaningId");
                }
            }
        }

        public string Label
        {
            get
            {
                return Model.Label;
            }
            set
            {
                if (Label != value)
                {
                    Model.Label = value;
                    this.OnPropertyChanged("Label");
                }
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return Model.StartDate;
            }
            set
            {
                if (StartDate != value)
                {
                    Model.StartDate = value;
                    this.OnPropertyChanged("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return Model.EndDate;
            }
            set
            {
                if (EndDate != value)
                {
                    Model.EndDate = value;
                    this.OnPropertyChanged("EndDate");
                }
            }
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
            //SealingSchoolWPF.Model.Qualification qualification = new Model.Qualification();
            //qualification.ShortName = this.ShortName;
            //qualification.Name = this.Name;
            //qualification.Description = this.Description;
            //qualificationMgr.Create(qualification);
        }
    }
}
