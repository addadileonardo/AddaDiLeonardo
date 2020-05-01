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

        public HomePage()
        {
            InitializeComponent();
            mappaIcon.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.arrow-white.png");
            if(Application.Current.Properties.ContainsKey("lang"))
                ActiveLanguage = Application.Current.Properties["lang"].ToString(); //viene impostata la lingua memorizzata se presente, altrimenti ita di default.
            btnOpen.Text = ActiveLanguage; //imposto la lingua attiva
            LanguageStack.TranslateTo(0, -200, 00); //traslo lo stack di selezione di -200 sull'asse y-> in realtà purtroppo non escono fuori dallo schermo ma si sovrappongono nell'angolino a destra. quindi se lo sfono non è trasparente si vedono..
            accordions = new List<Accordion>() { Accordion_0 };
            foreach (Accordion accordion in accordions)
                accordion.AccordionOpened += accordionEvent;

            Accordion_0.Indicator = new Image() { Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.arrow-white.png"), WidthRequest = 20 };
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
            Close();
        }

        private void btnENG_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "ENG";
            Application.Current.Properties["lang"] = "ENG";
            Close();
        }

        private void btnFR_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "FR";
            Application.Current.Properties["lang"] = "FR";
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