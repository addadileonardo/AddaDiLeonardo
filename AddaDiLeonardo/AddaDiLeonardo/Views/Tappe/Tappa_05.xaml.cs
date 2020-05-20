using AddaDiLeonardo.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddaDiLeonardo.Views.Tappe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tappa_05 : ContentPage
    {
        public Tappa_05()
        {
            InitializeComponent();
            var display = DeviceDisplay.MainDisplayInfo;
            var widthScreenpixel = display.Width;
            var HeightScreenpixel = display.Height;
            var densityScreenPixel = display.Density;
            var widthScreenUnit = widthScreenpixel / densityScreenPixel;
            var imageUnitHeight = (594 * widthScreenUnit) / 1080;
            Grid1.RowDefinitions.Add(new RowDefinition { Height = imageUnitHeight });
            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
            ImgTappa.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.cover.centrali_cover.jpg");
            iconMarker.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.Icon-Place_@3x.png");
            var tappa = App.Database.GetTappeSingleAsync(idTappa: 5).Result;
            var sezioni = App.Database.GetSezioniAsync(idTappa: tappa.Id).Result;


            accordions = new List<Accordion>() { Accordion_0, Accordion_1, Accordion_2, Accordion_3 };
            foreach (Accordion accordion in accordions)
                accordion.AccordionOpened += accordionEvent;

            #region introduction
            
            lblTitle.Text = tappa.Titolo;
            lblSubTitle.Text = tappa.Sottotitolo;
            lblDescription.Text = tappa.Descrizione;
            #endregion

            #region accordion_0
            var contenuti_0 = App.Database.GetContenutiAsync(idSezione: sezioni[0].Id).Result;
            Accordion_0.Title = sezioni[0].Titolo;
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[0].Testo));
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[1].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_03.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[3].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_04.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[5].Testo));
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[6].Testo));
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[7].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_01.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[9].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_02.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[11].Testo));
            #endregion

            #region accordion_1
            var contenuti_1 = App.Database.GetContenutiAsync(idSezione: sezioni[1].Id).Result;
            Accordion_1.Title = sezioni[1].Titolo;
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[0].Testo));
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[1].Testo));
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[4].Testo));
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[5].Testo));
            #endregion

            #region accordion_2
            var contenuti_2 = App.Database.GetContenutiAsync(idSezione: sezioni[2].Id).Result;
            Accordion_2.Title = sezioni[2].Titolo;
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[0].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[1].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_07.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[3].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_05.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[5].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_06.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[7].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[8].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[9].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[10].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[12].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_08.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[14].Testo));
            #endregion

            #region accordion_3
            var contenuti_3 = App.Database.GetContenutiAsync(idSezione: sezioni[3].Id).Result;
            Accordion_3.Title = sezioni[0].Titolo;
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[0].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[1].Testo));
            stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_05.centrali_09.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[3].Testo));
            #endregion


        }

        private void close_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void ImgTappa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlayerPage("https://fondazionepolitecnico.box.com/shared/static/fdyeuyuyvqb7ochf9khd12yjhrkdsjn9.mp4"));
        }

        static List<Accordion> accordions;
        private void accordionEvent(object sender, EventArgs e)
        {
            accordions.Remove((Accordion)sender);
            foreach (Accordion accordion in accordions)
                if (accordion.IsOpen)
                    accordion.IsOpen = !accordion.IsOpen;
            accordions.Add((Accordion)sender);
            Thread.Sleep((int)Accordion.AnimationDuration);
            ScrollTop(((Accordion)sender).AccordionName);
        }

        private void ScrollTop(string elementname)
        {
            this.Scroll.ScrollToAsync(this.FindByName<Element>(elementname), ScrollToPosition.Start, true);
        }
    }
}