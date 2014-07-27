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
    /// ViewModel for QualificationsList
    /// @Author Benjamin Böcherer
    /// </summary>
    public class QualificationListViewModel : ViewModel<SailingSchoolWPF.Model.Qualification>
    {
        #region ctor
        public QualificationListViewModel(SailingSchoolWPF.Model.Qualification model)
            : base(model)
        {
            BindDataGrid();
        }

        static QualificationListViewModel instance = null;
        static readonly object padlock = new object();

        public static QualificationListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new QualificationListViewModel(new SailingSchoolWPF.Model.Qualification());

                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        private ObservableCollection<QualificationViewModel> qualifications;
        public ObservableCollection<QualificationViewModel> Qualifications
        {
            get
            {
                return qualifications;
            }
            set
            {
                if (Qualifications != value)
                {
                    qualifications = value;
                    this.OnPropertyChanged("Qualifications");
                }
            }
        }

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

            this.ClearFields();
            this.ReBindDataGrid();
        }

        public void ExecuteDeleteCommand(int qId)
        {
            Qualification q = qualiMgr.GetById(qId);
            qualiMgr.Delete(q);
            this.ReBindDataGrid();
        }
        #endregion

        #region helpers
        private void BindDataGrid()
        {
            IList<SailingSchoolWPF.Model.Qualification> qualificationsList = qualiMgr.GetAll();
            qualifications = new ObservableCollection<QualificationViewModel>(qualificationsList.Select(q => new QualificationViewModel(q)));
        }

        private void ReBindDataGrid()
        {
            this.qualifications.Clear();
            IList<SailingSchoolWPF.Model.Qualification> qualificationsList = qualiMgr.GetAll();
            Qualifications = new ObservableCollection<QualificationViewModel>(qualificationsList.Select(q => new QualificationViewModel(q)));
        }

        private void ClearFields()
        {
            this.ShortName = string.Empty;
            this.Description = string.Empty;
            this.Name = string.Empty;
        }
        #endregion
    }
}