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
    /// ViewModel for material typ
    /// @Author Stefan Müller
    /// </summary>
    public class MaterialTypViewModel : ViewModel<SailingSchoolWPF.Model.MaterialTyp>
    {

        public MaterialTypViewModel(SailingSchoolWPF.Model.MaterialTyp model)
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
                        instance = new MaterialTypViewModel(new SailingSchoolWPF.Model.MaterialTyp());
                    }
                    return instance;
                }
            }
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
        }


    }
}
