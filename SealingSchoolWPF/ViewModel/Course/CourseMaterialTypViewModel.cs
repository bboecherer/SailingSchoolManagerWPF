using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for course material
    /// @Author Stefan Müller
    /// </summary>
    public class CourseMaterialTypViewModel : ViewModel<SailingSchoolWPF.Model.CourseMaterialTyp>
    {

        public CourseMaterialTypViewModel(SailingSchoolWPF.Model.CourseMaterialTyp model)
            : base(model)
        {
        }

        static CourseMaterialTypViewModel instance = null;
        static readonly object padlock = new object();

        public static CourseMaterialTypViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CourseMaterialTypViewModel(new SailingSchoolWPF.Model.CourseMaterialTyp());
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

        public MaterialTyp MaterialTyp
        {
            get
            {
                return Model.MaterialTyp;
            }
            set
            {
                Model.MaterialTyp = value;
                this.OnPropertyChanged("MaterialTyp");
            }
        }

        public int MatAmount
        {
            get
            {
                return Model.Amount;
            }
            set
            {
                if (MatAmount != value)
                {
                    Model.Amount = value;
                    this.OnPropertyChanged("MatAmount");
                }
            }
        }

        public String Name
        {
            get
            {
                return MaterialTyp.Name;
            }
            
        }



    }
}
