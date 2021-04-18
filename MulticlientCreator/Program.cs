using MulticlientCreator.Helpers;
using System;
using System.IO;
using System.Text;

namespace MulticlientCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MulticlientCreator by Fizo";
            WriteMessage(ConsoleColor.DarkBlue, @"______  ___      _______________      __________            _____       _________                  _____              
___   |/  /___  ____  /_  /___(_)________  /__(_)_____________  /_      __  ____/_________________ __  /______________
__  /|_/ /_  / / /_  /_  __/_  /_  ___/_  /__  /_  _ \_  __ \  __/_______  /    __  ___/  _ \  __ `/  __/  __ \_  ___/
_  /  / / / /_/ /_  / / /_ _  / / /__ _  / _  / /  __/  / / / /_ _/_____/ /___  _  /   /  __/ /_/ // /_ / /_/ /  /    
/_/  /_/  \__,_/ /_/  \__/ /_/  \___/ /_/  /_/  \___//_/ /_/\__/        \____/  /_/    \___/\__,_/ \__/ \____//_/     
                                                                                                                      ");

            string officialName = "NosAdventureX.exe";
            string pattern = "0C 00 00 00 37 39 2E 31 31 30 2E 38 34 2E 37 35 00 00 00 00".Replace(" ", ""); // maybe a dynamic pattern soon but flemme right now lmfao

            boucle:
            // C:\Users\HP Gaming Pavilion\Desktop\NosAdventure
            WriteMessage(ConsoleColor.Magenta, "Enter your nostale path :");
            string nostalePath = Console.ReadLine();

            if (nostalePath == null)
                goto boucle;

            string finalPath = @$"{nostalePath}\{officialName}";
            Stream fs = new FileStream(finalPath, FileMode.Open, FileAccess.Read);
            byte[] getFileBytes = DeserializationHelper.ReadFully(fs);
            string getFileString = HexHelper.ToHexString(getFileBytes);

            if (getFileString.Contains(pattern))
            {
                WriteMessage(ConsoleColor.DarkGreen, "Pattern found !");
                WriteMessage(ConsoleColor.Magenta, "Enter your vps ip :");
                string ip = Console.ReadLine();
                // todo : support port but now idc
                string[] split = ip.Split(".");
                StringBuilder builder = new StringBuilder();
                var i = 0;
                foreach (var str in split)
                {
                    builder.Append(HexHelper.ToHexString(str));

                    if (i == 3) break;

                    builder.Append("2E"); // this is the dot "."
                    i++;
                }

                for (var j = builder.ToString().Length; j < 32; j++)
                {
                    builder.Append("0");
                }

                Console.WriteLine(builder.ToString());
            }

            //HexFinder finder = new HexFinder(finalPath, );

            //Console.WriteLine(getFileString);
            WriteMessage(ConsoleColor.DarkGreen, "Done");
            Console.ReadLine();
        }

        public static void WriteMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
