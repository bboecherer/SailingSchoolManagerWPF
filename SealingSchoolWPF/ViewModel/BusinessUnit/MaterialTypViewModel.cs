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
    public class MaterialTypViewModel : ViewModel<SealingSchoolWPF.Model.MaterialTyp>
    {

        public MaterialTypViewModel(SealingSchoolWPF.Model.MaterialTyp model)
            : base(model)
        {
        }

        static MaterialTypViewModel instance = null;
        static readonly object padlock = new object();

        public static MaterialTypViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MaterialTypViewModel(new SealingSchoolWPF.Model.MaterialTyp());
                    }
                    return instance;
                }
            }
        }

        private MaterialTypMgr matTypMgr = new MaterialTypMgr();

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
            SealingSchoolWPF.Model.MaterialTyp matTyp = new Model.MaterialTyp();
            matTyp.Name = this.Name;
            matTyp.Description = this.Description;
            matTypMgr.Create(matTyp);
        }


    }
}
