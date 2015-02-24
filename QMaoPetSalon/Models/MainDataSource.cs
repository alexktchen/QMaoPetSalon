using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMaoPetSalon.DbContexts;

namespace QMaoPetSalon.Models
{
    public class MainDataSource : Bindable
    {
        private static MainDataSource sInstance;
        public static MainDataSource Instance
        {
            get { return sInstance ?? (sInstance = new MainDataSource()); }
        }

        public QMaoPetSalonDataBase Context { get; set; }

        private ObservableCollection<DiseaseType> mDiseaseTypes;
        public ObservableCollection<DiseaseType> DiseaseTypes
        {
            get { return mDiseaseTypes; }
            set { SetProperty(ref mDiseaseTypes, value); }
        }
        private ObservableCollection<PetVariety> mPetVarietys;
        public ObservableCollection<PetVariety> PetVarietys
        {
            get { return mPetVarietys; }
            set { SetProperty(ref mPetVarietys, value); }
        }
        private ObservableCollection<CouponType> mCouponTypes;
        public ObservableCollection<CouponType> CouponTypes
        {
            get { return mCouponTypes; }
            set { SetProperty(ref mCouponTypes, value); }
        }

        private ObservableCollection<ServiceType> mServiceTypes;
        public ObservableCollection<ServiceType> ServiceTypes
        {
            get { return mServiceTypes; }
            set { SetProperty(ref mServiceTypes, value); }
        }

    }
}
