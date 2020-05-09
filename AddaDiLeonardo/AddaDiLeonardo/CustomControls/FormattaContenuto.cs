using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AddaDiLeonardo.CustomControls
{
    public static class FormattaContenuto
    {
        public static CustomLabel Formatta(string contenuto)
        {
            CustomLabel label = new CustomLabel();//Label ritornata
            FormattedString formatted = new FormattedString();//Contenuto label formattato

            label.Text = contenuto;//Imposta già il contenuto inizialmente

            if (contenuto.Contains("**"))//Controlla se sono presenti cratteri da rendere grassetto
            {
                label.Text = ""; //Svuota il testo

                string[] splits = contenuto.Split('*');//Divide in parti dove è presente la parola (**Grassetto**)
                int x = 0;
                while (x < splits.Length)//Ciclo per ogni parte
                {
                    Span span = new Span()//Sezione di testo formattata normalmente (Light)
                    {
                        Text = splits[x],
                        FontFamily = Device.RuntimePlatform == Device.iOS ? "Roboto-Light" : Device.RuntimePlatform == Device.Android ? "Roboto-Light.ttf#Roboto" : "Assets/Roboto-Light.ttf#Roboto",
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    };
                    if (x == 0 || x == splits.Length - 1)//Se si tratta della prima parte o dell'ulta li aggiunge (Non possono mai essere parti da formattare)
                    {
                        formatted.Spans.Add(span);//Aggiunge alla stringa finale formattata
                        x++;
                        continue;//ignora il resto del ciclo
                    }

                    if (splits[x - 1] == "" && splits[x + 1] == "")//Controlla se è da formattare (Bold) (stringa divisa -> *x-1* x *x+1*)
                    {
                        span.FontAttributes = FontAttributes.Bold;
                        span.FontFamily = Device.RuntimePlatform == Device.iOS ? "Roboto-Bold" : Device.RuntimePlatform == Device.Android ? "Roboto-Medium.ttf#Roboto" : "Assets/Roboto-Medium.ttf#Roboto";
                        //span.ForegroundColor = Color.Black;

                        //Metodi di estensione per gli aaray che permette di rimuovere elementi modificando la lunghezza dell'array stesso
                        //Rimuovono gli spazi vuooti di *x-1* grassetto x *x+1*
                        splits = splits.RemoveAt(x - 1);
                        x--;
                        splits = splits.RemoveAt(x + 1);
                    }
                    formatted.Spans.Add(span); //Aggiunge alla stringa finale formattata
                    x++;
                }
                label.FormattedText = formatted;//Assegna la stringa formattata alla label
                //formatted.Spans.Clear();//Pulisce la stringa formattata
            }
            if (contenuto.Contains("__"))//Controlla se sono presenti caratteri da rendere italico
            {
                label.Text = ""; //Svuota il testo

                string[] splits = contenuto.Split('_');//Divide in parti dove è presente la parola (__Italico__)
                int x = 0;

                while (x < splits.Length)
                {
                    Span span = new Span()//Sezione di testo formattata normalmente (Light)
                    {
                        Text = splits[x],
                        FontFamily = Device.RuntimePlatform == Device.iOS ? "Roboto-Light" : Device.RuntimePlatform == Device.Android ? "Roboto-Light.ttf#Roboto" : "Assets/Roboto-Light.ttf#Roboto",
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    };
                    if (x == 0 || x == splits.Length - 1)//Se si tratta della prima parte o dell'ulta li aggiunge (Non possono mai essere parti da formattare)
                    {
                        formatted.Spans.Add(span);//Aggiunge alla stringa finale formattata
                        x++;
                        continue;//ignora il resto del ciclo
                    }
                    if (splits[x - 1] == "" && splits[x + 1] == "")//Controlla se è da formattare (Bold) (stringa divisa -> *x-1* x *x+1*)
                    {
                        span.FontAttributes = FontAttributes.Bold;
                        span.FontFamily = Device.RuntimePlatform == Device.iOS ? "Roboto-LightItalic" : Device.RuntimePlatform == Device.Android ? "Roboto-LightItalic.ttf#Roboto" : "Assets/Roboto-LightItalic.ttf#Roboto";
                        //span.ForegroundColor = Color.Black;

                        //Metodi di estensione per gli aaray che permette di rimuovere elementi modificando la lunghezza dell'array stesso
                        //Rimuovono gli spazi vuooti di *x-1* grassetto x *x+1*
                        splits = splits.RemoveAt(x - 1);
                        x--;
                        splits = splits.RemoveAt(x + 1);
                    }
                    formatted.Spans.Add(span); //Aggiunge alla stringa finale formattata
                    x++;
                }
                label.FormattedText = formatted;//Assegna la stringa formattata alla label
                //formatted.Spans.Clear();//Pulisce la stringa formattata
            }

            return label;
        }
    }
}
