using AS.IBAN;
using AS.IBAN.Helper;
using AS.IBAN.Model;
using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SealingSchoolWPF.ViewModel.StudentViewModel
{
    public class UpdateStudentViewModel : ViewModel<Student>
    {
        public Student StudentDummy { get; set; }

        public UpdateStudentViewModel(Student model)
            : base(model)
        {
            instance = this;
            this.StudentDummy = model;
        }

        static UpdateStudentViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateStudentViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateStudentViewModel(new SealingSchoolWPF.Model.Student());
                    }
                    return instance;
                }
            }
        }

        public string FirstName
        {
            get
            {
                return StudentDummy.FirstName;
            }
            set
            {
                StudentDummy.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return StudentDummy.LastName;
            }
            set
            {
                StudentDummy.LastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return StudentDummy.Adress.Street;
            }
            set
            {
                StudentDummy.Adress.Street = value;
                this.OnPropertyChanged("Street");
            }
        }

        public string Postal
        {
            get
            {
                return StudentDummy.Adress.ZipCode;
            }
            set
            {
                StudentDummy.Adress.ZipCode = value;
                this.OnPropertyChanged("Postal");
            }
        }

        public string City
        {
            get
            {
                return StudentDummy.Adress.City;
            }
            set
            {
                StudentDummy.Adress.City = value;
                this.OnPropertyChanged("City");
            }
        }

        public string AccountNo
        {
            get
            {
                return StudentDummy.Bank.AccountNo;
            }
            set
            {
                StudentDummy.Bank.AccountNo = value;
                this.OnPropertyChanged("AccountNo");
            }
        }

        public string BankNo
        {
            get
            {
                return StudentDummy.Bank.BankNo;
            }
            set
            {
                StudentDummy.Bank.BankNo = value;
                this.OnPropertyChanged("BankNo");
            }
        }

        public string BankName
        {
            get
            {
                return StudentDummy.Bank.BankName;
            }
            set
            {
                StudentDummy.Bank.BankName = value;
                this.OnPropertyChanged("BankName");
            }
        }

        public string Iban
        {
            get
            {
                return StudentDummy.Bank.Iban;
            }
            set
            {
                StudentDummy.Bank.Iban = value;
                this.OnPropertyChanged("Iban");
            }
        }

        public bool Sepa
        {
            get
            {
                return StudentDummy.Bank.Sepa;
            }
            set
            {
                StudentDummy.Bank.Sepa = value;
                this.OnPropertyChanged("Sepa");
            }
        }

        public string Bic
        {
            get
            {
                return StudentDummy.Bank.Bic;
            }
            set
            {
                StudentDummy.Bank.Bic = value;
                this.OnPropertyChanged("Bic");
            }
        }

        public string Notes
        {
            get
            {
                return StudentDummy.AdditionalInfo;
            }
            set
            {
                StudentDummy.AdditionalInfo = value;
                this.OnPropertyChanged("Notes");
            }
        }

        private string _saveImage = "/Resources/Images/save_16xLG.png";
        public string SaveImage
        {
            get
            {
                return _saveImage;
            }
            set
            {
                _saveImage = value;
                this.OnPropertyChanged("SaveImage");
            }
        }

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get
            {
                return _isButtonEnabled;
            }
            set
            {
                _isButtonEnabled = value;
                this.OnPropertyChanged("IsButtonEnabled");
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

        public void Close()
        {
            instance = null;

        }

        private void ExecuteAddCommand()
        {
            Model.ModifiedOn = DateTime.Now;

            Model.Qualifications.Clear();
            if (prepared != null)
            {
                foreach (QualificationViewModel q in prepared)
                {
                    Model.Qualifications.Add(prepareQualiToSave(q));
                }
            }

            studentMgr.Update(Model);
            this.SaveImage = "/Resources/Images/StatusAnnotations_Complete_and_ok_16xLG_color.png";
            this.IsButtonEnabled = false;
        }

        private SealingSchoolWPF.Model.Qualification prepareQualiToSave(QualificationViewModel q)
        {
            SealingSchoolWPF.Model.Qualification quali = new Model.Qualification();
            quali.QualificationId = q.Id;
            return quali;
        }

        private ICommand generateBankData;
        public ICommand GenerateBankData
        {
            get
            {
                if (generateBankData == null)
                {
                    generateBankData = new RelayCommand(p => ExecuteBankCommand());
                }
                return generateBankData;
            }
        }

        private void ExecuteBankCommand()
        {
            try
            {
                this.BankName = GetGermanBank(this.BankNo, this.AccountNo);
                this.Iban = GenerateGermanIban(this.BankNo, this.AccountNo);
                this.Bic = GetGermanBic(this.Iban);
            }
            catch (Exception ex)
            {
                this.BankName = "Nicht gefunden";
                this.Iban = "Nicht gefunden";
                this.Bic = "Nicht gefunden";
            }
        }


        private string GenerateGermanIban(string bankIdent, string accountNumber)
        {
            IbanGenerator generator = new IbanGenerator();
            string iban = string.Empty;
            string bic = string.Empty;

            try
            {
                var result = generator.GenerateIban(ECountry.DE, bankIdent, accountNumber);
                iban = result.IBAN.IBAN;
                bic = result.BIC.Bic;
            }
            catch (IbanException ex)
            {
                this.Iban = "Nicht gefunden";
            }

            return iban;
        }

        private string GetGermanBank(string bankIdent, string accountNumber)
        {
            IbanGenerator generator = new IbanGenerator();
            Bank bank = null;

            try
            {
                var result = generator.GenerateIban(ECountry.DE, bankIdent, accountNumber);
                bank = result.IBAN.Bank;
            }
            catch (IbanException ex)
            {
                this.BankName = "Nicht gefunden";
            }

            return bank.Name;
        }

        private string GetGermanBic(string iban)
        {
            IbanGetBic getBic = new IbanGetBic();
            string bic = string.Empty;

            try
            {
                var result = getBic.GetBic(iban);
                bic = result.Bic;
            }
            catch (IbanException ex)
            {
                this.Bic = "Nicht gefunden";
            }

            return bic;
        }


        public void ExecuteDeleteCommand(QualificationViewModel quali)
        {
            this.prepared.Remove(quali);
        }

        private ICommand addQualiCommand;

        public ICommand AddQualiCommand
        {
            get
            {
                if (addQualiCommand == null)
                {
                    addQualiCommand = new RelayCommand(p => ExecuteAddQualiCommand());
                }
                return addQualiCommand;
            }
        }

        private void ExecuteAddQualiCommand()
        {
            if (this.QualificationTyp == null)
                return;

            SealingSchoolWPF.Model.Qualification origQauli = this.QualificationTyp;
            QualificationViewModel quali = new QualificationViewModel(origQauli);

            foreach (QualificationViewModel q in prepared)
            {
                if (q.ShortName == quali.ShortName)
                    return;
            }

            this.prepared.Add(quali);
        }

        private IList<SealingSchoolWPF.Model.Qualification> GetQualificationTypNames()
        {
            QualificationTypNames = new List<SealingSchoolWPF.Model.Qualification>();
            foreach (Model.Qualification quali in qualiMgr.GetAll())
            {
                QualificationTypNames.Add(quali);
            }
            return QualificationTypNames;
        }

        private IList<SealingSchoolWPF.Model.Qualification> QualificationTypNames;

        public IEnumerable<SealingSchoolWPF.Model.Qualification> QualificationValues
        {
            get
            {
                return GetQualificationTypNames();
            }
        }

        private SealingSchoolWPF.Model.Qualification _qualificationTyp;
        public SealingSchoolWPF.Model.Qualification QualificationTyp
        {
            get
            {
                return _qualificationTyp;
            }
            set
            {
                _qualificationTyp = value;
                this.OnPropertyChanged("QualificationTyp");
            }
        }

        private ObservableCollection<QualificationViewModel> qualifications;

        public ObservableCollection<QualificationViewModel> Qualifications
        {
            get
            {
                return qualiList();
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

        private ObservableCollection<QualificationViewModel> prepared;

        private ObservableCollection<QualificationViewModel> qualiList()
        {
            if (prepared == null || prepared.Count == 0)
            {
                prepared = new ObservableCollection<QualificationViewModel>();
            }
            foreach (QualificationViewModel q in prepareQualifications(Model.Qualifications))
            {
                prepared.Add(q);
            }
            return prepared;
        }

        private ObservableCollection<QualificationViewModel> prepareQualifications(ICollection<SealingSchoolWPF.Model.Qualification> collection)
        {
            ObservableCollection<QualificationViewModel> list = new ObservableCollection<QualificationViewModel>();

            foreach (Model.Qualification q in collection)
            {
                QualificationViewModel model = new QualificationViewModel(q);
                list.Add(model);
            }

            return list;
        }
    }
}