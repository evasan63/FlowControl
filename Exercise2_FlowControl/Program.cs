
namespace Exercise2_FlowControl
{
    //------------------------------------------------------------------
    // This program gives the user a menu to choose different options from, such as
    //  - Calculating the price for one or several movie tickets,
    //  - Repeating a given text 10 times,
    //  - Printing the third word in a text.
    //------------------------------------------------------------------
    class Program
    {
        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("* Väkommen till huvudmenyn, välj ett alternativ för att testa olika funktioner: *");
                Console.WriteLine("1. För att se priset för en bio biljett eller totalapriset för bio biljetter till ett sällskap");
                Console.WriteLine("2. Upprepa en given text 10 gånger");
                Console.WriteLine("3. Skriv ut det tredje ordet i en mening");
                Console.WriteLine("0. För att avsluta");
                Console.Write("Välj alternativ: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("1. För att se priset för en bio biljett");
                        Console.WriteLine("2. För att se totalapriset för bio biljetter till ett sällskap");
                        Console.Write("Välj alternativ: ");

                        switch (Console.ReadLine()?.Trim())
                        {
                            case "1":
                                // Call the method to calculate the price for one movie ticket
                                PriceForOneMovieTicket();
                                break;
                            case "2":
                                // Call the method to calculate the total price for movie tickets for a group
                                PriceForMovieTickets();
                                break;
                            default:
                                Console.WriteLine("Ogiltigt val, försök igen.");
                                break;
                        }
                        break;
                    case "2":
                        // Call the method to repeat a text 10 times in a single row
                        Repeat10Times();
                        break;
                    case "3":
                        // Call the method to print the third word of a text
                        Print3rdWord();
                        break;
                    case "0":
                        // Exit the program
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }

        //------------------------------------------------------------------------
        // This method asks for the age and prints the ticketprice for one person
        //------------------------------------------------------------------------
        static void PriceForOneMovieTicket()
        {
            //Console.WriteLine();
            Console.Write("För att se ditt pris, ange din ålder: ");
            string input = Console.ReadLine().Trim();

            int age;
            if (int.TryParse(input, out age))
            {
                if (age < 5)
                {
                    Console.WriteLine("Barn under 5 år går gratis.");
                }
                else if (age < 20)
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
                else if (age > 64 && age <= 100)
                {
                    Console.WriteLine("Pensionärspris: 90kr");
                }
                else if (age > 100)
                {
                    Console.WriteLine("Pensionär över 100 år går gratis.");
                }
                else
                {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }
            else
            {
                Console.WriteLine("Ogiltig ålder, försök igen.");
            }
        }

        //-----------------------------------------------------------------
        // This method asks for the age of each person in a group and
        // prints the total price for the group
        //-----------------------------------------------------------------
        static void PriceForMovieTickets()
        {
            Console.Write("För att se totala priset för ett sällskap, ange antal personer: ");
            int numberOfPeople;
            int age;

            string input = Console.ReadLine().Trim();

            if (int.TryParse(input, out numberOfPeople))
            {
                // Initialize total price
                int totalPrice = 0;

                // Loop through and ask for the age of each person in the group
                for (int i = 0; i < numberOfPeople; i++)
                {
                    Console.Write($"Ange ålder för person {i + 1}: ");

                    string ageInput = Console.ReadLine().Trim();
                    if (int.TryParse(ageInput, out age))
                    {
                        if (age < 5)
                        {
                            // Children under 5 years old go for free
                            totalPrice += 0;
                        }
                        else if (age < 20)
                        {
                            // Youth between 5 and 19 years old pay 80kr
                            totalPrice += 80;
                        }

                        else if (age > 64 && age <= 100)
                        {
                            // Pensioners between 65 and 100 years old pay 90kr
                            totalPrice += 90;
                        }
                        else if (age > 100)
                        {
                            // Pensioners over 100 years old go for free
                            totalPrice += 0;
                        }
                        else
                        {
                            // Standard price for adults between 20 and 64 years old is 120kr
                            totalPrice += 120;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig ålder, försök igen.");
                    }
                }

                Console.WriteLine($"Totalpris för sällskapet på {numberOfPeople} personer: {totalPrice}kr");
            }
            else
            {
                Console.WriteLine("Ogiltigt antal personer, försök igen.");
            }
        }

        //-----------------------------------------------------------------
        // This method asks for a text input and repeats it 10 times
        //-----------------------------------------------------------------
        static void Repeat10Times()
        {
            Console.Write("Skriv in en text, så upprepas den 10 ggr: ");
            var text = Console.ReadLine().Trim();


            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}. {text} ");
            }
            Console.WriteLine();
        }

        //--------------------------------------------------------------------------
        // This method asks for a text input and prints the third word if it exists
        //-------------------------------------------------------------------------
        static void Print3rdWord()
        {
            Console.Write("Skriv in en text, så visar vi det tredje ordet: ");
            var text = Console.ReadLine().Trim();

            // Split the string and return all non-empty elements
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length >= 3)
            {
                Console.WriteLine($"Det tredje ordet är: {words[2]}");
            }
            else
            {
                Console.WriteLine("Texten innehåller inte tillräckligt många ord.");
            }
        }
    }
}
