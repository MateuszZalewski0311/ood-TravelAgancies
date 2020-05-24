//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess
{
    interface IIterable<T>
    {
        IIterator<T> GetIterator(); //call Next() once before attempting to read data
    }
}
