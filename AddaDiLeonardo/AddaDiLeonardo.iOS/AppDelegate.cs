using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using LibVLCSharp.Forms.Shared;
using UIKit;

namespace AddaDiLeonardo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            LibVLCSharpFormsRenderer.Init();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            //Database
            ExtractBDFromResources("Italiano.db");
            ExtractBDFromResources("Inglese.db");
            ExtractBDFromResources("Francese.db");

            return base.FinishedLaunching(app, options);
        }

        public static void ExtractBDFromResources(string dbname)
        {
            string destination = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = System.IO.Path.Combine(destination, dbname);

            if (!File.Exists(filename))
            {
                //System.IO.File.Copy("Database/"+dbname, filename);
                System.IO.File.Copy(NSBundle.MainBundle.PathForResource(dbname, type), filename);
            }
        }
    }
}
