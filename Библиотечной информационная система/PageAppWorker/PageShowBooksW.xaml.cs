using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageShowBooksW.xaml
    /// </summary>
    public partial class PageShowBooksW : Page
    {
        public static List<Book> books1 { get; set; }
        public static List<Discipline> disciplines { get; set; }
        public static List<Date_of_publication> date_Of_Publications { get; set; }

   
        public PageShowBooksW()
        {
            InitializeComponent();
            ListInfo.ItemsSource = App.Connetction.Book.ToList();
            books1 = new List<Book>(BdConnection.libraryEntities1.Book.Where(i => i.IsDelete == true).ToList());
           // books1 = new List<Book>(BdConnection.libraryEntities1.Book.ToList());
            date_Of_Publications = new List<Date_of_publication>(BdConnection.libraryEntities1.Date_of_publication.ToList());


            books1.Insert(0, new Book() { id = -1, books = "Вывести всех" }); //для обратного вывода списка от combobox
            
            this.DataContext = this;
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageEdit());
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = books1.Where(p => p.books.ToLower().Contains(filterText)).ToList();
            ListInfo.ItemsSource = new ObservableCollection<Book>(filteredProducts);
        }

        private void ListInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Gropscombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grouosirt = Gropscombo.SelectedItem as Discipline;
            if (grouosirt.id != -1)
            {

                ListInfo.ItemsSource = new List<Discipline>(BdConnection.libraryEntities1.Discipline.Where(i => i.discipline1 == grouosirt.discipline1).ToList()); // филтрация по дисциплинам
            }
            else
            {
                ListInfo.ItemsSource = new List<Discipline>(BdConnection.libraryEntities1.Discipline.ToList());
            }
        }

        private void navigateeditbook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageEdit());
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Book;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BdConnection.libraryEntities1.SaveChanges();
            ListInfo.ItemsSource = new List<Book>(BdConnection.libraryEntities1.Book.Where(i => i.IsDelete == true).ToList());
        }

        private void navigateAddbook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageAddBook());
        }
    }
}
