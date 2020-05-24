//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    abstract class TemporaryTripOffer : PermanentTripOffer
    {
        protected int ViewsLeft { get; set; }
        protected TemporaryTripOffer(ITrip _trip, int _viewsLeft) : base(_trip) => ViewsLeft = _viewsLeft;

        public override void WriteOffer()
        {
            if (ViewsLeft-- < 1)
            {
                Console.WriteLine("This offer is expired\n");
                return;
            }
            base.WriteOffer();
        }
    }
}
