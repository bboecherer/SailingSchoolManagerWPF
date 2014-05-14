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
    public class QualificationViewModel : ViewModel<SealingSchoolWPF.Model.Qualification>
    {

        public QualificationViewModel(SealingSchoolWPF.Model.Qualification model)
            : base(model)
        {
        }

        static QualificationViewModel instance = null;
        static readonly object padlock = new object();

        public static QualificationViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new QualificationViewModel(new SealingSchoolWPF.Model.Qualification());
                    }
                    return instance;
                }
            }
        }

        private QualificationMgr qualificationMgr = new QualificationMgr();

        public int Id
        {
            get
            {
                return Model.Id;
            }
            set
            {
                if (Id != value)
                {
                    Model.Id = value;
                    this.OnPropertyChanged("Id");
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

        public string Description
        {
            get
            {
                return Model.Description;
            }
            set
            {
                if (Description != value)
                {
                    Model.Description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        public string ShortName
        {
            get
            {
                return Model.ShortName;
            }
            set
            {
                if (ShortName != value)
                {
                    Model.ShortName = value;
                    this.OnPropertyChanged("ShortName");
                }
            }
        }

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                if (Name != value)
                {
                    Model.Name = value;
                    this.OnPropertyChanged("Name");
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
            SealingSchoolWPF.Model.Qualification qualification = new Model.Qualification();
            qualification.ShortName = this.ShortName;
            qualification.Name = this.Name;
            qualification.Description = this.Description;
            qualificationMgr.Create(qualification);
        }

      
    }
}
