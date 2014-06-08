using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class BoatTypListViewModel : ViewModel<SealingSchoolWPF.Model.BoatTyp>
    {

        public BoatTypListViewModel(SealingSchoolWPF.Model.BoatTyp model)
            : base(model)
        {
            BindDataGrid();
        }

        private BoatTypMgr BoatTypMgr = new BoatTypMgr();

        static BoatTypListViewModel instance = null;
        static readonly object padlock = new object();

        public static BoatTypListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BoatTypListViewModel(new SealingSchoolWPF.Model.BoatTyp());

                    }
                    return instance;
                }
            }
        }

        private ObservableCollection<BoatTypViewModel> boatTyps;

        public ObservableCollection<BoatTypViewModel> BoatTyps
        {
            get
            {
                return boatTyps;
            }
            set
            {
                if (BoatTyps != value)
                {
                    boatTyps = value;
                    this.OnPropertyChanged("BoatTyps");
                }
            }
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.BoatTyp> boatTypList = BoatTypMgr.GetAll();
            boatTyps = new ObservableCollection<BoatTypViewModel>(boatTypList.Select(q => new BoatTypViewModel(q)));
        }


        public int Id
        {
            get
            {
                return Model.BoatID;
            }
            set
            {
                if (Id != value)
                {
                    Model.BoatID = value;
                    this.OnPropertyChanged("Id");
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
            SealingSchoolWPF.Model.BoatTyp boatTyp = new Model.BoatTyp();
            boatTyp.Name = this.Name;
            boatTyp.Description = this.Description;
            BoatTypMgr.Create(boatTyp);

            this.ClearFields();
            this.ReBindDataGrid();
        }

        private void ReBindDataGrid()
        {
            this.boatTyps.Clear();
            IList<SealingSchoolWPF.Model.BoatTyp> boatTypList = BoatTypMgr.GetAll();
            BoatTyps = new ObservableCollection<BoatTypViewModel>(boatTypList.Select(q => new BoatTypViewModel(q)));
        }

        private void ClearFields()
        {
            this.Description = string.Empty;
            this.Name = string.Empty;
        }

        public void ExecuteDeleteCommand(int qId)
        {
            BoatTyp q = BoatTypMgr.GetById(qId);
            BoatTypMgr.Delete(q);
            this.ReBindDataGrid();
        }


    }
}