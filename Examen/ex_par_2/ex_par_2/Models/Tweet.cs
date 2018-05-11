using System;
using System.Collections.Generic;

namespace ex_par_2.Models
{
    public class Tweet
    {
        string nombreUsr;
        string usr;
        string foto;
        string mensaje;
        int retweetsMsj;
        int favoritosMsj;


        public Tweet()
        {
            
        }

        public Tweet(string pNombre, string pUsr, string pFoto, string pMensaje, int pRetweet, int pFavoritos)
        {
            NombreUsr = pNombre;
            Usr = pUsr;
            Foto = pFoto;
            Mensaje = pMensaje;
            RetweetsMsj = pRetweet;
            FavoritosMsj = pFavoritos; 
        }

        public string NombreUsr { get => nombreUsr; set => nombreUsr = value; }
        public string Usr { get => usr; set => usr = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public int RetweetsMsj { get => retweetsMsj; set => retweetsMsj = value; }
        public int FavoritosMsj { get => favoritosMsj; set => favoritosMsj = value; }
    }
}
