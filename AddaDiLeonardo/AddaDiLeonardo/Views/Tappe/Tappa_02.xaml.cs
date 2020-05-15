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
    public partial class Tappa_02 : ContentPage
    {
        public Tappa_02()
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
            ImgTappa.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.cover.traghetto_cover.jpg");
            iconMarker.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.Icon-Place_@3x.png");
            var tappa = App.Database.GetTappeSingleAsync(idTappa: 3).Result;
            var sezioni = App.Database.GetSezioniAsync(idTappa: tappa.Id).Result;
            

            accordions = new List<Accordion>() { Accordion_0, Accordion_1, Accordion_2, Accordion_3, Accordion_4, Accordion_5 };
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
            #endregion

            #region accordion_1
            var contenuti_1 = App.Database.GetContenutiAsync(idSezione: sezioni[1].Id).Result;
            Accordion_1.Title = sezioni[1].Titolo;
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[0].Testo));
            //img
            //img
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[3].Testo));

            #endregion

            #region accordion_2
            var contenuti_2 = App.Database.GetContenutiAsync(idSezione: sezioni[2].Id).Result;
            Accordion_2.Title = sezioni[2].Titolo;
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[0].Testo));
            #endregion

            #region accordion_3
            var contenuti_3 = App.Database.GetContenutiAsync(idSezione: sezioni[3].Id).Result;
            Accordion_3.Title = sezioni[3].Titolo;
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[0].Testo));
            #endregion

            #region accordion_4
            var contenuti_4 = App.Database.GetContenutiAsync(idSezione: sezioni[4].Id).Result;
            Accordion_4.Title = sezioni[4].Titolo;
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[0].Testo));
         
            #endregion

            #region accordion_5
            var contenuti_5 = App.Database.GetContenutiAsync(idSezione: sezioni[5].Id).Result;
            Accordion_5.Title = sezioni[5].Titolo;
            stackContenuto_5.Children.Add(FormattaContenuto.Formatta(contenuti_5[0].Testo));
            //img
            //img
            stackContenuto_5.Children.Add(FormattaContenuto.Formatta(contenuti_5[3].Testo));
            #endregion
        }

        private async void ImgTappa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1erw66iglXnyz4jtZPI_cCbifx62N7J2T"));
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
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