using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabelTitle), typeof(CustomLabelTitleRender))]
namespace AddaDiLeonardo.Droid
{
    public class CustomLabelTitleRender : LabelRenderer
    {
        public CustomLabelTitleRender(Context context) : base(context)
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