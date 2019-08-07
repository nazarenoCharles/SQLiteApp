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

            reg.FirstName = FirstName.Text;
            reg.LastName = LastName.Text;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email.Text;
            reg.Password = Password.Text;
            reg.Address = Address.Text;
            
            
            }
        }
        private async void Show_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new UserList());
 
        }
    }
}
