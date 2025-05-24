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
    /// Логика взаимодействия для PageShowBook.xaml
    /// </summary>
    public partial class PageShowBook : Page
    {
        public static List<Book> Books { get; set; }
        public ObservableCollection<Book> Books1 { get; set; }
        public ICollectionView BooksView { get; set; }
        public PageShowBook()
        {
            InitializeComponent();
            ListBooks.ItemsSource = App.Connetction.Book.ToList();
            Books = new List<Book>(BdConnection.libraryEntities1.Book.Where(i => i.IsDelete == true).ToList());
            this.DataContext = this;
        }
        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = Books.Where(p => p.books.ToLower().Contains(filterText)).ToList();
            ListBooks.ItemsSource = new ObservableCollection<Book>(filteredProducts);
        }

      
    }
}
