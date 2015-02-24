using System.Windows.Controls;
using QMaoPetSalon.ViewModels;

namespace QMaoPetSalon.Content
{
    /// <summary>
    /// Interaction logic for CouponTypeView.xaml
    /// </summary>
    public partial class CouponTypeView : UserControl
    {
        readonly CouponTypeViewModel mViewModel = new CouponTypeViewModel();

        public CouponTypeView()
        {
            InitializeComponent();
            DataContext = mViewModel;
        }
    }
}
