using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddaDiLeonardo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        private string _link = default;
        public PlayerPage(string link)
        {
            
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Core.Initialize();
            _link = link;
            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("ATTENZIONE!", "Accendi la connessione ad internet per vedere il video!", "OK");
                Navigation.PopModalAsync();
            }
            else
            {
                
                using (var _libVLC = new LibVLC())
                {
                    var media = new Media(_libVLC, _link, FromType.FromLocation);
                    myvideo.MediaPlayer = new MediaPlayer(media)
                    {
                        EnableHardwareDecoding = true,
                        Fullscreen = true
                    };
                    myvideo.MediaPlayer.Playing += MediaPlayer_Playing;
                    myvideo.MediaPlayer.Play();
                };
            }
        }

        private void MediaPlayer_Playing(object sender, EventArgs e)
        {
            spinner.IsRunning = false;
        }



        protected override void OnDisappearing()
        {
            myvideo.MediaPlayer.Stop();
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}