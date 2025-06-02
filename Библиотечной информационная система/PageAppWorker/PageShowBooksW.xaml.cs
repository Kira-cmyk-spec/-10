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
        public static List<Book> books { get; set; }
        public static List<Discipline> disciplines { get; set; }
        public static List<Date_of_publication> date_Of_Publications { get; set; }

   
        public PageShowBooksW()
        {
            InitializeComponent();
            ListInfo.ItemsSource = App.Connetction.Book.ToList();
            books = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == true).ToList());
           // books1 = new List<Book>(BdConnection.libraryEntities1.Book.ToList());
            date_Of_Publications = new List<Date_of_publication>(BdConnection.libraryEntities.Date_of_publication.ToList());


            books.Insert(0, new Book() { id = -1, books = "Вывести всех" }); //для обратного вывода списка от combobox
            
            this.DataContext = this;
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var selectionBooks = ListInfo.SelectedItem as Book;
            var selectionDiscipline = ListInfo.SelectedItem as Discipline;
            var selectionLovation = ListInfo.SelectedItem as location;
            NavigationService.Navigate(new PageAppWorker.PageEdit(selectionBooks, selectionDiscipline, selectionLovation));
        }



        private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = books.Where(p => p.books.ToLower().Contains(filterText)).ToList();
            ListInfo.ItemsSource = new ObservableCollection<Book>(filteredProducts);
        }

      

    

      

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as Book;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = true;
            BdConnection.libraryEntities.SaveChanges();
            ListInfo.ItemsSource = new List<Book>(BdConnection.libraryEntities.Book.Where(i => i.IsDelete == false).ToList());
        }

        private void navigateAddbook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAppWorker.PageAddBook());
        }

        private void navigateEditBook_Click(object sender, RoutedEventArgs e)
        {
            var selectionBooks = ListInfo.SelectedItem as Book;
            var selectionDiscipline = ListInfo.SelectedItem as Discipline;
            var selectionLovation = ListInfo.SelectedItem as location;
            NavigationService.Navigate(new PageAppWorker.PageEdit(selectionBooks, selectionDiscipline, selectionLovation));
        }
    }
}
