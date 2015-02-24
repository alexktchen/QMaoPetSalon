using System.Windows.Controls;
using QMaoPetSalon.ViewModels;

namespace QMaoPetSalon.Content
{
    public partial class PetVarietyView : UserControl
    {
        readonly PetVarietyViewModel mViewModel = new PetVarietyViewModel();

        public PetVarietyView()
        {
            InitializeComponent();
            DataContext = mViewModel;
        }
    }
}
