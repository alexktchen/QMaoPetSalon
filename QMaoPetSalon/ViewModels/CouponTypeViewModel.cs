using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class CouponTypeViewModel : Bindable, IDataErrorInfo
    {
        #region Properties


      

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
        private CouponType mSelectedTypeModel;
        public CouponType SelectedTypeModel
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

        public CouponTypeViewModel()
        {

        }

        private void Add()
        {
            var couponType = new CouponType { Name = NewType, Description = NewDescription };
            MainDataSource.Instance.CouponTypes.Add(couponType);
            MainDataSource.Instance.Context.CouponTypes.Add(couponType);
            MainDataSource.Instance.Context.SaveChangesAsync();
        }

        private void Delete()
        {
            MainDataSource.Instance.Context.CouponTypes.Remove(SelectedTypeModel);
            MainDataSource.Instance.Context.SaveChangesAsync();
            MainDataSource.Instance.CouponTypes.Remove(SelectedTypeModel);
         
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
