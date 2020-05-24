//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Text;

namespace TravelAgencies.DataAccess.Codecs
{
    class PushCodec : ICodec
    {
        private int N { get; }
        private int Mod(int a, int b) => a < 0 ? ((a % b) + b) % b : a % b;
        public PushCodec(int _N)
        {
            N = _N;
        }
        public string Encode(string str)
        {
            if (Mod(N, str.Length) == 0)
                return str;
            StringBuilder builder = new StringBuilder(str);
            for (int i = 0; i < str.Length; ++i)
                builder[Mod(i + N, str.Length)] = str[i];
            return builder.ToString();
        }

        public string Decode(string str)
        {
            if (Mod(N, str.Length) == 0)
                return str;
            StringBuilder builder = new StringBuilder(str);
            for (int i = 0; i < str.Length; ++i)
                builder[Mod(i - N, str.Length)] = str[i];
            return builder.ToString();
        }
    }
}
