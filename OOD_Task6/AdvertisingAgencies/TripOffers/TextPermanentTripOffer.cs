//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Review;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    class TextPermanentTripOffer : PermanentTripOffer
    {
        private readonly IReview[] Reviews;
        public TextPermanentTripOffer(ITrip trip, IReview[] reviews) : base(trip) => Reviews = reviews;

        public override void WriteOffer()
        {
            base.WriteOffer();
            foreach (IReview review in Reviews)
                Console.WriteLine(review);
            Console.WriteLine();
        }
    }
}
