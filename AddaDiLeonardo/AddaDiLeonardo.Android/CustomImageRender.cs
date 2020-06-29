using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomImage), typeof(CustomImageRender))]
namespace AddaDiLeonardo.Droid
{
    public class CustomImageRender : ImageRenderer
    {

        public CustomImageRender(Context context) : base(context)
        {

        }
    }
}