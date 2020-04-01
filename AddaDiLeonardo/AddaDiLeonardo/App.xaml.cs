using AddaDiLeonardo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddaDiLeonardo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Views.Tappe.Tappa_01();
            MainPage = new MainPage();
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
