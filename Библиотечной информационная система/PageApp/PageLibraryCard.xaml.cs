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
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система.PageApp
{
    /// <summary>
    /// Логика взаимодействия для PageLibraryCard.xaml
    /// </summary>
    public partial class PageLibraryCard : Page
    {
        public PageLibraryCard()
        {
            InitializeComponent();
            DisplayCurrentDate();
            DisplayCurrentUserName();


        }

        

        private void design_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime dateInTwoWeeks = today.AddDays(14);
            try
            {


                Library_Card items = new Library_Card()
                {
                    id_client = Convert.ToInt32(SurNameTextBlock),
                
                    id_book = Convert.ToInt32(namebook),
                  
                    id_location=0,
                    part_number =Convert.ToInt32(Number),
                    date_redister = today,
                    date_register_end = dateInTwoWeeks,
                    IsDelete = true,


                };
              

                App.Connetction.Library_Card.Add(items);
               


                App.Connetction.SaveChanges();
              
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DisplayCurrentDate()
        {
            DateTime today = DateTime.Now;
            
            DateTextBlock.Text = today.ToString("D"); 
        }
        private void DisplayCurrentUserName()
        {
            SurNameTextBlock.Text = $"Имя пользователя: {Environment.UserName}";
        }

    }
}
