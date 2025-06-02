using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public static List<Book> book_S { get; set; }
        public static List<Discipline> disciplines { get; set; }      
        public static List<location> locations { get; set; }
        Book book = new Book();
        Discipline disciplin_e = new Discipline();
        location location = new location();
       
   
        public PageEdit(Book book_, Discipline discipline_, location location_)
        {
            InitializeComponent();
            book_S = new List<Book>(ClassApp.BdConnection.libraryEntities.Book.ToList());
            disciplines = new List<Discipline>(ClassApp.BdConnection.libraryEntities.Discipline.ToList());
            locations = new List<location>(ClassApp.BdConnection.libraryEntities.location.ToList());

            book = book_;
            disciplin_e = discipline_;
            location = location_;

            NameBooksTextBox.Text = book.books;
            DiscpiplineCMD.SelectedItem = disciplines.FirstOrDefault(i => i.discipline1 == disciplin_e.discipline1);
            AuthorTextBox.Text = book.Author;
            RackTextBox.Text = location.rack.ToString();
            SthelfTextBox.Text = location.sthelf.ToString();
            DateTextBox.Text = book.date_of_publication;

            DataContext = this;

        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            book.books = NameBooksTextBox.Text;
            disciplin_e.discipline1 = (DiscpiplineCMD.SelectedItem as Discipline).discipline1;
            book.Author = AuthorTextBox.Text;
            location.rack = Convert.ToInt32(RackTextBox.Text);
            location.sthelf = Convert.ToInt32(SthelfTextBox.Text);
            book.date_of_publication = DateTextBox.Text;
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
            NavigationService.Navigate(new PageAppWorker.PageShowBooksW());
        }
    }
}
