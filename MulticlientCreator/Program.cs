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

            string finalPath = @$"{nostalePath}\NostaleClientX.exe";
            Stream fs = new FileStream(finalPath, FileMode.Open, FileAccess.Read);
            byte[] getFileBytes = DeserializationHelper.ReadFully(fs);
            string getFileString = HexHelper.ToHexString(getFileBytes);
            Console.WriteLine(getFileString);
            Console.ReadLine();
        }
    }
}
