//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Photo;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    class GraphicPermanentTripOffer : PermanentTripOffer
    {
        private readonly IPhoto[] Photos;
        public GraphicPermanentTripOffer(ITrip _trip, IPhoto[] _photos) : base(_trip) => Photos = _photos;

        public override void WriteOffer()
        {
            base.WriteOffer();
            foreach(IPhoto photo in Photos)
                Console.WriteLine(photo);
            Console.WriteLine();
        }
    }
}
