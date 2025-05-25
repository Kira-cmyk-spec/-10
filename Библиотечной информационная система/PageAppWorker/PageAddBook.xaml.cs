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
        public ObservableCollection<Book> books1 { get; set; }
        public static List<Discipline> disciplines { get; set; }
     
        public static List<location> locations { get; set; }
   
        public static List<Date_of_publication> date_Of_Publications { get; set; }
        public PageAddBook()
        {
            InitializeComponent();
            disciplinComboBox.ItemsSource = App.Connetction.Discipline.ToList();

            disciplines = new List<Discipline>(BdConnection.libraryEntities1.Discipline.ToList());
            this.DataContext = this;

        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            //Book book = new Book();
            //location location = new location();

            //if (bookTextBox != null && dataTextBox != null && date_Of_Publications != null &&AuthorTextBox != null && RackTextBox != null && ShelftextBox != null )
            //{
            //    book.books = bookTextBox.ToString();
            //    book.date_of_publication = date_Of_Publications.ToString();
            //    book.Author = AuthorTextBox.ToString();
            //    book.IsDelete = true;
            //    location.rack = Convert.ToInt32(RackTextBox);
            //    location.sthelf = Convert.ToInt32(ShelftextBox);
            //    BdConnection.libraryEntities1.Discipline.Add(book);
            //    BdConnection.libraryEntities1.Discipline.Add(location);
            //    BdConnection.libraryEntities1.SaveChanges();
            //    MessageBox.Show("Добавления произошло успешно");


            //}
            try
            {
                var _cat = disciplinComboBox.SelectedItem as Discipline;

                Book items = new Book()
                {
                    books = bookTextBox.Text,
                    date_of_publication = dataTextBox.Text,
                    Author = AuthorTextBox.Text,
                    IsDelete = true

                };

                location location = new location()
                {
                    rack = Convert.ToInt32(RackTextBox),
                    sthelf = Convert.ToInt32(ShelftextBox),

                };


                App.Connetction.Book.Add(items);
                App.Connetction.location.Add(location);



               App.Connetction.SaveChanges();
                MessageBox.Show("Добавление произошло успешно ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
 }

