using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabelTitle), typeof(CustomLabelTitleRender))]
namespace AddaDiLeonardo.iOS
{
    public class CustomLabelTitleRender : LabelRenderer
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