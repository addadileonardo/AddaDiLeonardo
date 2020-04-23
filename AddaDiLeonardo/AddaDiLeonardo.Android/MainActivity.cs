using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LibVLCSharp.Forms.Shared;
using Android.Content.Res;
using Android.Graphics;
using Java.IO;
using System.IO;

namespace AddaDiLeonardo.Droid
{
    [Activity(Label = "AddaDiLeonardo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            LibVLCSharpFormsRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //Caricamento dei database
            ExtractDBFromAssets(dbname: "Italiano.db");
            ExtractDBFromAssets(dbname: "Inglese.db");
            ExtractDBFromAssets(dbname: "Francese.db");

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
        //funzione per copiare i file dalla cartella Assets del progetto ad una altra con i privilegi di lettura/scrittura
        public void ExtractDBFromAssets(string dbname)
        {
            string destination = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //cartella di sistema con i permessi
            string filename = System.IO.Path.Combine(destination, dbname); //nuovo path+filename composto dalla cartella e il nome del file passato come argomento

            if (!System.IO.File.Exists(filename)) //controlla se il file esiste già
            {
                using (FileStream writeStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    Assets.Open(dbname).CopyTo(writeStream); //Metodi concatenati per aprire e copiare i file con AssetsManager di Android
                }
            }
        }
    }
}