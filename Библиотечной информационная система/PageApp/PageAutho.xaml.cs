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



namespace Библиотечной_информационная_система.PageApp
{
    /// <summary>
    /// Логика взаимодействия для PageAutho.xaml
    /// </summary>
    public partial class PageAutho : Page
    {
        public PageAutho()
        {
            InitializeComponent();
        }

        private void void_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bdloguin.Text != "" && bdpassword != null)
                {
                    var _user = App.Connetction.Client.Where(z => z.password == bdpassword.Password && z.login == bdloguin.Text).FirstOrDefault();
                    var _admin = App.Connetction.Worker.Where(z => z.Password == bdpassword.Password && z.Login == bdloguin.Text).FirstOrDefault();
                    //MessageBox.Show("Добро пожаловать! ",_user.Name);
                    //MessageBox.Show("Добро пожаловать! ",_admin.Name);
                    if (_user != null )
                    {
                        if (_user.id_role == 1)
                        {
                            Class_User.CorrClient = _user;
                            NavigationService.Navigate(new PageMenu());

                        }
                       

                    }
                    else if (_admin != null)
                    {
                          if (_admin.id_role == 2)
                        {
                            Class_Worker.CorrWorker = _admin;
                            NavigationService.Navigate(new PageAppWorker.PageMenuWorker());
                        }
                        else if (_admin.id_role == 3)
                        {
                            Class_Worker.CorrWorker = _admin;
                            NavigationService.Navigate(new PageAppWorker.PageMenuAdmin());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Таких пользователей не существует", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Поля логина или пароля введены неправильно", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch { }
        }
    }
}
