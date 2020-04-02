using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //proprietà per tener traccia della lingua attiva -> da sostituire con quella già implementata in app per poi conservare l'impostazione alla chiusura
        public static string ActiveLanguage = "IT";

        public HomePage()
        {
            InitializeComponent();
            btnOpen.Text = ActiveLanguage; //imposto la lingua attiva
            LanguageStack.TranslateTo(0, -200, 00); //traslo lo stack di selezione di -200 sull'asse y-> in realtà purtroppo non escono fuori dallo schermo ma si sovrappongono nell'angolino a destra. quindi se lo sfono non è trasparente si vedono..
        }

        private object syncLockPlayer = new object();
        bool isInCallPlayer = false;

        private async void btnRiproduci_Clicked(object sender, EventArgs e)
        {
            lock (syncLockPlayer)
            {
                if (isInCallPlayer)
                    return;
                isInCallPlayer = true;
            }

            try
            {
                //await Navigation.PushModalAsync(new PlayerPage("https://drive.google.com/uc?export=download&id=1-ybKXJo6ZUxK-OAVCftXiX0gq7IOpbQB"));
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
            Close();
        }

        private void btnENG_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "ENG";
            Close();
        }

        private void btnFR_Clicked(object sender, EventArgs e)
        {
            ActiveLanguage = "FR";
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