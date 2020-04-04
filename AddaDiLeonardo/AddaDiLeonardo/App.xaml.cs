using AddaDiLeonardo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AddaDiLeonardo.Database;
using System.Reflection;
using System.Linq;
using System.IO;

namespace AddaDiLeonardo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Views.Tappe.Tappa_01();
            MainPage = new HomePage();
        }

        private static Database.Database database;
        public static Database.Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database.Database();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            //TEST DB

            //var path = AddaDiLeonardo.Database.Constants.DatabasePath;

            //var tappa = App.Databasea.GetTappeSingleAsync(idTappa: 2).Result;
            //var sezioni = App.Databasea.GetSezioniAsync(idTappa: tappa.Id).Result;
            //var contenuti = App.Databasea.GetContenutiAsync(idSezione: sezioni[0].Id).Result;

            //int totale = contenuti.Count;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
