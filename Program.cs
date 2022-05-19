using System;
/*
Si vuole progettare un sistema per la gestione di una biblioteca.
Gli utenti registrati al sistema, fornendo 
- cognome, 
- nome, 
- email, 
- password, 
- recapito telefonico,
Possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD).
I documenti sono caratterizzati da 
- un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD), 
- titolo, 
- anno, 
- settore (storia, matematica, economia, …),
- stato (In Prestito, Disponibile), 
- uno scaffale in cui è posizionato, 
- un elenco di autori (Nome, Cognome).
Per i libri si ha in aggiunta
- il numero di pagine,
mentre per i dvd 
- la durata.
L’utente deve poter eseguire delle ricerche per 
- codice o per 
- titolo
e, eventualmente, effettuare dei prestiti registrando 
- il periodo (Dal/Al) del prestito 
- il documento.
Il sistema per ogni prestito determina
- un numero progressivo di tipo alfanumerico.
Deve essere possibile effettuare la ricerca dei prestiti dato 
- nome e cognome di un utente.
 */

//Da completare nell'esercizio
//NB: la chiave di un dizionario non deve necessarimente essere una stringa. ome abbiamo visto nelle procedure di ordinamento,
//questa può essere anche una tupl
//Esempio:  var dict = new Dictionary<Tuple<int, double, string>, string>();


namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca b = new Biblioteca("Civica");

            Scaffale s1 = new Scaffale("S001");
            Scaffale s2 = new Scaffale("S002");
            Scaffale s3 = new Scaffale("S003");

            #region "Libro 1"
            Libro l1 = new Libro("ISBN1", "Titolo 1", 2009, "Storia", 220);
            Autore a1 = new Autore("Nome 1", "Cognome 1");
            Autore a2 = new Autore("Nome 2", "Cognome 2");
            l1.Autori.Add(a1);
            l1.Autori.Add(a2);
            l1.Scaffale = s1;

            b.Documenti.Add(l1);
            #endregion

            #region "Libro 2"
            Libro l2 = new Libro("ISBN2", "Titolo 2", 2009, "Storia", 130);
            Autore a3 = new Autore("Nome 3", "Cognome 3");
            Autore a4 = new Autore("Nome 4", "Cognome 4");
            l2.Autori.Add(a3);
            l2.Autori.Add(a4);
            l2.Scaffale = s2;

            b.Documenti.Add(l2);
            #endregion

            #region "DVD"
            DVD dvd1 = new DVD("Codice1", "Titolo 3", 2019, "Storia", 130);
            dvd1.Autori.Add(a3);
            dvd1.Scaffale = s3;

            b.Documenti.Add(dvd1);
            #endregion

            Utente u1 = new Utente("Nome 1", "Cognome 1", "Telefono 1", "Email 1", "Password 1");

            b.Utenti.Add(u1);

            Prestito p1 = new Prestito("P00001", new DateTime(2019, 1, 20), new DateTime(2019, 2, 20), u1, l1);
            Prestito p2 = new Prestito("P00002", new DateTime(2019, 3, 20), new DateTime(2019, 4, 20), u1, l2);

            b.Prestiti.Add(p1);
            b.Prestiti.Add(p2);

            Console.WriteLine("\n\nSearchByCodice: ISBN1\n\n");

            List<Documento> results = b.SearchByCodice("ISBN1");

            foreach (Documento doc in results)
            {
                Console.WriteLine(doc.ToString());

                if (doc.Autori.Count > 0)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Autori");
                    Console.WriteLine("--------------------------");
                    foreach (Autore a in doc.Autori)
                    {
                        Console.WriteLine(a.ToString());
                        Console.WriteLine("--------------------------");
                    }
                }
            }

            Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");

            List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");

            foreach (Prestito p in prestiti)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }

        }


        enum Stato { Disponibile, Prestito }

        
    }
}

