using RDA.TaskSQL._2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
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

namespace RDA.TaskSQL._2
{
    public partial class MainWindow : Window
    {
        private Test01DBEntities _db = new Test01DBEntities();
        public MainWindow()
        {
            InitializeComponent();

            DGInfo.ItemsSource = _db.UserInfoes.ToList();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TbLogin.Text) || 
                    string.IsNullOrEmpty(PBPassword.Password) ||
                    string.IsNullOrEmpty(TbPhone.Text) ||
                    string.IsNullOrEmpty(TbEmail.Text))

                    
                {
                    MessageBox.Show($"Не все строки заполнены!");
                }
                else
                {
                    _db.UserInfoes.Add(new UserInfo()
                    {
                        Login = TbLogin.Text,
                        Password = PBPassword.Password,
                        Phone = TbPhone.Text,
                        Email = TbEmail.Text
                    });
                    _db.SaveChanges();
                    MessageBox.Show($"New User Created! Well done!");
                    TbLogin.Text = string.Empty;
                    PBPassword.Password = string.Empty;
                    TbPhone.Text = string.Empty;
                    TbEmail.Text = string.Empty;
                    DGInfo.ItemsSource = _db.UserInfoes.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error 3");
            }

        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo userInfoModel = await _db.UserInfoes.FirstOrDefaultAsync(d => d.Login == TbLogin1.Text && d.Password == PBPassword1.Password);
                if (userInfoModel != null)
                {
                    MessageBox.Show($"Hello user - {userInfoModel.Login}!");
                    TbLogin1.Text = string.Empty;
                    PBPassword1.Password = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Error");
                }
            }
            catch (Exception)
            {

                //MessageBox.Show($"Error 1");
            }
           
        }
    }
}
