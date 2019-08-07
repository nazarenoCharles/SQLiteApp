using SQLite;
using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SQLiteApp.Database
{
    public class UserDb
    {
        private SQLiteConnection _sqlconnection;

        public UserDb()
        {
            _sqlconnection = DependencyService.Get<ISqlite>().GetConnection();
            _sqlconnection.CreateTable<Registration>();
        }
        public IEnumerable<Registration> GetUsers()
        {
            return (from t in _sqlconnection.Table<Registration>()
                    select t).ToList();
        }
        public Registration GetRegistration(int id)
        {
            return _sqlconnection.Table<Registration>().FirstOrDefault(t => t.Id == id);
        }
        public void AddRegistration(Registration registration)
        {
            _sqlconnection.Insert(registration);
        }
        public void DeleteRegistration(int id)
        {
            _sqlconnection.Delete<Registration>(id);
        }
    }
}
