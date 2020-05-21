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

            MainPage = new Views.Blank();
            MainPage = new HomePage();
        }

        //Singleton pattern per la gestione del db
        private static Database.Database database;
        private static string currentlanguage = "IT";
        public static Database.Database Database
        {
            get
            {
                if (database == null || currentlanguage != HomePage.ActiveLanguage)
                {
                    currentlanguage = HomePage.ActiveLanguage;
                    database = new Database.Database();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
