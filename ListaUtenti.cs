using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class ListaUtenti
    {
        private Dictionary<Tuple<string, string, string>, Utente> MyDictionary;

        public ListaUtenti()
        {
            MyDictionary = new Dictionary<Tuple<string, string, string>, Utente>();
        }


        //Tutti i metodi per inserire, cercare e fare tutto nel dizionario
        public void AggiungiUtente(Utente uUtente)
        {
            var chiave = new Tuple<string, string, string>(uUtente.Nome, uUtente.Cognome, uUtente.Email);
            MyDictionary.Add(chiave, uUtente);
            //string sChiaveUtente = 
            //    uUtente.Nome.ToLower() + ";" + 
            //    uUtente.Cognome.ToLower() + ";" + 
            //    uUtente.Email.ToLower();
            //MyDictionary.Add(sChiaveUtente, uUtente);
        }
    }
}
