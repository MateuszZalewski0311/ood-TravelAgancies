//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using System.Collections.Generic;
using TravelAgencies.AdvertisingAgencies.TripOffers;
using TravelAgencies.TravelAgencies;
using TravelAgencies.TripOfferData.Review;

namespace TravelAgencies.AdvertisingAgencies
{
    class TextAdvertisingAgency : IAdvertisingAgency
    {
        private Random Rd { get; }
        private int NumberOfReviews { get; }
        private int ViewLimit { get; }
        public List<ITravelAgency> TravelAgencies { get; }
        public TextAdvertisingAgency(Random _rd, int _NumberOfReviews, int _ViewLimit, List<ITravelAgency> _TravelAgencies)
        {
            Rd = _rd;
            NumberOfReviews = _NumberOfReviews;
            ViewLimit = _ViewLimit;
            TravelAgencies = _TravelAgencies;
            if (TravelAgencies.Count == 0)
                throw new ArgumentException();
        }
        public ITripOffer CreatePermanentTripOffer()
        {
            ITravelAgency travelAgency = TravelAgencies[Rd.Next(0, TravelAgencies.Count)];
            IReview[] reviews = new IReview[NumberOfReviews];
            for (int i = 0; i < NumberOfReviews; ++i)
                reviews[i] = travelAgency.CreateReview();
            return new TextPermanentTripOffer(travelAgency.CreateTrip(), reviews);
        }

        public ITripOffer CreateTemporaryTripOffer()
        {
            ITravelAgency travelAgency = TravelAgencies[Rd.Next(0, TravelAgencies.Count)];
            IReview[] reviews = new IReview[NumberOfReviews];
            for (int i = 0; i < NumberOfReviews; ++i)
                reviews[i] = travelAgency.CreateReview();
            return new TextTemporaryTripOffer(travelAgency.CreateTrip(), ViewLimit, reviews);
        }
    }
}
