/* 
Detta är en statisk hjälparklass för att hantera JSON-filer.
- Lagra kontakter i en fil.
- Ladda kontakter från en fil.
*/


using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ContactListApp.Console.Models;

namespace ContactListApp.Console.Utilities
{
    public static class JsonUtility
    {
        private const string FilePath = "contacts.json";

        /// <param name="contacts">Lista med kontakter.</param>
        public static void SaveContactsToFile(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static List<Contact> LoadContactsFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<Contact>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
