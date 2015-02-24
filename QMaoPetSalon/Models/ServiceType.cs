using System.ComponentModel.DataAnnotations.Schema;

namespace QMaoPetSalon.Models
{
    public class ServiceType : Bindable
    {
        private string mName;
        public string Name
        {
            get { return mName; }
            set { SetProperty(ref mName, value); }
        }

        private int mId;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return mId; }
            set { SetProperty(ref mId, value); }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { SetProperty(ref mDescription, value); }
        }
    }
}
