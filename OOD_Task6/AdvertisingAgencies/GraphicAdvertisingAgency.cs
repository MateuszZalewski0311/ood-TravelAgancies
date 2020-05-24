//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using System.Collections.Generic;
using TravelAgencies.AdvertisingAgencies.TripOffers;
using TravelAgencies.TravelAgencies;
using TravelAgencies.TripOfferData.Photo;

namespace TravelAgencies.AdvertisingAgencies
{
    class GraphicAdvertisingAgency : IAdvertisingAgency
    {
        private Random Rd { get; }
        private int NumberOfPhotos { get; }
        private int ViewLimit { get; }
        public List<ITravelAgency> TravelAgencies { get; }
        public GraphicAdvertisingAgency(Random _rd, int _NumberOfPhotos, int _ViewLimit, List<ITravelAgency> _TravelAgencies)
        {
            Rd = _rd;
            NumberOfPhotos = _NumberOfPhotos;
            ViewLimit = _ViewLimit;
            TravelAgencies = _TravelAgencies;
            if (TravelAgencies.Count == 0)
                throw new ArgumentException();
        }
        public ITripOffer CreatePermanentTripOffer()
        {
            ITravelAgency travelAgency = TravelAgencies[Rd.Next(0, TravelAgencies.Count)];
            IPhoto[] photos = new IPhoto[NumberOfPhotos];
            for (int i = 0; i < NumberOfPhotos; ++i)
                photos[i] = travelAgency.CreatePhoto();
            return new GraphicPermanentTripOffer(travelAgency.CreateTrip(), photos);
        }

        public ITripOffer CreateTemporaryTripOffer()
        {
            ITravelAgency travelAgency = TravelAgencies[Rd.Next(0, TravelAgencies.Count)];
            IPhoto[] photos = new IPhoto[NumberOfPhotos];
            for (int i = 0; i < NumberOfPhotos; ++i)
                photos[i] = travelAgency.CreatePhoto();
            return new GraphicTemporaryTripOffer(travelAgency.CreateTrip(), ViewLimit, photos);
        }
    }
}
