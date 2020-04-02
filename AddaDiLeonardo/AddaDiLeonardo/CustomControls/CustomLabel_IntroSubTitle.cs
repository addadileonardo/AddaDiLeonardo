using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AddaDiLeonardo.CustomControls
{
    public class CustomLabel_IntroSubTitle : Label
    {
        public CustomLabel_IntroSubTitle()
        {
            FontFamily = Device.RuntimePlatform == Device.iOS ? "RobotoCondensed-Light" : Device.RuntimePlatform == Device.Android ? "RobotoCondensed-Light.ttf#RobotoCondensed-Light" : "Assets/RobotoCondensed-Light.ttf#RobotoCondensed-Light";
            FontSize = 26;
            TextColor = Color.Black;
        }
    }
}
