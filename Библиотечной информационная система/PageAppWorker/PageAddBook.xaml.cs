using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для PageAddBook.xaml
    /// </summary>
    public partial class PageAddBook : Page
    {
        public static List<Book> books { get; set; }
        public static List<Discipline> disciplines { get; set; }
     
        public static List<location> locations { get; set; }
   
      
        public PageAddBook()
        {
            InitializeComponent();
            disciplinComboBox.ItemsSource = App.Connetction.Discipline.ToList();

            disciplines = new List<Discipline>(BdConnection.libraryEntities.Discipline.ToList());
            books = new List<Book>(BdConnection.libraryEntities.Book.ToList());
            locations = new List<location>(BdConnection.libraryEntities.location.ToList());
          
            this.DataContext = this;

        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
          Book book = new Book();
            Discipline discipline = new Discipline();
            location location = new location();
            book.books = bookTextBox.Text;
            book.date_of_publication = dataTextBox.Text;
            book.Author = AuthorTextBox.Text;

            book.IsDelete = true;
            discipline.discipline1 = (disciplinComboBox.SelectedItem as Discipline).discipline1;
            location.rack = Convert.ToInt32(RackTextBox.Text);
            location.sthelf = Convert.ToInt32(ShelftextBox.Text);


            BdConnection.libraryEntities.Book.Add(book);
            BdConnection.libraryEntities.Discipline.Add(discipline);
            BdConnection.libraryEntities.location.Add(location);
            BdConnection.libraryEntities.SaveChanges();
                MessageBox.Show("Добавление произошло успешно ");
           
        }
    }
 }

