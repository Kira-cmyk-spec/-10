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
    /// Логика взаимодействия для PageAddClient.xaml
    /// </summary>
    public partial class PageAddClient : Page
    {
        public static List<Client> clients { get; set; }
     
        public static List<Group_student> group_Students { get; set; }
 
        public PageAddClient()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = App.Connetction.Group_student.ToList();

            clients = new List<Client>(BdConnection.libraryEntities.Client.ToList());
            group_Students = new List<Group_student>(BdConnection.libraryEntities.Group_student.ToList());
            

            this.DataContext = this;
        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            Group_student group_Student = new Group_student();

            client.Name = NameTextBox.Text;
            client.Surname = SurNameTextBox.Text;
            client.Patronymic = PatronymicTextBox.Text;
            client.login = loginTextBox.Text;
            client.password = passwordTextBox.Text;
            group_Student.Name = (GroupComboBox.SelectedItem as Group_student).Name;
      


            BdConnection.libraryEntities.Client.Add(client);
            BdConnection.libraryEntities.Group_student.Add(group_Student);
            BdConnection.libraryEntities.SaveChanges();
            MessageBox.Show("Добавление произошло успешно ");
        }
    }
}

    

