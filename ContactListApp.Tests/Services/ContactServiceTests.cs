using System;
using System.Collections.Generic;
using ContactListApp.Console.Models;
using ContactListApp.Console.Services;
using ContactListApp.Console.Utilities;
using Xunit;

namespace ContactListApp.Tests.Services
{
    public class ContactServiceTests
    {
        [Fact]
        public void AddContact_ShouldAddContactToList()
        {
            // Arrange
            var repository = new JsonContactRepository(); // Skapar en tom fil för testning
            var service = new ContactService(repository);
            var contact = new Contact
            {
                FirstName = "Test",
                LastName = "Person",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                StreetAddress = "Testvägen 1",
                PostalCode = "12345",
                City = "Teststad"
            };

            // Act
            service.AddContact(contact);

            // Assert
            var contacts = service.GetAllContacts();
            Assert.Contains(contact, contacts);
        }

        [Fact]
        public void EditContact_ShouldUpdateContactDetails()
        {
            // Arrange
            var repository = new JsonContactRepository(); // Skapar en tom fil för testning
            var service = new ContactService(repository);
            var contact = new Contact
            {
                FirstName = "Test",
                LastName = "Person",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                StreetAddress = "Testvägen 1",
                PostalCode = "12345",
                City = "Teststad"
            };
            service.AddContact(contact);

            var updatedContact = new Contact
            {
                FirstName = "Updated",
                LastName = "Person",
                Email = "updated@example.com",
                PhoneNumber = "987654321",
                StreetAddress = "Updatedvägen 2",
                PostalCode = "54321",
                City = "Updatedstad"
            };

            // Act
            service.EditContact(contact.Id, updatedContact);

            // Assert
            var contacts = service.GetAllContacts();
            var editedContact = contacts.Find(c => c.Id == contact.Id);
            Assert.NotNull(editedContact);
            Assert.Equal("Updated", editedContact.FirstName);
            Assert.Equal("updated@example.com", editedContact.Email);
        }

        [Fact]
        public void DeleteContact_ShouldRemoveContactFromList()
        {
            // Arrange
            var repository = new JsonContactRepository(); 
            var service = new ContactService(repository);
            var contact = new Contact
            {
                FirstName = "Test",
                LastName = "Person",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                StreetAddress = "Testvägen 1",
                PostalCode = "12345",
                City = "Teststad"
            };
            service.AddContact(contact);

            // Act
            service.DeleteContact(contact.Id);

            // Assert
            var contacts = service.GetAllContacts();
            Assert.DoesNotContain(contact, contacts);
        }
    }
}
