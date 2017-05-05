using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using Xamarin.Forms;
using CatatPengeluaran;
using CatatPengeluaran.Droid;

[assembly: Dependency(typeof(SqliteService))]
namespace CatatPengeluaran.Droid
{
    public class SqliteService : ISQLite
    {
        public SqliteService() { }
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "pengeluaran.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            return conn;
        }
    }
}