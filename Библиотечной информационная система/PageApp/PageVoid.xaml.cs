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

namespace Библиотечной_информационная_система.PageApp
{
    /// <summary>
    /// Логика взаимодействия для PageVoid.xaml
    /// </summary>
    public partial class PageVoid : Page
    {
        public PageVoid()
        {
            InitializeComponent();
        }

        private void forgot_password_Click(object sender, RoutedEventArgs e)
        {

        }

        private void void_Click(object sender, RoutedEventArgs e)
        {
            MenuEmployeeWindow menuEmployeeWindow = new MenuEmployeeWindow();
            menuEmployeeWindow.Show();
        }
    }
}
