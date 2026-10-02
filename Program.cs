
/*SKRIV AV OCH OM HÄR!!!!!!!*/

/*Programfil som hanterar meny och användares input*/



//Anger vilken namespace som programfilen tillhör
namespace Lab_3_Guestbook
{


    //Skapar klassen Program som är programmets huvuddel
    class Program
    {
        /*static void main - startmetod. Används föra att programmet ska med Main som metod ska kunna
        köras utan att först skapat ett program-objekt. Void innebär att detoden inte returnerar någo värde */
        //string och args används för att kunna ta emot argument när programmet startas
        static void Main(string[] args)
        {


            //Skapar Guestbook-objekt
            //Gusetbook är klassen medan myGuestbook är namnet på objektet.
            //new Guestbook() skapar objektet
            Guestbook myGuestbook = new Guestbook();

            while (true)
            {
                //MENY
                //Skriver ut menyn till användare
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Visa alla inlägg");
                Console.WriteLine("X. Avsluta");



                //Frågar användaren vilket alternativ den vill välja
                Console.Write("Välj ett alternativ:");


                //Läser in input från användaren och spara i variabeln menyChoice
                //?string används för att inlägget skrivs i text men får också vara null
                string? menyChoice = Console.ReadLine();


                //KOntrollerar vad användaren angett och skriver ut text baserat på valet
                switch (menyChoice)
                {
                    //Användaren skrev "1"
                    case "1":
                        //Ber användare skriva in sitt namn
                        Console.Write("Ange ditt namn:");

                        //Vaiablerna author och text motsvarar properties i klassen guestbookPost

                        //Läser in namnet som användare skrev och sparar det i variabeln author 
                        //?string används för att namnet skrivs i text men får också vara null
                        string? author = Console.ReadLine();

                        //Ber användare skriva inlägg
                        Console.Write("Skriv inlägg:");

                        //Läser in text som användare skrev och sparar det i variabeln text 
                        //?string används för att inlägg skrivs i text men får också vara null
                        string? text = Console.ReadLine();

                        //Lägger till inlägget (objektet myGuestbook) i gästboken
                        //Anropar metoden AddPost från Guestbook-klassen som skickar med namn och text
                        myGuestbook.AddPost(author, text);

                        break;

                    //Användaren skrev "2"
                    case "2":
                        Console.WriteLine("Du valde att ta bort ett inlägg");
                        break;

                    //Användaren skrev "3"
                    case "3":
                        Console.WriteLine("Du valde att visa alla inlägg");
                        break;

                    //Användaren skrev "X"
                    //return avslutar mainmetoden och stänger programmet
                    case "X":
                        Console.WriteLine("Stänger programmet");
                        return;
                }

            }

        }

    }


}