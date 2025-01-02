/* 
Detta hanterar kontakter i applikationen.
- Lägga till, lista, redigera och ta bort kontakter.
- Laddar och sparar kontakter från/till en JSON-fil via JsonContactRepository. 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using ContactListApp.Console.Models;
using ContactListApp.Console.Interfaces;
using ContactListApp.Console.Utilities;

namespace ContactListApp.Console.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new List<Contact>();
        private readonly JsonContactRepository _repository;

        public ContactService(JsonContactRepository repository)
        {
            _repository = repository;
            LoadContacts();
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact), "Kontakt kan inte vara null.");

            _contacts.Add(contact);
            System.Console.WriteLine("Kontakt har lagts till.");
            SaveContacts();
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void ListContacts()
        {
            if (_contacts.Count == 0)
            {
                System.Console.WriteLine("Inga kontakter hittades.");
                return;
            }

            System.Console.WriteLine("Kontakter:");
            foreach (var contact in _contacts)
            {
                System.Console.WriteLine($"ID: {contact.Id}");
                System.Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                System.Console.WriteLine($"E-post: {contact.Email}");
                System.Console.WriteLine($"Telefon: {contact.PhoneNumber}");
                System.Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
                System.Console.WriteLine("-----------------------------------");
            }
        }

        public void EditContact(Guid contactId, Contact updatedContact)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == contactId);
            if (contact == null)
            {
                System.Console.WriteLine("Kontakten hittades inte.");
                return;
            }

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.StreetAddress = updatedContact.StreetAddress;
            contact.PostalCode = updatedContact.PostalCode;
            contact.City = updatedContact.City;

            SaveContacts();
            System.Console.WriteLine("Kontakten har uppdaterats.");
        }

        public void DeleteContact(Guid contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == contactId);
            if (contact == null)
            {
                System.Console.WriteLine("Kontakten hittades inte.");
                return;
            }

            _contacts.Remove(contact);
            SaveContacts();
            System.Console.WriteLine("Kontakten har tagits bort.");
        }

        private void SaveContacts()
        {
            _repository.SaveContacts(_contacts);
        }

        private void LoadContacts()
        {
            var loadedContacts = _repository.LoadContacts();
            if (loadedContacts.Any())
            {
                _contacts.Clear();
                _contacts.AddRange(loadedContacts);
                System.Console.WriteLine("Kontakter har lästs in från fil.");
            }
            else
            {
                System.Console.WriteLine("Inga kontakter hittades i filen.");
            }
        }
    }
}
