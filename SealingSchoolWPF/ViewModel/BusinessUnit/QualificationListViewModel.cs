﻿using SealingSchoolWPF.Data;
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
    public class QualificationListViewModel : ViewModel<SealingSchoolWPF.Model.Qualification>
    {

        public QualificationListViewModel(SealingSchoolWPF.Model.Qualification model)
            : base(model)
        {
            BindDataGrid();
        }

        private QualificationMgr qualificationMgr = new QualificationMgr();

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
                        instance = new QualificationListViewModel(new SealingSchoolWPF.Model.Qualification());

                    }
                    return instance;
                }
            }
        }

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

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Qualification> qualificationsList = qualificationMgr.GetAll();
            qualifications = new ObservableCollection<QualificationViewModel>(qualificationsList.Select(q => new QualificationViewModel(q)));
        }


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

            this.ClearFields();
            this.ReBindDataGrid();
        }

        private void ReBindDataGrid()
        {
            this.qualifications.Clear();
            IList<SealingSchoolWPF.Model.Qualification> qualificationsList = qualificationMgr.GetAll();
            Qualifications = new ObservableCollection<QualificationViewModel>(qualificationsList.Select(q => new QualificationViewModel(q)));
        }

        private void ClearFields()
        {
            this.ShortName = string.Empty;
            this.Description = string.Empty;
            this.Name = string.Empty;
        }

        public void ExecuteDeleteCommand(int qId)
        {
            Qualification q = qualificationMgr.GetById(qId);
            qualificationMgr.Delete(q);
            this.ReBindDataGrid();
        }


    }
}