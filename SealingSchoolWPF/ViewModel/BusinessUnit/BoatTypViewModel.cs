﻿using SailingSchoolWPF.Data;
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
    /// ViewModel for boat typ
    /// @Author Stefan Müller
    /// </summary>
    public class BoatTypViewModel : ViewModel<SailingSchoolWPF.Model.BoatTyp>
    {

        public BoatTypViewModel(SailingSchoolWPF.Model.BoatTyp model)
            : base(model)
        {
        }

        static BoatTypViewModel instance = null;
        static readonly object padlock = new object();

        public static BoatTypViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BoatTypViewModel(new SailingSchoolWPF.Model.BoatTyp());
                    }
                    return instance;
                }
            }
        }

        private BoatTypMgr BoatTypMgr = new BoatTypMgr();

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
        }


    }
}
