using System;
using System.IO;

namespace MulticlientCreator.Helpers
{
    public static class HexHelper
    {
        public static byte[] ToByteArray(string hex)
        {
            var charNumber = hex.Length;
            var bytes = new byte[charNumber / 2];
            for (var i = 0; i < charNumber; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string ToHexString(byte[] barray)
        {
            var c = new char[barray.Length * 2];
            for (var i = 0; i < barray.Length; ++i)
            {
                var b = ((byte)(barray[i] >> 4));
                c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(barray[i] & 0xF));
                c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }
    }
}
