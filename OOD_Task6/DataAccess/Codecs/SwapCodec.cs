//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess.Codecs
{
    class SwapCodec : ICodec
    {
        public string Decode(string str)
        {
            return Encode(str);
        }

        public string Encode(string str)
        {
            char[] arr = str.ToCharArray();
            char tmp;
            for (int i = 0; i + 1 < arr.Length; i += 2)
            {
                tmp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = tmp;
            }
            return new string(arr);
        }
    }
}
