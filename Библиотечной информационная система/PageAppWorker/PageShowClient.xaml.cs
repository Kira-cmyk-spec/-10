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
    /// Логика взаимодействия для PageShowClient.xaml
    /// </summary>
    public partial class PageShowClient : Page
    {
        public static List<Client> clients { get; set; }
        public static List<Group_student> group_Students { get; set; }
        public ObservableCollection<Client> clients1 { get; set; }
        public ICollectionView StudentsView { get; set; }
        public PageShowClient()
        {
            InitializeComponent();
            ListClient.ItemsSource = App.Connetction.Client.ToList();
            clients = new List<Client>(BdConnection.libraryEntities1.Client.Where(i => i.IsDelete == true).ToList());
            this.DataContext = this;
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageEditClient());
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Client;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BdConnection.libraryEntities1.SaveChanges();
            ListClient.ItemsSource = new List<Client>(BdConnection.libraryEntities1.Client.Where(i => i.IsDelete == true).ToList());
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = clients.Where(p => p.Surname.ToLower().Contains(filterText)).ToList();
            ListClient.ItemsSource = new ObservableCollection<Client>(filteredProducts);
        }
    }
}
