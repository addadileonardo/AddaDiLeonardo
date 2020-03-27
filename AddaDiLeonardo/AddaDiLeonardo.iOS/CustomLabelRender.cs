using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRender))]
namespace AddaDiLeonardo.iOS
{
    public class CustomLabelRender : LabelRenderer
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