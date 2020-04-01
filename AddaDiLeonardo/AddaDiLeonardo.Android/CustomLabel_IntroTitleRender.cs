using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel_IntroTitle), typeof(CustomLabel_IntroTitleRender))]
namespace AddaDiLeonardo.Droid
{
    public class CustomLabel_IntroTitleRender : LabelRenderer
    {
        public CustomLabel_IntroTitleRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.JustificationMode = Android.Text.JustificationMode.InterWord;
            }
        }
    }
}