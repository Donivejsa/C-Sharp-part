/* 
Detta är programmets startpunkt. 
- Här används Dependency Injection för att skapa och hantera tjänster som ContactService och MenuHandler.
- MenuHandler kör programmets huvudmeny. 
*/


using Microsoft.Extensions.DependencyInjection;
using ContactListApp.Console.Services;
using ContactListApp.Console.Interfaces;
using ContactListApp.Console.Utilities;

namespace ContactListApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IContactService, ContactService>()
                .AddSingleton<JsonContactRepository>()
                .AddSingleton<MenuHandler>()
                .BuildServiceProvider();

            var menuHandler = serviceProvider.GetService<MenuHandler>();
            menuHandler.Run();
        }
    }
}
