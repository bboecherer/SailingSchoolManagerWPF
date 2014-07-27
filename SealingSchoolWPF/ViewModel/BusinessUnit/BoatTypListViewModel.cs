using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.BusinessUnit
{
    /// <summary>
    /// ViewModel for boat typ list
    /// @Author Stefan Müller
    /// </summary>
    public class BoatTypListViewModel : ViewModel<SailingSchoolWPF.Model.BoatTyp>
    {

        public BoatTypListViewModel(SailingSchoolWPF.Model.BoatTyp model)
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
                        instance = new BoatTypListViewModel(new SailingSchoolWPF.Model.BoatTyp());

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
            IList<SailingSchoolWPF.Model.BoatTyp> boatTypList = BoatTypMgr.GetAll();
            boatTyps = new ObservableCollection<BoatTypViewModel>(boatTypList.Select(q => new BoatTypViewModel(q)));
        }


        public int Id
        {
            get
            {
                return Model.BoatTypID;
            }
            set
            {
                if (Id != value)
                {
                    Model.BoatTypID = value;
                    this.OnPropertyChanged("Id");
                }
            }
        }

        public int CrewAmount
        {
            get
            {
                return Model.CrewAmount;
            }
            set
            {
                if (CrewAmount != value)
                {
                    Model.CrewAmount = value;
                    this.OnPropertyChanged("CrewAmount");
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
            SailingSchoolWPF.Model.BoatTyp boatTyp = new Model.BoatTyp();
            boatTyp.Name = this.Name;
            boatTyp.Description = this.Description;
            boatTyp.CrewAmount = this.CrewAmount;
            BoatTypMgr.Create(boatTyp);

            this.ClearFields();
            this.ReBindDataGrid();
        }

        private void ReBindDataGrid()
        {
            this.boatTyps.Clear();
            IList<SailingSchoolWPF.Model.BoatTyp> boatTypList = BoatTypMgr.GetAll();
            BoatTyps = new ObservableCollection<BoatTypViewModel>(boatTypList.Select(q => new BoatTypViewModel(q)));
        }

        private void ClearFields()
        {
            this.Description = string.Empty;
            this.Name = string.Empty;
            this.CrewAmount = 0;
        }

        public void ExecuteDeleteCommand(int qId)
        {
            BoatTyp q = BoatTypMgr.GetById(qId);
            BoatTypMgr.Delete(q);
            this.ReBindDataGrid();
        }


    }
}