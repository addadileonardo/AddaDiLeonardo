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
    public partial class Tappa_03 : ContentPage
    {
        public Tappa_03()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(loadImage));
            thread.Start();
            iconMarker.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.Icon-Place_@3x.png");
            var tappa = App.Database.GetTappeSingleAsync(idTappa: 2).Result;
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
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[0].Testo));
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[1].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_01.JPG"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            //stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_02.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[4].Testo));
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[5].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_03.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            //stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_04.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_0.Children.Add(FormattaContenuto.Formatta(contenuti_0[8].Testo));
            stackContenuto_0.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_05.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            #endregion

            #region accordion_1
            var contenuti_1 = App.Database.GetContenutiAsync(idSezione: sezioni[1].Id).Result;
            Accordion_1.Title = sezioni[1].Titolo;
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[0].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_06.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[2].Testo));
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[3].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_07.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[5].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_08.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_1.Children.Add(FormattaContenuto.Formatta(contenuti_1[7].Testo));
            stackContenuto_1.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_09.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            #endregion

            #region accordion_2
            var contenuti_2 = App.Database.GetContenutiAsync(idSezione: sezioni[2].Id).Result;
            Accordion_2.Title = sezioni[2].Titolo;
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[0].Testo));
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[1].Testo));
            //Ci va rocchetta 10 -> è un video
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_02.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[3].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_11.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            //stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_12.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_2.Children.Add(FormattaContenuto.Formatta(contenuti_2[6].Testo));
            stackContenuto_2.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_13.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            #endregion

            #region accordion_3
            var contenuti_3 = App.Database.GetContenutiAsync(idSezione: sezioni[3].Id).Result;
            Accordion_3.Title = sezioni[3].Titolo;
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[0].Testo));
            //stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_14.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_15.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[3].Testo));
            stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_16.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 0) });
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[5].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[6].Testo));
            stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_17.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[8].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[9].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[10].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[11].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[12].Testo));
            stackContenuto_3.Children.Add(FormattaContenuto.Formatta(contenuti_3[13].Testo));
            stackContenuto_3.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_18.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            #endregion

            #region accordion_4
            var contenuti_4 = App.Database.GetContenutiAsync(idSezione: sezioni[4].Id).Result;
            Accordion_4.Title = sezioni[4].Titolo;
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[0].Testo));
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[1].Testo));
            stackContenuto_4.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_19.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[3].Testo));
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[4].Testo));
            stackContenuto_4.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_20.jpg"), Aspect = Aspect.AspectFill, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_4.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.Tappa_03.Rocchetta_21.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 5, 0, 5) });
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[7].Testo));
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[8].Testo));
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[9].Testo));
            stackContenuto_4.Children.Add(FormattaContenuto.Formatta(contenuti_4[10].Testo));
            ImageButton imgbtn = new ImageButton();
            imgbtn.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.cover.rocchetta2_cover.jpg");
            imgbtn.Aspect = Aspect.AspectFill;
            imgbtn.Margin = new Thickness(0, 5, 0, 5);
            imgbtn.Clicked += Imgbtn_Clicked;
            stackContenuto_4.Children.Add(imgbtn);
            #endregion
        }

        private void loadImage()
        {
            ImgTappa.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Tappe.cover.rocchetta_cover.jpg");
            close.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.close_5.png");
        }


        private async void Imgbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1CKaLQyFhWr5ABpk0MkpezqDyCA-mdkFA"));
        }

        private async void ImgTappa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1CKaLQyFhWr5ABpk0MkpezqDyCA-mdkFA"));
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