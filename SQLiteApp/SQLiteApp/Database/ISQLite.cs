using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApp.Database
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
