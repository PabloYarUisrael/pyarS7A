using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using pyarS7A.Droid;

//el assembly es para que esta clase se compile en el proyecto principal
[assembly:Xamarin.Forms.Dependency(typeof(SqlClientAndroid))]
namespace pyarS7A.Droid
{
    // se debe crear tamibién en el proyecto IOS
    public class SqlClientAndroid : IDataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}