//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.TripOfferData.Review;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.AdvertisingAgencies.TripOffers
{
    class TextTemporaryTripOffer : TemporaryTripOffer
    {
        private readonly IReview[] Reviews;
        public TextTemporaryTripOffer(ITrip _trip, int _viewsLeft, IReview[] _reviews) : base(_trip, _viewsLeft) => Reviews = _reviews;

        public override void WriteOffer()
        {
            base.WriteOffer();
            if (ViewsLeft < 0)
                return;
            foreach (IReview review in Reviews)
                Console.WriteLine(review);
            Console.WriteLine();
        }
    }
}
