using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VivePortLibraryScanner;

namespace ViveScanner
{


    public class Program
    {
        
        static async Task Main(string[] args)
        {
            string appFolder = null;
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Type in your vive port folder path and press enter:");
                appFolder = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(appFolder))
                {
                    appFolder = @"F:\Viveport\ViveApps";
                }
            } 
            else
            {
                appFolder = args[0];
            }

            if (Directory.Exists(appFolder))
            {                
                IVivePortScanner scanner = new VivePortScanner();

                List<ViveGame> apps = scanner.Scan(appFolder);

                var x = JsonConvert.SerializeObject(apps, Formatting.Indented);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(x);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Found {apps.Count} apps");

                //await File.WriteAllTextAsync(Path.Combine(appFolder, "games.json"), x);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Folder does not exist..");  
            }

            Console.WriteLine("Press any Key to Quit");
            Console.ReadKey();
        }

        
    }
}
