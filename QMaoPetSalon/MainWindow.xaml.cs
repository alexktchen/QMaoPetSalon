using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using FirstFloor.ModernUI.Windows.Controls;
using QMaoPetSalon.Views;


namespace QMaoPetSalon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();

           

            new LoadingWindows().ShowDialog();
        }
    }
}
