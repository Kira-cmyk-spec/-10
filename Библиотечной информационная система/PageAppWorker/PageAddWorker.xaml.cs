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
        public static List<Worker> workers { get; set; }
    
        public PageAddWorker()
        {


            workers = new List<Worker>(BdConnection.libraryEntities.Worker.ToList());
         

            this.DataContext = this;
        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker();

            worker.Name = NameTextBox.Text;
            worker.Surname = SurNameTextBox.Text;
            worker.Patronymic = PatronymicTextBox.Text;
            worker.Login = loginTextBox.Text;
            worker.Password = passwordTextBox.Text;
            


            BdConnection.libraryEntities.Worker.Add(worker);
            BdConnection.libraryEntities.SaveChanges();
            MessageBox.Show("Добавление произошло успешно ");
        }
    }
}
