using LibVLCSharp.Forms.Shared;
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
            
            _link = link;
            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                
                await DisplayAlert("ATTENZIONE!", "Devi essere connesso ad internet per vedere il video!", "Ok");
                await Navigation.PopModalAsync();
            }
            else
            {
                Core.Initialize();
                using (var _libVLC = new LibVLC())
                {
                    var media = new Media(_libVLC, _link, FromType.FromLocation);
                    myvideo.MediaPlayer = new MediaPlayer(media)
                    {
                        EnableHardwareDecoding = true,
                        Fullscreen = true
                    };
                    myvideo.MediaPlayer.Playing += MediaPlayer_Playing;
                    myvideo.MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;
                    myvideo.MediaPlayer.Play();
                };

            }
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                spinner.IsRunning = false;
                await DisplayAlert("ERRORE!", "Si è verificato un errore durante la riproduzione del video. Riprovare più tardi.", "OK");
                await Navigation.PopModalAsync();
            });
            
        }

        private void MediaPlayer_Playing(object sender, EventArgs e)
        {
            spinner.IsRunning = false;
        }



        protected override void OnDisappearing()
        {
            if (myvideo.MediaPlayer != null || myvideo.MediaPlayer.IsPlaying == true)
            {
                myvideo.MediaPlayer.Stop();
            }
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PopModalAsync();
        }
    }
}