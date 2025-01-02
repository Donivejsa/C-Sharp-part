/* 
Detta Hanterar användarens interaktion med programmet via en meny.
- Användaren kan visa kontakter, skapa, redigera eller ta bort kontakter.
- Använder ContactService för att hantera data. 
*/


using System;
using ContactListApp.Console.Interfaces;
using ContactListApp.Console.Models;

namespace ContactListApp.Console
{
    public class MenuHandler
    {
        private readonly IContactService _contactService;

        public MenuHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListContacts();
                        break;

                    case "2":
                        AddNewContact();
                        break;

                    case "3":
                        EditExistingContact();
                        break;

                    case "4":
                        DeleteExistingContact();
                        break;

                    case "5":
                        System.Console.WriteLine("Programmet avslutas...");
                        return;

                    default:
                        System.Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================");
            System.Console.WriteLine("      Välkommen till Kontaktlistan!   ");
            System.Console.WriteLine("======================================");
            System.Console.WriteLine("1. Visa alla dina kontakter");
            System.Console.WriteLine("2. Skapa en ny kontakt");
            System.Console.WriteLine("3. Redigera en befintlig kontakt");
            System.Console.WriteLine("4. Ta bort en befintlig kontakt");
            System.Console.WriteLine("5. Avsluta programmet");
            System.Console.Write("Välj ett alternativ: ");
        }

        private void ListContacts()
        {
            System.Console.Clear();
            _contactService.ListContacts();
            System.Console.WriteLine("\nTryck på valfri tangent för att gå tillbaka till huvudmenyn...");
            System.Console.ReadKey();
        }

        private void AddNewContact()
        {
            System.Console.Clear();
            var newContact = GetContactInput();
            _contactService.AddContact(newContact);
        }

        private void EditExistingContact()
        {
            System.Console.Clear();
            System.Console.WriteLine("Ange ID för kontakten du vill redigera:");
            var contactIdInput = System.Console.ReadLine();

            if (Guid.TryParse(contactIdInput, out var contactId))
            {
                var updatedContact = GetContactInput();
                _contactService.EditContact(contactId, updatedContact);
            }
            else
            {
                System.Console.WriteLine("Ogiltigt ID.");
            }
        }

        private void DeleteExistingContact()
        {
            System.Console.Clear();
            System.Console.WriteLine("Ange ID för kontakten du vill ta bort:");
            var contactIdInput = System.Console.ReadLine();

            if (Guid.TryParse(contactIdInput, out var contactId))
            {
                _contactService.DeleteContact(contactId);
            }
            else
            {
                System.Console.WriteLine("Ogiltigt ID.");
            }
        }

        private Contact GetContactInput()
        {
            System.Console.Write("Förnamn: ");
            var firstName = System.Console.ReadLine();

            System.Console.Write("Efternamn: ");
            var lastName = System.Console.ReadLine();

            System.Console.Write("E-postadress: ");
            var email = System.Console.ReadLine();

            System.Console.Write("Telefonnummer: ");
            var phoneNumber = System.Console.ReadLine();

            System.Console.Write("Gatuadress: ");
            var streetAddress = System.Console.ReadLine();

            System.Console.Write("Postnummer: ");
            var postalCode = System.Console.ReadLine();

            System.Console.Write("Stad: ");
            var city = System.Console.ReadLine();

            return new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city
            };
        }
    }
}
