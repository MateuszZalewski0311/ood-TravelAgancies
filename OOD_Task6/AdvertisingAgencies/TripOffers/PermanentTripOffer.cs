//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    abstract class PermanentTripOffer : ITripOffer
    {
        protected ITrip Trip { get; }

        protected PermanentTripOffer(ITrip _trip)
        {
            Trip = _trip;
        }

        public virtual void WriteOffer()
        {
            Console.Write(Trip);
        }
    }
}
