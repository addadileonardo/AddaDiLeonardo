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
            //https://drive.google.com/uc?export=download&id=1IZxR7_jlFOtGRcUMGMPl0D9MdM1d8LUN
            Core.Initialize();
            var _libVLC = new LibVLC();
            var media = new Media(_libVLC, "https://drive.google.com/uc?export=download&id=1IZxR7_jlFOtGRcUMGMPl0D9MdM1d8LUN", FromType.FromLocation);
            myvideo.MediaPlayer = new MediaPlayer(media);
            myvideo.MediaPlayer.Fullscreen = true;
            myvideo.MediaPlayer.Play();
        }
    }
}
