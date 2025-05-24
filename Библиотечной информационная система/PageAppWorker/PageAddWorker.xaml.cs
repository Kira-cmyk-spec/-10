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
    /// Логика взаимодействия для PageAddWorker.xaml
    /// </summary>
    public partial class PageAddWorker : Page
    {
        public static List<Client> clients { get; set; }
        public ObservableCollection<Client> clients1 { get; set; }
        public PageAddWorker()
        {
            InitializeComponent();
        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker();
            Group_student group_Student = new Group_student();
            var _cat = tov.SelectedItem as Group_student;

            if (NameTextBox != null && SurNameTextBox != null && PatronymicTextBox != null && passwordTextBox != null && loginTextBox != null && GroupComboBox != null)
            {
                worker.Name = NameTextBox.ToString();
                worker.Surname = SurNameTextBox.ToString();
                worker.Patronymic = PatronymicTextBox.ToString();
                worker.Password = passwordTextBox.ToString();
                worker.Login = loginTextBox.ToString();
                worker.id_role = 1;
                worker.IsDelete = true;
                group_Student.Name = _cat.ToString();

                BdConnection.libraryEntities1.Discipline.Add(worker);
                BdConnection.libraryEntities1.Discipline.Add(group_Student);
                BdConnection.libraryEntities1.SaveChanges();
                MessageBox.Show("Добавления произошло успешно");


            }
            //try
            //{

            //    Client client = new Client()
            //    {
            //        Name = NameTextBox.Text,
            //        Surname = SurNameTextBox.Text,
            //        Patronymic = NameTextBox.Text,
            //        login = NameTextBox.Text,
            //        password = NameTextBox.Text,
            //        id_role = 2,
            //        IsDelete = true

            //    };



            //    App.Connetction.Client.Add(client);




            //    App.Connetction.SaveChanges();
            //    MessageBox.Show("Добавление произошло  успешно ");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
