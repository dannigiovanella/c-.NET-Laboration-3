
/*Laboration 3

Laboration syftar till att skapa en enkel gästbok där användaren kan lägga till,
ta bort och visa gästboksinkägg.
Inläggen ska sparas i en JSON-fil så att dessa finns kvar när programmet avslutats.

Kod av: Daniela Giovanella
*/

/*Programfil som hanterar meny och användares input*/



//Anger vilken namespace som programfilen tillhör
namespace Lab_3_Guestbook
{


    //Skapar klassen Program som innehåller programmets huvuddel
    class Program
    {
        //static void main är programmets startmetod. 
        //Programmet börjar köras här när det startas
        //Void innebär att metoden inte returnerar något värde
        //string och args används för att kunna ta emot argument när programmet startas
        static void Main(string[] args)
        {


            //Skapar Guestbook-objekt
            //Gusetbook är klassen och myGuestbook är namnet på objektet.
            //new Guestbook() skapar objektet från klassen Guestbook
            Guestbook myGuestbook = new Guestbook();

            while (true)
            {

                //Rensar console innan manyn visas igen
                Console.Clear();

                //MENY
                //Skriver ut menyn till användare
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Visa alla inlägg");
                Console.WriteLine("X. Avsluta");



                //Frågar användaren vilket alternativ den vill välja
                Console.Write("Välj ett alternativ:");


                //Läser in input från användaren och spara i variabeln menyChoice
                //?string betydet att värdet är text men får också vara null
                string? menyChoice = Console.ReadLine();


                //KOntrollerar vilket alternativ användaren angett
                switch (menyChoice)
                {
                    //Användaren skrev "1" - Lägga till inlägg
                    case "1":
                        //Ber användare skriva in sitt namn
                        Console.Write("Ange ditt namn:");

                        //Vaiabeln author och text används för att spara namn som användare skriver in
                        //Läser in namnet som användare skrev och sparar det i variabeln author 
                        //?string används för att namnet skrivs i text men får också vara null
                        string? author = Console.ReadLine();

                        //Ber användare skriva inlägg
                        Console.Write("Skriv inlägg:");

                        //Vaiabeln text och text används för att spara text som användare skriver in
                        //Läser in text som användare skrev och sparar det i variabeln text 
                        //?string används för att inlägg skrivs i text men får också vara null
                        string? text = Console.ReadLine();


                        //KONTROLL AV INPUT
                        //Kontrollerar så både namn och inläggstext innehåller något
                        if (!string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(text))
                        {
                            //Om båda fälten innehåller text läggs inlägget till
                            //Anropar metoden AddPost från Guestbook-klassen
                            //skickar med namn och text till metoden
                            myGuestbook.AddPost(author, text);
                        }
                        else
                        {
                            //Om något av fälten är tomt visas felmeddelande
                            Console.WriteLine("Fält för namn och inlägg får inte vara tomma");
                        }

                        //Väntar på att användaren trycker på en tangent innan menyn visas igen
                        //Detta för att unvika att while loop börrjar om innan användare hinner se resultat
                        //Läser av knapptryck
                        Console.WriteLine("Tryck på en tangent för att fortsätta.");
                        Console.ReadKey();

                        break;

                    //Användaren skrev "2" - Ta bort inlägg
                    case "2":

                        //Hämtar alla inlägg som finns sparade i Guestbook klassen med metoden GetPosts
                        //List<GuestbookPost> Listan med GuestbookPosts objekt
                        //Listan sparas i variabeln postToDelete så att valt index kan kontrolleras
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

                            //Kontrollerar att indexet finns bland inläggen
                            //Indexenummer måste vara 0 eller större
                            //Index måste vara mindre än antalet inlägg (count räknar inläggen)
                            if (selectedIndex >= 0 && selectedIndex < postsToDelete.Count)
                            {

                                //Anropar metoden DeletePost från Guestbook-klassen
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
                            //Om TryParse returnerar false och misslyckad omvandling:
                            //Felmeddelande om användare inte skrivit ett giltit heltal
                            Console.WriteLine("Du måste ange ett giltigt indexnummer");
                        }

                        //Väntar på att användaren trycker på en tangent innan menyn visas igen
                        //Läser av knapptryck
                        Console.WriteLine("Tryck på en tangent för att fortsätta.");
                        Console.ReadKey();

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


                        //Väntar på att användaren trycker på en tangent innan menyn visas igen
                        //Detta för att unvika att while loop börrjar om innan användare hinner se resultat
                        //Läser av knapptryck
                        Console.WriteLine("Tryck på en tangent för att fortsätta.");
                        Console.ReadKey();

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