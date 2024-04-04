using AdressBuchv2;
using System;
using System.IO;

namespace AdressBuchv2;
class Program
{

    public static void Main(string[] args)
    {
        var adressbuch = new Adressbuch();


        //........
        Init(adressbuch);

    }   

    public static void Init(Adressbuch adressbuch)
    {

        var exit = false;
        Console.WriteLine("Please enter the filepath to your address book.");
        adressbuch.filepath = Console.ReadLine();

        do
        {
            if (!string.IsNullOrWhiteSpace(adressbuch.filepath))
            {
                if (File.Exists(adressbuch.filepath))
                {
                    ReadAdressbuch.ReadCsv(adressbuch.filepath);
                    break;
                }
                else
                {
                    Console.WriteLine("Filepath doesn't exist. Try again!");
                    adressbuch.filepath = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Filepath cannot be empty. Try again!");

            }
        }
        while (true);

        do
        {
            if (adressbuch.filepath != null)
            {
                Console.WriteLine("Welcome, what do you want to do?");
                Console.WriteLine("1. View the address book");
                Console.WriteLine("2. Add a person to the address book");
                Console.WriteLine("3. Update the data of a person");
                Console.WriteLine("4. Delete a person from the address book");
                Console.WriteLine("5. Exit the program");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        adressbuch.DisplayData();
                        break;
                    case "2":
                        adressbuch.AddPerson();
                        break;
                    case "3":
                        adressbuch.UpdatePerson();
                        break;
                    case "4":
                        adressbuch.DeletePerson();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the program");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again. ");
                        break;
                }
            }
            else
            {
                Console.WriteLine("File path not found. Please  try again.");
            }


        } while (!exit); 
    }
}