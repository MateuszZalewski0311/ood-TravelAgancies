//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
namespace TravelAgencies.DataAccess
{
    interface IIterator<T>
    {
        void First(); //Reset
        void Next(); //Move to the next element or initialize iteration to the first element
        bool IsDone { get; }
        T Current { get; }
    }
}
