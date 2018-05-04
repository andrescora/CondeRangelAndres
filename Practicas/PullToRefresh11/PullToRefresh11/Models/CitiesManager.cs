using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PullToRefresh11
{
    public class CitiesManager 
    {
        #region Singleton
        //SingleTon clase que se instancia una sola vez en el proyecto.
        static readonly private Lazy<CitiesManager> lazy = new Lazy<CitiesManager>(() => new CitiesManager());
        public static CitiesManager SharedInstance { get => lazy.Value; }

        #endregion

        #region Class Variables

        HttpClient httpClient;
        Dictionary<string, List<string>> cities;

        #endregion

        #region Events

        public event EventHandler<CitiesEventArgs> CitiesFetched;
        public event EventHandler<EventArgs> FetchedCitiesFailed;

        #endregion

        #region Constructors
        //Contructor privado
        CitiesManager()
        {
            httpClient = new HttpClient();
        }

        #endregion

        #region Public functionality

        public Dictionary<string,List<string>> GetDefaultCities()
        {
            var citiesJson = File.ReadAllText("citites-incomplete.json");
            //Vamos a parsear el Json, usando Json.net
            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);
        }

        public void FetchCities()
        {
            //Se manda llamar en nuevo hilo
            Task.Factory.StartNew(FetchCitiesAsync);

            async Task FetchCitiesAsync()
            {
                try
                {
                    if (CitiesFetched == null)
                        return;

                    var citiesJson = await httpClient.GetStringAsync("https://dl.dropbox.com/s/0adq8yw6vd5r6bj/cities.json?dl=0");
                    cities = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);

                    // Avisar al controller que ya están disponibles los datos.
                    //1. A través de eventos(Events/Delegate):
                    //2. A través de notificaciones. 
                    //3. (Sólo cuando estás dentro de un view controller) A través de Unwind Segues.

                    var e = new CitiesEventArgs(cities);
                    CitiesFetched(this, e);

                }
                catch (Exception ex)
                {
                    // Avisar al controller que algo falló
                    //1. A través de eventos:
                    //2. A través de notificaciones. 
                    //3. (Sólo cuando estás dentro de un view controller) A través de Unwind Segues
                    if (FetchedCitiesFailed == null)
                        return;
                    FetchedCitiesFailed(this, new EventArgs());
                }
            }
        }

        #endregion
    }

    public class CitiesEventArgs : EventArgs{
        public Dictionary<string, List<string>> Cities { get; private set;  }

        public CitiesEventArgs(Dictionary<string, List<string>> cities)
        {
            Cities = cities;
        }
    }

}
