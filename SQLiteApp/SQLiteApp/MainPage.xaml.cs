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
        public UserDb userDb;
        public Registration reg;
        
        public MainPage()
        {
            InitializeComponent();
        }
        private void Signed_Clicked(object sender, EventArgs e)
        {
            reg = new Registration();
            userDb = new UserDb();
            reg.Id++;
            reg.FirstName = FirstName.Text;
            reg.LastName = LastName.Text;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email.Text;
            reg.Password = Password.Text;
            reg.Address = Address.Text;

            if (FirstName.Text == null || LastName.Text == null || Password.Text == null)
            {
                DisplayAlert("Registration", "Please Enter All the Fields!", "Ok");
            }
            DisplayAlert("Registration", "Thanks for Registration", "Ok");
            userDb.AddUser(reg);
            ClearAll();
            }

        private void Show_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserList());
        }
        public void ClearAll()
        {
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            Email.Text = string.Empty;
            Password.Text = string.Empty;
            Address.Text = string.Empty;
            ConfirmPass.Text = string.Empty;
        }
    }
}
