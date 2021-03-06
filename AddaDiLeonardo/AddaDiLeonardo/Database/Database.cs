﻿using AddaDiLeonardo.Database.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddaDiLeonardo.Database
{
    public class Database
    {
        //Inizializzazione ritardata 
        //Viene richiamato quando l'istanza viene inizializzata e assegna il valore a DatabaseConnection
        private readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //Connessione
        public SQLiteAsyncConnection DatabaseConnection => lazyInitializer.Value;
        static bool initialized = false;

        async Task Initialize()
        {
            //Controlla se l'istanza non è inizializzata
            if (!initialized)
            {
                //Controlla se sono presenti le tabelle e ne controlla la mappatura delle classi
                if (!DatabaseConnection.TableMappings.Any(m => m.MappedType.Name == typeof(Tappe).Name) ||
                    !DatabaseConnection.TableMappings.Any(m => m.MappedType.Name == typeof(Sezioni).Name) ||
                    !DatabaseConnection.TableMappings.Any(m => m.MappedType.Name == typeof(Contenuti).Name))
                {

                    //Originariamente creava le tabelle se non erano presenti

                    //await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItem)).ConfigureAwait(false);
                    //initialized = true;
                    //throw new Exception("Non tutte le tabelle sono implementate correttamente");
                }

                initialized = true;
            }
        }

        public Database()
        {
            Initialize().SafeFireAndForget(false);//Metodo di estensione per eseguire funzioni asincrone all'interno dei costruttori di classe
            //DatabaseConnection = lazyInitializer.Value;
        }

        //===== Metodi =====

        #region Tappe

        //Metodo che ritorna la lista completa delle tappe
        public Task<List<Tappe>> GetTappeAsync()
        {
            return DatabaseConnection.Table<Tappe>().ToListAsync();
        }

        //Metodo che ritorna la tappa in base all'id
        public Task<Tappe> GetTappeSingleAsync(int idTappa)
        {
            return DatabaseConnection.FindWithQueryAsync<Tappe>("SELECT [Id], [Titolo], [Sottotitolo], [Descrizione] FROM [Tappe] WHERE [Id] = ?", idTappa);
        }

        #endregion

        #region Sezioni

        //Metodo che ritorna la lista completa delle sezioni
        public Task<List<Sezioni>> GetSezioniAsync()
        {
            return DatabaseConnection.Table<Sezioni>().ToListAsync();
        }

        //Metodo che ritorna la lista di sezioni appartenenti alla tappa con id uguale a idTappa
        public Task<List<Sezioni>> GetSezioniAsync(int idTappa)
        {
            return DatabaseConnection.QueryAsync<Sezioni>("SELECT [Id], [Titolo], [Tappa] FROM [Sezioni] WHERE [Tappa] = ?", idTappa);
        }

        //Metodo che ritorna la sezione in base al suo id
        public Task<Sezioni> GetSezioniSingleAsync(int idSezioni)
        {
            return DatabaseConnection.FindWithQueryAsync<Sezioni>("SELECT [Id], [Titolo], [Tappa] FROM [Sezioni] WHERE [Id] = ?", idSezioni);
        }

        #endregion

        #region Contenuti

        //Metodo che ritorna la lista completa di contenuti
        public Task<List<Contenuti>> GetContenutiAsync()
        {
            return DatabaseConnection.Table<Contenuti>().ToListAsync();
        }

        //Metodo che ritorna la lista di contenuti appartenenti alla sezione con id uguale a idSezione
        public Task<List<Contenuti>> GetContenutiAsync(int idSezione)
        {
            return DatabaseConnection.QueryAsync<Contenuti>("SELECT [Sezione], [Indice], [Testo] FROM [Contenuti] WHERE [Sezione] = ?", idSezione);
        }

        //Metodo che ritorna il contenuto inbase alla sezione e l'indice forniti
        public Task<Contenuti> GetContenutiSingleAsync(int idSezione, int idIndice)
        {
            return DatabaseConnection.FindWithQueryAsync<Contenuti>("SELECT [Sezione], [Indice], [Testo] FROM [Contenuti] WHERE [Sezione] = ? AND [Indice] = ?", idSezione, idIndice);
        }

        #endregion

        #region Errori

        public Task<List<Errori>> GetErroriAsync()
        {
            return DatabaseConnection.Table<Errori>().ToListAsync();
        }

        public Task<Errori> GetErroriAsync(int idErrore)
        {
            return DatabaseConnection.FindWithQueryAsync<Errori>("SELECT [Id], [Titolo], [Messaggio] FROM [Errori] WHERE [Id] = ?", idErrore);
        }

        #endregion
    }
}
