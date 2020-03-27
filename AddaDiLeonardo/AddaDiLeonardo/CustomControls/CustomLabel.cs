using Xamarin.Forms;

namespace AddaDiLeonardo.CustomControls
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            FontFamily = Device.RuntimePlatform == Device.iOS ? "Roboto-Light" : Device.RuntimePlatform == Device.Android ? "Roboto-Light.ttf#Roboto" : "Assets/Roboto-Light.ttf#Roboto";
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            LineHeight = 1.10;
        }
    }
}
