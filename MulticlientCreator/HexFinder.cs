using MulticlientCreator.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MulticlientCreator
{
    public class HexFinder
    {
        private readonly string _nostalePath;
        private readonly string _newIp;

        private readonly List<string> _oldHexToString;
        private readonly List<string> _newHexToString;
        private readonly List<byte[]> _byteHex;

        public HexFinder(string nostalePath, string newIp)
        {
            _nostalePath = nostalePath;
            _newIp = newIp;

            _oldHexToString = new List<string>();
            _newHexToString = new List<string>();
            _byteHex = new List<byte[]>();
        }

        public bool ReplaceIpPattern(string ipPattern)
        {
            var byteData = DeserializationHelper.ReadFully(new FileStream(_nostalePath, FileMode.Open));
            _oldHexToString.Add(HexHelper.ToHexString(byteData));

            var currentInfo = _oldHexToString.FirstOrDefault(s => s.Contains(ipPattern));
            if (currentInfo == null)
            {
                return false;
            }

            using (var writer = new BinaryWriter(File.Open(_nostalePath, FileMode.Open)))
            {
                for (var i = 0; i < _oldHexToString.Count; i++)
                {
                    _oldHexToString[i] = _oldHexToString[i].Replace(ipPattern, $"{_newIp}");
                    _newHexToString.Add(_oldHexToString[i]);
                }

                foreach (var currentString in _newHexToString)
                {
                    var byteArray = HexHelper.ToByteArray(currentString);
                    _byteHex.Add(byteArray);
                }

                foreach (var hexBytes in _byteHex)
                {
                    writer.Write(hexBytes);
                }
            }

            return true;
        }
    }
}
