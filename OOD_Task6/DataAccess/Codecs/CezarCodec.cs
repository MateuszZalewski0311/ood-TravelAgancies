//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess.Codecs
{
    class CezarCodec : ICodec
    {
        private int N { get; }
        private int Mod(int a, int b) => a < 0 ? ((a % b) + b) % b : a % b;
        public CezarCodec(int _N)
        {
            this.N = _N;
        }
        public string Encode(string str)
        {
            string outStr = string.Empty;
            for (int i = 0; i < str.Length; ++i)
            {
                int temp = str[i] - '0' + N;
                outStr += Mod(temp, 10).ToString();
            }
            return outStr;
        }

        public string Decode(string str)
        {
            string outStr = string.Empty;
            for (int i = 0; i < str.Length; ++i)
            {
                int temp = str[i] - '0' - N;
                outStr += Mod(temp, 10).ToString();
            }
            return outStr;
        }
    }
}
