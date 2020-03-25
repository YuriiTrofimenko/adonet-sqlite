using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;

namespace Library_manager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Entry entry = new Entry();
            //Application.Run(new Form1(entry));
            Application.Run(new Form1());
        }
        //
        //"Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer"
        public static SQLiteConnection getSQLiteConnection(String _loginString, String _passString)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            //String result = "";
            SQLiteConnection sqlite_conn;
            String login = ((System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("secureAppSettings"))["login"].ToString();//AppSettings["login"];
            String password = ((System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("secureAppSettings"))["password"].ToString();

            if (_loginString.Equals(login) && _passString.Equals(password))
            {
                
                sqlite_conn =
                    new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString);
                //result = "Ok!";
            }
            else
            {
                sqlite_conn = null;
            }
            //return result;
            return sqlite_conn;
        }
    }
}
