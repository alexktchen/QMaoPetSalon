using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace QMaoPetSalon.Views
{
    /// <summary>
    /// Interaction logic for CustomInfoView.xaml
    /// </summary>
    public partial class CustomOrderView : UserControl
    {
        readonly CustomOrderViewModel mViewModel = new CustomOrderViewModel();

        public CustomOrderView()
        {
            InitializeComponent();
            DataContext = mViewModel;
            Loaded += OnLoaded;
        }

        void OnLoaded(object aSender, RoutedEventArgs aEventArgs)
        {
            Keyboard.Focus(OwnerNameTextBox);
        }
    }
}
