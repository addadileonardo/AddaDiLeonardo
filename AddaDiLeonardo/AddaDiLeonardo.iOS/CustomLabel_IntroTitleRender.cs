using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel_IntroTitle), typeof(CustomLabel_IntroTitleRender))]
namespace AddaDiLeonardo.iOS
{
    public class CustomLabel_IntroTitleRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.TextAlignment = UITextAlignment.Justified;
            }
        }
    }
}