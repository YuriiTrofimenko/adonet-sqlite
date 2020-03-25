using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Library_manager
{
    static class Globals
    {
        private static SQLiteConnection mSQLiteConnection;
        public static void setSQLiteConnection(SQLiteConnection _sqliteConnection)
        {
            mSQLiteConnection = _sqliteConnection;
        }
        public static SQLiteConnection getSQLiteConnection()
        {
            return mSQLiteConnection;
        }
    }
}
