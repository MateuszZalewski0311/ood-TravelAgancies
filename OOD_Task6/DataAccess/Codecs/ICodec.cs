//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess.Codecs
{
    interface ICodec
    {
        string Encode(string str);
        string Decode(string str);
    }
}
