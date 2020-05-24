//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Photo;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    class GraphicTemporaryTripOffer : TemporaryTripOffer
    {
        private readonly IPhoto[] Photos;
        public GraphicTemporaryTripOffer(ITrip _trip, int _viewsLeft, IPhoto[] _photos) : base(_trip, _viewsLeft) => Photos = _photos;

        public override void WriteOffer()
        {
            base.WriteOffer();
            if (ViewsLeft < 0)
                return;
            foreach (IPhoto photo in Photos)
                Console.WriteLine(photo);
            Console.WriteLine();
        }
    }
}
