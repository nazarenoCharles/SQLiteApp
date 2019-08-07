using SQLite;
using SQLiteApp.Database;
using SQLiteApp.Model;
using System;
using System.Collections.Generic;
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
        public SQLiteConnection conn;
        public Registration regmodel;
        public UserList()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<Registration>();
            DisplayDetails();
        }

        private void DisplayDetails()
        {
            var userDetails = (from x in conn.Table<Registration>() select x).ToList();
            myListView.ItemsSource = userDetails;
        }
    }
}