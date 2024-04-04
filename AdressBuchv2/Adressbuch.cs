using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdressBuchv2
{
    public class Adressbuch
    {

        public string filepath;
        private List<Personen> data = new List<Personen>();

       

        public void DisplayData()
        {
            Console.WriteLine("Adressbuch:");
            foreach (var personen in data)
            {
                Console.WriteLine($"Id: {personen.Id}, Name: {personen.Name}, Adress: {personen.Address}, Phone Number: {personen.PhoneNumber}");
            }
        }

        public  void AddPerson()
        {
            Console.WriteLine("Enter your persons details!");
            Console.WriteLine("Id: ");
            string id = Console.ReadLine();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            data.Add(new Personen(id, name, address, phoneNumber));
            Console.WriteLine("Person added successfully.");
            WriteCsv();
        }

        public  void UpdatePerson()
        {
            Console.WriteLine("Enter the Id of the person you want to update: ");
            string id = Console.ReadLine();

            Personen personToUpdate = data.Find(p => p.Id == id);
            if (personToUpdate != null)
            {
                Console.WriteLine($"Enter new details for the person with Id {id}:");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                personToUpdate.Name = name;
                personToUpdate.Address = address;
                personToUpdate.PhoneNumber = phoneNumber;

                Console.WriteLine($"The details of the person with the Id of {id} havae been successfully updated.");
                WriteCsv();
            }
            else
            {
                Console.WriteLine($"No person found with Id {id}.");
            }
        }

        public  void DeletePerson()
        {
            Console.WriteLine("Enter the Id of the person you want to delete.");
            string id = Console.ReadLine();

            Personen personToDelete = data.FirstOrDefault(p => p.Id == id);
            if (personToDelete != null)
            {
                data.Remove(personToDelete);
                Console.WriteLine($"The person with Id {id} has been deleted.");
                WriteCsv();
            }
            else
            {
                Console.WriteLine($"A person with the Id of {id} does not exist.");
            }
        }

        private  void WriteCsv()
        {
            using (var writer = new StreamWriter(filepath))
            {
                writer.WriteLine("Id, Name, Address, PhoneNumber");
                foreach (var person in data)
                {
                    writer.WriteLine($"{person.Id},{person.Name},{person.Address},{person.PhoneNumber};");
                }
            }
        }
    }
}
