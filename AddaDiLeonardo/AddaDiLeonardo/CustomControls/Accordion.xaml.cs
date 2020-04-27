using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddaDiLeonardo.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accordion : ContentView
    {
        public Accordion()
        {
            InitializeComponent();

            IsOpen = false;
            Close();

            Indicator = Img;
        }

        //Elements

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(AccordionName), typeof(string), typeof(Accordion), default(string));
        public string AccordionName
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(Accordion), default(string));
        public string Title
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public static readonly BindableProperty IndicatorProperty = BindableProperty.Create(nameof(Indicator), typeof(View), typeof(Accordion), default(View));
        public View Indicator
        {
            get => (View)GetValue(IndicatorProperty);
            set => SetValue(IndicatorProperty, value);
        }

        Image Img = new Image() { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.arrow2.png"), WidthRequest = 20 };

        public static readonly BindableProperty BGColorProperty = BindableProperty.Create(nameof(BGColor), typeof(Color), typeof(Accordion), default(Color));
        public Color BGColor
        {
            get => (Color)GetValue(BGColorProperty);
            set => SetValue(BGColorProperty, value);
        }

        public static readonly BindableProperty TxtColorProperty = BindableProperty.Create(nameof(TxtColor), typeof(Color), typeof(Accordion), default(Color));
        public Color TxtColor
        {
            get => (Color)GetValue(TxtColorProperty);
            set => SetValue(TxtColorProperty, value);
        }

        public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(nameof(IsOpen), typeof(bool), typeof(Accordion), false, propertyChanged: IsOpenChanged);
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public static readonly BindableProperty AccordionContentProperty = BindableProperty.Create(nameof(AccordionContent), typeof(View), typeof(Accordion), default(View));
        public View AccordionContent
        {
            get => (View)GetValue(AccordionContentProperty);
            set => SetValue(AccordionContentProperty, value);
        }

        //Event
        public event EventHandler<EventArgs> AccordionOpened;

        //Open handling

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
            EventHandler<EventArgs> handler = AccordionOpened;
            if (handler != null)
                handler(this, e);
        }

        public static void IsOpenChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable != null && newValue != null)
            {
                var Control = (Accordion)bindable;

                if (Control.IsOpen == false)
                {
                    VisualStateManager.GoToState(Control, "Open");
                    Control.Close();
                }
                if (Control.IsOpen == true)
                {
                    VisualStateManager.GoToState(Control, "Closed");
                    Control.Open();
                }
            }
        }

        public static uint AnimationDuration { get; set; } = /*250*/50;
        public async void Open()
        {
            _content.IsVisible = true;
            await Task.WhenAll(
                _content.TranslateTo(0, 0, AnimationDuration),
                Img.TranslateTo(-20, 0, AnimationDuration),
                IndicatorOpen(),
                _indicator.RotateTo(0, AnimationDuration),
                _content.FadeTo(30, 50, Easing.SinIn)
                );
        }
        public async Task IndicatorOpen()
        {
            Img.Margin = new Thickness(0, 0, -10, 0);

            return;
        }

        public async void Close()
        {
            await Task.WhenAll(
                _content.TranslateTo(0, 0, AnimationDuration),
                Img.TranslateTo(10, 0, AnimationDuration),
                IndicatorClose(),
                _indicator.RotateTo(-180, AnimationDuration),
                _content.FadeTo(0, 50)
                );
            _content.IsVisible = false;
        }
        public async Task IndicatorClose()
        {
            Img.Margin = new Thickness(0, 0, 0, 0);

            return;
        }
    }
}