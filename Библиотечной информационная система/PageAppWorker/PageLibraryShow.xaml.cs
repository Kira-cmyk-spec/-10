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
    /// Логика взаимодействия для PageLibraryShow.xaml
    /// </summary>
    public partial class PageLibraryShow : Page
    {
       
        public static List<Book> Books { get; set; }
        public static List<location> locations = new List<location>();
        public static List<Discipline> disciplines = new List<Discipline>();
        public static List<Client> clients = new List<Client>();
        public static List<Library_Card> library_Cards = new List<Library_Card>();
        public static List<LibraryCard_Client> libraryCard_Clients { get; set; }
        public static List<Date_of_publication> date_Of_Publications = new List<Date_of_publication>();
        public ObservableCollection<Book> Books1 { get; set; }
        public ICollectionView BooksView { get; set; }
        public PageLibraryShow()
        {
            InitializeComponent();

            //ListInfo.ItemsSource = App.Connetction.LibraryCard_Client.ToList();
         
            Books = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == true).ToList());          
            date_Of_Publications = new List<Date_of_publication>(BdConnection.libraryEntities.Date_of_publication.ToList());           
            clients = new List<Client>(BdConnection.libraryEntities.Client.ToList());
            libraryCard_Clients = new List<LibraryCard_Client>(BdConnection.libraryEntities.LibraryCard_Client.ToList());
            library_Cards = new List<Library_Card>(BdConnection.libraryEntities.Library_Card.ToList());
            locations = new List<location>(BdConnection.libraryEntities.location.ToList());
            disciplines = new List<Discipline>(BdConnection.libraryEntities.Discipline.ToList());
            clients.Insert(0, new Client() { id = -1, Surname = "Вывести всех" }); //для обратного вывода списка от combobox

            this.DataContext = this;
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            ListInfo.ItemsSource = BdConnection.libraryEntities.LibraryCard_Client.Where(p => p.Client.Surname.ToLower().Contains(filterText)).ToList();
   
        }

       

        private void deletelibrarybook_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Book;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BdConnection.libraryEntities.SaveChanges();
            ListInfo.ItemsSource = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == true).ToList());
        }
    }
}

