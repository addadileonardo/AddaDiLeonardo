using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomImage), typeof(CustomImageRender))]
namespace AddaDiLeonardo.iOS
{
    public class CustomImageRender : ImageRenderer
    {
    }
}