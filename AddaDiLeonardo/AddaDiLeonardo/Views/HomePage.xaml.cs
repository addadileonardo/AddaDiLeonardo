using AddaDiLeonardo.CustomControls;
using AddaDiLeonardo.Views.Tappe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddaDiLeonardo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        //proprietà booleana per verificare se lo stack di selezione è aperto o chiuso
        public static bool isOpen = false;

        //proprietà per tener traccia della lingua attiva
        public static string ActiveLanguage = "IT";

        //immagini tappe e mappa
        Image imageT1 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageT2 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageT3 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageT4 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageT5 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };

        Image imageM1 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageM2 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageM3 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageM4 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageM5 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };

        public HomePage()
        {
            InitializeComponent();
            mappaIcon.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.arrow-white.png");
            if (Application.Current.Properties.ContainsKey("lang"))
                ActiveLanguage = Application.Current.Properties["lang"].ToString(); //viene impostata la lingua memorizzata se presente, altrimenti ita di default.
            btnOpen.Text = ActiveLanguage; //imposto la lingua attiva
            LanguageStack.TranslateTo(0, -200, 00); //traslo lo stack di selezione di -200 sull'asse y-> in realtà purtroppo non escono fuori dallo schermo ma si sovrappongono nell'angolino a destra. quindi se lo sfono non è trasparente si vedono..

            #region stackMappa
            var tapGestureRecognizer = new TapGestureRecognizer();

            switch (ActiveLanguage)
            {
                case "IT":
                    {
                        imagesIT();
                        break;
                    }
                case "ENG":
                    {
                        imagesEN();
                        break;
                    }
                case "FR":
                    {
                        imagesFR();
                        break;
                    }    
            }

            imageT1.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappe.Children.Add(imageT1);

            imageT2.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappe.Children.Add(imageT2);

            imageT3.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappe.Children.Add(imageT3);

            imageT4.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappe.Children.Add(imageT4);

            imageT5.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappe.Children.Add(imageT5);

            imageM1.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa.Children.Add(imageM1);

            imageM2.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa.Children.Add(imageM2);

            imageM3.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa.Children.Add(imageM3);
            
            imageM4.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa.Children.Add(imageM4);

            imageM5.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa.Children.Add(imageM5);


            //stackMappa.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-1.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0) });
            //stackMappa.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-2.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0) });
            //stackMappa.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-3.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0) });
            //stackMappa.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-4.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0) });
            //stackMappa.Children.Add(new Image { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-5.jpg"), Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0) });
            #endregion

            accordions = new List<Accordion>() { Accordion_0 };
            foreach (Accordion accordion in accordions)
                accordion.AccordionOpened += accordionEvent;

            Accordion_0.Indicator = new Image() { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.arrow-white.png"), WidthRequest = 20 };

            // Evento tap mappa
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                // Cast image and push async to step
                OnImageMapTapped(sender, e);

            };
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

        private void mappaIcon_Clicked(object sender, EventArgs e)
        {
            this.Scroll.ScrollToAsync(this.FindByName<Element>("Accordion_0"), ScrollToPosition.Start, true); //da modificare con mappa
        }

        private void imagesIT()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-1-Fiume.jpg");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-2-Ponte.jpg");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-3-Rocchetta.jpg");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-4-Traghetto.jpg");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-5-Centrali.jpg");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-1.jpg");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-2.jpg");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-3.jpg");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-4.jpg");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-5.jpg");

        }
        private void imagesEN()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-1-Fiume.jpg");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-2-Ponte.jpg");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-3-Rocchetta.jpg");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-4-Traghetto.jpg");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-5-Centrali.jpg");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-1.jpg");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-2.jpg");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-3.jpg");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-4.jpg");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-5.jpg");

        }
        private void imagesFR()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-1-Fiume.jpg");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-2-Ponte.jpg");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-3-Rocchetta.jpg");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-4-Traghetto.jpg");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-5-Centrali.jpg");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-1.jpg");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-2.jpg");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-3.jpg");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-4.jpg");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-5.jpg");

        }
        #region "MAP"
        private object syncLockMappa = new object();
        bool isInCallMappa = false;

        private async void OnImageMapTapped(object sender, EventArgs args)
        {

            lock (syncLockMappa)
            {
                if (isInCallMappa)
                    return;
                isInCallMappa = true;
            }

            try
            {

                switch (((Image)sender).ClassId)
                {

                    case "map1":
                        var TappaTraghetto = new Tappa_02();
                        await Navigation.PushModalAsync(TappaTraghetto);
                        break;
                    case "map2":
                        var TappaFiume = new Tappa_01();
                        await Navigation.PushModalAsync(TappaFiume);
                        break;
                    case "map3":
                        var TappaPonte = new Tappa_04();
                        await Navigation.PushModalAsync(TappaPonte);
                        break;
                    case "map4":
                        var TappaRocchetta = new Tappa_03();
                        await Navigation.PushModalAsync(TappaRocchetta);
                        break;
                    case "map5":
                        var TappaCentrali = new Tappa_05();
                        await Navigation.PushModalAsync(TappaCentrali);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lock (syncLockTappa)
                {
                    isInCallMappa = false;
                }
            }

        }
        #endregion

        #region "STEP"
        private object syncLockTappa = new object();
        bool isInCallTappa = false;

        private async void OnImageNameTapped(object sender, EventArgs args)
        {

            lock (syncLockTappa)
            {
                if (isInCallTappa)
                    return;
                isInCallTappa = true;
            }

            try
            {

                switch (((Image)sender).ClassId)
                {

                    case "step1":
                        var TappaFiume = new Tappa_01();
                        await Navigation.PushModalAsync(TappaFiume);
                        break;

                    case "step2":
                        var TappaPonte = new Tappa_04();
                        await Navigation.PushModalAsync(TappaPonte);
                        break;

                    case "step3":
                        var TappaRocchetta = new Tappa_03();
                        await Navigation.PushModalAsync(TappaRocchetta);
                        break;

                    case "step4":
                        var TappaTraghetto = new Tappa_02();
                        await Navigation.PushModalAsync(TappaTraghetto);
                        break;
                    case "step5":
                        var TappaCentrali = new Tappa_05();
                        await Navigation.PushModalAsync(TappaCentrali);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lock (syncLockTappa)
                {
                    isInCallTappa = false;
                }
            }

        }
        #endregion

        #region "VIDEOPLAYER"
        private object syncLockPlayer = new object();
        bool isInCallPlayer = false;

        private async void btnVideoPlayer_Clicked(object sender, EventArgs e)
        {
            lock (syncLockPlayer)
            {
                if (isInCallPlayer)
                    return;
                isInCallPlayer = true;
            }

            try
            {
                await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1-ybKXJo6ZUxK-OAVCftXiX0gq7IOpbQB"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lock (syncLockPlayer)
                {
                    isInCallPlayer = false;
                }
            }

        }
        #endregion

        #region "MAP"
        private object syncLockMap = new object();
        bool isInCallMap = false;

        private async void btnMap_Clicked(object sender, EventArgs e)
        {
            lock (syncLockMap)
            {
                if (isInCallMap)
                    return;
                isInCallPlayer = true;
            }

            try
            {
                await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1-ybKXJo6ZUxK-OAVCftXiX0gq7IOpbQB"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lock (syncLockMap)
                {
                    isInCallMap = false;
                }
            }

        }
        #endregion

        /// <summary>
        /// Apre o chiude lo stack di selezione
        /// </summary>
        private void btnOpen_Clicked(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private void btnIT_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "IT";
            Application.Current.Properties["lang"] = "IT";
            imagesIT();
            Close();
        }

        private void btnENG_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "ENG";
            Application.Current.Properties["lang"] = "ENG";
            imagesEN();
            Close();
        }

        private void btnFR_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "FR";
            Application.Current.Properties["lang"] = "FR";
            imagesFR();
            Close();
        }

        /// <summary>
        /// Apre il LanguageStack e imposta il colore grigio per la lingua attiva,
        /// </summary>
        public void Open()
        {
            btnIT.TextColor = Color.White; btnENG.TextColor = Color.White; btnFR.TextColor = Color.White;
            if (ActiveLanguage == "IT")
                btnIT.TextColor = Color.Gray;
            if (ActiveLanguage == "ENG")
                btnENG.TextColor = Color.Gray;
            if (ActiveLanguage == "FR")
                btnFR.TextColor = Color.Gray;
            LanguageStack.TranslateTo(0, 1, 150);
            isOpen = true;

        }

        /// <summary>
        /// Chiude il languagestack e imposta il database in base alla lingua
        /// </summary>
        public void Close()
        {
            LanguageStack.TranslateTo(0, -200, 150);
            isOpen = false;
            if (btnOpen.Text == ActiveLanguage)
                return;
            if (ActiveLanguage == "IT")
            {
                btnOpen.Text = ActiveLanguage;
                //Cambio database attuale -> italiano
                //funzione di riavvio app
            }
            if (ActiveLanguage == "ENG")
            {
                btnOpen.Text = ActiveLanguage;
                //Cambio database attuale -> inglese
                //funzione di riavvio app
            }
            if (ActiveLanguage == "FR")
            {
                btnOpen.Text = ActiveLanguage;
                //Cambio database attuale -> francese
                //funzione di riavvio app
            }
        }


    }
}