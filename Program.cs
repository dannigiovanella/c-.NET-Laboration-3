
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
                    //Användaren skrev "1" - Lägga till inlägg
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


                        //KONTROLL AV INPUT
                        //Kontrollerar så både namn och inläggstext innehåller något
                        if (!string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(text))
                        {
                            //Om båda fälten innehåller text läggs inlägget till
                            //Lägger till inlägget (objektet myGuestbook) i gästboken
                            //Anropar metoden AddPost från Guestbook-klassen som skickar med namn och text
                            myGuestbook.AddPost(author, text);
                        }
                        else
                        {
                            //Om något av fälten är tomt visas felmeddelande
                            Console.WriteLine("Fält för namn och inlägg får inte vara tomma");
                        }


                        break;

                    //Användaren skrev "2" - Ta bort inlägg
                    case "2": 

                        //Hämtar alla inlägg som finns sparade i Guestbook klassen med metoden GetPosts
                        //List<GuestbookPost> Listan med GuestbookPosts objekt
                        //Listan sparas i variabeln posts som används för att skriva ut listan
                        List<GuestbookPost> postsToDelete = myGuestbook.GetPosts();

                        //Ber användare skriva indexnummer på inlägget de vill ta bort
                        Console.Write("Skriv indexnummer på inlägget du vill ta bort:");

                        //Läser av användarens input för index och sparar det som text
                        string? index = Console.ReadLine();

                        //KONTROLL AV INPUT
                        //Kontrollerar så att användare skrivt heltal (ska inte gå att skriva bokstäver)
                        //TryParse används för att försöka omvandlar input från text till heltal
                        //Lyckas omvandligen resulterar detta i true och false vid misslyckad omvandling
                        //out in selectedIndex skapar variabel där heltalet sparas
                        //
                        if (int.TryParse(index, out int selectedIndex))
                        {

                            //Vid true lyckas omvandlingen:

                            //Kontrollerar att indexet finns blan inläggen
                            //Indexenummer måste vara 0 eller större
                            //Index måste vara mindre än antalet inlägg (count räknar inläggen)
                            if (selectedIndex >= 0 && selectedIndex < postsToDelete.Count)
                            {

                                //Anropar metoden DeletePosts från Guestbook-klassen
                                //Skickar med selectedIndex för att visa vilket inlägg som ska tas bort
                                //Tar bort inlägget 
                                myGuestbook.DeletePost(selectedIndex);
                            }
                            else
                            {
                                //Om indexet som användare anger inte finns visas felmeddelande.
                                Console.WriteLine("Det finns inget inlägg med det indexnumret");
                            }

                        }
                        else
                        {
                            //Vid false och misslyckad omvandling
                            //Felmeddelande om användare inte skrivit ett giltit heltal
                            Console.WriteLine("Du måste ange ett giltigt indexnummer");
                        }

                        break;
                    

                    //Användaren skrev "3" - Visa inlägg
                    case "3":
                        //Hämtar alla inlägg som finns sparade i Guestbook klassen med metoden GetPosts
                        //List<GuestbookPost> Listan med GuestbookPosts objekt
                        //Listan sparas i variabeln posts som används för att skriva ut listan
                        List<GuestbookPost> posts = myGuestbook.GetPosts();

                        //Loopar igenom inläggen i listan och skriver ut dessa
                        for (int i = 0; i < posts.Count; i++)
                        {
                            //Skriver ut inlägget index, författare och text
                            Console.WriteLine("[" + i + "] " + posts[i].Author + ": " + posts[i].Text);
                        }


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