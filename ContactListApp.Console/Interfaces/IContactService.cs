/* 
Detta definierar ett gränssnitt för ContactService. 
- Anger metoder som behövs för att hantera kontakter: lägga till, lista, redigera och ta bort. 
*/


using System.Collections.Generic;
using ContactListApp.Console.Models;

namespace ContactListApp.Console.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        void ListContacts();
        void EditContact(Guid contactId, Contact updatedContact);
        void DeleteContact(Guid contactId);
    }
}
