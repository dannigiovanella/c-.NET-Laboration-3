
/*Klassfil som hanterar gästboken och inläggen*/


//Gör så att List (lista) kan användas i programmet. 
using System.Collections.Generic;

//System.IO används för att kunna hantera filer
//ex. kontroll. läsa av och skriva information till fil
using System.IO;

//System.Text.Json används för att kunna omvandla C# objekt till Json och omvänt
using System.Text.Json;

//Anger vilken namespace som klassen tillhör
namespace Lab_3_Guestbook
{


    //Skapar klass för att hantera gästboken och alla inläggen
    //Public för att klassen ska kunna användas från andra delar i programmet.
    public class Guestbook
    {

        //Anger JSON filnamnet där gästboksinläggen ska sparas
        //Sparas i private variabel då bara ska användas inom denna klassen
        private string guestbookJson = @"guestbook.json";


        //Skapar en private list som bara ska kunnas användas inom klassen
        //List är en typ för att lagra flera objekt i en lista. (Gästboksinläggen)  
        //posts - Namnet pålistan
        //new list<GuestbookPost>() skapar en ny tom lista att placera inläggen i som skapats i klassen GuestbookPost.
        private List<GuestbookPost> posts = new List<GuestbookPost>();


        //KOnstruktor för klassen Guestbook som körst automatiskt när nytt Guestbook-objekt skapas
        //Public då denna används när objekt skapas i program-filen
        public Guestbook()
        {
            //Kontrollerar om filen finns, om sant läses fil av och omvandlas till C# objekt
            if (File.Exists(guestbookJson) == true)
            {

                //Läser av innehåller i json-fil och sparar som text i variaveln jsonToText
                string jsonToText = File.ReadAllText(guestbookJson);

                //Omvandlar json-texten till en lista i GUestbookPost-objektet
                //Listan som läses av från json-filen sparas i den befintliga varaibeln för Guesbook-lista, posts
                // ! används för att tala om att att lista ska returneras med deserialize, inte null
                posts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonToText)!;
            }
        }


        ////////// Lägga till inlägg /////////

        //Metod addpost används för att skapa och lägga till ett inlägg i listan
        //GuestbookPost är det objket som skapas
        //string author och string text betyder att etoden tar emot författarens namn och inläggstext.
        public GuestbookPost AddPost(string author, string text)
        {
            //Skapar nytt GuestbookPost-inlägg i listan
            GuestbookPost post = new GuestbookPost();

            //Sparar författarens namn i objketets author egenskap
            post.Author = author;

            //Sparar inläggstexten i objektets text egenskap
            post.Text = text;

            //Lägger till  nytt inlägg i listan
            posts.Add(post);

            //Sparar uppdaterad lista till jsson-filen
            SaveToJson();

            //Skickar tillbaka de nya guestbookPost objektet
            return post;
        }




        ///// Hämta inlägg ////////

        //Metod för att hämta alla inlägg som finns sparade i listan
        public List<GuestbookPost> GetPosts()
        {
            //Returnerar listan med alla gästboksinlägg
            return posts;

        }



        /////// Ta bort inlägg //////////


        //Metod för att ta bort ett inlägg från listan
        //int index är numret på det inlägget som ska tas bort
        public int DeletePost(int index)
        {
            //RemoveAt tar bort inlägget som finns på den plats i listan som angivits
            posts.RemoveAt(index);

            //Spara uppdaterad lista till Json-fil
            SaveToJson();

            //Returnerar indexnumret för inlägget som togs bort
            return index;
        }


        ////// SPARA TILL FIL /////

        //Metod för att spara alla gästboksinlägg till json-fil
        //private då denna metod bara används inom klassen
        //void- returnerar inget värde
        private void SaveToJson()
        {
            //Omvandlar listan (posts) med guestbookPost-objekt till json-text
            /*ex:
             "Author": "Daniela"
             "Text": "Hej!"
             */
            var jsonText = JsonSerializer.Serialize(posts);

            //Skriver json-texten till filen guestbook.json
            //File.WriteALLText skapar filen
            File.WriteAllText(guestbookJson, jsonText);
        }




    }

}