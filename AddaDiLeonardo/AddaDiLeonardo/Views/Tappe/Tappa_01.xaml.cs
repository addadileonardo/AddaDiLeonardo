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
    public partial class Tappa_01 : ContentPage
    {
        public Tappa_01()
        {
            InitializeComponent();
            var tappa = App.Database.GetTappeSingleAsync(idTappa: 1).Result;
            var sezioni = App.Database.GetSezioniAsync(idTappa: tappa.Id).Result;
            var contenuti_0 = App.Database.GetContenutiAsync(idSezione: sezioni[0].Id).Result;

            accordions = new List<Accordion>() { Accordion_0 };
            foreach (Accordion accordion in accordions)
                accordion.AccordionOpened += accordionEvent;
            #region introduction

            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
            ImgTappa.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_01.jpg");
            iconMarker.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.Icon-Place_@3x.png");
            lblTitle.Text = tappa.Titolo;
            lblSubTitle.Text = tappa.Sottotitolo;
            lblDescription.Text = tappa.Descrizione;

            #endregion

            #region accordion
            Accordion_0.Title = sezioni[0].Titolo;
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[0].Testo));
            #endregion

        }

        private void close_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ImgTappa_Clicked(object sender, EventArgs e)
        {

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