/* 
Detta hanterar läsning och skrivning av kontakter till en JSON-fil.
- Sparar och laddar listor med kontakter. 
*/


using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContactListApp.Console.Models;

namespace ContactListApp.Console.Utilities
{

    public class JsonContactRepository
    {
        private const string FilePath = "contacts.json";

        /// <param name="contacts">Lista med kontakter.</param>
        public void SaveContacts(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public List<Contact> LoadContacts()
        {
            if (!File.Exists(FilePath))
                return new List<Contact>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
