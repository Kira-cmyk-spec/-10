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

namespace Библиотечной_информационная_система.PageAppWorker
{
    /// <summary>
    /// Логика взаимодействия для PageMenuAdmin.xaml
    /// </summary>
    public partial class PageMenuAdmin : Page
    {
       
        public PageMenuAdmin()
        {
            InitializeComponent();
         
        }

        private void Library_card_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageAppWorker.PageLibraryShow());
        }

        private void book_buton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageAppWorker.PageShowBooksW());
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageAppWorker.PageShowWorker());
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.NavigationService.Navigate(new PageAppWorker.PageShowClient());
        }
    }
}
