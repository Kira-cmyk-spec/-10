using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Библиотечной_информационная_система.ClassApp;
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система.PageApp
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
       
        public PageMenu()
        {
            InitializeComponent();
           
           
        }

        private void Library_card_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageApp.PageLibraryCard());
        }

        private void book_buton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageApp.PageShowBook());
        }
    }
}
