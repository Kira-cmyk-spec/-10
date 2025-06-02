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
    /// Логика взаимодействия для PageEditWorker.xaml
    /// </summary>
    public partial class PageEditWorker : Page
    {
        public static List<Worker> workers { get; set; }

        Worker worker = new Worker();
        public PageEditWorker(Worker worker_)
        {
            InitializeComponent();

            workers = new List<Worker>(ClassApp.BdConnection.libraryEntities.Worker.ToList());

            worker = worker_;
          

         
            NameTextBox.Text = worker.Name;
            SurNameTextBox.Text = worker.Surname;
            PatronymicTextBox.Text = worker.Patronymic;
            loginTextBox.Text = worker.Login;
            passwordTextBox.Text = worker.Password;
     


            this.DataContext = this;
        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            worker.Name = NameTextBox.Text;
            worker.Surname = SurNameTextBox.Text;
            worker.Patronymic = PatronymicTextBox.Text;
            worker.Login = loginTextBox.Text;
            worker.Password = passwordTextBox.Text;
            App.Connetction.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
        }
    }
}
