using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using FirstFloor.ModernUI.Windows.Controls;
using QMaoPetSalon.DbContexts;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindows.xaml
    /// </summary>
    public partial class LoadingWindows : Window
    {
        Thread loadingThread;
        Storyboard Showboard;
        Storyboard Hideboard;
        private delegate void ShowDelegate(string txt);
        private delegate void HideDelegate();
        ShowDelegate showDelegate;
        HideDelegate hideDelegate;

        public LoadingWindows()
        {
            InitializeComponent();
            showDelegate = new ShowDelegate(this.showText);
            hideDelegate = new HideDelegate(this.hideText);
            Showboard = this.Resources["showStoryBoard"] as Storyboard;
            Hideboard = this.Resources["HideStoryBoard"] as Storyboard;
        }

        async private void Load()
        {
            //await InitData();

            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)Close);
        }

        async private Task InitData()
        {
            // Thread.Sleep(1000);
            Dispatcher.Invoke(showDelegate, "準備資料");
            // Thread.Sleep(1000);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QMaoPetSalonDataBase>());
            MainDataSource.Instance.Context = new QMaoPetSalonDataBase();
            Dispatcher.Invoke(hideDelegate);


            Thread.Sleep(1000);
            Dispatcher.Invoke(showDelegate, "準備疾病資料");
            Thread.Sleep(1000);
            MainDataSource.Instance.Context.DiseaseTypes.Load();
            MainDataSource.Instance.DiseaseTypes = new ObservableCollection<DiseaseType>();
            foreach (var diseaseTypes in MainDataSource.Instance.Context.DiseaseTypes)
            {
                MainDataSource.Instance.DiseaseTypes.Add(diseaseTypes);
            }

            Dispatcher.Invoke(hideDelegate);



            // Thread.Sleep(1000);
            Dispatcher.Invoke(showDelegate, "準備優惠資料");
            //  Thread.Sleep(1000);
            MainDataSource.Instance.Context.CouponTypes.Load();
            MainDataSource.Instance.CouponTypes = new ObservableCollection<CouponType>();
            foreach (var couponType in MainDataSource.Instance.Context.CouponTypes)
            {
                MainDataSource.Instance.CouponTypes.Add(couponType);
            }

            Dispatcher.Invoke(hideDelegate);


            //  Thread.Sleep(1000);
            Dispatcher.Invoke(showDelegate, "準備寵物資料");
            //  Thread.Sleep(1000);
            MainDataSource.Instance.Context.PetVarietys.Load();
            MainDataSource.Instance.PetVarietys = new ObservableCollection<PetVariety>();
            foreach (var petVariety in MainDataSource.Instance.Context.PetVarietys)
            {
                MainDataSource.Instance.PetVarietys.Add(petVariety);
            }

            Dispatcher.Invoke(hideDelegate);

            // Thread.Sleep(1000);
            Dispatcher.Invoke(showDelegate, "準備服務資料");
            // Thread.Sleep(1000);
            MainDataSource.Instance.Context.ServiceTypes.Load();
            MainDataSource.Instance.ServiceTypes = new ObservableCollection<ServiceType>();
            foreach (var serviceTypes in MainDataSource.Instance.Context.ServiceTypes)
            {
                MainDataSource.Instance.ServiceTypes.Add(serviceTypes);
            }

            Dispatcher.Invoke(hideDelegate);

        }
        private void LoadingWindows_OnLoaded(object aSender, RoutedEventArgs aE)
        {
            loadingThread = new Thread(Load);
            loadingThread.Start();
        }

        private void showText(string txt)
        {
            txtLoading.Text = txt;
            BeginStoryboard(Showboard);
        }
        private void hideText()
        {
            BeginStoryboard(Hideboard);
        }
    }
}
