/* 
Detta definierar modellen för en kontakt.
- En kontakt innehåller ID, namn, e-post, telefonnummer, adress och stad.
*/


using System;

namespace ContactListApp.Console.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
