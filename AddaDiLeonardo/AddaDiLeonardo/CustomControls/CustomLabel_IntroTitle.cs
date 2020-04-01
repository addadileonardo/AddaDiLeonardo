using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AddaDiLeonardo.CustomControls
{
    public class CustomLabel_IntroTitle : Label
    {
        public CustomLabel_IntroTitle()
        {
            FontFamily = Device.RuntimePlatform == Device.iOS ? "RobotoCondensed-Bold" : Device.RuntimePlatform == Device.Android ? "RobotoCondensed-Bold.ttf#RobotoCondensed-Bold" : "Assets/RobotoCondensed-Bold.ttf#RobotoCondensed-Bold";
            FontSize = 28;
            TextColor = Color.Black;
        }
    }
}
