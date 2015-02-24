using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class ServiceTypeViewModel : Bindable, IDataErrorInfo
    {
         #region Properties

        private string mNewServiceType;
        public string NewServiceType
        {
            get { return mNewServiceType; }
            set { SetProperty(ref mNewServiceType, value); }
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
        private ServiceType mSelectedServiceType;
        public ServiceType SelectedServiceType
        {
            get { return mSelectedServiceType; }
            set
            {
                SetProperty(ref mSelectedServiceType, value);

                if (mSelectedServiceType == null)
                {
                    DeleteIsEnabled = false;
                }
                else
                {
                    DeleteIsEnabled = true;
                }

            }
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

        private void Add()
        {
            var serviceType = new ServiceType { Name = NewServiceType, Description = NewDescription };
            MainDataSource.Instance.ServiceTypes.Add(serviceType);
            MainDataSource.Instance.Context.ServiceTypes.Add(serviceType);
            MainDataSource.Instance.Context.SaveChangesAsync();
        }

        private void Delete()
        {
            MainDataSource.Instance.Context.ServiceTypes.Remove(SelectedServiceType);
            MainDataSource.Instance.Context.SaveChangesAsync();
            MainDataSource.Instance.ServiceTypes.Remove(SelectedServiceType);
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string aColumnName]
        {
            get
            {
                if (aColumnName == "NewServiceType")
                {
                    AddIsEnabled = !string.IsNullOrEmpty(NewServiceType);
                    return string.IsNullOrEmpty(NewServiceType) ? "必填" : null;
                }
                return null;
            }
        }
    }
}
