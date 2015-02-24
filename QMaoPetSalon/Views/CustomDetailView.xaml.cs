using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace QMaoPetSalon.Views
{
    public partial class CustomDetailView : UserControl
    {
        readonly CustomDetailViewModel mViewModel = new CustomDetailViewModel();

        public CustomDetailView()
        {
            InitializeComponent();
            DataContext = mViewModel;
            MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Debug.Write(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
