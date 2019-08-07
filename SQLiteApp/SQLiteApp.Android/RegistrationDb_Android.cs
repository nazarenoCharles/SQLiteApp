using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;
using SQLiteApp.Database;
using SQLiteApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(RegistrationDb_Android))]
namespace SQLiteApp.Droid
{
    public class RegistrationDb_Android : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UsersDb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            // Return the database connection 
            return conn;
        }
    }
}