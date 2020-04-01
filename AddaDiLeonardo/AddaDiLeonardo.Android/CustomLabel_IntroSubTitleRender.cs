using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel_IntroSubTitle), typeof(CustomLabel_IntroSubTitleRender))]
namespace AddaDiLeonardo.Droid
{
    public class CustomLabel_IntroSubTitleRender : LabelRenderer
    {
        public CustomLabel_IntroSubTitleRender(Context context) : base(context)
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