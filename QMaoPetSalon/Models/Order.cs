using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QMaoPetSalon.Models
{
    public class Order : Bindable
    {
        private int mId;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return mId; }
            set { SetProperty(ref mId, value); }
        }

        private int mCustomerId;
        public int CustomerId
        {
            get { return mCustomerId; }
            set { SetProperty(ref mCustomerId, value); }
        }

        private DateTime mOrderDateTime = DateTime.Now;
        public DateTime OrderDateTime
        {
            get { return mOrderDateTime; }
            set { SetProperty(ref mOrderDateTime, value); }
        }

        private double mPrice;
        public double Price
        {
            get { return mPrice; }
            set { SetProperty(ref mPrice, value); }
        }

        private int mServiceType;
        public int ServiceType
        {
            get { return mServiceType; }
            set { SetProperty(ref mServiceType, value); }
        }
        private int mDiseaseType;
        public int DiseaseType
        {
            get { return mDiseaseType; }
            set { SetProperty(ref mDiseaseType, value); }
        }
    }
}
