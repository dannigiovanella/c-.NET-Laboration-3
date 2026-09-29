
/*Klassfil som hanterar enskilda gästboksinlägg */

//Anger vilken namespace som klassen tillhör
namespace Lab_3_Guestbook
{

    //Skapar klassen GUestbookPost som beskriver varje enskilt inlägg
    //Public klass eftersom denna ska användas i andra delar av programmet
    public class GuestbookPost
    {
        //Skapar en publik textsträng med property (egenskap) om vem som skrivit inlägget
        //? innebär att värdet även får vara null
        //Author är namnet på personen som gjort inlägget
        public string? Author {
            //Get används för att kunna hämta namnet
            //Set gör så att ett namn kan läggas till
            get; set;
        }

        //Publik property som för texten som personen har skrivit
        //Även här kan värder vara null (?)
        public string? Text
        {
            //Get används för att hämta och läsa av texten
            //Set används för att kunna lägga in text
            get; set;
        }
    }

}