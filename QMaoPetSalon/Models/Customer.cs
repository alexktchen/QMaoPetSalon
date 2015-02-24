using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMaoPetSalon.Models
{
    public class Customer : Bindable
    {
        private int mId;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return mId; }
            set { SetProperty(ref mId, value); }
        }
        private int mCouponTypeId;
        public int CouponTypeId
        {
            get { return mCouponTypeId; }
            set { SetProperty(ref mCouponTypeId, value); }
        }
        private string mOwnerName;
        public string OwnerName
        {
            get { return mOwnerName; }
            set { SetProperty(ref mOwnerName, value); }
        }

        private string mPetName;
        public string PetName
        {
            get { return mPetName; }
            set { SetProperty(ref mPetName, value); }
        }

        private string mOwnerPhone;
        public string OwnerPhone
        {
            get { return mOwnerPhone; }
            set { SetProperty(ref mOwnerPhone, value); }
        }

        private string mOwnerAddress;
        public string OwnerAddress
        {
            get { return mOwnerAddress; }
            set { SetProperty(ref mOwnerAddress, value); }
        }

        private string mPetAge;
        public string PetAge
        {
            get { return mPetAge; }
            set { SetProperty(ref mPetAge, value); }
        }

        private int mPetVariety;
        public int PetVariety
        {
            get { return mPetVariety; }
            set { SetProperty(ref mPetVariety, value); }
        }
    }
}
