using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.BusinessUnit
{
    /// <summary>
    /// ViewModel for Qualification
    /// @Author Benjamin Böcherer
    /// </summary>
    public class QualificationViewModel : ViewModel<SailingSchoolWPF.Model.Qualification>
    {
        #region ctor
        public QualificationViewModel(SailingSchoolWPF.Model.Qualification model)
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
                        instance = new QualificationViewModel(new SailingSchoolWPF.Model.Qualification());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        public int Id
        {
            get
            {
                return Model.QualificationId;
            }
            set
            {
                if (Id != value)
                {
                    Model.QualificationId = value;
                    this.OnPropertyChanged("QualificationId");
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
            SailingSchoolWPF.Model.Qualification qualification = new Model.Qualification();
            qualification.ShortName = this.ShortName;
            qualification.Name = this.Name;
            qualification.Description = this.Description;
            qualiMgr.Create(qualification);
        }
        #endregion
    }
}
