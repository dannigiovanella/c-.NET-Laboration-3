
/*Klassfil som hanterar gästboken och inläggen*/


//Gör så att List (lista) kan användas i programmet. 
using System.Collections.Generic;

//Anger vilken namespace som klassen tillhör
namespace Lab_3_Guestbook
{


    //Skapar klass för att hantera gästboken och alla inläggen
    //Public för att klassen ska kunna användas från andra delar i programmet.
    public class Guestbook
    {
        //Skapar en private list som bara ska kunnas användas inom klassen
        //List är en typ för att lagra flera objekt i en lista. (Gästboksinläggen)  
        //posts - Namnet pålistan
        //new list<GuestbookPost>() skapar en ny tom lista att placera inläggen i som skapats i klassen GuestbookPost.
        private List<GuestbookPost> posts = new List<GuestbookPost>();


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


        //Method för att ta bort ett inlägg från listan
        //int index är numret på det inlägget som ska tas bort
        public int DeletePost(int index)
        {
            //RemoveAt tar bort inlägget som finns på den plats i listan som angivits
            posts.RemoveAt(index);

            //Returnerar indexnumret för inlägget som togs bort
            return index;
        }


    }

}