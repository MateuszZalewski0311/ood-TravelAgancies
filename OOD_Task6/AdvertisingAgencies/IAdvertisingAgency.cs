//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.AdvertisingAgencies.TripOffers;

namespace TravelAgencies.AdvertisingAgencies
{
    interface IAdvertisingAgency
    {
        ITripOffer CreatePermanentTripOffer();
        ITripOffer CreateTemporaryTripOffer();
    }
}
