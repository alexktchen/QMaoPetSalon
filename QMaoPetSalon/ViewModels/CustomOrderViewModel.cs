using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class CustomOrderViewModel : Bindable, IDataErrorInfo
    {
        #region Properties
        private DateTime mSelectedDateTime;
        public DateTime SelectedDateTime
        {
            get { return mSelectedDateTime; }
            set { SetProperty(ref mSelectedDateTime, value); }
        }
        private ICommand mSaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return mSaveCommand ?? (mSaveCommand = new CommandHandler(SaveOrder, true));
            }
        }
        #endregion

        public CustomOrderViewModel()
        {
            InitData();
        }

        private void InitData()
        {
            SelectedDateTime = DateTime.Now;
        }

        private void SaveOrder()
        {
            
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string aColumnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
