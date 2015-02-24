using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    class DiseaseTypeViewModel : Bindable, IDataErrorInfo
    {
        #region Properties
        private DiseaseType mSelectedTypeModel;
        public DiseaseType SelectedTypeModel
        {
            get { return mSelectedTypeModel; }
            set
            {
                SetProperty(ref mSelectedTypeModel, value);

                if (mSelectedTypeModel == null)
                {
                    DeleteIsEnabled = false;
                }
                else
                {
                    DeleteIsEnabled = true;
                }

            }
        }
        private string mNewType;
        public string NewType
        {
            get { return mNewType; }
            set { SetProperty(ref mNewType, value); }
        }
        private string mNewDescription;
        public string NewDescription
        {
            get { return mNewDescription; }
            set { SetProperty(ref mNewDescription, value); }
        }


        private bool mDeleteIsEnabled = false;
        public bool DeleteIsEnabled
        {
            get { return mDeleteIsEnabled; }
            set { SetProperty(ref mDeleteIsEnabled, value); }
        }
        private bool mAddIsEnabled = false;
        public bool AddIsEnabled
        {
            get { return mAddIsEnabled; }
            set { SetProperty(ref mAddIsEnabled, value); }
        }


        private ICommand mAddCommand;
        public ICommand AddCommand
        {
            get
            {
                return mAddCommand ?? (mAddCommand = new CommandHandler(Add, true));
            }
        }

        private ICommand mDeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return mDeleteCommand ?? (mDeleteCommand = new CommandHandler(Delete, true));
            }
        }

        #endregion

        public DiseaseTypeViewModel()
        {
           
        }


        private void Add()
        {
            var diseaseTypes = new DiseaseType { Name = NewType, Description = NewDescription };
            MainDataSource.Instance.DiseaseTypes.Add(diseaseTypes);
            MainDataSource.Instance.Context.DiseaseTypes.Add(diseaseTypes);
            MainDataSource.Instance.Context.SaveChangesAsync();
        }

        private void Delete()
        {
            MainDataSource.Instance.Context.DiseaseTypes.Remove(SelectedTypeModel);
            MainDataSource.Instance.Context.SaveChangesAsync();
            MainDataSource.Instance.DiseaseTypes.Remove(SelectedTypeModel);
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string aColumnName]
        {
            get
            {
                if (aColumnName == "NewType")
                {
                    AddIsEnabled = !string.IsNullOrEmpty(NewType);
                    return string.IsNullOrEmpty(NewType) ? "必填" : null;
                }
                return null;
            }
        }
    }
}
