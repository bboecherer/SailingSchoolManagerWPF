using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.BusinessUnit
{
    /// <summary>
    /// ViewModel for material typ list
    /// @Author Stefan Müller
    /// </summary>
    public class MaterialTypListViewModel : ViewModel<SailingSchoolWPF.Model.MaterialTyp>
    {

        public MaterialTypListViewModel(SailingSchoolWPF.Model.MaterialTyp model)
            : base(model)
        {
            BindDataGrid();
        }

        static MaterialTypListViewModel instance = null;
        static readonly object padlock = new object();

        public static MaterialTypListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MaterialTypListViewModel(new SailingSchoolWPF.Model.MaterialTyp());

                    }
                    return instance;
                }
            }
        }

        private ObservableCollection<MaterialTypViewModel> matTyps;

        public ObservableCollection<MaterialTypViewModel> MatTyps
        {
            get
            {
                return matTyps;
            }
            set
            {
                if (MatTyps != value)
                {
                    matTyps = value;
                    this.OnPropertyChanged("MatTyps");
                }
            }
        }

        private void BindDataGrid()
        {
            IList<SailingSchoolWPF.Model.MaterialTyp> matTypList = matTypMgr.GetAll();
            matTyps = new ObservableCollection<MaterialTypViewModel>(matTypList.Select(q => new MaterialTypViewModel(q)));
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
            SailingSchoolWPF.Model.MaterialTyp matTyp = new Model.MaterialTyp();
            matTyp.Name = this.Name;
            matTyp.Description = this.Description;
            matTypMgr.Create(matTyp);

            this.ClearFields();
            this.ReBindDataGrid();
        }

        private void ReBindDataGrid()
        {
            this.matTyps.Clear();
            IList<SailingSchoolWPF.Model.MaterialTyp> matTypList = matTypMgr.GetAll();
            MatTyps = new ObservableCollection<MaterialTypViewModel>(matTypList.Select(q => new MaterialTypViewModel(q)));
        }

        private void ClearFields()
        {
            this.Description = string.Empty;
            this.Name = string.Empty;
        }

        public void ExecuteDeleteCommand(int qId)
        {
            MaterialTyp q = matTypMgr.GetById(qId);
            matTypMgr.Delete(q);
            this.ReBindDataGrid();
        }


    }
}