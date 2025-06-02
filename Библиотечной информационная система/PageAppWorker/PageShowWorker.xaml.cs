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
    /// Логика взаимодействия для PageShowWorker.xaml
    /// </summary>
    public partial class PageShowWorker : Page
    {
        public static List<Worker> workers { get; set; }
       
        public ObservableCollection<Worker> workers1 { get; set; }
        public ICollectionView StudentsView { get; set; }
        public PageShowWorker()
        {
            InitializeComponent();
            Listworker.ItemsSource = App.Connetction.Client.ToList();
            workers = new List<Worker>(BdConnection.libraryEntities.Worker.Where(i => i.IsDelete == true).ToList());
            this.DataContext = this;
        }
     


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Client;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BdConnection.libraryEntities.SaveChanges();
            Listworker.ItemsSource = new List<Client>(BdConnection.libraryEntities.Client.Where(i => i.IsDelete == true).ToList());
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = workers.Where(p => p.Surname.ToLower().Contains(filterText)).ToList();
            Listworker.ItemsSource = new ObservableCollection<Worker>(filteredProducts);
        }

        private void navigateAddbook_Click(object sender, RoutedEventArgs e)
        {

        }

    

        private void Listworker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectionworker = Listworker.SelectedItem as Worker;
            NavigationService.Navigate(new PageAppWorker.PageEditWorker(selectionworker));
        }

       
    }
}
