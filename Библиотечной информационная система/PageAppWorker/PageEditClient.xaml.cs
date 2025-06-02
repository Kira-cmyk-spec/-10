using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageEditClient.xaml
    /// </summary>
    public partial class PageEditClient : Page
    {
        public static List<Client> clients { get; set; }
        public static List<Group_student> group_Students { get; set; }
        public static List<Library_Card> library_Cards { get; set; }
     
        Client client = new Client();
        Group_student group_Student = new Group_student();
        Library_Card library_Card = new Library_Card();
    
        public PageEditClient(Client client_, Group_student group_Student_, Library_Card library_Card_)
        {
            InitializeComponent();

            clients = new List<Client>(ClassApp.BdConnection.libraryEntities.Client.ToList());
            group_Students = new List<Group_student>(ClassApp.BdConnection.libraryEntities.Group_student.ToList());

            client = client_;
            group_Student = group_Student_;
            library_Card = library_Card_;

            Library_card_idCMD.SelectedItem = library_Cards.FirstOrDefault(i => i.id == client.id);
            NameTextBox.Text = client.Name;
            SurNameTextBox.Text = client.Surname;
            PatronymicTextBox.Text = client.Patronymic;
            loginTextBox.Text = client.login;
            passwordTextBox.Text = client.password;
            GroupeCMD.SelectedItem = group_Students.FirstOrDefault(i => i.Name == group_Student.Name);


            this.DataContext = this;
           

        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            library_Card.id = (Library_card_idCMD.SelectedItem as Library_Card).id;
            client.Name = NameTextBox.Text;
            client.Surname = SurNameTextBox.Text;
            client.Patronymic = PatronymicTextBox.Text;
            client.login = loginTextBox.Text;
            client.password = passwordTextBox.Text;
            group_Student.Name = (GroupeCMD.SelectedItem as Group_student).Name;
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");

        }
    }
}
