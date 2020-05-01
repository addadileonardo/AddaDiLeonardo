using AddaDiLeonardo.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
            ImgTappa.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_02.traghetto_cover.png");
            iconMarker.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.Icon-Place_@3x.png");
            var tappa = App.Database.GetTappeSingleAsync(idTappa: 4).Result;
            var sezioni = App.Database.GetSezioniAsync(idTappa: tappa.Id).Result;
            

            accordions = new List<Accordion>() { Accordion_0, Accordion_1, Accordion_2, Accordion_3, Accordion_4 };
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
            stackContenuto_0.Children.Add(new Label { Text="video"});
            #endregion

            #region accordion_1
            var contenuti_1 = App.Database.GetContenutiAsync(idSezione: sezioni[1].Id).Result;
            Accordion_1.Title = sezioni[1].Titolo;
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[0].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_04.ponte_01.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[2].Testo));
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[3].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_04.ponte_02.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[5].Testo));
            #endregion

            #region accordion_2
            var contenuti_2 = App.Database.GetContenutiAsync(idSezione: sezioni[2].Id).Result;
            Accordion_2.Title = sezioni[2].Titolo;
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[0].Testo));
            //stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_04.ponte_03.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[2].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[3].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_04.ponte_04.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[5].Testo));
            #endregion

            #region accordion_3
            #endregion

            #region accordion_4
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