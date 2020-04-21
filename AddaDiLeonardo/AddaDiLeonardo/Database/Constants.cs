using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddaDiLeonardo.Database
{
    public static class Constants
    {
        //Nomi dei file datatabase per le diverse lingue
        public static readonly string[] DatabaseNames = { "Italiano.db", "Inglese.db", "Francese.db" };

        //Flag per definire le modalità di apertura del database
        public const SQLite.SQLiteOpenFlags Flags =
        // modalità lettura/scrittura
        SQLite.SQLiteOpenFlags.ReadWrite |
        // crea il database se non presente (non serve)
        //SQLite.SQLiteOpenFlags.Create |
        // accesso multi-thread al database (non servirebbe perchè usa singleton)
        SQLite.SQLiteOpenFlags.SharedCache;

        //Percorso completo del file database
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //cartella di sistema con permessi (vedi MainActivity.cs)
                return Path.Combine(basePath, DatabaseNames[0]); //combina il percorso della cartella con il database selezionato //DA SISTEMARE !!! -> cambio lingua
            }
        }
    }
}
