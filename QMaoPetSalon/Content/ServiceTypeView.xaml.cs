using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QMaoPetSalon.ViewModels;

namespace QMaoPetSalon.Content
{
    /// <summary>
    /// Interaction logic for ServiceTypeView.xaml
    /// </summary>
    public partial class ServiceTypeView : UserControl
    {
        readonly ServiceTypeViewModel mViewModel = new ServiceTypeViewModel();

        public ServiceTypeView()
        {
            InitializeComponent();
            DataContext = mViewModel;
        }
    }
}
