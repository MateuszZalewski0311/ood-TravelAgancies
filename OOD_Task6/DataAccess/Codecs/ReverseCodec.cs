//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;

namespace TravelAgencies.DataAccess.Codecs
{
    class ReverseCodec : ICodec
    {
        public string Decode(string str)
        {
            return Encode(str);
        }

        public string Encode(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
