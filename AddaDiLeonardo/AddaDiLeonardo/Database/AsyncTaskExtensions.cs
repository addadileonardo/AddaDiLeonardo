using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddaDiLeonardo.Database
{
    //Metodo di estensione per eseguire in modo asincrono in contesti dove non è possibile
    public static class AsyncTaskExtensions
    {
        public static async void SafeFireAndForget(this Task task,
        bool returnToCallingContext,
        Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
