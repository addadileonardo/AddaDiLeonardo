﻿using AddaDiLeonardo.Views;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AddaDiLeonardo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1-ybKXo6ZUxK-OAVCftXiX0gq7IOpbQB"));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Tappe.Tappa_01());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Tappe.Tappa_04());
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Tappe.Tappa_03());
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Tappe.Tappa_02());
        }

        private async void Button_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Tappe.Tappa_05());
        }

        private async void Button_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.HomePage());
        }

    }
}
