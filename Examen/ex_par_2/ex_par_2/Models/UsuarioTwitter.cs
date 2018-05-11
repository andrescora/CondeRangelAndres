using System;
using System.Collections.Generic;

namespace ex_par_2.Models
{
    public class UsuarioTwitter
    {
        string nombre;
        string foto;
        int retweets;
        int favoritos;
        List<Tweet> tweets;

        public UsuarioTwitter()
        {
            
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Foto { get => foto; set => foto = value; }
        public int Retweets { get => retweets; set => retweets = value; }
        public int Favoritos { get => favoritos; set => favoritos = value; }
        public List<Tweet> Tweets { get => tweets; set => tweets = value; }
    }
}
