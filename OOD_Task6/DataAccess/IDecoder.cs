//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess
{
    interface IDecoder<T>
    {
        string Decode(string str);
        T Decode(T input);
    }
}
