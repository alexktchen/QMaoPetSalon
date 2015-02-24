using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;
using QMaoPetSalon.Helper;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class PetVarietyViewModel : Bindable, IDataErrorInfo
    {
        #region Properties

        private string mNewPetVariety;
        public string NewPetVariety
        {
            get { return mNewPetVariety; }
            set { SetProperty(ref mNewPetVariety, value); }
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
        private PetVariety mSelectedPetVariety;
        public PetVariety SelectedPetVariety
        {
            get { return mSelectedPetVariety; }
            set
            {
                SetProperty(ref mSelectedPetVariety, value);

                if (mSelectedPetVariety == null)
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

        public PetVarietyViewModel()
        {
            MainDataSource.Instance.PetVarietys = new ObservableCollection<PetVariety>();
            LoadData();
        }

        private void LoadData()
        {
            using (var sr = new StreamReader(mBaseDir + "test.txt"))
            {
                String line = sr.ReadToEnd();
                var petVariety = JsonConvert.DeserializeObject<PetVariety>(line);

                //   return petVariety;
                //  MainDataSource.Instance.PetVarietys.Add(petVariety);
            }


        }
        readonly string mBaseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        async private void Add()
        {
            var petVariety = new PetVariety { Name = NewPetVariety, Description = NewDescription };

            //            using (StreamWriter outfile = new StreamWriter(baseDir + @"test.txt", true))
            //            {
            //                string output = JsonConvert.SerializeObject(petVariety);
            //                await outfile.WriteAsync(output);
            //            }

            DataBaseHelper helper = new DataBaseHelper();

            MainDataSource.Instance.PetVarietys.Add(petVariety);
            await helper.SaveAsync<PetVariety>(petVariety);




            // MainDataSource.Instance.Context.PetVarietys.Add(petVariety);
            // MainDataSource.Instance.Context.SaveChangesAsync();
        }

        private void Delete()
        {
            MainDataSource.Instance.Context.PetVarietys.Remove(SelectedPetVariety);
            MainDataSource.Instance.Context.SaveChangesAsync();
            MainDataSource.Instance.PetVarietys.Remove(SelectedPetVariety);
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string aColumnName]
        {
            get
            {
                if (aColumnName == "NewPetVariety")
                {
                    AddIsEnabled = !string.IsNullOrEmpty(NewPetVariety);
                    return string.IsNullOrEmpty(NewPetVariety) ? "必填" : null;
                }
                return null;
            }
        }
    }
}
