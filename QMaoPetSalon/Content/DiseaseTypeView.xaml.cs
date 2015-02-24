using System.Windows.Controls;
using QMaoPetSalon.ViewModels;

namespace QMaoPetSalon.Content
{
    /// <summary>
    /// Interaction logic for DiseaseTypeView.xaml
    /// </summary>
    public partial class DiseaseTypeView : UserControl
    {
        readonly DiseaseTypeViewModel mViewModel = new DiseaseTypeViewModel();

        public DiseaseTypeView()
        {
            InitializeComponent();
            DataContext = mViewModel;
        }
    }
}
