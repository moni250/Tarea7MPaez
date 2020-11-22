using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tarea7MPaez.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace Tarea7MPaez.Droid
{
    class SqliteClient : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var parth = Path.Combine(document, "uisrael.db3");
            return new SQLiteAsyncConnection(parth);
        }
    }
}