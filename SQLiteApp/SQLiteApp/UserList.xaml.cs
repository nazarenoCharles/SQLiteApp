using SQLite;
using SQLiteApp.Database;
using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        private ObservableCollection<UserDb> userItem = new ObservableCollection<UserDb>();
        public UserDb userDb;
        public Registration reg;
        public UserList()
        {
            InitializeComponent();

            userDb = new UserDb();
            var users = userDb.GetUsers();
            myListView.ItemsSource = users;   
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var dataModel = menuItem.CommandParameter as UserDb;
            var viewModel = menuItem.CommandParameter as Registration;
            bool confirm = await DisplayAlert("Delete Contact", "Are you sure to delete this?", "Yes", "No");
            if (confirm == true)
            {
                this.userItem.Remove(dataModel);
                userDb.DeleteUser(viewModel.Id);
            }
        }

        private void MyListView_Refreshing(object sender, EventArgs e)
        {
            userDb = new UserDb();
            var users = userDb.GetUsers();
            myListView.ItemsSource = users;
            myListView.EndRefresh();
        }
    }
}