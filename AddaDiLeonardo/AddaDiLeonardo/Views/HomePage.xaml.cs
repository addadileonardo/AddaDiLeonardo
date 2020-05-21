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
using Xamarin.Essentials;

namespace AddaDiLeonardo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        //proprietà booleana per verificare se lo stack di selezione è aperto o chiuso
        public static bool isOpen = false;

        //proprietà per tener traccia della lingua attiva
        public static string ActiveLanguage = "IT";

        //contenuti database
        struct dataStruct
        {
            public Database.Data.Tappe tappa;
            public List<Database.Data.Sezioni> sezioni;
            public List<Database.Data.Contenuti> contenuti;
        }

        //immagini tappe e mappa
        Image imageT1 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "step1" };
        Image imageT2 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "step2" };
        Image imageT3 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "step3" };
        Image imageT4 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "step4" };
        Image imageT5 = new Image { Aspect = Aspect.AspectFit, Margin = new Thickness(0, 0, 0, 0), ClassId = "step5" };

        Image imageM1 = new Image { Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), ClassId = "map1" };
        Image imageM2 = new Image { Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), ClassId = "map2" };
        Image imageM3 = new Image { Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), ClassId = "map3" };
        Image imageM4 = new Image { Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), ClassId = "map4" };
        Image imageM5 = new Image { Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), ClassId = "map5" };

        public HomePage()
        {
            
            InitializeComponent();
            mappaIcon.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Icons.map_icon_2.png");
            if (Application.Current.Properties.ContainsKey("lang"))
                ActiveLanguage = Application.Current.Properties["lang"].ToString(); //viene impostata la lingua memorizzata se presente, altrimenti ita di default.
            if(ActiveLanguage == "ENG")
            {
                btnOpen.Text = "EN"; //imposto la lingua attiva
            }
            else
            {
                btnOpen.Text = ActiveLanguage; //imposto la lingua attiva
            }
            
            LanguageStack.TranslateTo(0, -200, 00); //traslo lo stack di selezione di -200 sull'asse y-> in realtà purtroppo non escono fuori dallo schermo ma si sovrappongono nell'angolino a destra. quindi se lo sfono non è trasparente si vedono..

            var display = DeviceDisplay.MainDisplayInfo;
            var widthScreenpixel = display.Width;
            var HeightScreenpixel = display.Height;
            var densityScreenPixel = display.Density;
            var widthScreenUnit = widthScreenpixel / densityScreenPixel;

            var heightRowUnitTappa = (884 * widthScreenUnit) / 1809;

            gridTappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitTappa });
            gridTappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitTappa });
            gridTappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitTappa });
            gridTappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitTappa });
            gridTappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitTappa });

            var heightRowUnitMappa1 = (384 * widthScreenUnit) / 1126;
            var heightRowUnitMappa2 = (363 * widthScreenUnit) / 1126;
            var heightRowUnitMappa3 = (378 * widthScreenUnit) / 1126;
            var heightRowUnitMappa4 = (383 * widthScreenUnit) / 1126;
            var heightRowUnitMappa5 = (365 * widthScreenUnit) / 1126;

            gridMappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitMappa1 });
            gridMappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitMappa2 });
            gridMappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitMappa3 });
            gridMappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitMappa4 });
            gridMappe.RowDefinitions.Add(new RowDefinition { Height = heightRowUnitMappa5 });

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
            stackTappa1.Children.Add(imageT1);

            imageT2.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappa2.Children.Add(imageT2);

            imageT3.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappa3.Children.Add(imageT3);

            imageT4.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappa4.Children.Add(imageT4);

            imageT5.GestureRecognizers.Add(tapGestureRecognizer);
            stackTappa5.Children.Add(imageT5);

            imageM1.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa1.Children.Add(imageM1);

            imageM2.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa2.Children.Add(imageM2);

            imageM3.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa3.Children.Add(imageM3);
            
            imageM4.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa4.Children.Add(imageM4);

            imageM5.GestureRecognizers.Add(tapGestureRecognizer);
            stackMappa5.Children.Add(imageM5);


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

            //evento tap mappa
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                //cast image and push async to step
                OnImageNameTapped(sender, e);

            };

            //testo iniziale
            dataStruct data = databaseChange();
            descrizione.FormattedText = FormattaContenuto.Formatta(data.contenuti[0].Testo).FormattedText;
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
            this.Scroll.ScrollToAsync(this.FindByName<Element>("gridMappe"), ScrollToPosition.Start, true); //da modificare con collegamento mappa
        }

        private dataStruct databaseChange()  
        {
            dataStruct data = new dataStruct();
            data.tappa = App.Database.GetTappeSingleAsync(idTappa: 0).Result;
            data.sezioni = App.Database.GetSezioniAsync(idTappa: data.tappa.Id).Result;
            data.contenuti = App.Database.GetContenutiAsync(idSezione: data.sezioni[0].Id).Result;
            return data;
        }

        private void imagesIT()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-1-Fiume.png");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-2-Ponte.png");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-3-Rocchetta.png");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-4-Traghetto.png");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.IT-5-Centrali.png");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-1.png");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-2.png");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-3.png");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-4.png");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.IT-Map-5.png");

        }
        private void imagesEN()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-1-Fiume.png");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-2-Ponte.png");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-3-Rocchetta.png");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-4-Traghetto.png");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.EN-5-Centrali.png");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-1.png");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-2.png");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-3.png");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-4.png");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.EN-Map-5.png");

        }
        private void imagesFR()
        {
            imageT1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-1-Fiume.png");
            imageT2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-2-Ponte.png");
            imageT3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-3-Rocchetta.png");
            imageT4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-4-Traghetto.png");
            imageT5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Tappe.FR-5-Centrali.png");
            imageM1.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-1.png");
            imageM2.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-2.png");
            imageM3.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-3.png");
            imageM4.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-4.png");
            imageM5.Source = ImageSource.FromResource("AddaDiLeonardo.Images.Home.Mappa.FR-Map-5.png");
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
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_01());
                        break;
                    case "step2":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_04());
                        break;
                    case "step3":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_03());
                        break;
                    case "step4":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_02());
                        break;
                    case "step5":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_05());
                        break;
                    case "map1":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_02());
                        break;
                    case "map2":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_01());
                        break;
                    case "map3":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_04());
                        break;
                    case "map4":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_03());
                        break;
                    case "map5":
                        await Navigation.PushModalAsync(new Views.Tappe.Tappa_05());
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
                await Navigation.PushModalAsync(new PlayerPage("https://fondazionepolitecnico.box.com/shared/static/8sb7zumfmudhi12hjga9q5uuphyf7r05.mp4"));
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
            dataStruct data = databaseChange();
            descrizione.FormattedText = FormattaContenuto.Formatta(data.contenuti[0].Testo).FormattedText;
            imagesIT();
            Close();
        }

        private void btnENG_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "ENG";
            Application.Current.Properties["lang"] = "ENG";
            dataStruct data = databaseChange();
            descrizione.FormattedText = FormattaContenuto.Formatta(data.contenuti[0].Testo).FormattedText;
            imagesEN();
            Close();
        }

        private void btnFR_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "FR";
            Application.Current.Properties["lang"] = "FR";
            dataStruct data = databaseChange();
            descrizione.FormattedText = FormattaContenuto.Formatta(data.contenuti[0].Testo).FormattedText;
            imagesFR();
            Close();
        }

        /// <summary>
        /// Apre il LanguageStack e imposta il colore grigio per la lingua attiva,
        /// </summary>
        public void Open()
        {
            btnENG.BackgroundColor = Color.FromHex("#33000000");
            btnIT.BackgroundColor = Color.FromHex("#33000000");
            btnFR.BackgroundColor = Color.FromHex("#33000000");
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
            btnENG.BackgroundColor = Color.Transparent;
            btnIT.BackgroundColor = Color.Transparent;
            btnFR.BackgroundColor = Color.Transparent;
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
                btnOpen.Text = "EN";
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

        private void btnReadMore_Clicked(object sender, EventArgs e)
        {
            if(lblReasonWhy.MaxLines == 6)
            {
                lblReasonWhy.MaxLines = 99;
                btnReadMore.Text = "- Hide";
            }
            else
            {
                lblReasonWhy.MaxLines = 6;
                btnReadMore.Text = "+ Read More";
                this.Scroll.ScrollToAsync(this.FindByName<Element>("Accordion_0"), ScrollToPosition.Start, true);
            }
        }
    }
}