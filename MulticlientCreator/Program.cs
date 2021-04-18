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
            boucle:
            // C:\Users\HP Gaming Pavilion\Desktop\NosAdventure
            Console.WriteLine("Enter your nostale path :");
            var nostalePath = Console.ReadLine();

            if (nostalePath == null)
                goto boucle;

            string finalPath = @$"{nostalePath}\tkt.exe";
            Stream fs = new FileStream(finalPath, FileMode.Open, FileAccess.Read);
            byte[] getFileBytes = DeserializationHelper.ReadFully(fs);
            string getFileString = HexHelper.ToHexString(getFileBytes);

            if (getFileString.Contains("0C 00 00 00 37 39 2E 31 31 30 2E 38 34 2E 37 35 00 00 00 00".Replace(" ", "")))
            {
                Console.WriteLine("Pattern found !");
                Console.WriteLine(HexHelper.ToHexString("110")); // supposed to return 37
                string[] split = "79.110.84.75".Split(".");
                StringBuilder builder = new StringBuilder();
                var i = 0;
                foreach (var str in split)
                {
                    builder.Append(HexHelper.ToHexString(str));

                    if (i == 3) break;

                    builder.Append("2E"); // this is the dot "."
                    i++;
                }
                Console.WriteLine(builder.ToString());
            }

            //HexFinder finder = new HexFinder(finalPath, );

            //Console.WriteLine(getFileString);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
