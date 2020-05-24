//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Trip
{
    class FranceTrip : CountryTrip
    {
        public FranceTrip(int days, ListNode[] _accommodation, TripAdvisorNode[,] _attractions) : base(days, 3, _accommodation, _attractions, "France") { }
    }
}
