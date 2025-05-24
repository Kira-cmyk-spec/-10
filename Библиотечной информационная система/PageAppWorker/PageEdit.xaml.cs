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
        public static List<Book> books { get; set; }
        public static Book books1 = new Book();
        public static Discipline discipline1 = new Discipline();
        public static location location1 = new location();
        public static Date_of_publication Date_Of_Publication1 = new Date_of_publication();
        public ObservableCollection<Book> books2 { get; set; }
        public static List<Discipline> disciplines { get; set; }      
        public static List<location> locations { get; set; }
   
        public PageEdit(Book book, Discipline discipline, location location, Date_of_publication date_Of_Publication)
        {
            InitializeComponent();
            books = new List<Book>(BdConnection.libraryEntities1.Book.ToList());
            locations = new List<location>(BdConnection.libraryEntities1.location.ToList());
            disciplines = new List<Discipline>(BdConnection.libraryEntities1.Discipline.ToList());
            //this.DataContext = App.Connetction.Book.Where(z => z.id == Class_Book.CorrBook.id).FirstOrDefault();
            //this.DataContext = App.Connetction.Discipline.Where(z => z.id == Class_Discipline.Corrdiscipline.id).FirstOrDefault();
            //this.DataContext = App.Connetction.location.Where(z => z.id == Class_location.Corrlocation.id).FirstOrDefault();
            books1 = book;
            location1 = location;
            discipline1 = discipline;
            Date_Of_Publication1 = date_Of_Publication;
            NameTextBox.Text = books1.books;
          
            AuthorTextBox.Text = books1.Author;
            RackTextBox.Text =Convert.ToInt32(location1.rack);
            ShelfTextBox.Text = location1.sthelf;
            DiscpiplineComboBox.SelectedItem = disciplines.FirstOrDefault(t => t.id == discipline1.id);
            this.DataContext = this;








        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            books1.books = NameTextBox.Text;
            books1.Author = AuthorTextBox.Text;
            location1.rack = Convert.ToInt32(RackTextBox.Text);
            location1.sthelf = Convert.ToInt32(ShelfTextBox.Text);

            Date_Of_Publication1.date_of_publication1 = DateTextBox.Text;
        
            DiscpiplineComboBox.SelectedItem = disciplines.FirstOrDefault(t => t.id == discipline1.id);
            BdConnection.libraryEntities1.SaveChanges;
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
            NavigationService.Navigate(new PageAppWorker.PageShowBooksW());
        }
    }
}
