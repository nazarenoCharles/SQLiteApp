using SQLite;
using SQLiteApp.Database;
using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLiteApp
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public SQLiteConnection conn;
        public Registration regmodel;
        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<Registration>();
        }
        private void Signed_Clicked(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.FirstName = FirstName.Text;
            reg.LastName = LastName.Text;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email.Text;
            reg.Password = Password.Text;
            reg.Address = Address.Text;
            int x = 0;
            try
            {
                x = conn.Insert(reg);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (x == 1)
            {
                DisplayAlert("Registration", "Thanks for Registration", "Cancel");
            }
            else
            {
                DisplayAlert("Registration Failed", "Please try again", "ERROR");
            }
        }
        private async void Show_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new UserList());
 
        }

    }

}
