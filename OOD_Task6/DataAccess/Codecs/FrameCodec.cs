//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;

namespace TravelAgencies.DataAccess.Codecs
{
    class FrameCodec : ICodec
    {
        private int N { get; }

        public FrameCodec(int _N)
        {
            if (N < 0 || N > 9)
                throw new ArgumentOutOfRangeException();
            this.N = _N;
        }

        public string Encode(string str)
        {
            string temp = string.Empty;
            for (int i = 1; i <= N; ++i)
                temp += i.ToString();

            char[] tempRev = temp.ToCharArray();
            Array.Reverse(tempRev);

            return temp + str + new string(tempRev);
        }

        public string Decode(string str)
        {
            return str.Substring(N, str.Length - 2 * N);
        }
    }
}
