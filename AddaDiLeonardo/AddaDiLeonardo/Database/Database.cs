using AddaDiLeonardo.Database.Data;
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
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //Connessione
        static SQLiteAsyncConnection DatabaseConnection => lazyInitializer.Value;
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
                    //await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItem)).ConfigureAwait(false);
                    //initialized = true;
                    //throw new Exception("Non tutte le tabelle sono implementate correttamente");
                }

                initialized = true;
            }
        }

        public Database()
        {
            Initialize().SafeFireAndForget(false);
        }

        //===== Metodi =====

        //Tappe
        public Task<List<Tappe>> GetTappeAsync()
        {
            return DatabaseConnection.Table<Tappe>().ToListAsync();
        }

        public Task<Tappe> GetTappeSingleAsync(int idTappa)
        {
            return DatabaseConnection.FindWithQueryAsync<Tappe>("SELECT [Id], [Titolo], [Sottotitolo], [Descrizione] FROM [Tappe] WHERE [Id] = ?", idTappa);
        }

        //sezioni
        public Task<List<Sezioni>> GetSezioniAsync()
        {
            return DatabaseConnection.Table<Sezioni>().ToListAsync();
        }

        public Task<List<Sezioni>> GetSezioniAsync(int idTappa)
        {
            return DatabaseConnection.QueryAsync<Sezioni>("SELECT [Id], [Titolo], [Tappa] FROM [Sezioni] WHERE [Tappa] = ?", idTappa);
        }

        public Task<Sezioni> GetSezioniSingleAsync(int idSezioni)
        {
            return DatabaseConnection.FindWithQueryAsync<Sezioni>("SELECT [Id], [Titolo], [Tappa] FROM [Sezioni] WHERE [Id] = ?", idSezioni);
        }

        //contenuti
        public Task<List<Contenuti>> GetContenutiAsync()
        {
            return DatabaseConnection.Table<Contenuti>().ToListAsync();
        }

        public Task<List<Contenuti>> GetContenutiAsync(int idSezione)
        {
            return DatabaseConnection.QueryAsync<Contenuti>("SELECT [Sezione], [Indice], [Testo] FROM [Contenuti] WHERE [Sezione] = ?", idSezione);
        }

        public Task<Contenuti> GetContenutiSingleAsync(int idSezione, int idIndice)
        {
            return DatabaseConnection.FindWithQueryAsync<Contenuti>("SELECT [Sezione], [Indice], [Testo] FROM [Contenuti] WHERE [Sezione] = ? AND [Indice] = ?", idSezione, idIndice);
        }
    }
}
